using Datos.Contracts.Items;
using Datos.IDGenerator;
using Domain;
using Domain.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.Items
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad DETALLE_PEDIDO.
    /// </summary>
    public class DetallePedidoDAO : IDetallePedidoRepository
    {
        #region singleton
        private static readonly DetallePedidoDAO instance = new DetallePedidoDAO();

        /// <summary>
        /// Obtiene la instancia única de DetallePedidoDAO.
        /// </summary>
        public static DetallePedidoDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo detalle de pedido a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto DETALLE_PEDIDO a agregar.</param>
        public void Agregar(DETALLE_PEDIDO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                obj.ID_DETALLE = GuidGenerator.NewGuid();
                context.DETALLE_PEDIDO.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina un detalle de pedido de la base de datos.
        /// </summary>
        /// <param name="id">El ID del detalle de pedido a eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var detalle = context.DETALLE_PEDIDO.SingleOrDefault(d => d.ID_DETALLE == id);
                if (detalle != null)
                {
                    context.DETALLE_PEDIDO.Remove(detalle);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El detalle especificado no existe");
                }
            }
        }

        /// <summary>
        /// Obtiene un detalle de pedido por su ID.
        /// </summary>
        /// <param name="id">El ID del detalle de pedido a obtener.</param>
        /// <returns>El objeto DETALLE_PEDIDO correspondiente.</returns>
        public DETALLE_PEDIDO GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var detalle = context.DETALLE_PEDIDO.SingleOrDefault(d => d.ID_DETALLE == id);
                return detalle;
            }
        }

        /// <summary>
        /// Modifica un detalle de pedido existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto DETALLE_PEDIDO con los nuevos valores.</param>
        public void Modificar(DETALLE_PEDIDO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var detalle = context.DETALLE_PEDIDO.SingleOrDefault(d => d.ID_DETALLE == obj.ID_DETALLE);

                if (detalle != null)
                {
                    context.Entry(detalle).CurrentValues.SetValues(obj);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El detalle especificado a modificar no existe");
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de detalles de productos por el ID de un pedido.
        /// </summary>
        /// <param name="PedidoID">El ID del pedido para el cual se desean los detalles.</param>
        /// <returns>Una lista de objetos ProductoDetalleDTO.</returns>
        public List<ProductoDetalleDTO> ObtenerDetallesPorPedido(Guid PedidoID)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var detalles = context.DETALLE_PEDIDO
                    .Where(d => d.ID_PEDIDO == PedidoID)
                    .Select(d => new ProductoDetalleDTO
                    {
                        Id_Detalle = d.ID_DETALLE,
                        Id_Producto = d.ID_PRODUCTO,
                        Producto = d.PRODUCTO.NOMBRE,
                        Cantidad = d.CANTIDAD
                    })
                    .ToList();

                return detalles;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de detalles de pedidos.
        /// Este método no está implementado y lanza una excepción <see cref="NotImplementedException"/>.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="DETALLE_PEDIDO"/> que representan los detalles de los pedidos.</returns>
        /// <exception cref="NotImplementedException">Lanzado cuando el método no ha sido implementado aún.</exception>
        public List<DETALLE_PEDIDO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
