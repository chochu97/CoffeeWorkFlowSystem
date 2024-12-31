using Business.Contracts;
using Datos.Contracts.People;
using Datos.Factory;
using Domain;
using Domain.DTO;
using Services.Security.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Business.People
{
    /// <summary>
    /// Lógica de negocio para la gestión de empleados.
    /// Implementa la interfaz <see cref="IGenericInterface{EMPLEADO}"/>.
    /// </summary>
    public class EmpleadoLogic : IGenericInterface<EMPLEADO>
    {
        /// <summary>
        /// Instancia única de la clase <see cref="EmpleadoLogic"/>.
        /// </summary>
        private static EmpleadoLogic instance = null;

        /// <summary>
        /// Objeto utilizado para asegurar la sincronización en el patrón Singleton.
        /// </summary>
        private static readonly object _lock = new object();


        /// <summary>
        /// Repositorio para interactuar con los datos de los empleados.
        /// </summary>
        private readonly IEmpleadoRepository _repository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EmpleadoLogic"/>.
        /// </summary>
        public EmpleadoLogic()
        {
            _repository = FactoryDAO.GetEmpleadoRepository();
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="EmpleadoLogic"/> (patrón Singleton).
        /// </summary>
        /// <returns>La instancia única de <see cref="EmpleadoLogic"/>.</returns>
        public static EmpleadoLogic GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new EmpleadoLogic();
                }
                return instance;
            }
        }

        /// <summary>
        /// Agrega un nuevo empleado.
        /// </summary>
        /// <param name="obj">El empleado a agregar.</param>
        public void Add(EMPLEADO obj)
        {
            try
            {
                if (obj.COD_EMPLEADO == 0 || obj.NOMBRE == null || obj.APELLIDO == null || obj.DNI == 0 || obj.TELEFONO == null || obj.TURNO == null || obj.ROL == null)
                {
                    throw new BusinessRuleException("Complete todos los campos.");
                }

                _repository.Agregar(obj);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todos los empleados registrados.
        /// </summary>
        /// <returns>Una lista de todos los empleados.</returns>
        public List<EMPLEADO> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza un empleado existente.
        /// </summary>
        /// <param name="obj">El empleado a actualizar.</param>
        public void Update(EMPLEADO obj)
        {
            try
            {
                if (obj.COD_EMPLEADO == 0 || obj.NOMBRE == null || obj.APELLIDO == null || obj.DNI == 0 || obj.TELEFONO == null || obj.TURNO == null || obj.ROL == null)
                {
                    throw new BusinessRuleException("Complete todos los campos.");
                }

                _repository.Modificar(obj);
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina un empleado por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado a eliminar.</param>
        public void Delete(int id)
        {
            try
            {
                _repository.DeleteEmp(id);
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un empleado por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado a obtener.</param>
        /// <returns>El empleado correspondiente al identificador, o lanza una excepción si no se encuentra.</returns>
        public EMPLEADO GetOne(int id)
        {
            try
            {
                var emp = _repository.GetEmpById(id);

                if (emp == null) throw new BusinessRuleException("El empleado solicitado no existe.");

                return emp;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrio un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DTOs

        /// <summary>
        /// Obtiene una lista de todos los empleados en formato DTO.
        /// </summary>
        /// <returns>Una lista de empleados registrados.</returns>
        public List<EmpleadoDTO> GetEmpleados()
        {
            try
            {
                var list = _repository.GetEmpleadosDTO();

                if (list.Count == 0) throw new BusinessRuleException("No hay empleados registrados.");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista de empleados que coinciden con el nombre proporcionado.
        /// </summary>
        /// <param name="name">El nombre del empleado a buscar.</param>
        /// <returns>Una lista de empleados que coinciden con el nombre proporcionado.</returns>
        public List<EmpleadoDTO> GetByName(string name)
        {
            try
            {
                var list = _repository.GetEmpByName(name);

                if (list.Count == 0) throw new BusinessRuleException("No hay empleados registrados.");

                return list;
            }
            catch (BusinessRuleException ex)
            {
                throw ex;
            }
            catch (SqlException)
            {
                throw new DataAccessException("Ocurrió un error al acceder a la base de datos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método no implementado para eliminar un empleado por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado a eliminar.</param>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método no implementado para obtener un empleado por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del empleado a obtener.</param>
        /// <returns>El empleado correspondiente al identificador.</returns>
        public EMPLEADO GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
