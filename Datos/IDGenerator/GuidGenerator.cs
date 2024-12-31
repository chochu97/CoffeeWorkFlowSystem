using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.IDGenerator
{
    /// <summary>
    /// Clase estática para generar identificadores únicos globales (GUID).
    /// </summary>
    public static class GuidGenerator
    {
        /// <summary>
        /// Genera un nuevo GUID.
        /// </summary>
        /// <returns>Un nuevo identificador único global (GUID).</returns>
        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
