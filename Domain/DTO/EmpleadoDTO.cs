using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para un empleado.
    /// </summary>
    public class EmpleadoDTO
    {
        /// <summary>
        /// Obtiene o establece el código único del empleado.
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el rol del empleado dentro de la organización.
        /// </summary>
        public string Rol { get; set; }

        /// <summary>
        /// Obtiene o establece el turno de trabajo del empleado (por ejemplo, mañana, tarde, noche).
        /// </summary>
        public string Turno { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del empleado.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del empleado.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del empleado (por ejemplo, activo, inactivo).
        /// </summary>
        public string Estado { get; set; }
    }
}
