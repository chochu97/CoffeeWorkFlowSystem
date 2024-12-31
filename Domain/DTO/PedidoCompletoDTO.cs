using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para un pedido completo.
    /// </summary>
    public class PedidoCompletoDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del pedido.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que se realizó el pedido.
        /// </summary>
        public DateTime Fecha_Hora { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente que realizó el pedido.
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de productos incluidos en el pedido.
        /// </summary>
        public string Productos { get; set; }

        /// <summary>
        /// Obtiene o establece el total del pedido.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado que gestionó el pedido.
        /// </summary>
        public string Empleado { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual del pedido (por ejemplo, pendiente, completado, cancelado).
        /// </summary>
        public string Estado { get; set; }


    }
}
