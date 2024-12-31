using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para una tarea.
    /// </summary>
    public class TareaDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la tarea.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la tarea.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción de la tarea.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual de la tarea (por ejemplo, pendiente, en progreso, completada).
        /// </summary>
        public string Estado { get; set; }
    
    }
}
