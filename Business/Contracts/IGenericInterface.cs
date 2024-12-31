
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Contracts
{
    /// <summary>
    /// These are the namespace comments for <c>Business.Contracts</c>.
    /// </summary>



    /// <summary>
    /// Define un contrato genérico para operaciones básicas de gestión de entidades.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad que se gestionará.</typeparam>
    public interface IGenericInterface<T>
    {
        /// <summary>
        /// Agrega un nuevo objeto de tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">El objeto a agregar.</param>
        void Add(T obj);

        /// <summary>
        /// Actualiza un objeto existente de tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">El objeto a actualizar.</param>
        void Update(T obj);

        /// <summary>
        /// Elimina un objeto de tipo <typeparamref name="T"/> por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del objeto a eliminar.</param>
        void Remove(Guid id);

        /// <summary>
        /// Obtiene un objeto de tipo <typeparamref name="T"/> por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del objeto a obtener.</param>
        /// <returns>El objeto de tipo <typeparamref name="T"/> correspondiente al identificador, o null si no se encuentra.</returns>
        T GetById(Guid id);

        /// <summary>
        /// Obtiene una lista de todos los objetos de tipo <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Una lista de objetos de tipo <typeparamref name="T"/>.</returns>
        List<T> GetAll();


    }
}


