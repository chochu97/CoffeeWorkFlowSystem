using Services.Datos.Factory;
using Services.Datos.Contracts;
using Services.Domain.Composite;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Security.Domain.DTO;

namespace Services.Logic
{
    /// <summary>
    /// Clase que gestiona la lógica relacionada con los usuarios en el panel de administración.
    /// </summary>
    public class UserLogic 
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor de la clase <see cref="UserLogic"/>.
        /// Inicializa el repositorio de usuarios utilizando el patrón Factory.
        /// </summary>
        public UserLogic()
        {
            _usuarioRepository = FactoryDAO.GetUsuarioRepository();
        }

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <returns>True si las credenciales son válidas, de lo contrario, false.</returns>
        public bool ValidateUser(string username, string password)
        {
            // Obtener el usuario por su nombre de usuario
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                // Verificar si el usuario está deshabilitado
                if (usuario.Estado == false)
                {
                    // Usuario está deshabilitado
                    return false;
                }

                // Verificar la contraseña
                string hashedPassword = CryptographyService.HashMd5(password);
                return usuario.Password == hashedPassword;
            }
            return false;
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El objeto usuario a crear.</param>
        /// <param name="plainPassword">La contraseña en texto plano del usuario.</param>
        public void CreateUser(Usuario usuario, string plainPassword)
        {
            usuario.Password = CryptographyService.HashMd5(plainPassword);

            string concatenatedData = usuario.UserName + usuario.Password + usuario.Estado;

            usuario.Digit = CryptographyService.HashMd5(concatenatedData);

            _usuarioRepository.CreateUsuario(usuario);
        }

        /// <summary>
        /// Deshabilita un usuario dado su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario a deshabilitar.</param>
        public void DisableUser(Guid idUsuario)
        {
            _usuarioRepository.DisableUsuario(idUsuario);
        }

        /// <summary>
        /// Habilita un usuario dado su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario a habilitar.</param>
        public void EnabledUsuario(Guid idUsuario)
        {
            _usuarioRepository.EnabledUsuario(idUsuario);
        }

        /// <summary>
        /// Actualiza los accesos de un usuario dado su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="accesos">La lista de accesos a actualizar.</param>
        public void UpdateUserAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            _usuarioRepository.UpdateAccesos(idUsuario, accesos);
        }

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Una lista de usuarios.</returns>
        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <returns>El objeto Usuario correspondiente.</returns>
        public Usuario GetUsuarioByUsername(string username)
        {
            return _usuarioRepository.GetUsuarioByUsername(username);
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario dado su ID.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de familias asociadas al usuario.</returns>
        public List<Familia> GetFamiliasByUsuarioId(Guid usuarioId)
        {
            return _usuarioRepository.GetFamiliasByUsuarioId(usuarioId);
        }

        /// <summary>
        /// Elimina un usuario dado su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        public void DeleteUser(Guid id)
        {
            _usuarioRepository.Remove(id);
        }

        /// <summary>
        /// Obtiene una lista de usuarios en formato DTO.
        /// </summary>
        /// <returns>Una lista de objetos UsuarioDTO.</returns>
        public List<UsuarioDTO> GetUsuariosDTO()
        {
            return _usuarioRepository.GetUsuariosDTO();
        }

    }
}

