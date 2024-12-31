using Datos.Contracts.Items;
using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.IDGenerator;

namespace Datos.Implementations.SqlServer.Items
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad PRODUCTO.
    /// </summary>
    public class ProductoDAO : IProductoRepository
    {
        #region singleton
        private static readonly ProductoDAO instance = new ProductoDAO();

        /// <summary>
        /// Obtiene la instancia única de ProductoDAO.
        /// </summary>
        public static ProductoDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo producto a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto PRODUCTO a agregar.</param>
        public void Agregar(PRODUCTO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                obj.ID_PRODUCTO = GuidGenerator.NewGuid();
                context.PRODUCTO.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Modifica un producto existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto PRODUCTO con los nuevos valores.</param>
        public void Modificar(PRODUCTO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var product = context.PRODUCTO.SingleOrDefault(p => p.ID_PRODUCTO == obj.ID_PRODUCTO);

                if (product != null)
                {
                    context.Entry(product).CurrentValues.SetValues(obj);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El producto especificado a modificar no existe");
                }
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var producto = context.PRODUCTO.SingleOrDefault(p => p.ID_PRODUCTO == id);
                if (producto != null)
                {
                    context.PRODUCTO.Remove(producto);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El producto especificado a eliminar no existe");
                }
            }
        }

        /// <summary>
        /// Habilita o deshabilita un producto. (Método no implementado)
        /// </summary>
        /// <param name="id">El ID del producto a habilitar o deshabilitar.</param>
        public void EnableDisable(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos PRODUCTO.</returns>
        public List<PRODUCTO> GetAll()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var productos = context.PRODUCTO.OrderBy(p => p.NOMBRE).ToList();
                return productos;
            }
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a obtener.</param>
        /// <returns>El objeto PRODUCTO correspondiente.</returns>
        public PRODUCTO GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var product = context.PRODUCTO.SingleOrDefault(p => p.ID_PRODUCTO == id);
                return product;
            }
        }

        /// <summary>
        /// Obtiene una lista de productos de tipo "Bebida" que están habilitados.
        /// </summary>
        /// <returns>Una lista de objetos ProductoDTO que representan las bebidas.</returns>
        public List<ProductoDTO> GetBebidas()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var products = context.PRODUCTO
                    .Where(p => p.TIPO.Equals("Bebida") && p.ESTADO == true)
                    .Select(p => new ProductoDTO
                    {
                        Id = p.ID_PRODUCTO,
                        Nombre = p.NOMBRE,
                        Descripcion = p.DESCRIPCION,
                        Precio = p.PRECIO,
                        Tipo = p.TIPO
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                return products;
            }
        }

        /// <summary>
        /// Obtiene una lista de productos de tipo "Comida" que están habilitados.
        /// </summary>
        /// <returns>Una lista de objetos ProductoDTO que representan las comidas.</returns>
        public List<ProductoDTO> GetComidas()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var products = context.PRODUCTO
                    .Where(p => p.TIPO.Equals("Comida") && p.ESTADO == true)
                    .Select(p => new ProductoDTO
                    {
                        Id = p.ID_PRODUCTO,
                        Nombre = p.NOMBRE,
                        Descripcion = p.DESCRIPCION,
                        Precio = p.PRECIO,
                        Tipo = p.TIPO
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                return products;
            }
        }

        /// <summary>
        /// Obtiene una lista de productos que contienen el nombre especificado.
        /// </summary>
        /// <param name="name">El nombre o parte del nombre del producto a buscar.</param>
        /// <returns>Una lista de objetos ProductoDTO que representan los productos encontrados.</returns>
        public List<ProductoDTO> GetByName(string name)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var productos = context.PRODUCTO
                    .Where(p => p.NOMBRE.Contains(name))
                    .Select(p => new ProductoDTO
                    {
                        Id = p.ID_PRODUCTO,
                        Nombre = p.NOMBRE,
                        Descripcion = p.DESCRIPCION,
                        Tipo = p.TIPO,
                        Precio = p.PRECIO,
                        Estado = p.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .ToList();

                return productos;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los productos en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos ProductoDTO que representan todos los productos.</returns>
        public List<ProductoDTO> GetProducts()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var products = context.PRODUCTO
                    .Select(p => new ProductoDTO
                    {
                        Id = p.ID_PRODUCTO,
                        Nombre = p.NOMBRE,
                        Descripcion = p.DESCRIPCION,
                        Tipo = p.TIPO,
                        Precio = p.PRECIO,
                        Estado = p.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                return products;
            }
        }
    }
}
