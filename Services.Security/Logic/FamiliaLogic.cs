using Services.Datos.Implementations.SqlServer;
using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{

    /// <summary>
    /// Clase que gestiona la lógica relacionada con las familias y las patentes.
    /// </summary>
    public class FamiliaLogic 
    {
        private readonly FamiliaRepository _familiaRepository;

        /// <summary>
        /// Constructor de la clase <see cref="FamiliaLogic"/>.
        /// Inicializa el repositorio de familias.
        /// </summary>
        public FamiliaLogic()
        {
            _familiaRepository = new FamiliaRepository();
        }


        /// <summary>
        /// Crea una nueva familia con las patentes asociadas.
        /// </summary>
        /// <param name="familia">La familia a crear.</param>
        public void CrearFamiliaConPatentes(Familia familia)
        {
            _familiaRepository.SaveFamilia(familia);
        }


        /// <summary>
        /// Crea una nueva patente.
        /// </summary>
        /// <param name="patente">La patente a crear.</param>
        public void CreatePatente(Patente patente)
        {
            _familiaRepository.CreatePatente(patente);
        }

        /// <summary>
        /// Agrega patentes a una familia existente.
        /// </summary>
        /// <param name="familia">La familia a la que se agregarán las patentes.</param>
        /// <param name="patentes">Lista de patentes a agregar.</param>
        public void AddPatentesToFamilia(Familia familia, List<Patente> patentes)
        {
            _familiaRepository.AddPatentesToFamilia(familia, patentes);
        }


        /// <summary>
        /// Asigna una familia a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <param name="familia">La familia a asignar.</param>
        public void AsignarFamiliaAUsuario(Guid usuarioId, Familia familia)
        {
            _familiaRepository.SaveUsuarioFamilia(usuarioId, familia.Id);
        }


        /// <summary>
        /// Actualiza la información de una familia existente.
        /// </summary>
        /// <param name="familia">La familia con la información actualizada.</param>
        public void ActualizarFamilia(Familia familia)
        {
            _familiaRepository.UpdateFamilia(familia);
        }


        /// <summary>
        /// Actualiza las familias asociadas a un usuario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <param name="familias">Lista de familias a actualizar.</param>
        public void ActualizarFamiliasDeUsuario(Guid usuarioId, List<Familia> familias)
        {
            _familiaRepository.UpdateUsuarioFamilia(usuarioId, familias);
        }

        /// <summary>
        /// Obtiene las patentes asociadas a una familia dada su ID.
        /// </summary>
        /// <param name="familiaId">El ID de la familia.</param>
        /// <returns>Lista de patentes asociadas a la familia.</returns>
        public List<Patente> GetPatentesByFamiliaId(Guid familiaId)
        {
            return _familiaRepository.GetPatentesByFamiliaId(familiaId);
        }

        /// <summary>
        /// Obtiene todas las familias registradas.
        /// </summary>
        /// <returns>Lista de todas las familias.</returns>
        public List<Familia> GetAllFamilias()
        {
            return _familiaRepository.GetAll();
        }

        /// <summary>
        /// Obtiene todas las patentes registradas.
        /// </summary>
        /// <returns>Lista de todas las patentes.</returns>
        public List<Patente> GetAllPatentes()
        {
            return _familiaRepository.GetAllPatentes();
        }

        /// <summary>
        /// Elimina una familia dada su ID.
        /// </summary>
        /// <param name="id">El ID de la familia a eliminar.</param>
        public void DeleteFamilia(Guid id)
        {
            _familiaRepository.DeleteFamilia(id);
        }

        /// <summary>
        /// Elimina una patente dada su ID.
        /// </summary>
        /// <param name="id">El ID de la patente a eliminar.</param>
        public void DeletePatente(Guid id)
        {
            _familiaRepository.DeletePatente(id);
        }
    }
}
