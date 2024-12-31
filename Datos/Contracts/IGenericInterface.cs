using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /// <summary>
    /// Interfaz genérica para operaciones CRUD (Crear, Leer, Actualizar, Eliminar).
    /// </summary>
    /// <typeparam name="T">El tipo de objeto que se manejará en la interfaz.</typeparam>
    public interface IGenericInterface<T>
    {
        /// <summary>
        /// Agrega un nuevo objeto.
        /// </summary>
        /// <param name="obj">El objeto a agregar.</param>
        void Agregar(T obj);

        /// <summary>
        /// Elimina un objeto por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del objeto a eliminar.</param>
        void Eliminar(Guid id);

        /// <summary>
        /// Modifica un objeto existente.
        /// </summary>
        /// <param name="obj">El objeto a modificar.</param>
        void Modificar(T obj);

        /// <summary>
        /// Obtiene un objeto por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del objeto a obtener.</param>
        /// <returns>El objeto correspondiente al identificador.</returns>
        T GetOne(Guid id);

        /// <summary>
        /// Obtiene todos los objetos.
        /// </summary>
        /// <returns>Una lista de todos los objetos.</returns>
        List<T> GetAll();

    }
}
