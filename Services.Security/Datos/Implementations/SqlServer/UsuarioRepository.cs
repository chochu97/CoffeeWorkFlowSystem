using Services.Datos.Implementations.SqlServer.Helpers;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Datos.Contracts;
using Services.Domain.Composite;
using Services.Security.Domain.DTO;


namespace Services.Datos.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con los usuarios en la base de datos.
    /// Proporciona métodos para obtener información de usuarios, incluyendo sus familias y patentes asociadas.
    /// Implementa la interfaz <see cref="IUsuarioRepository"/> para asegurar la consistencia en el acceso a datos.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FamiliaRepository _familiaRepository;

        /// <summary>
        /// Constructor de la clase <see cref="UsuarioRepository"/>.
        /// Inicializa el repositorio de familias, creando una nueva instancia de <see cref="FamiliaRepository"/>.
        /// </summary>
        public UsuarioRepository()
        {
            _familiaRepository = new FamiliaRepository();
        }


        /// <summary>
        /// Obtiene un usuario a partir de su nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario a buscar.</param>
        /// <returns>El objeto Usuario correspondiente, o null si no se encuentra.</returns>
        public Usuario GetUsuarioByUsername(string username)
        {
            Usuario usuario = null;

            // Primero, obtenemos los datos básicos del usuario
            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT ID_USUARIO, USERNAME, PASSWORD, ESTADO FROM USUARIO WHERE USERNAME = @USERNAME",
                CommandType.Text,
                new SqlParameter("@USERNAME", username)))
            {
                // Si se encuentra un registro, se crea un objeto Usuario
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = reader.GetGuid(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        Estado = reader.GetBoolean(3)
                    };
                }
            }

            // Si se encontró el usuario, se obtienen sus familias
            if (usuario != null)
            {
                // Obtener las familias del usuario
                List<Familia> familias = GetFamiliasByUsuarioId(usuario.IdUsuario);

                // Asignar las familias (con sus patentes) al usuario
                usuario.Accesos.AddRange(familias);
            }

            return usuario;
        }

        /// <summary>
        /// Obtiene las familias asociadas a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El identificador del usuario.</param>
        /// <returns>Lista de familias asociadas al usuario.</returns>
        public List<Familia> GetFamiliasByUsuarioId(Guid usuarioId)
        {
            List<Familia> familias = new List<Familia>();

            // Ejecutar la consulta para obtener las familias del usuario
            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT f.ID_FAMILIA, f.ROLE_NAME FROM FAMILIA f " +
                "INNER JOIN USUARIO_FAMILIA uf ON f.ID_FAMILIA = uf.ID_FAMILIA " +
                "WHERE uf.ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", usuarioId)))
            {
                // Leer cada familia encontrada
                while (reader.Read())
                {
                    var familia = new Familia
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1)
                    };

                    // Obtener las patentes asociadas a esta familia
                    familia.Accesos.AddRange(_familiaRepository.GetPatentesByFamiliaId(familia.Id));

                    // Añadir la familia a la lista
                    familias.Add(familia);
                }
            }

            return familias;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">El objeto Usuario que contiene la información del nuevo usuario.</param>
        public void CreateUsuario(Usuario usuario)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO USUARIO (ID_USUARIO, USERNAME, PASSWORD, ESTADO, DIGIT) VALUES (@ID_USUARIO, @USERNAME, @PASSWORD, @ESTADO, @DIGIT)",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", usuario.IdUsuario),
                new SqlParameter("@USERNAME", usuario.UserName),
                new SqlParameter("@PASSWORD", usuario.Password),
                new SqlParameter("@ESTADO", usuario.Estado),  // Asignar estado por defecto como Habilitado
                new SqlParameter("@DIGIT", usuario.Digit)
            );
        }

        /// <summary>
        /// Desactiva un usuario estableciendo su estado a inactivo en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario a desactivar.</param>
        public void DisableUsuario(Guid idUsuario)
        {
            SqlHelper.ExecuteNonQuery(
                "UPDATE USUARIO SET ESTADO = 0 WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", idUsuario)
            );
        }

        /// <summary>
        /// Activa un usuario estableciendo su estado a activo en la base de datos.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario a activar.</param>
        public void EnabledUsuario(Guid idUsuario)
        {
            SqlHelper.ExecuteNonQuery(
                "UPDATE USUARIO SET ESTADO = 1 WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", idUsuario)
            );
        }

        /// <summary>
        /// Actualiza los accesos de un usuario en la base de datos.
        /// Primero elimina los accesos existentes y luego inserta los nuevos accesos.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario cuyos accesos se van a actualizar.</param>
        /// <param name="accesos">Lista de objetos Acceso que representan los nuevos accesos del usuario.</param>
        public void UpdateAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            // Primero eliminamos los accesos existentes
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM USUARIO_PATENTE WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", idUsuario)
            );

            // Luego insertamos los nuevos accesos
            foreach (var acceso in accesos)
            {
                SqlHelper.ExecuteNonQuery(
                    "INSERT INTO USUARIO_PATENTE (ID_USUARIO, ID_PATENTE) VALUES (@ID_USUARIO, @ID_PATENTE)",
                    CommandType.Text,
                    new SqlParameter("@ID_USUARIO", idUsuario),
                    new SqlParameter("@ID_PATENTE", acceso.Id)
                );
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Usuario.</returns>
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string query = "SELECT ID_USUARIO, USERNAME, PASSWORD, ESTADO, DIGIT FROM USUARIO";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);

                    usuarios.Add(new Usuario
                    {
                        IdUsuario = reader.GetGuid(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        Estado = reader.GetBoolean(3),
                        Digit = reader.GetString(4)
                    });
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Agrega un nuevo usuario a la base de datos. (Método no implementado).
        /// </summary>
        /// <param name="obj">El objeto Usuario a agregar.</param>
        public void Add(Usuario obj) // not used
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos. (Método no implementado).
        /// </summary>
        /// <param name="obj">El objeto Usuario con los datos actualizados.</param>
        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina un usuario de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">El identificador del usuario a eliminar.</param>
        public void Remove(Guid id)
        {
            // Primero eliminamos las relaciones del usuario en la tabla USUARIO_FAMILIA
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM USUARIO_FAMILIA WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", id)
            );

            // Luego eliminamos el usuario de la tabla USUARIO
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM USUARIO WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", id)
            );
        }

        /// <summary>
        /// Obtiene un usuario por su identificador. (Método no implementado).
        /// </summary>
        /// <param name="id">El identificador del usuario a obtener.</param>
        /// <returns>El objeto Usuario correspondiente al identificador.</returns>
        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de usuarios en formato DTO (Data Transfer Object) desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos UsuarioDTO que contienen el ID, el nombre de usuario y el estado del usuario.</returns>
        public List<UsuarioDTO> GetUsuariosDTO()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            string query = "SELECT ID_USUARIO, USERNAME, ESTADO FROM USUARIO";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);

                    usuarios.Add(new UsuarioDTO
                    {
                        Id = reader.GetGuid(0), // Obtiene el ID del usuario
                        Username = reader.GetString(1), // Obtiene el nombre de usuario
                        Estado = reader.GetBoolean(2) ? "Habilitado" : "Deshabilitado" // Convierte el estado booleano a texto
                    });
                }
            }

            return usuarios;
        }
    }
    
}
