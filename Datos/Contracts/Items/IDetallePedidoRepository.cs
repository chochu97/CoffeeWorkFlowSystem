using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.Items
{
    /// <summary>
    /// Interfaz para el repositorio de detalles de pedidos.
    /// Hereda de <see cref="IGenericInterface{DETALLE_PEDIDO}"/> para operaciones CRUD.
    /// </summary>
    public interface IDetallePedidoRepository : IGenericInterface<DETALLE_PEDIDO>
    {
        /// <summary>
        /// Obtiene una lista de detalles de productos asociados a un pedido específico.
        /// </summary>
        /// <param name="PedidoID">El identificador único del pedido.</param>
        /// <returns>Una lista de <see cref="ProductoDetalleDTO"/> que representan los detalles del pedido.</returns>
        List<ProductoDetalleDTO> ObtenerDetallesPorPedido(Guid PedidoID);
    }
}
