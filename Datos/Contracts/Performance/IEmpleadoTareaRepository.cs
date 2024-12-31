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
    /// Interfaz para el repositorio de tareas de empleados.
    /// Hereda de <see cref="IGenericInterface{DETALLE_TAREA}"/> para operaciones CRUD.
    /// </summary>
    public interface IEmpleadoTareaRepository : IGenericInterface<DETALLE_TAREA>
    {
        /// <summary>
        /// Asigna una tarea a un empleado.
        /// </summary>
        /// <param name="detalle">El detalle de la tarea a realizar.</param>
        void HacerTarea(DETALLE_TAREA detalle);

        /// <summary>
        /// Finaliza una tarea específica por su identificador.
        /// </summary>
        /// <param name="idTarea">El identificador de la tarea a finalizar.</param>
        void FinalizarTarea(Guid idTarea);

        /// <summary>
        /// Obtiene una lista de todos los detalles de tareas.
        /// </summary>
        /// <returns>Una lista de <see cref="DetalleTareaDTO"/> que representan todos los detalles de tareas.</returns>
        List<DetalleTareaDTO> GetDetalles();

        /// <summary>
        /// Obtiene una lista de detalles de tareas asignadas a un empleado específico.
        /// </summary>
        /// <param name="id">El identificador del empleado.</param>
        /// <returns>Una lista de <see cref="DetalleTareaDTO"/> que representan los detalles de tareas del empleado.</returns>
        List<DetalleTareaDTO> GetDetallesPorEmp(int id);

        /// <summary>
        /// Obtiene una lista de bonos del mes para los empleados.
        /// </summary>
        /// <returns>Una lista de <see cref="EmpleadoDesempDTO"/> que representan los bonos del mes.</returns>
        List<EmpleadoDesempDTO> ObtenerBonosDelMes();
    }
}
