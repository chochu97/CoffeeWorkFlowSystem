using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    /// <summary>
    /// Representa un objeto de transferencia de datos (DTO) para un cliente.
    /// </summary>
    public class ClienteDTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del cliente.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del cliente.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento de identidad (DNI) del cliente.
        /// </summary>
        public int DNI { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de puntos acumulados por el cliente.
        /// </summary>
        public int Puntos { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del cliente (por ejemplo, activo, inactivo).
        /// </summary>
        public string Estado { get; set; }
    }
}
