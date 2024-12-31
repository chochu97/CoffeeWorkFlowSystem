using Business.Contracts;
using Datos.Contracts.Items;
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
    /// Lógica de negocio para la gestión de pedidos.
    /// Implementa la interfaz <see cref="IGenericInterface{PEDIDO}"/>.
    /// </summary>
    public class PedidoLogic : IGenericInterface<PEDIDO>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="PedidoLogic"/>.
        /// </summary>
        private static PedidoLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de los pedidos.
        /// </summary>
        private readonly IPedidoRepository _petoRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PedidoLogic"/>.
        /// </summary>
        public PedidoLogic()
        {
            _petoRepository = FactoryDAO.GetPedidoRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="PedidoLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="PedidoLogic"/>.</returns>
        public static PedidoLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new PedidoLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo pedido.
        /// </summary>
        /// <param name="obj">El pedido a agregar.</param>
        public void Add(PEDIDO obj)
        {
            try
            {
                if (obj.FECHA_HORA == null || obj.ESTADO == null)
                    throw new BusinessRuleException("Complete todos los campos");

                _petoRepository.Agregar(obj);
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
        /// Obtiene todos los pedidos registrados.
        /// </summary>
        /// <returns>Una lista de pedidos completos.</returns>
        public List<PedidoCompletoDTO> GetPedidos()
        {
            try
            {
                var list = _petoRepository.ObtenerPedidos();

                if (list.Count == 0)
                    throw new BusinessRuleException("No hay Pedidos registrados");

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
        /// Procesa un pedido existente.
        /// </summary>
        /// <param name="ped">El pedido a procesar.</param>
        public void ProcesarPedido(PEDIDO ped)
        {
            try
            {
                _petoRepository.ProcesarPedido(ped);
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
        /// Obtiene un pedido por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del pedido a obtener.</param>
        /// <returns>El pedido correspondiente al identificador, o null si no se encuentra.</returns>
        public PEDIDO GetById(Guid id)
        {
            try
            {
                return _petoRepository.GetOne(id);
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

        // Métodos no utilizados
        /// <summary>
        /// Obtiene todos los pedidos (no implementado).
        /// </summary>
        /// <returns>Una lista de todos los pedidos.</returns>
        public List<PEDIDO> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un pedido existente (no implementado).
        /// </summary>
        /// <param name="obj">El pedido a actualizar.</param>
        public void Update(PEDIDO obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina un pedido por su identificador único (no implementado).
        /// </summary>
        /// <param name="id">El identificador único del pedido a eliminar.</param>

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
