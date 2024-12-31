using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para los detalles de una tarea.
    /// </summary>
    public class DetalleTareaDTO
    {
        /// <summary>
        /// Obtiene o establece la fecha y hora en que se inició la tarea.
        /// </summary>
        public DateTime Iniciada { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que se finalizó la tarea. 
        /// Este campo es opcional y puede ser nulo si la tarea aún no ha sido finalizada.
        /// </summary>
        public DateTime? Finalizada { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción de la tarea.
        /// </summary>
        public string Tarea { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado que está asignado a la tarea.
        /// </summary>
        public string Empleado { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual de la tarea (por ejemplo, pendiente, en progreso, completada).
        /// </summary>
        public string Estado { get; set; }

    }
}
