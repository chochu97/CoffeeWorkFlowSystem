using Business.Contracts;
using Business.People;
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
    /// Lógica de negocio para la gestión de bonos.
    /// Implementa la interfaz <see cref="IGenericInterface{BONO}"/>.
    /// </summary>
    public class BonoLogic : IGenericInterface<BONO>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="BonoLogic"/>.
        /// </summary>
        private static BonoLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de los bonos.
        /// </summary>
        private readonly IBonoRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BonoLogic"/>.
        /// </summary>
        public BonoLogic()
        {
            _repository = FactoryDAO.GetBonoRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="BonoLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="BonoLogic"/>.</returns>
        public static BonoLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new BonoLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo bono.
        /// </summary>
        /// <param name="obj">El bono a agregar.</param>
        public void Add(BONO obj)
        {
            try
            {
                if (obj.CATEGORIA == null || obj.MONTO <= 0 || obj.MINIMO_TAREAS <= 0)
                {
                    throw new BusinessRuleException("Complete todos los campos.");
                }

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
        /// Obtiene todos los bonos registrados.
        /// </summary>
        /// <returns>Una lista de todos los bonos.</returns>
        public List<BONO> GetAll()
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
        /// Actualiza un bono existente.
        /// </summary>
        /// <param name="obj">El bono a modificar.</param>
        public void Update(BONO obj)
        {
            try
            {
                if (obj == null) throw new BusinessRuleException("El bono a modificar no existe");

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
        /// Elimina un bono por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del bono a eliminar.</param>
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
        /// Obtiene un bono por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del bono a obtener.</param>
        /// <returns>El bono correspondiente al identificador.</returns>
        public BONO GetById(Guid id)
        {
            try
            {
                var bono = _repository.GetOne(id);

                if (bono == null) throw new BusinessRuleException("El Bono solicitado no existe.");

                return bono;
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

        // DTOs

        /// <summary>
        /// Obtiene una lista de todos los bonos en formato DTO.
        /// </summary>
        /// <returns>Una lista de bonos registrados.</returns>
        public List<BonoDTO> GetBonos()
        {
            try
            {
                var list = _repository.GetBonos();

                if (list.Count == 0) throw new BusinessRuleException("No hay bonos registrados");

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
    }
}
