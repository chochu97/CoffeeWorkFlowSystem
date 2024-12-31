using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.Performance
{
    /// <summary>
    /// Interfaz para el repositorio de tareas.
    /// Hereda de <see cref="IGenericInterface{TAREA}"/> para operaciones CRUD.
    /// </summary>
    public interface ITareaRepository : IGenericInterface<TAREA>
    {
        /// <summary>
        /// Reinicia las tareas del turno actual.
        /// </summary>
        void ResetearTareasTurno();

        /// <summary>
        /// Procesa el estado de una tarea específica.
        /// </summary>
        /// <param name="obj">El objeto <see cref="TAREA"/> que representa la tarea a procesar.</param>
        void ProcesarEstado(TAREA obj);

        /// <summary>
        /// Obtiene una lista de todas las tareas.
        /// </summary>
        /// <returns>Una lista de <see cref="TareaDTO"/> que representan todas las tareas.</returns>
        List<TareaDTO> GetTareas();
    }
}
