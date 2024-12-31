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
    /// Lógica de negocio para la gestión de detalles de pedidos.
    /// Implementa la interfaz <see cref="IGenericInterface{DETALLE_PEDIDO}"/>.
    /// </summary>
    public class DetallePedidoLogic : IGenericInterface<DETALLE_PEDIDO>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="DetallePedidoLogic"/>.
        /// </summary>
        private static DetallePedidoLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de los detalles de los pedidos.
        /// </summary>
        private readonly IDetallePedidoRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DetallePedidoLogic"/>.
        /// </summary>
        public DetallePedidoLogic()
        {
            _repository = FactoryDAO.GetDetallePedidoRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="DetallePedidoLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="DetallePedidoLogic"/>.</returns>
        public static DetallePedidoLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new DetallePedidoLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo detalle de pedido.
        /// </summary>
        /// <param name="obj">El detalle de pedido a agregar.</param>
        public void Add(DETALLE_PEDIDO obj)
        {
            try
            {
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
        /// Obtiene todos los detalles de pedido.
        /// </summary>
        /// <returns>Una lista de todos los detalles de pedido.</returns>
        public List<DETALLE_PEDIDO> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un detalle de pedido existente.
        /// </summary>
        /// <param name="obj">El detalle de pedido a actualizar.</param>
        public void Update(DETALLE_PEDIDO obj)
        {
            try
            {
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
        /// Elimina un detalle de pedido por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del detalle de pedido a eliminar.</param>
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
        /// Obtiene los detalles de pedido asociados a un pedido específico.
        /// </summary>
        /// <param name="PedidoID">El identificador del pedido.</param>
        /// <returns>Una lista de detalles de pedido asociados al pedido especificado.</returns>
        public List<ProductoDetalleDTO> ObtenerDetallesPorPedido(Guid PedidoID)
        {
            try
            {
                return _repository.ObtenerDetallesPorPedido(PedidoID);
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
        /// Obtiene un detalle de pedido por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del detalle de pedido a obtener.</param>
        /// <returns>El detalle de pedido correspondiente al identificador, o null si no se encuentra.</returns>
        public DETALLE_PEDIDO GetById(Guid id)
        {
            try
            {
                return _repository.GetOne(id);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
        }
    }
}
