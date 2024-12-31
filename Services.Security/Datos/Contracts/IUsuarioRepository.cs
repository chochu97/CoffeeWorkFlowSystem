using Services.Domain.Composite;
using Services.Security.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Datos.Contracts
{
    /// <summary>
    /// Interfaz que define las operaciones específicas para el repositorio de usuarios.
    /// Hereda de IGenericInterface para operaciones CRUD básicas.
    /// </summary>
    public interface IUsuarioRepository : IGenericInterface<Usuario>
    {
        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario del usuario a buscar.</param>
        /// <returns>El usuario correspondiente al nombre de usuario.</returns>
        Usuario GetUsuarioByUsername(string username);

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El usuario a crear.</param>
        void CreateUsuario(Usuario usuario);

        /// <summary>
        /// Desactiva un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario a desactivar.</param>
        void DisableUsuario(Guid idUsuario);

        /// <summary>
        /// Actualiza los accesos de un usuario.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <param name="accesos">Lista de accesos a asignar al usuario.</param>
        void UpdateAccesos(Guid idUsuario, List<Acceso> accesos);

        /// <summary>
        /// Habilita un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario a habilitar.</param>
        void EnabledUsuario(Guid idUsuario);

        /// <summary>
        /// Obtiene las familias asociadas a un usuario por su identificador.
        /// </summary>
        /// <param name="usuarioId">El identificador del usuario.</param>
        /// <returns>Lista de familias asociadas al usuario.</returns>
        List<Familia> GetFamiliasByUsuarioId(Guid usuarioId);

        /// <summary>
        /// Obtiene una lista de usuarios en formato DTO.
        /// </summary>
        /// <returns>Lista de usuarios como objetos DTO.</returns>
        List<UsuarioDTO> GetUsuariosDTO();
    }
}
