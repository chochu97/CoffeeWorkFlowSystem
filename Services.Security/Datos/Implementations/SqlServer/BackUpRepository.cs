using Services.Datos.Implementations.SqlServer.Helpers;
using Services.Security.Datos.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Datos.Implementations.SqlServer
{
    /// <summary>
    /// Implementación del repositorio para realizar copias de seguridad y restauraciones de bases de datos.
    /// </summary>
    public class BackUpRepository : IBackUpRepository
    {
        /// <summary>
        /// Realiza una copia de seguridad de la base de datos especificada en la ruta de respaldo proporcionada.
        /// </summary>
        /// <param name="dataBaseName">Nombre de la base de datos a respaldar.</param>
        /// <param name="backUpPath">Ruta donde se almacenará la copia de seguridad.</param>
        public void BackUpDataBase(string dataBaseName, string backUpPath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fullBackUpPath = Path.Combine(baseDirectory, backUpPath);

            string query1 = $@"CHECKPOINT; BACKUP DATABASE [{dataBaseName}] TO DISK = @backUpPath WITH FORMAT, INIT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@backUpPath", fullBackUpPath)
            };

            SqlHelper.ExecuteNonQuery(query1, CommandType.Text, parameters);
        }

        /// <summary>
        /// Restaura la base de datos especificada desde la ruta de respaldo proporcionada.
        /// </summary>
        /// <param name="dataBaseName">Nombre de la base de datos a restaurar.</param>
        /// <param name="backUpPath">Ruta desde donde se restaurará la base de datos.</param>
        public void RestoreDataBase(string dataBaseName, string backUpPath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fullBackUpPath = Path.Combine(baseDirectory, backUpPath);

            string query = $@"ALTER DATABASE [{dataBaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            RESTORE DATABASE [{dataBaseName}] FROM DISK = @backUpPath WITH REPLACE;
                            ALTER DATABASE [{dataBaseName}] SET MULTI_USER;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@backUpPath", fullBackUpPath)
            };

            // Cambia la cadena de conexión para conectarse a la base de datos master.
            string masterConnString = SqlHelper.conString.Replace($"Initial Catalog={dataBaseName};", "Initial Catalog=master;");

            try
            {
                using (SqlConnection conn = new SqlConnection(masterConnString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Error realizando el restore: {ex.Message}", ex);
            }
        }
    }
}
