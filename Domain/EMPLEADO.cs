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
    /// Representa un empleado en el sistema, incluyendo información personal y su relación con tareas y pedidos.
    /// </summary>
    public partial class EMPLEADO
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EMPLEADO"/>.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.DETALLE_TAREA = new HashSet<DETALLE_TAREA>();
            this.PEDIDO = new HashSet<PEDIDO>();
        }

        /// <summary>
        /// Obtiene o establece el código único del empleado.
        /// </summary>
        public int COD_EMPLEADO { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del bono asociado al empleado.
        /// </summary>
        public Guid ID_BONO { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        public string NOMBRE { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del empleado.
        /// </summary>
        public string APELLIDO { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del empleado.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del empleado.
        /// </summary>
        public string TELEFONO { get; set; }

        /// <summary>
        /// Obtiene o establece el rol del empleado en la organización.
        /// </summary>
        public string ROL { get; set; }

        /// <summary>
        /// Obtiene o establece el turno de trabajo del empleado.
        /// </summary>
        public string TURNO { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del empleado (por ejemplo, activo o inactivo).
        /// </summary>
        public bool ESTADO { get; set; }

        /// <summary>
        /// Obtiene o establece el bono asociado a este empleado.
        /// </summary>
        public virtual BONO BONO { get; set; }

        /// <summary>
        /// Obtiene la colección de detalles de tareas asociados a este empleado.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_TAREA> DETALLE_TAREA { get; set; }

        /// <summary>
        /// Obtiene la colección de pedidos asociados a este empleado.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
    }
}