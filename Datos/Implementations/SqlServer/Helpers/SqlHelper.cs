using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.Helpers
{
    internal static class SqlHelper
    {
        readonly static string conString;

        static SqlHelper()
        {
            conString = ConfigurationManager.ConnectionStrings["EjemploDB"].ConnectionString;
        }
        /// <summary>
        /// Ejecuta un comando SQL que no devuelve filas (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="commandText">El texto del comando SQL.</param>
        /// <param name="commandType">El tipo de comando (StoredProcedure, Text, etc.).</param>
        /// <param name="parameters">Parámetros opcionales para el comando SQL.</param>
        /// <returns>El número de filas afectadas.</returns>
        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);

            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Verifica y reemplaza los valores nulos de los parámetros por DBNull.Value.
        /// </summary>
        /// <param name="parameters">Los parámetros a verificar.</param>
        private static void CheckNullables(SqlParameter[] parameters)
        {
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// Ejecuta un comando SQL y devuelve un único valor.
        /// </summary>
        /// <param name="commandText">El texto del comando SQL.</param>
        /// <param name="commandType">El tipo de comando (StoredProcedure, Text, etc.).</param>
        /// <param name="parameters">Parámetros opcionales para el comando SQL.</param>
        /// <returns>El valor devuelto por el comando SQL.</returns>
        public static Object ExecuteScalar(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Ejecuta un comando SQL y devuelve un SqlDataReader para leer los resultados.
        /// </summary>
        /// <param name="commandText">El texto del comando SQL.</param>
        /// <param name="commandType">El tipo de comando (StoredProcedure, Text, etc.).</param>
        /// <param name="parameters">Parámetros opcionales para el comando SQL.</param>
        /// <returns>Un SqlDataReader para leer los resultados.</returns>
        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(conString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // Cuando se usa CommandBehavior.CloseConnection, la conexión se cerrará
                // cuando el IDataReader se cierre.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

    }
}
