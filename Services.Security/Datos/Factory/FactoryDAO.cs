using Services.Datos.Contracts;
using Services.Datos.Implementations.SqlServer;
using Services.Security.Datos.Contracts;
using Services.Security.Datos.Implementations.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Datos.Factory
{
    /// <summary>
    /// Clase estática <see cref="FactoryDAO"/> que proporciona métodos para obtener instancias de repositorios.
    /// Utiliza el patrón Factory para crear repositorios dependiendo del tipo de backend configurado.
    /// </summary>
    public static class FactoryDAO
    {
        private static IUsuarioRepository _UsuarioRepository;
        private static readonly int backendType;
        private static readonly object _lock = new object();

        /// <summary>
        /// Constructor estático de la clase <see cref="FactoryDAO"/>.
        /// Lee el tipo de backend desde la configuración de la aplicación.
        /// </summary>
        static FactoryDAO()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["ServiceBackendType"]);
        }

        /// <summary>
        /// Obtiene una instancia del repositorio de usuarios.
        /// </summary>
        /// <returns>Una instancia de <see cref="IUsuarioRepository"/>.</returns>
        /// <exception cref="NotSupportedException">Si el tipo de backend no es soportado.</exception>
        public static IUsuarioRepository GetUsuarioRepository()
        {
            if (backendType == (int)BackendType.SqlServer)
            {
                _UsuarioRepository = new UsuarioRepository();
                return _UsuarioRepository;
            }
            else
            {
                throw new NotSupportedException("Backend no soportado");
            }
        }

        /// <summary>
        /// Obtiene una instancia del repositorio de respaldo (backup).
        /// </summary>
        /// <returns>Una instancia de <see cref="IBackUpRepository"/>.</returns>
        /// <exception cref="NotSupportedException">Si el tipo de backend no es soportado.</exception>
        public static IBackUpRepository GetBackUp()
        {
            if (backendType == (int)BackendType.SqlServer)
            {
                return new BackUpRepository();
            }
            else
            {
                throw new NotSupportedException("Backend no soportado");
            }
        }
    }

    /// <summary>
    /// Enumeración que define los tipos de backend soportados.
    /// </summary>
    internal enum BackendType
    {
        /// <summary>
        /// Tipo de backend SqlServer.
        /// </summary>
        SqlServer = 1

    }
}
