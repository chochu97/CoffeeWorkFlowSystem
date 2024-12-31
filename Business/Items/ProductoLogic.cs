using Business.Contracts;
using Datos.Contracts.Items;
using Datos.Factory;
using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.CodeDom;
using System.Diagnostics;
using Services.Security.Domain.Exceptions;
using System.Data.SqlClient;

namespace Business.Items
{
    /// <summary>
    /// Lógica de negocio para la gestión de productos.
    /// Implementa la interfaz <see cref="IGenericInterface{PRODUCTO}"/>.
    /// </summary>
    public class ProductoLogic : IGenericInterface<PRODUCTO>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="ProductoLogic"/>.
        /// </summary>
        private static ProductoLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Repositorio para interactuar con los datos de los productos.
        /// </summary>
        private readonly IProductoRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ProductoLogic"/>.
        /// </summary>
        public ProductoLogic()
        {
            _repository = FactoryDAO.GetProductoRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="ProductoLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="ProductoLogic"/>.</returns>
        public static ProductoLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ProductoLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo producto.
        /// </summary>
        /// <param name="obj">El producto a agregar.</param>
        public void Add(PRODUCTO obj)
        {
            try
            {
                if (obj.NOMBRE == null || obj.DESCRIPCION == null || obj.PRECIO == 0 || obj.TIPO == null)
                    throw new BusinessRuleException("Complete todos los campos");

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
        /// Obtiene todos los productos registrados.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        public List<ProductoDTO> GetProducts()
        {
            try
            {
                var list = _repository.GetProducts();

                if (list.Count == 0)
                    throw new BusinessRuleException("No hay Productos registrados");

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
        /// Obtiene todos los productos de tipo bebida.
        /// </summary>
        /// <returns>Una lista de bebidas.</returns>
        public List<ProductoDTO> GetBebidas()
        {
            try
            {
                var list = _repository.GetBebidas();

                if (list.Count == 0)
                    throw new BusinessRuleException("No hay bebidas en existencia");

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
        /// Obtiene todos los productos de tipo comida.
        /// </summary>
        /// <returns>Una lista de comidas.</returns>
        public List<ProductoDTO> GetComidas()
        {
            try
            {
                var list = _repository.GetComidas();

                if (list.Count == 0)
                    throw new BusinessRuleException("No hay Comidas registradas");

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
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="obj">El producto a actualizar.</param>
        public void Update(PRODUCTO obj)
        {
            try
            {
                if (obj.NOMBRE == null || obj.DESCRIPCION == null || obj.PRECIO == 0 || obj.TIPO == null) throw new BusinessRuleException("Complete todos los campos");

                _repository.Modificar(obj);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Elimina un producto por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del producto a eliminar.</param>
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
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del producto a obtener.</param>
        /// <returns>El producto correspondiente al identificador, o lanza una excepción si no se encuentra.</returns>
        public PRODUCTO GetById(Guid id)
        {
            try
            {
                var produ = _repository.GetOne(id);

                if (produ == null) throw new BusinessRuleException("No se encuentra el producto solicitado");

                return produ;
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
        /// Obtiene todos los productos registrados.
        /// </summary>
        /// <returns>Una lista de todos los productos.</returns>
        public List<PRODUCTO> GetAll()
        {
            try
            {
                var produ = _repository.GetAll();

                if (produ.Count == 0) throw new BusinessRuleException("No se encontraron Productos");

                return produ;
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
        /// Obtiene productos por su nombre.
        /// </summary>
        /// <param name="name">El nombre del producto a buscar.</param>
        /// <returns>Una lista de productos que coinciden con el nombre proporcionado.</returns>
        public List<ProductoDTO> GetProductoByName(string name)
        {
            try
            {
                var list = _repository.GetByName(name);

                if (list.Count == 0) throw new BusinessRuleException("No se encontró el Producto solicitado");

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
    }
}
