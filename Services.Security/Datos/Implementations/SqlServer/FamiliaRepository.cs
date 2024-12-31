using Services.Datos.Implementations.SqlServer.Helpers;
using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Datos.Implementations.SqlServer
{
    /// <summary>
    /// Repositorio para gestionar las familias y sus permisos (patentes) en la base de datos.
    /// </summary>
    public class FamiliaRepository
    {
        /// <summary>
        /// Obtiene una lista de patentes asociadas a una familia específica.
        /// </summary>
        /// <param name="familiaId">Identificador de la familia.</param>
        /// <returns>Lista de patentes asociadas a la familia.</returns>
        public List<Patente> GetPatentesByFamiliaId(Guid familiaId)
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT p.ID_PATENTE, p.PERMISO_NAME, p.TIPO_ACCESO, p.DATAKEY FROM PATENTE p " +
                "INNER JOIN FAMILIA_PATENTE fp ON p.ID_PATENTE = fp.ID_PATENTE " +
                "WHERE fp.ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", familiaId)))
            {
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1),
                        TipoAcceso = (TipoAcceso)reader.GetInt32(2),
                        DataKey = reader.GetString(3)
                    });
                }
            }

            return patentes;
        }

        /// <summary>
        /// Agrega patentes a una familia específica.
        /// </summary>
        /// <param name="familia">La familia a la que se agregarán las patentes.</param>
        /// <param name="patentes">Lista de patentes a agregar.</param>
        public void AddPatentesToFamilia(Familia familia, List<Patente> patentes)
        {
            foreach (var patente in patentes)
            {
                var existePatente = SqlHelper.ExecuteScalar(
                    "SELECT COUNT(1) FROM FAMILIA_PATENTE WHERE ID_FAMILIA = @ID_FAMILIA AND ID_PATENTE = @ID_PATENTE",
                    CommandType.Text,
                    new SqlParameter("@ID_FAMILIA", familia.Id),
                    new SqlParameter("@ID_PATENTE", patente.Id)
                );

                if (Convert.ToInt32(existePatente) == 0)
                {
                    SqlHelper.ExecuteNonQuery(
                        "INSERT INTO FAMILIA_PATENTE (ID_FAMILIA, ID_PATENTE) VALUES (@ID_FAMILIA, @ID_PATENTE)",
                        CommandType.Text,
                        new SqlParameter("@ID_FAMILIA", familia.Id),
                        new SqlParameter("@ID_PATENTE", patente.Id)
                    );

                    familia.Add(patente);
                }
            }
        }

        /// <summary>
        /// Guarda una nueva familia en la base de datos.
        /// </summary>
        /// <param name="familia">La familia a guardar.</param>
        public void SaveFamilia(Familia familia)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO FAMILIA (ID_FAMILIA, ROLE_NAME) VALUES (@ID_FAMILIA, @ROLE_NAME)",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", familia.Id),
                new SqlParameter("@ROLE_NAME", familia.Nombre)
            );

            foreach (var patente in familia.Accesos.OfType<Patente>())
            {
                SqlHelper.ExecuteNonQuery(
                    "INSERT INTO FAMILIA_PATENTE (ID_FAMILIA, ID_PATENTE) VALUES (@ID_FAMILIA, @ID_PATENTE)",
                    CommandType.Text,
                    new SqlParameter("@ID_FAMILIA", familia.Id),
                    new SqlParameter("@ID_PATENTE", patente.Id)
                );
            }
        }

        /// <summary>
        /// Crea una nueva patente en la base de datos.
        /// </summary>
        /// <param name="patente">La patente a crear.</param>
        public void CreatePatente(Patente patente)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO PATENTE (ID_PATENTE, PERMISO_NAME, TIPO_ACCESO, DATAKEY) VALUES (@ID_PATENTE, @PERMISO_NAME, @TIPO_ACCESO, @DATAKEY)",
                CommandType.Text,
                new SqlParameter("@ID_PATENTE", patente.Id),
                new SqlParameter("@PERMISO_NAME", patente.Nombre),
                new SqlParameter("@DATAKEY", patente.DataKey),
                new SqlParameter("@TIPO_ACCESO", (int)patente.TipoAcceso) // Convertimos el enum a entero
            );
        }
        /// <summary>
        /// Actualiza la información de una familia en la base de datos.
        /// </summary>
        /// <param name="familia">La familia a actualizar.</param>
        public void UpdateFamilia(Familia familia)
        {
            // Actualizar el nombre de la familia
            SqlHelper.ExecuteNonQuery(
                "UPDATE FAMILIA SET ROLE_NAME = @ROLE_NAME WHERE ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", familia.Id),
                new SqlParameter("@ROLE_NAME", familia.Nombre)
            );

            // Eliminar patentes actuales de la familia en Familia_Patente
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM FAMILIA_PATENTE WHERE ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", familia.Id)
            );

            // Reinsertar las patentes actualizadas
            foreach (var patente in familia.Accesos.OfType<Patente>())
            {
                SqlHelper.ExecuteNonQuery(
                    "INSERT INTO FAMILIA_PATENTE (ID_FAMILIA, ID_PATENTE) VALUES (@ID_FAMILIA, @ID_PATENTE)",
                    CommandType.Text,
                    new SqlParameter("@ID_FAMILIA", familia.Id),
                    new SqlParameter("@ID_PATENTE", patente.Id)
                );
            }
        }

        /// <summary>
        /// Guarda una relación entre un usuario y una familia en la base de datos.
        /// </summary>
        /// <param name="IdUsuario">Identificador del usuario.</param>
        /// <param name="IdFamilia">Identificador de la familia.</param>
        public void SaveUsuarioFamilia(Guid IdUsuario, Guid IdFamilia)
        {
            SqlHelper.ExecuteNonQuery(
                "INSERT INTO USUARIO_FAMILIA (ID_USUARIO, ID_FAMILIA) VALUES (@ID_USUARIO, @ID_FAMILIA)",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", IdUsuario),
                new SqlParameter("@ID_FAMILIA", IdFamilia)
            );
        }

        /// <summary>
        /// Actualiza las relaciones entre un usuario y sus familias en la base de datos.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <param name="familias">Lista de familias a las que el usuario debe estar asociado.</param>
        public void UpdateUsuarioFamilia(Guid usuarioId, List<Familia> familias)
        {
            // Eliminar relaciones actuales
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM USUARIO_FAMILIA WHERE ID_USUARIO = @ID_USUARIO",
                CommandType.Text,
                new SqlParameter("@ID_USUARIO", usuarioId)
            );

            // Reinsertar relaciones actualizadas
            foreach (var familia in familias)
            {
                SaveUsuarioFamilia(usuarioId, familia.Id);
            }
        }
        /// <summary>
        /// Obtiene todas las familias de la base de datos.
        /// </summary>
        /// <returns>Lista de familias.</returns>
        public List<Familia> GetAll()
        {
            List<Familia> familias = new List<Familia>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT ID_FAMILIA, ROLE_NAME FROM FAMILIA",
                CommandType.Text))
            {
                while (reader.Read())
                {
                    familias.Add(new Familia
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }

            return familias;
        }

        /// <summary>
        /// Obtiene todas las patentes de la base de datos.
        /// </summary>
        /// <returns>Lista de patentes.</returns>
        public List<Patente> GetAllPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(
                "SELECT ID_PATENTE, PERMISO_NAME, DATAKEY, TIPO_ACCESO FROM PATENTE",
                CommandType.Text))
            {
                while (reader.Read())
                {
                    patentes.Add(new Patente
                    {
                        Id = reader.GetGuid(0),
                        Nombre = reader.GetString(1),
                        DataKey = reader.GetString(2),
                        TipoAcceso = (TipoAcceso)reader.GetInt32(3)
                    });
                }
            }

            return patentes;
        }

        /// <summary>
        /// Elimina una patente de la base de datos y sus relaciones en la tabla FAMILIA_PATENTE.
        /// </summary>
        /// <param name="id">Identificador de la patente a eliminar.</param>
        public void DeletePatente(Guid id)
        {
            // Eliminar las relaciones de la patente con las familias
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM FAMILIA_PATENTE WHERE ID_PATENTE = @ID_PATENTE",
                CommandType.Text,
                new SqlParameter("@ID_PATENTE", id)
            );

            // Eliminar la patente
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM PATENTE WHERE ID_PATENTE = @ID_PATENTE",
                CommandType.Text,
                new SqlParameter("@ID_PATENTE", id)
            );
        }

        /// <summary>
        /// Elimina una familia de la base de datos y sus relaciones en las tablas FAMILIA_PATENTE y USUARIO_FAMILIA.
        /// </summary>
        /// <param name="id">Identificador de la familia a eliminar.</param>
        public void DeleteFamilia(Guid id)
        {
            // Eliminar las relaciones de la familia con las patentes
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM FAMILIA_PATENTE WHERE ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", id)
            );

            // Eliminar las relaciones de la familia con los usuarios
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM USUARIO_FAMILIA WHERE ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", id)
            );

            // Eliminar la familia
            SqlHelper.ExecuteNonQuery(
                "DELETE FROM FAMILIA WHERE ID_FAMILIA = @ID_FAMILIA",
                CommandType.Text,
                new SqlParameter("@ID_FAMILIA", id)
            );
        }
    }
    
}
