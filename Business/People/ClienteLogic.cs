using Business.Contracts;
using Datos.Contracts.People;
using Datos.Factory;
using Domain;
using Domain.DTO;
using Services.Security.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.People
{
    /// <summary>
    /// Lógica de negocio para la gestión de clientes.
    /// Implementa la interfaz <see cref="IGenericInterface{CLIENTE}"/>.
    /// </summary>
    public class ClienteLogic : IGenericInterface<CLIENTE>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="ClienteLogic"/>.
        /// </summary>
        private static ClienteLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de los clientes.
        /// </summary>
        private readonly IClienteRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClienteLogic"/>.
        /// </summary>
        public ClienteLogic()
        {
            _repository = FactoryDAO.GetClienteRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="ClienteLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="ClienteLogic"/>.</returns>
        public static ClienteLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ClienteLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo cliente.
        /// </summary>
        /// <param name="obj">El cliente a agregar.</param>
        public void Add(CLIENTE obj)
        {
            try
            {
                if (obj.NOMBRE == null || obj.APELLIDO == null || obj.DNI == 0)
                    throw new BusinessRuleException("Complete todos los campos.");

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
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Una lista de todos los clientes.</returns>
        public List<CLIENTE> GetAll()
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
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="obj">El cliente a actualizar.</param>
        public void Update(CLIENTE obj)
        {
            try
            {
                if (obj.NOMBRE == null || obj.APELLIDO == null || obj.DNI == 0)
                    throw new BusinessRuleException("Complete todos los campos.");

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
        /// Elimina un cliente por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del cliente a eliminar.</param>
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
        /// Obtiene un cliente por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del cliente a obtener.</param>
        /// <returns>El cliente correspondiente al identificador, o lanza una excepción si no se encuentra.</returns>
        public CLIENTE GetById(Guid id)
        {
            try
            {
                var cli = _repository.GetOne(id);

                if (cli == null) throw new BusinessRuleException("No se encontró el cliente solicitado.");

                return cli;
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
        /// Obtiene un cliente por su número de DNI.
        /// </summary>
        /// <param name="dni">El número de DNI del cliente a obtener.</param>
        /// <returns>El cliente correspondiente al DNI, o lanza una excepción si no se encuentra.</returns>
        public CLIENTE GetOneByDNI(int dni)
        {
            try
            {
                var client = _repository.GetOneClientDNI(dni);

                if (client == null) throw new BusinessRuleException("No se encontró el cliente solicitado.");

                return client;
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
        /// Obtiene una lista de clientes por su número de DNI.
        /// </summary>
        /// <param name="dni">El número de DNI de los clientes a buscar.</param>
        /// <returns>Una lista de clientes que coinciden con el DNI proporcionado.</returns>
        public List<ClienteDTO> GetByDNI(int dni)
        {
            try
            {
                var client = _repository.GetClienteByDNI(dni);

                if (client.Count == 0) throw new BusinessRuleException("No se encontró el cliente solicitado.");

                return client;
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
        /// Obtiene todos los clientes registrados.
        /// </summary>
        /// <returns>Una lista de todos los clientes.</returns>
        public List<ClienteDTO> GetClientes()
        {
            try
            {
                var lista = _repository.GetClientes();

                if (lista.Count == 0) throw new BusinessRuleException("No hay Clientes registrados");

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

    }
}
