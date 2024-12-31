using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Datos.Contracts
{
    /// <summary>
    /// Interfaz que define el patrón Observer para notificar cambios de idioma.
    /// </summary>
    public interface ILanguageObserver
    {
        /// <summary>
        /// Método que se llama cuando se produce un cambio de idioma.
        /// </summary>
        void UpdateLanguage();
    }
}
