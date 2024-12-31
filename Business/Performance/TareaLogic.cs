using Business.Contracts;
using Business.Performance;
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

namespace Business.Items
{
    /// <summary>
    /// Lógica de negocio para la gestión de tareas.
    /// Implementa la interfaz <see cref="IGenericInterface{TAREA}"/>.
    /// </summary>
    public class TareaLogic : IGenericInterface<TAREA>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="TareaLogic"/>.
        /// </summary>
        private static TareaLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de las tareas.
        /// </summary>
        private readonly ITareaRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TareaLogic"/>.
        /// </summary>
        public TareaLogic()
        {
            _repository = FactoryDAO.GetTareaRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="TareaLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="TareaLogic"/>.</returns>
        public static TareaLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new TareaLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega una nueva tarea.
        /// </summary>
        /// <param name="obj">La tarea a agregar.</param>
        public void Add(TAREA obj)
        {
            try
            {
                if (obj.NOMBRE == null || obj.DESCRIPCION == null)
                    throw new BusinessRuleException("Complete todos los campos");

                _repository.Agregar(obj);
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
        /// Obtiene todas las tareas.
        /// </summary>
        /// <returns>Una lista de todas las tareas.</returns>
        public List<TAREA> GetAll()
        {
            try
            {
                return _repository.GetAll();
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
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="obj">La tarea a modificar.</param>
        public void Update(TAREA obj)
        {
            try
            {
                if (obj == null) throw new BusinessRuleException("No se encuentra la Tarea a modificar");
                _repository.Modificar(obj);
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
        /// Elimina una tarea por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la tarea a eliminar.</param>
        public void Remove(Guid id)
        {
            try
            {
                _repository.Eliminar(id);
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
        /// Obtiene una tarea por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la tarea a obtener.</param>
        /// <returns>La tarea correspondiente al identificador.</returns>
        public TAREA GetById(Guid id)
        {
            try
            {
                var tarea = _repository.GetOne(id);

                if (tarea == null) throw new BusinessRuleException("No se encuentra la Tarea solicitada");

                return tarea;
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
        /// Obtiene todas las tareas registradas.
        /// </summary>
        /// <returns>Una lista de tareas registradas.</returns>
        public List<TareaDTO> GetTareas()
        {
            try
            {
                var lista = _repository.GetTareas();

                if (lista.Count == 0) throw new BusinessRuleException("No hay Tareas registradas");

                return lista;
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
        /// Procesa el estado de una tarea.
        /// </summary>
        /// <param name="obj">La tarea a procesar.</param>
        public void ProcesarTarea(TAREA obj)
        {
            try
            {
                if (obj == null) throw new BusinessRuleException("La Tarea a procesar no se encuentra.");

                _repository.ProcesarEstado(obj);
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
        /// Inicia un proceso de actualización automática de tareas a intervalos específicos.
        /// Este método se ejecuta de forma asíncrona.
        /// </summary>
        public async void IniciarActualizacionAutomatica()
        {
            while (true)
            {
                DateTime ahora = DateTime.Now;
                if (ahora.Hour == 12 || ahora.Hour == 18)
                {
                    _repository.ResetearTareasTurno();
                }

                DateTime nextHour = ahora.AddHours(1).AddMinutes(-ahora.Minute).AddSeconds(-ahora.Second);
                TimeSpan delay = nextHour - ahora;

                await Task.Delay(delay);
            }
        }
    }
}
