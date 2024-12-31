using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.People
{
    /// <summary>
    /// Interfaz para el repositorio de empleados.
    /// Hereda de <see cref="IGenericInterface{EMPLEADO}"/> para operaciones CRUD.
    /// </summary>
    public interface IEmpleadoRepository : IGenericInterface<EMPLEADO>
    {
        /// <summary>
        /// Obtiene una lista de empleados que coinciden con el nombre especificado.
        /// </summary>
        /// <param name="name">El nombre del empleado a buscar.</param>
        /// <returns>Una lista de <see cref="EmpleadoDTO"/> que representan los empleados encontrados.</returns>
        List<EmpleadoDTO> GetEmpByName(string name);

        /// <summary>
        /// Obtiene un empleado específico por su identificador.
        /// </summary>
        /// <param name="empId">El identificador del empleado a buscar.</param>
        /// <returns>Un objeto <see cref="EMPLEADO"/> que representa el empleado encontrado, o null si no se encuentra.</returns>
        EMPLEADO GetEmpById(int empId);

        /// <summary>
        /// Obtiene una lista de todos los empleados en formato DTO.
        /// </summary>
        /// <returns>Una lista de <see cref="EmpleadoDTO"/> que representan todos los empleados.</returns>
        List<EmpleadoDTO> GetEmpleadosDTO();

        /// <summary>
        /// Elimina un empleado por su identificador.
        /// </summary>
        /// <param name="id">El identificador del empleado a eliminar.</param>
        void DeleteEmp(int id);
    }
}
