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
    /// Representa un pedido realizado por un cliente, incluyendo información sobre el cliente, el empleado que gestionó el pedido y los detalles del pedido.
    /// </summary>
    public partial class PEDIDO
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PEDIDO"/>.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            this.DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        /// <summary>
        /// Obtiene o establece el identificador único del pedido.
        /// </summary>
        public Guid ID_PEDIDO { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del cliente que realizó el pedido.
        /// </summary>
        public Guid ID_CLIENTE { get; set; }

        /// <summary>
        /// Obtiene o establece el código del empleado que gestionó el pedido.
        /// </summary>
        public int COD_EMPLEADO { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que se realizó el pedido.
        /// </summary>
        public DateTime FECHA_HORA { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del pedido (por ejemplo, "Pendiente", "Completado", "Cancelado").
        /// </summary>
        public string ESTADO { get; set; }

        /// <summary>
        /// Obtiene o establece el cliente asociado a este pedido.
        /// </summary>
        public virtual CLIENTE CLIENTE { get; set; }

        /// <summary>
        /// Obtiene la colección de detalles de pedido asociados a este pedido.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        /// <summary>
        /// Obtiene o establece el empleado asociado a este pedido.
        /// </summary>
        public virtual EMPLEADO EMPLEADO { get; set; }
    }
}