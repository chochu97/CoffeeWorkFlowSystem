using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Composite
{
    /// <summary>
    /// Clase que representa una familia de accesos. 
    /// Hereda de la clase abstracta Acceso y permite agregar, remover y contar accesos.
    /// </summary>
    public class Familia : Acceso
    {
        private List<Acceso> accesos = new List<Acceso>();

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Familia.
        /// Si se proporciona un acceso, se agrega a la lista de accesos.
        /// </summary>
        /// <param name="acceso">Acceso opcional a agregar a la familia.</param>
        public Familia(Acceso acceso = null)
        {
            Id = Guid.NewGuid();
            if (acceso != null)
                // Asegurarse de que el acceso no sea nulo
                accesos.Add(acceso);
        }

        /// <summary>
        /// Agrega un componente de tipo Acceso a la familia.
        /// </summary>
        /// <param name="component">El componente a agregar.</param>
        public override void Add(Acceso component)
        {
            accesos.Add(component);
        }

        /// <summary>
        /// Remueve un componente de tipo Acceso de la familia.
        /// </summary>
        /// <param name="component">El componente a remover.</param>
        public override void Remove(Acceso component)
        {
            // Verificar que no se quede sin hijos...
            // accesos.Remove(component);
            accesos.RemoveAll(o => o.Id == component.Id); // Usando LINQ para eliminar por Id
        }

        /// <summary>
        /// Obtiene el conteo de accesos en la familia.
        /// </summary>
        /// <returns>El número de accesos en la familia.</returns>
        public override int GetCount()
        {
            return accesos.Count;
        }

        /// <summary>
        /// Propiedad que obtiene la lista de accesos.
        /// </summary>
        public List<Acceso> Accesos
        {
            get
            {
                return accesos;
            }
        }
    } // end Composite
}
