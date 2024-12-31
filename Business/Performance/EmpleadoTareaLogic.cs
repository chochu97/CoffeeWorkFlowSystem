using Business.Contracts;
using Datos.Contracts.Performance;
using Datos.Factory;
using Domain;
using Domain.DTO;
using Services.Security.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Performance
{
    /// <summary>
    /// Lógica de negocio para la gestión de tareas de empleados.
    /// Implementa la interfaz <see cref="IGenericInterface{DETALLE_TAREA}"/>.
    /// </summary>
    public class EmpleadoTareaLogic : IGenericInterface<DETALLE_TAREA>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="EmpleadoTareaLogic"/>.
        /// </summary>
        private static EmpleadoTareaLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de la relación entre empleados y tareas.
        /// </summary>
        private readonly IEmpleadoTareaRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EmpleadoTareaLogic"/>.
        /// </summary>
        public EmpleadoTareaLogic()
        {
            _repository = FactoryDAO.GetEmpleadoTareaRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="EmpleadoTareaLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="EmpleadoTareaLogic"/>.</returns>
        public static EmpleadoTareaLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new EmpleadoTareaLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Asigna una tarea a un empleado.
        /// </summary>
        /// <param name="detalle">El detalle de la tarea a realizar.</param>
        public void HacerTarea(DETALLE_TAREA detalle)
        {
            try
            {
                if (detalle.COD_EMPLEADO == 0 || detalle.ID_TAREA == null)
                    throw new BusinessRuleException("Seleccione la tarea e ingrese el código de empleado primero.");

                _repository.HacerTarea(detalle);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Finaliza una tarea por su identificador único.
        /// </summary>
        /// <param name="idTarea">El identificador único de la tarea a finalizar.</param>
        public void FinTarea(Guid idTarea)
        {
            try
            {
                _repository.FinalizarTarea(idTarea);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todos los detalles de tareas registrados.
        /// </summary>
        /// <returns>Una lista de detalles de tareas.</returns>
        public List<DetalleTareaDTO> GetDetalles()
        {
            try
            {
                var list = _repository.GetDetalles();

                if (list.Count == 0) throw new BusinessRuleException("No hay detalles registrados este mes.");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene los detalles de tareas asignadas a un empleado específico.
        /// </summary>
        /// <param name="id">El identificador del empleado.</param>
        /// <returns>Una lista de detalles de tareas para el empleado especificado.</returns>
        public List<DetalleTareaDTO> GetDetallesPorEmp(int id)
        {
            try
            {
                var list = _repository.GetDetallesPorEmp(id);

                if (list.Count == 0) throw new BusinessRuleException("No hay detalles de este empleado este mes.");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene los desempeños de empleados registrados en el mes actual.
        /// </summary>
        /// <returns>Una lista de desempeños de empleados.</returns>
        public List<EmpleadoDesempDTO> ObtenerDesempDelMes()
        {
            try
            {
                var list = _repository.ObtenerBonosDelMes();

                if (list.Count == 0) throw new BusinessRuleException("No hay desempeños registrados este mes");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Métodos no utilizados (no implementados)

        /// <summary>
        /// Agrega un nuevo detalle de tarea. Este método no está implementado.
        /// </summary>
        /// <param name="obj">El detalle de tarea a agregar.</param>
        public void Add(DETALLE_TAREA obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todos los detalles de tareas. Este método no está implementado.
        /// </summary>
        /// <returns>Una lista de todos los detalles de tareas.</returns>
        public List<DETALLE_TAREA> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un detalle de tarea existente. Este método no está implementado.
        /// </summary>
        /// <param name="obj">El detalle de tarea a actualizar.</param>
        public void Update(DETALLE_TAREA obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina un detalle de tarea por su identificador único. Este método no está implementado.
        /// </summary>
        /// <param name="id">El identificador único del detalle de tarea a eliminar.</param>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un detalle de tarea por su identificador único. Este método no está implementado.
        /// </summary>
        /// <param name="id">El identificador único del detalle de tarea a obtener.</param>
        /// <returns>El detalle de tarea correspondiente al identificador.</returns>
        public DETALLE_TAREA GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
