using Services.Domain;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Services.Facade
{
    /// <summary>
    /// Proporciona servicios de registro para la aplicación, permitiendo escribir logs y manejar excepciones.
    /// Funciona como un adaptador para la lógica de registro subyacente.
    /// </summary>
    public static class LoggerService // medio un adapter para guardar los logs
    {
        /// <summary>
        /// Escribe un log con un objeto Log y una excepción opcional.
        /// </summary>
        /// <param name="log">El objeto Log que se desea registrar.</param>
        /// <param name="ex">La excepción asociada al log, si existe.</param>
        public static void WriteLog(Log log, Exception ex = null)
        {
            LoggerLogic.WriteLog(log, ex);
        }

        /// <summary>
        /// Escribe un log con un mensaje y un nivel de traza. El nivel por defecto es INFO.
        /// </summary>
        /// <param name="message">El mensaje que se desea registrar.</param>
        /// <param name="level">El nivel de traza del log (por defecto es TraceLevel.Info).</param>
        public static void WriteLog(string message, TraceLevel level = TraceLevel.Info)
        {
            LoggerLogic.WriteLog(new Log(message, level));
        }

        /// <summary>
        /// Escribe un log para una excepción específica.
        /// </summary>
        /// <param name="ex">La excepción que se desea registrar.</param>
        public static void WriteException(Exception ex)
        {
            LoggerLogic.WriteLog(new Log(ex.Message, TraceLevel.Error), ex);
        }

        /// <summary>
        /// Obtiene una lista de logs registrados.
        /// </summary>
        /// <returns>Una lista de objetos Log.</returns>
        public static List<Log> GetLogs()
        {
            return LoggerLogic.GetLogs();
        }

        /// <summary>
        /// Obtiene la bitácora de logs.
        /// </summary>
        /// <returns>Una lista de objetos Log que representan la bitácora.</returns>
        public static List<Log> GetBitacora()
        {
            return LoggerLogic.GetBitacora();
        }
    }
}
