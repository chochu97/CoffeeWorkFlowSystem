using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.Items
{
    /// <summary>
    /// Interfaz para el repositorio de productos.
    /// Hereda de <see cref="IGenericInterface{PRODUCTO}"/> para operaciones CRUD.
    /// </summary>
    public interface IProductoRepository : IGenericInterface<PRODUCTO>
    {
        /// <summary>
        /// Obtiene una lista de productos que coinciden con el nombre especificado.
        /// </summary>
        /// <param name="name">El nombre del producto a buscar.</param>
        /// <returns>Una lista de <see cref="ProductoDTO"/> que representan los productos encontrados.</returns>
        List<ProductoDTO> GetByName(string name);

        /// <summary>
        /// Obtiene una lista de todos los productos.
        /// </summary>
        /// <returns>Una lista de <see cref="ProductoDTO"/> que representan todos los productos.</returns>
        List<ProductoDTO> GetProducts();

        /// <summary>
        /// Obtiene una lista de productos que son bebidas.
        /// </summary>
        /// <returns>Una lista de <see cref="ProductoDTO"/> que representan las bebidas.</returns>
        List<ProductoDTO> GetBebidas();

        /// <summary>
        /// Obtiene una lista de productos que son comidas.
        /// </summary>
        /// <returns>Una lista de <see cref="ProductoDTO"/> que representan las comidas.</returns>
        List<ProductoDTO> GetComidas();

        /// <summary>
        /// Habilita o deshabilita un producto por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del producto a habilitar o deshabilitar.</param>
        void EnableDisable(Guid id);
    }
}
