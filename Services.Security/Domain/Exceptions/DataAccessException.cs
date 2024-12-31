using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Domain.Exceptions
{
    /// <summary>
    /// Excepción personalizada que representa un error de acceso a datos.
    /// Hereda de la clase base Exception.
    /// </summary>
    public class DataAccessException : Exception
    {
        /// <summary>
        /// Constructor para crear una nueva instancia de DataAccessException.
        /// </summary>
        /// <param name="message">El mensaje que describe la excepción.</param>
        /// <param name="innerException">La excepción interna que causó el error (opcional).</param>
        public DataAccessException(string message, Exception innerException = null) : base(message, innerException) { }
    }
}
