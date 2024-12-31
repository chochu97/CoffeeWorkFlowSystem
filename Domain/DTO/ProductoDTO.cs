using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para un producto.
    /// </summary>
    public class ProductoDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del producto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de producto (por ejemplo, alimento, bebida, etc.).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece el precio del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del producto (por ejemplo, disponible, agotado).
        /// </summary>
        public string Estado { get; set; }
    }

    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para los detalles de un producto en un pedido.
    /// </summary>
    public class ProductoDetalleDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del detalle del producto.
        /// </summary>
        public Guid Id_Detalle { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del producto asociado a este detalle.
        /// </summary>
        public Guid Id_Producto { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string Producto { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad del producto en este detalle.
        /// </summary>
        public int Cantidad { get; set; }

    }
}
