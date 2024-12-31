using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Datos.Contracts
{
    /// <summary>
    /// Interfaz que define los métodos para realizar copias de seguridad y restaurar bases de datos.
    /// </summary>
    public interface IBackUpRepository
    {
        /// <summary>
        /// Realiza una copia de seguridad de la base de datos especificada.
        /// </summary>
        /// <param name="dataBaseName">El nombre de la base de datos a respaldar.</param>
        /// <param name="backUpPath">La ruta donde se almacenará la copia de seguridad.</param>
        void BackUpDataBase(string dataBaseName, string backUpPath);

        /// <summary>
        /// Restaura la base de datos desde una copia de seguridad.
        /// </summary>
        /// <param name="dataBaseName">El nombre de la base de datos a restaurar.</param>
        /// <param name="backUpPath">La ruta de la copia de seguridad desde la cual se restaurará.</param>
        void RestoreDataBase(string dataBaseName, string backUpPath);
    }
}
