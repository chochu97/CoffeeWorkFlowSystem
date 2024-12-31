using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Services.Datos.Implementations.Texto
{
    /// <summary>
    /// Repositorio para el registro de logs de errores y bitácoras de información.
    /// </summary>
    internal static class LoggerRepository
    {
        // Ruta para el log de errores, obtenida de la configuración
        private static string PathLogError => ConfigurationManager.AppSettings["PathLogError"];

        // Ruta para la bitácora de información, obtenida de la configuración
        private static string PathLogInfo => ConfigurationManager.AppSettings["PathLogInfo"];

        /// <summary>
        /// Escribe un log en el archivo correspondiente según el nivel de traza.
        /// </summary>
        /// <param name="log">El objeto de log que contiene la información a registrar.</param>
        /// <param name="ex">Una excepción opcional relacionada con el log.</param>
        public static void WriteLog(Log log, Exception ex = null)
        {
            // Dependiendo del nivel de traza, se escribe en el archivo correspondiente
            switch (log.TraceLevel)
            {
                case TraceLevel.Error:
                    // Formatear el mensaje de error y agregar la traza de la excepción
                    string formatMessage = FormatMessage(log);
                    //formatMessage += ex?.StackTrace; // Agrega la traza de la excepción si existe

                    // Escribir el mensaje en el archivo de log de errores
                    WriteToFile(PathLogError, formatMessage);
                    break;

                case TraceLevel.Warning:
                case TraceLevel.Verbose:
                case TraceLevel.Info: // Bitácora
                    // Formatear el mensaje de log
                    string format = FormatMessage(log);

                    // Escribir el mensaje en el archivo de bitácora de información
                    WriteToFile(PathLogInfo, format);
                    break;
            }
        }

        /// <summary>
        /// Formatea el log recibido para crear una cadena ordenada para un archivo .txt.
        /// </summary>
        /// <param name="log">El objeto de log que contiene la información a formatear.</param>
        /// <returns>Una cadena formateada que representa el log.</returns>
        private static string FormatMessage(Log log)
        {
            string truncatedMessage = TruncateMessage(log.Message);

            return $"{log.Date.ToString("dd/MM/yyyy HH:mm:ss")} [{log.TraceLevel}] : {truncatedMessage}";
        }

        private static string TruncateMessage(string message)
        {
            // Buscar el primer doble espacio (indicado como "  ")
            int doubleSpaceIndex = message.IndexOf("  ");
            if (doubleSpaceIndex != -1)
            {
                // Truncamos el mensaje hasta el primer doble espacio
                return message.Substring(0, doubleSpaceIndex).Trim();
            }
            return message; // Si no encontramos el doble espacio, devolvemos la línea completa
        }

        /// <summary>
        /// Escribe un mensaje en un archivo, creando un nuevo archivo con la fecha actual si es necesario.
        /// </summary>
        /// <param name="path">La ruta del archivo donde se escribirá el mensaje.</param>
        /// <param name="message">El mensaje que se escribirá en el archivo.</param>
        private static void WriteToFile(string path, string message)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fullPathCombined = Path.Combine(baseDirectory, path);

            string directoryPath = Path.GetDirectoryName(path); 
            string fileName = Path.GetFileNameWithoutExtension(path); 
            string fileExtension = Path.GetExtension(path); 

            string newFileName = $"{DateTime.Now:dd-MM-yyyy}_{fileName}{fileExtension}"; // fecha al archivito
            string fullPath = Path.Combine(directoryPath, newFileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (StreamWriter str = new StreamWriter(fullPath, true)) // true para agregar al archivo
            {
                str.WriteLine(message); // Escribe el mensaje en el archivo
            }
        }

        /// <summary>
        /// Obtiene una lista de logs de error desde el archivo de registro.
        /// </summary>
        /// <returns>Una lista de objetos Log que representan los logs de error.</returns>
        public static List<Log> GetLogs()
        {
            return ReadLogsFromFile(PathLogError, TraceLevel.Error);
        }

        /// <summary>
        /// Obtiene una lista de logs de información desde el archivo de registro.
        /// </summary>
        /// <returns>Una lista de objetos Log que representan los logs de información.</returns>
        public static List<Log> GetBitacora()
        {
            return ReadLogsFromFile(PathLogInfo, TraceLevel.Info);
        }


        /// <summary>
        /// Lee los logs desde un archivo y devuelve una lista de objetos Log.
        /// </summary>
        /// <param name="path">La ruta del archivo desde el cual se leerán los logs.</param>
        /// <param name="level">El nivel de traza que se filtrará al leer los logs.</param>
        /// <returns>Una lista de objetos Log que representan los logs leídos del archivo.</returns>
        private static List<Log> ReadLogsFromFile(string path, TraceLevel level)
        {
            var logs = new List<Log>();

            string directoryPath = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExtension = Path.GetExtension(path);

            if (!Directory.Exists(directoryPath)) return logs;

            var files = Directory.GetFiles(directoryPath, $"*{fileName}{fileExtension}");

            foreach (var file in files)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var log = ParseLogLine(line, level);
                        if (log != null)
                        {
                            logs.Add(log);
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Analiza una línea de log y devuelve un objeto Log si la línea es válida.
        /// </summary>
        /// <param name="line">La línea de log que se va a analizar.</param>
        /// <param name="level">El nivel de traza que se utilizará para el log.</param>
        /// <returns>Un objeto Log que representa la línea analizada, o null si la línea no es válida.</returns>
        private static Log ParseLogLine(string line, TraceLevel level)
        {
            try
            {
                int dateEnd = line.IndexOf(' ');
                if (dateEnd == -1) throw new FormatException("Fecha no encontrada en la línea.");

                // Extraer la fecha
                string dateString = line.Substring(0, dateEnd);
                DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);

                // Extraer el mensaje después del primer espacio y corchetes (después del nivel de log)
                int messageStart = line.IndexOf("] :") + 3; // Ignorar "]:"
                if (messageStart == -1 || messageStart >= line.Length)
                    throw new FormatException("Mensaje no encontrado después del nivel de log.");

                string message = line.Substring(messageStart).Trim();

                // Crear y devolver el objeto Log
                return new Log(message, level, date);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
