using Services.Domain.Composite;
using Services.Logic;
using Services.Security.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    /// <summary>
    /// Proporciona servicios para gestionar familias y sus patentes.
    /// </summary>
    public static class FamiliaService
    {
        private static readonly FamiliaLogic _familiaLogic = new FamiliaLogic();

        /// <summary>
        /// Crea una nueva familia con las patentes especificadas.
        /// </summary>
        /// <param name="nombreFamilia">El nombre de la familia a crear.</param>
        /// <param name="patentes">La lista de patentes asociadas a la familia.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void CrearFamiliaConPatentes(string nombreFamilia, List<Patente> patentes)
        {
            try
            {
                var familia = new Familia { Nombre = nombreFamilia };
                foreach (var patente in patentes)
                {
                    familia.Add(patente);
                }

                _familiaLogic.CrearFamiliaConPatentes(familia);
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
        /// Crea una nueva patente.
        /// </summary>
        /// <param name="patente">La patente a crear.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void CreatePatente(Patente patente)
        {
            try
            {
                _familiaLogic.CreatePatente(patente);
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
        /// Agrega patentes a una familia existente.
        /// </summary>
        /// <param name="familia">La familia a la que se agregarán las patentes.</param>
        /// <param name="patentes">La lista de patentes a agregar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void AddPatentesToFamilia(Familia familia, List<Patente> patentes)
        {
            try
            {
                _familiaLogic.AddPatentesToFamilia(familia, patentes);
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
        /// Asigna una familia a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario al que se le asignará la familia.</param>
        /// <param name="familia">La familia que se asignará al usuario.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void AsignarFamiliaAUsuario(Guid usuarioId, Familia familia)
        {
            try
            {
                _familiaLogic.AsignarFamiliaAUsuario(usuarioId, familia);
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
        /// Actualiza la información de una familia existente.
        /// </summary>
        /// <param name="familia">La familia con la información actualizada.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void ActualizarFamilia(Familia familia)
        {
            try
            {
                _familiaLogic.ActualizarFamilia(familia);
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
        /// Actualiza las familias asociadas a un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario cuyas familias se actualizarán.</param>
        /// <param name="familias">La lista de familias con la información actualizada.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void ActualizarFamiliasDeUsuario(Guid usuarioId, List<Familia> familias)
        {
            try
            {
                _familiaLogic.ActualizarFamiliasDeUsuario(usuarioId, familias);
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
        /// Obtiene una lista de patentes asociadas a una familia específica.
        /// </summary>
        /// <param name="familiaId">El ID de la familia para la cual se desean obtener las patentes.</param>
        /// <returns>Una lista de patentes asociadas a la familia.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si la familia no posee permisos.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static List<Patente> GetPatentesByFamiliaId(Guid familiaId)
        {
            try
            {
                var list = _familiaLogic.GetPatentesByFamiliaId(familiaId);

                if (list.Count == 0) throw new BusinessRuleException("Este rol no posee permisos");

                return list;
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

        /// <summary>
        /// Obtiene una lista de todas las familias registradas.
        /// </summary>
        /// <returns>Una lista de todas las familias.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si no hay familias registradas.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static List<Familia> GetAllFamilias() 
        {
            try
            {
                var list = _familiaLogic.GetAllFamilias();

                if (list.Count == 0) throw new BusinessRuleException("No hay familias registradas");

                return list;
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

        /// <summary>
        /// Obtiene una lista de todas las patentes registradas.
        /// </summary>
        /// <returns>Una lista de todas las patentes.</returns>
        /// <exception cref="BusinessRuleException">Se lanza si no hay permisos registrados.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static List<Patente> GetAllPatentes() // obtener patentes
        {
            try
            {
                var list = _familiaLogic.GetAllPatentes();

                if (list.Count == 0) throw new BusinessRuleException("No hay permisos registrados");

                return list;

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

        /// <summary>
        /// Elimina una familia por su ID.
        /// </summary>
        /// <param name="id">El ID de la familia a eliminar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void DeleteFamilia(Guid id)
        {
            try
            {
                _familiaLogic.DeleteFamilia(id);
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
            _familiaLogic.DeleteFamilia(id);
        }

        /// <summary>
        /// Elimina una patente por su ID.
        /// </summary>
        /// <param name="id">El ID de la patente a eliminar.</param>
        /// <exception cref="BusinessRuleException">Se lanza si hay una violación de las reglas de negocio.</exception>
        /// <exception cref="DataAccessException">Se lanza si ocurre un error al acceder a la base de datos.</exception>
        public static void DeletePatente(Guid id)
        {
            try
            {
                _familiaLogic.DeletePatente(id);
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
    }
}
