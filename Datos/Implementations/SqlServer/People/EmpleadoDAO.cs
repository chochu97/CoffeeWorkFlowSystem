using Datos.Contracts.People;
using Datos.IDGenerator;
using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.People
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad EMPLEADO.
    /// </summary>
    public class EmpleadoDAO : IEmpleadoRepository
    {
        #region singleton
        private static readonly EmpleadoDAO instance = new EmpleadoDAO();

        /// <summary>
        /// Obtiene la instancia única de EmpleadoDAO.
        /// </summary>
        public static EmpleadoDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo empleado a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto EMPLEADO a agregar.</param>
        public void Agregar(EMPLEADO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                context.EMPLEADO.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina un empleado de la base de datos.
        /// </summary>
        /// <param name="id">El ID del empleado a eliminar.</param>
        public void DeleteEmp(int id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var emp = context.EMPLEADO.SingleOrDefault(e => e.COD_EMPLEADO == id);
                if (emp != null)
                {
                    context.EMPLEADO.Remove(emp);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los empleados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos EMPLEADO.</returns>
        public List<EMPLEADO> GetAll()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var empleados = context.EMPLEADO.OrderBy(e => e.NOMBRE).ToList();
                return empleados;
            }
        }

        /// <summary>
        /// Modifica un empleado existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto EMPLEADO con los nuevos valores.</param>
        public void Modificar(EMPLEADO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var emp = context.EMPLEADO.SingleOrDefault(e => e.COD_EMPLEADO == obj.COD_EMPLEADO);

                if (emp != null)
                {
                    context.Entry(emp).CurrentValues.SetValues(obj);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El empleado especificado a modificar no existe");
                }
            }
        }

        /// <summary>
        /// Obtiene un empleado por su ID.
        /// </summary>
        /// <param name="empId">El ID del empleado a obtener.</param>
        /// <returns>El objeto EMPLEADO correspondiente.</returns>
        public EMPLEADO GetEmpById(int empId)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var emp = context.EMPLEADO.SingleOrDefault(e => e.COD_EMPLEADO == empId);
                return emp;
            }
        }

        /// <summary>
        /// Obtiene una lista de empleados que coinciden con el nombre especificado.
        /// </summary>
        /// <param name="name">El nombre o parte del nombre del empleado a buscar.</param>
        /// <returns>Una lista de objetos EmpleadoDTO que representan los empleados encontrados.</returns>
        public List<EmpleadoDTO> GetEmpByName(string name)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var empleados = context.EMPLEADO
                    .Where(e => e.NOMBRE.Contains(name))
                    .Select(e => new EmpleadoDTO
                    {
                        Codigo = e.COD_EMPLEADO,
                        Nombre = e.NOMBRE + " " + e.APELLIDO,
                        Rol = e.ROL,
                        Turno = e.TURNO,
                        Telefono = e.TELEFONO,
                        DNI = e.DNI,
                        Estado = e.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderBy(e => e.Nombre)
                    .ToList();

                return empleados;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los empleados en formato DTO.
        /// </summary>
        /// <returns>Una lista de objetos EmpleadoDTO que representan todos los empleados.</returns>
        public List<EmpleadoDTO> GetEmpleadosDTO()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var empleados = context.EMPLEADO
                    .Select(e => new EmpleadoDTO
                    {
                        Codigo = e.COD_EMPLEADO,
                        Nombre = e.NOMBRE + " " + e.APELLIDO,
                        Rol = e.ROL,
                        Turno = e.TURNO,
                        Telefono = e.TELEFONO,
                        DNI = e.DNI,
                        Estado = e.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderBy(e => e.Nombre)
                    .ToList();

                return empleados;
            }
        }

        // Métodos no utilizados
        /// <summary>
        /// Elimina un empleado por su ID. (No implementado)
        /// </summary>
        /// <param name="id">El ID del empleado a eliminar.</param>
        public void Eliminar(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un empleado por su ID. (No implementado)
        /// </summary>
        /// <param name="id">El ID del empleado a obtener.</param>
        /// <returns>El objeto EMPLEADO correspondiente.</returns>
        public EMPLEADO GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
