//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Representa un detalle de una tarea, incluyendo información sobre el tiempo de inicio y fin, el empleado asignado y el estado de la tarea.
    /// </summary>
    public partial class DETALLE_TAREA
    {
        /// <summary>
        /// Obtiene o establece la fecha y hora de inicio de la tarea.
        /// </summary>
        public DateTime FECHA_HORA_INICIO { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora de finalización de la tarea. Puede ser nulo si la tarea aún no ha finalizado.
        /// </summary>
        public DateTime? FECHA_HORA_FIN { get; set; }

        /// <summary>
        /// Obtiene o establece el código del empleado asignado a esta tarea.
        /// </summary>
        public int COD_EMPLEADO { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la tarea asociada a este detalle.
        /// </summary>
        public Guid ID_TAREA { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la tarea (por ejemplo, "Pendiente", "En Progreso", "Completada").
        /// </summary>
        public string ESTADO { get; set; }

        /// <summary>
        /// Obtiene o establece el empleado asociado a este detalle de tarea.
        /// </summary>
        public virtual EMPLEADO EMPLEADO { get; set; }

        /// <summary>
        /// Obtiene o establece la tarea asociada a este detalle.
        /// </summary>
        public virtual TAREA TAREA { get; set; }
    }
}
