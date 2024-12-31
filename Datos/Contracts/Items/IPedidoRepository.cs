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
    /// Interfaz para el repositorio de pedidos.
    /// Hereda de <see cref="IGenericInterface{PEDIDO}"/> para operaciones CRUD.
    /// </summary>
    public interface IPedidoRepository : IGenericInterface<PEDIDO>
    {
        /// <summary>
        /// Obtiene una lista de todos los pedidos completos.
        /// </summary>
        /// <returns>Una lista de <see cref="PedidoCompletoDTO"/> que representan los pedidos.</returns>
        List<PedidoCompletoDTO> ObtenerPedidos();

        /// <summary>
        /// Procesa un pedido específico.
        /// </summary>
        /// <param name="pedido">El objeto <see cref="PEDIDO"/> a procesar.</param>
        void ProcesarPedido(PEDIDO pedido);
    }
}
