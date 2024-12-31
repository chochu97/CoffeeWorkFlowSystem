using Services.Security.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Facade
{
    /// <summary>
    /// Proporciona servicios para realizar copias de seguridad y restauraciones.
    /// </summary>
    public class BackUpService
    {
        private BackUpLogic backLogic = new BackUpLogic();

        /// <summary>
        /// Realiza una copia de seguridad utilizando la lógica de respaldo.
        /// </summary>
        public void BackUp()
        {
            backLogic.RealizarBackUp();
        }

        /// <summary>
        /// Restaura los datos desde una copia de seguridad utilizando la lógica de restauración.
        /// </summary>
        public void Restore()
        {
            backLogic.RealizarRestore();
        }
    }
}
