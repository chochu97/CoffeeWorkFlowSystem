using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para un bono.
    /// </summary>
    public class BonoDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del bono.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece la categoría del bono.
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Obtiene o establece el monto del bono.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Obtiene o establece el número mínimo de tareas requeridas para calificar para el bono.
        /// </summary>
        public int Tareas_Minimas { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del bono (por ejemplo, activo, inactivo).
        /// </summary>
        public string Estado { get; set; }
    }
}
