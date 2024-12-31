using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Composite
{
    /// <summary>
    /// Clase que representa una patente de acceso. 
    /// Hereda de la clase abstracta Acceso y no permite agregar o remover componentes.
    /// </summary>
    public class Patente : Acceso
    {
        /// <summary>
        /// Tipo de acceso asociado a la patente.
        /// </summary>
        public TipoAcceso TipoAcceso { get; set; }

        /// <summary>
        /// Clave de datos asociada a la patente.
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Patente.
        /// Se puede especificar el tipo de acceso, que por defecto es UI.
        /// </summary>
        /// <param name="tipoAcceso">Tipo de acceso de la patente.</param>
        public Patente(TipoAcceso tipoAcceso = TipoAcceso.UI)
        {
            Id = Guid.NewGuid();
            this.TipoAcceso = tipoAcceso;
        }

        /// <summary>
        /// Método que intenta agregar un componente de tipo Acceso.
        /// Lanza una excepción ya que no se puede agregar un elemento a una patente.
        /// </summary>
        /// <param name="component">El componente a agregar.</param>
        public override void Add(Acceso component)
        {
            throw new Exception("No se puede agregar un elemento");
        }

        /// <summary>
        /// Método que intenta remover un componente de tipo Acceso.
        /// Lanza una excepción ya que no se puede quitar un elemento de una patente.
        /// </summary>
        /// <param name="component">El componente a remover.</param>
        public override void Remove(Acceso component)
        {
            throw new Exception("No se puede quitar un elemento");
        }

        /// <summary>
        /// Obtiene el conteo de accesos en la patente, que siempre es 0.
        /// </summary>
        /// <returns>0, ya que una patente no tiene componentes hijos.</returns>
        public override int GetCount()
        {
            return 0;
        }
    } // end Leaf

    /// <summary>
    /// Enumeración que define los tipos de acceso disponibles.
    /// </summary>
    public enum TipoAcceso
    {
        /// <summary>
        /// Representa el acceso a la interfaz de usuario.
        /// </summary>
        UI,

        /// <summary>
        /// Representa el acceso a las funciones de control del sistema.
        /// </summary>
        Control,

        /// <summary>
        /// Representa el acceso a los casos de uso dentro del sistema.
        /// </summary>
        UseCases
    }
}
