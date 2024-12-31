using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Facade;
using Services.Facade.Extentions;

namespace Services.Domain.Exceptions
{
    /// <summary>
    /// Excepción personalizada que indica que no se encontró una palabra para traducir.
    /// </summary>
    internal class WordNotFoundException : Exception
    {
        /// <summary>
        /// Constructor para crear una nueva instancia de WordNotFoundException.
        /// Inicializa la excepción con un mensaje predeterminado.
        /// </summary>
        public WordNotFoundException()
            : base("No se encontró la palabra a traducir".Translate()) // Mensaje de error traducido
        {
            // Aquí puedes agregar lógica adicional si es necesario.
        }
    }
}
