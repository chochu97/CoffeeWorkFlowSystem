using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para el desempeño de un empleado.
    /// </summary>
    public class EmpleadoDesempDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del empleado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        public string Empleado { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de tareas realizadas por el empleado.
        /// </summary>
        public int Tareas_Realizadas { get; set; }

        /// <summary>
        /// Obtiene o establece el bono asociado al desempeño del empleado.
        /// </summary>
        public string Bono { get; set; }
    }
}
