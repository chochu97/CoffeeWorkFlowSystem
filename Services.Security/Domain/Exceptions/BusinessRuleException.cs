using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Domain.Exceptions
{
    /// <summary>
    /// Excepción personalizada que representa una violación de una regla de negocio.
    /// Hereda de la clase base Exception.
    /// </summary>
    public class BusinessRuleException : Exception
    {
        /// <summary>
        /// Constructor para crear una nueva instancia de BusinessRuleException.
        /// </summary>
        /// <param name="message">El mensaje que describe la excepción.</param>
        public BusinessRuleException(string message) : base(message) { }
    }
}
