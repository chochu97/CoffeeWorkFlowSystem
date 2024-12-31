using Datos.Contracts.Performance;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.DTO;
using System.Data.Entity.Migrations;

namespace Datos.Implementations.SqlServer.Performance
{
    /// <summary>
    /// Clase que implementa el repositorio para la gestión de tareas de empleados.
    /// </summary>
    public class EmpleadoTareaDAO : IEmpleadoTareaRepository
    {
        #region singleton
        private static readonly EmpleadoTareaDAO instance = new EmpleadoTareaDAO();

        /// <summary>
        /// Obtiene la instancia única de EmpleadoTareaDAO.
        /// </summary>
        public static EmpleadoTareaDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Inicia una tarea para un empleado.
        /// </summary>
        /// <param name="detalle">El objeto DETALLE_TAREA que representa la tarea a iniciar.</param>
        public void HacerTarea(DETALLE_TAREA detalle)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                detalle.FECHA_HORA_INICIO = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
                detalle.ESTADO = "En Proceso";

                context.DETALLE_TAREA.Add(detalle);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Finaliza una tarea en proceso.
        /// </summary>
        /// <param name="idTarea">El ID de la tarea a finalizar.</param>
        public void FinalizarTarea(Guid idTarea)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var detalleReciente = context.DETALLE_TAREA
                    .Where(d => d.ID_TAREA == idTarea && d.ESTADO == "En Proceso")
                    .OrderByDescending(d => d.FECHA_HORA_INICIO)
                    .FirstOrDefault();

                if (detalleReciente != null)
                {
                    detalleReciente.ESTADO = "Finalizada";
                    detalleReciente.FECHA_HORA_FIN = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encontró una tarea en proceso con el ID especificado.");
                }
            }
        }

        // DTOS
        /// <summary>
        /// Obtiene una lista de detalles de tareas que se han iniciado en el mes y año actuales.
        /// </summary>
        /// <returns>Una lista de objetos DetalleTareaDTO que representan los detalles de las tareas iniciadas.</returns>
        public List<DetalleTareaDTO> GetDetalles()
        {
            // Se utiliza el bloque 'using' para asegurar que el contexto de la base de datos se elimine correctamente después de su uso.
            using (var context = new GestionWorkFlowEntities())
            {
                // Obtiene el mes y el año actuales para filtrar las tareas.
                int mesActual = DateTime.Now.Month;
                int yearActual = DateTime.Now.Year;

                // Realiza una consulta LINQ para obtener los detalles de las tareas.
                var detalles = (from detalle in context.DETALLE_TAREA
                                    // Se une la tabla DETALLE_TAREA con la tabla TAREA para obtener el nombre de la tarea.
                                join tarea in context.TAREA on detalle.ID_TAREA equals tarea.ID_TAREA
                                // Se une la tabla DETALLE_TAREA con la tabla EMPLEADO para obtener el nombre del empleado.
                                join empleado in context.EMPLEADO on detalle.COD_EMPLEADO equals empleado.COD_EMPLEADO
                                // Filtra los detalles de tareas que se iniciaron en el mes y año actuales.
                                where detalle.FECHA_HORA_INICIO.Month == mesActual &&
                                      detalle.FECHA_HORA_INICIO.Year == yearActual
                                // Selecciona los campos necesarios para crear el objeto DetalleTareaDTO.
                                select new DetalleTareaDTO
                                {
                                    Iniciada = detalle.FECHA_HORA_INICIO, // Fecha y hora de inicio de la tarea.
                                    Finalizada = detalle.FECHA_HORA_FIN,   // Fecha y hora de finalización de la tarea.
                                    Tarea = tarea.NOMBRE,                   // Nombre de la tarea.
                                    Empleado = empleado.NOMBRE + " " + empleado.APELLIDO, // Nombre completo del empleado.
                                    Estado = detalle.ESTADO                 // Estado actual de la tarea.
                                })
                                // Ordena los resultados por la fecha de inicio en orden descendente.
                                .OrderByDescending(d => d.Iniciada)
                                .ToList(); // Convierte el resultado a una lista.

                // Devuelve la lista de detalles de tareas.
                return detalles;
            }
        }


        /// <summary>
        /// Obtiene una lista de detalles de tareas iniciadas por un empleado específico en el mes y año actuales.
        /// </summary>
        /// <param name="id">El ID del empleado para filtrar las tareas.</param>
        /// <returns>Una lista de objetos DetalleTareaDTO que representan los detalles de las tareas iniciadas por el empleado.</returns>
        public List<DetalleTareaDTO> GetDetallesPorEmp(int id)
        {
            // Se utiliza el bloque 'using' para asegurar que el contexto de la base de datos se elimine correctamente después de su uso.
            using (var context = new GestionWorkFlowEntities())
            {
                // Obtiene el mes y el año actuales para filtrar las tareas.
                int mesActual = DateTime.Now.Month;
                int yearActual = DateTime.Now.Year;

                // Realiza una consulta LINQ para obtener los detalles de las tareas del empleado especificado.
                var detalles = (from detalle in context.DETALLE_TAREA
                                    // Se une la tabla DETALLE_TAREA con la tabla TAREA para obtener el nombre de la tarea.
                                join tarea in context.TAREA on detalle.ID_TAREA equals tarea.ID_TAREA
                                // Se une la tabla DETALLE_TAREA con la tabla EMPLEADO para obtener el nombre del empleado.
                                join empleado in context.EMPLEADO on detalle.COD_EMPLEADO equals empleado.COD_EMPLEADO
                                // Filtra los detalles de tareas que se iniciaron en el mes y año actuales y que pertenecen al empleado especificado.
                                where detalle.FECHA_HORA_INICIO.Month == mesActual &&
                                      detalle.FECHA_HORA_INICIO.Year == yearActual &&
                                      detalle.COD_EMPLEADO == id
                                // Selecciona los campos necesarios para crear el objeto DetalleTareaDTO.
                                select new DetalleTareaDTO
                                {
                                    Iniciada = detalle.FECHA_HORA_INICIO, // Fecha y hora de inicio de la tarea.
                                    Finalizada = detalle.FECHA_HORA_FIN,   // Fecha y hora de finalización de la tarea.
                                    Tarea = tarea.NOMBRE,                   // Nombre de la tarea.
                                    Empleado = empleado.NOMBRE + " " + empleado.APELLIDO, // Nombre completo del empleado.
                                    Estado = detalle.ESTADO                 // Estado actual de la tarea.
                                })
                                // Ordena los resultados por la fecha de inicio en orden descendente.
                                .OrderByDescending(d => d.Iniciada)
                                .ToList(); // Convierte el resultado a una lista.

                // Devuelve la lista de detalles de tareas del empleado especificado.
                return detalles;
            }
        }

        /// <summary>
        /// Obtiene los bonos de los empleados en función de las tareas finalizadas en el mes actual.
        /// </summary>
        /// <returns>Una lista de objetos EmpleadoDesempDTO que representan los empleados y sus respectivos bonos.</returns>
        public List<EmpleadoDesempDTO> ObtenerBonosDelMes()
        {
            // Se utiliza el bloque 'using' para asegurar que el contexto de la base de datos se elimine correctamente después de su uso.
            using (var context = new GestionWorkFlowEntities())
            {
                // Obtiene el primer día del mes actual.
                DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                // Obtiene el primer día del mes siguiente.
                DateTime primerDiaMesSiguiente = primerDiaMes.AddMonths(1);

                // Realiza una consulta LINQ para obtener los empleados que han finalizado tareas en el mes actual.
                var empleadosConTareas = (from detalle in context.DETALLE_TAREA
                                              // Filtra las tareas que se iniciaron y finalizaron en el mes actual y que están finalizadas.
                                          where detalle.FECHA_HORA_INICIO >= primerDiaMes &&
                                                detalle.FECHA_HORA_FIN <= primerDiaMesSiguiente &&
                                                detalle.ESTADO == "Finalizada"
                                          // Agrupa los detalles de tareas por el código del empleado.
                                          group detalle by detalle.COD_EMPLEADO into grupoTareas
                                          select new
                                          {
                                              IdEmpleado = grupoTareas.Key, // ID del empleado.
                                              CantidadTareas = grupoTareas.Count() // Cantidad de tareas finalizadas por el empleado.
                                          }).ToList();

                // Itera sobre cada empleado que tiene tareas finalizadas.
                foreach (var empConTareas in empleadosConTareas)
                {
                    // Busca el mejor bono que el empleado puede recibir basado en la cantidad de tareas finalizadas.
                    var mejorBono = context.BONO
                        .Where(b => b.ESTADO != false && empConTareas.CantidadTareas >= b.MINIMO_TAREAS)
                        .OrderByDescending(b => b.MINIMO_TAREAS)
                        .FirstOrDefault();

                    // Si se encuentra un bono adecuado, se asigna al empleado.
                    if (mejorBono != null)
                    {
                        var empleado = context.EMPLEADO.Find(empConTareas.IdEmpleado);

                        // Solo se actualiza el bono si el empleado no tiene ya el bono asignado.
                        if (empleado.ID_BONO != mejorBono.ID_BONO)
                        {
                            empleado.ID_BONO = mejorBono.ID_BONO;
                        }
                    }
                }

                // Obtiene la lista completa de empleados de la base de datos.
                var empleadosDB = context.EMPLEADO.ToList();

                // Realiza una consulta para combinar la información de los empleados con sus bonos.
                var empleadosConBono = (from emp in empleadosDB
                                        join empTareas in empleadosConTareas on emp.COD_EMPLEADO equals empTareas.IdEmpleado
                                        join bono in context.BONO on emp.ID_BONO equals bono.ID_BONO into bonoGroup
                                        from empBono in bonoGroup.DefaultIfEmpty() // Permite que algunos empleados no tengan bono asignado.
                                        select new EmpleadoDesempDTO
                                        {
                                            Id = emp.COD_EMPLEADO, // ID del empleado.
                                            Empleado = emp.NOMBRE + " " + emp.APELLIDO, // Nombre completo del empleado.
                                            Tareas_Realizadas = empTareas.CantidadTareas, // Cantidad de tareas realizadas por el empleado.
                                            Bono = empBono != null ? empBono.CATEGORIA : "No Asignado" // Categoría del bono o "No Asignado" si no tiene bono.
                                        }).ToList();

                // Guarda los cambios en la base de datos (aunque en este caso no se realizan cambios que requieran guardar).
                context.SaveChanges();

                // Devuelve la lista de empleados con sus respectivos bonos.
                return empleadosConBono;
            }
        }


        // Método para agregar un nuevo objeto DETALLE_TAREA.
        // Actualmente no está implementado y lanzará una excepción si se llama.
        /// <summary>
        /// Agrega un nuevo detalle de tarea a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto DETALLE_TAREA que se desea agregar.</param>
        /// <exception cref="NotImplementedException">Siempre se lanza, ya que el método no está implementado.</exception>
        public void Agregar(DETALLE_TAREA obj)
        {
            throw new NotImplementedException();
        }

        // Método para obtener todos los objetos DETALLE_TAREA.
        // Actualmente no está implementado y lanzará una excepción si se llama.
        /// <summary>
        /// Obtiene todos los detalles de tareas de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos DETALLE_TAREA.</returns>
        /// <exception cref="NotImplementedException">Siempre se lanza, ya que el método no está implementado.</exception>
        public List<DETALLE_TAREA> GetAll()
        {
            throw new NotImplementedException();
        }

        // Método para obtener un objeto DETALLE_TAREA específico por su ID.
        // Actualmente no está implementado y lanzará una excepción si se llama.
        /// <summary>
        /// Obtiene un detalle de tarea específico por su ID.
        /// </summary>
        /// <param name="id">El ID del detalle de tarea que se desea obtener.</param>
        /// <returns>El objeto DETALLE_TAREA correspondiente al ID proporcionado.</returns>
        /// <exception cref="NotImplementedException">Siempre se lanza, ya que el método no está implementado.</exception>
        public DETALLE_TAREA GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        // Método para eliminar un objeto DETALLE_TAREA por su ID.
        // Actualmente no está implementado y lanzará una excepción si se llama.
        /// <summary>
        /// Elimina un detalle de tarea de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID del detalle de tarea que se desea eliminar.</param>
        /// <exception cref="NotImplementedException">Siempre se lanza, ya que el método no está implementado.</exception>
        public void Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }

        // Método para modificar un objeto DETALLE_TAREA existente.
        // Actualmente no está implementado y lanzará una excepción si se llama.
        /// <summary>
        /// Modifica un detalle de tarea existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto DETALLE_TAREA que contiene los cambios a aplicar.</param>
        /// <exception cref="NotImplementedException">Siempre se lanza, ya que el método no está implementado.</exception>
        public void Modificar(DETALLE_TAREA obj)
        {
            throw new NotImplementedException();
        }
    }
}
