using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Domain.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) para representar un usuario.
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Estado del usuario (por ejemplo, activo, inactivo).
        /// </summary>
        public string Estado { get; set; }
    }
}
