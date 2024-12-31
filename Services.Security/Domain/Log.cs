using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Services.Domain
{
    /// <summary>
    /// Clase que representa un registro de log o bitácora.
    /// Dependiendo del nivel de traza (TraceLevel), puede ser utilizado para diferentes propósitos de registro.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Mensaje que describe el evento o la información que se está registrando.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Nivel de traza que indica la severidad o importancia del log.
        /// </summary>
        public TraceLevel TraceLevel { get; set; }

        /// <summary>
        /// Fecha y hora en que se registró el log.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Constructor para crear una nueva instancia de Log.
        /// </summary>
        /// <param name="message">El mensaje que se desea registrar.</param>
        /// <param name="traceLevel">El nivel de traza del log (por defecto es Info).</param>
        /// <param name="date">La fecha y hora del registro (por defecto es la fecha y hora actual).</param>
        public Log(string message, TraceLevel traceLevel = TraceLevel.Info, DateTime date = default)
        {
            Message = message;
            TraceLevel = traceLevel;
            Date = (date == default) ? DateTime.Now : date;
        }

    }
}
