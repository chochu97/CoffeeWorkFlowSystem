
using Services.Datos.Factory;
using Services.Datos.Implementations.Texto;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    /// <summary>
    /// Clase que gestiona la lógica de registro de logs en la aplicación.
    /// </summary>
    public static class LoggerLogic
    {
        // Constructor estático, se puede usar para inicializar recursos estáticos si es necesario
        static LoggerLogic()
        {
            // Inicialización si es necesaria
        }

        /// <summary>
        /// Escribe un log en el repositorio de logs.
        /// </summary>
        /// <param name="log">El objeto log que se va a registrar.</param>
        /// <param name="ex">Una excepción opcional asociada al log.</param>
        public static void WriteLog(Log log, Exception ex = null)
        {
            LoggerRepository.WriteLog(log, ex);
        }

        /// <summary>
        /// Obtiene todos los logs registrados.
        /// </summary>
        /// <returns>Una lista de logs.</returns>
        public static List<Log> GetLogs()
        {
            return LoggerRepository.GetLogs();
        }

        /// <summary>
        /// Obtiene la bitácora de logs.
        /// </summary>
        /// <returns>Una lista de logs de la bitácora.</returns>
        public static List<Log> GetBitacora()
        {
            return LoggerRepository.GetBitacora();
        }

    }
}
