using Datos.Contracts.Performance;
using Domain;
using System;
using System.Data.Entity; //now this is cool
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Datos.IDGenerator;

namespace Datos.Implementations.SqlServer.Performance
{
    /// <summary>
    /// Clase que implementa el repositorio para manejar operaciones relacionadas con las tareas en la base de datos.
    /// Utiliza el patrón Singleton para asegurar que solo haya una instancia de TareaDAO en la aplicación.
    /// Proporciona métodos para agregar, eliminar, modificar y obtener tareas, así como para procesar su estado.
    /// </summary>
    public class TareaDAO : ITareaRepository
    {
        #region singleton
        // Instancia única de TareaDAO para implementar el patrón Singleton.
        private static readonly TareaDAO instance = new TareaDAO();

        /// <summary>
        /// Propiedad estática <see cref="Current"/> que obtiene la instancia actual del <see cref="TareaDAO"/>.
        /// Esta propiedad implementa un patrón singleton, asegurando que solo exista una instancia de <see cref="TareaDAO"/>.
        /// </summary>
        /// <value>La instancia actual de <see cref="TareaDAO"/>.</value>
        public static TareaDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega una nueva tarea a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto TAREA que se desea agregar.</param>
        public void Agregar(TAREA obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Genera un nuevo ID para la tarea.
                obj.ID_TAREA = GuidGenerator.NewGuid();
                // Agrega la tarea al contexto.
                context.TAREA.Add(obj);
                // Guarda los cambios en la base de datos.
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina una tarea de la base de datos por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarea que se desea eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Busca la tarea por su ID.
                var obj = context.TAREA.SingleOrDefault(t => t.ID_TAREA == id);
                if (obj != null)
                {
                    // Si se encuentra, la elimina del contexto.
                    context.TAREA.Remove(obj);
                    // Guarda los cambios en la base de datos.
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene todas las tareas de la base de datos, ordenadas por nombre.
        /// </summary>
        /// <returns>Una lista de objetos TAREA.</returns>
        public List<TAREA> GetAll()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Devuelve todas las tareas ordenadas por nombre.
                return context.TAREA.OrderBy(t => t.NOMBRE).ToList();
            }
        }

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la tarea que se desea obtener.</param>
        /// <returns>El objeto TAREA correspondiente al ID proporcionado.</returns>
        public TAREA GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Busca y devuelve la tarea por su ID.
                return context.TAREA.SingleOrDefault(t => t.ID_TAREA == id);
            }
        }

        /// <summary>
        /// Modifica una tarea existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto TAREA que contiene los cambios a aplicar.</param>
        public void Modificar(TAREA obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Busca la tarea existente por su ID.
                var tarea = context.TAREA.Find(obj.ID_TAREA);

                if (tarea != null)
                {
                    // Actualiza los valores de la tarea existente con los nuevos valores.
                    context.Entry(tarea).CurrentValues.SetValues(obj);
                    // Guarda los cambios en la base de datos.
                    context.SaveChanges();
                }
            }
        }

        // Métodos específicos para el manejo del estado de las tareas.

        /// <summary>
        /// Procesa el estado de una tarea, cambiándolo de "Pendiente" a "En Proceso" o de "En Proceso" a "Finalizada".
        /// </summary>
        /// <param name="obj">El objeto TAREA cuyo estado se desea procesar.</param>
        public void ProcesarEstado(TAREA obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                if (obj.ESTADO == "Pendiente")
                {
                    obj.ESTADO = "En Proceso";
                }
                else if (obj.ESTADO == "En Proceso")
                {
                    obj.ESTADO = "Finalizada";
                }
                else if (obj.ESTADO == "Finalizada")
                {

                }

                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Restablece el estado de todas las tareas a "Pendiente".
        /// </summary>
        public void ResetearTareasTurno()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Obtiene todas las tareas de la base de datos.
                var tareas = context.TAREA.ToList();

                // Verifica si hay tareas para procesar.
                if (tareas.Count > 0)
                {
                    foreach (var tarea in tareas)
                    {
                        // Cambia el estado de cada tarea a "Pendiente".
                        tarea.ESTADO = "Pendiente";
                        // Marca la tarea como modificada en el contexto.
                        context.Entry(tarea).State = EntityState.Modified;
                    }

                    // Guarda los cambios en la base de datos.
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de tareas que no están finalizadas.
        /// </summary>
        /// <returns>Una lista de objetos TareaDTO que representan las tareas activas.</returns>
        public List<TareaDTO> GetTareas()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                // Filtra las tareas que no están en estado "Finalizada" y proyecta en TareaDTO.
                var lista = context.TAREA
                    .Select(t => new TareaDTO
                    {
                        Id = t.ID_TAREA,
                        Nombre = t.NOMBRE,
                        Descripcion = t.DESCRIPCION,
                        Estado = t.ESTADO
                    }).ToList();

                // Devuelve la lista de tareas DTO.
                return lista;
            }
        }
    }
}
