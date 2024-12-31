using Services.Domain.Composite;
using Services.Logic;
using Services.Security.Domain.DTO;
using Services.Security.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Security.Facade
{
    /// <summary>
    /// Proporciona servicios relacionados con la gestión de usuarios, incluyendo la validación,
    /// creación y recuperación de usuarios.
    /// </summary>
    public class UserService
    {
        UserLogic userLogic = new UserLogic();

        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <param name="password">La contraseña del usuario.</param>
        /// <returns>True si las credenciales son válidas, de lo contrario false.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public bool ValidateUser(string username, string password)
        {
            try
            {
                return userLogic.ValidateUser(username, password);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <returns>Un objeto Usuario correspondiente al nombre de usuario.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public Usuario GetUsuarioByUsername(string username)
        {
            try
            {
                return userLogic.GetUsuarioByUsername(username);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que se desea crear.</param>
        /// <param name="plainPassword">La contraseña en texto plano del usuario.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public void CreateUser(Usuario usuario, string plainPassword)
        {
            try
            {
                userLogic.CreateUser(usuario, plainPassword);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Desactiva un usuario dado su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario que se desea desactivar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public void DisableUser(Guid idUsuario)
        {
            try
            {
                userLogic.DisableUser(idUsuario);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Habilita un usuario dado su ID.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario que se desea habilitar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public void EnabledUsuario(Guid idUsuario)
        {
            try
            {
                userLogic.EnabledUsuario(idUsuario);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Una lista de objetos Usuario.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public List<Usuario> GetAllUsuarios()
        {
            try
            {
                return userLogic.GetAllUsuarios();
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista de familias asociadas a un usuario dado su ID.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de objetos Familia.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si no hay roles asignados al usuario.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public List<Familia> GetFamiliasByUsuarioId(Guid usuarioId)
        {
            try
            {
                var list = userLogic.GetFamiliasByUsuarioId(usuarioId);

                if (list.Count == 0) throw new BusinessRuleException("No hay roles asignados al usuario");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina un usuario dado su ID.
        /// </summary>
        /// <param name="id">El ID del usuario que se desea eliminar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay un error de regla de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public void DeleteUser(Guid id)
        {
            try
            {
                userLogic.DeleteUser(id);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista de usuarios en formato DTO.
        /// </summary>
        /// <returns>Una lista de objetos UsuarioDTO.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si no hay usuarios registrados.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public List<UsuarioDTO> GetUsuariosDTO()
        {
            try
            {
                var list = userLogic.GetUsuariosDTO();

                if (list.Count == 0) throw new BusinessRuleException("No hay usuarios registrados");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
