using Datos.Contracts.Performance;
using Datos.Contracts.Items;
using Datos.Contracts.People;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace Datos.Factory
{
    /// <summary>
    /// Clase estática que proporciona métodos para obtener instancias de repositorios.
    /// Utiliza el patrón de diseño de fábrica para crear repositorios basados en el tipo de backend configurado.
    /// </summary>
    public static class FactoryDAO
    {
        #region ClienteRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de clientes.
        /// </summary>
        /// <returns>Una instancia de <see cref="IClienteRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IClienteRepository GetClienteRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.People.ClienteDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region EmpleadoRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de empleados.
        /// </summary>
        /// <returns>Una instancia de <see cref="IEmpleadoRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IEmpleadoRepository GetEmpleadoRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.People.EmpleadoDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region PedidoRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de pedidos.
        /// </summary>
        /// <returns>Una instancia de <see cref="IPedidoRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IPedidoRepository GetPedidoRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Items.PedidoDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region DetallePedidoRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de detalles de pedidos.
        /// </summary>
        /// <returns>Una instancia de <see cref="IDetallePedidoRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IDetallePedidoRepository GetDetallePedidoRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Items.DetallePedidoDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region ProductoRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de productos.
        /// </summary>
        /// <returns>Una instancia de <see cref="IProductoRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IProductoRepository GetProductoRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Items.ProductoDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region BonoRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de bonos.
        /// </summary>
        /// <returns>Una instancia de <see cref="IBonoRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IBonoRepository GetBonoRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Performance.BonoDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region EmpleadoTareaRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de tareas de empleados.
        /// </summary>
        /// <returns>Una instancia de <see cref="IEmpleadoTareaRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static IEmpleadoTareaRepository GetEmpleadoTareaRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Performance.EmpleadoTareaDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion

        #region TareaRepo
        /// <summary>
        /// Obtiene una instancia del repositorio de tareas.
        /// </summary>
        /// <returns>Una instancia de <see cref="ITareaRepository"/>.</returns>
        /// <exception cref="NotImplementedException">Se lanza si el backend no está implementado.</exception>
        public static ITareaRepository GetTareaRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if (backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.SqlServer.Performance.TareaDAO.Current;
            }
            else
            {
                throw new NotImplementedException("Backend no implementado.");
            }
        }
        #endregion
    }

    /// <summary>
    /// Enumeración que define los tipos de backend disponibles.
    /// </summary>
    internal enum BackendType
    {
        Sql
    }
}

        