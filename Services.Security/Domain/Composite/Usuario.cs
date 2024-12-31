using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Composite
{
    /// <summary>
    /// Clase que representa un usuario en el sistema.
    /// Contiene información sobre el usuario y sus accesos.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Estado del usuario (habilitado o deshabilitado).
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Dígito verificador horizontal.
        /// </summary>
        public string Digit { get; set; }

        /// <summary>
        /// Lista de accesos asociados al usuario.
        /// </summary>
        public List<Acceso> Accesos = new List<Acceso>();

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Usuario.
        /// Genera un nuevo GUID para el IdUsuario.
        /// </summary>
        public Usuario()
        {
            IdUsuario = Guid.NewGuid();  // Generador de GUID
        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Usuario con un IdUsuario específico.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
        public Usuario(Guid idUsuario)
        {
            this.IdUsuario = idUsuario;
        }

        /// <summary>
        /// Obtiene una lista de patentes asociadas al usuario.
        /// </summary>
        /// <returns>Lista de patentes.</returns>
        public List<Patente> GetPatentes()
        {
            List<Patente> patentes = new List<Patente>();
            GetAllPatentes(Accesos, patentes);
            return patentes;
        }

        /// <summary>
        /// Método recursivo que obtiene todas las patentes de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos a procesar.</param>
        /// <param name="patentesReturn">Lista de patentes a llenar.</param>
        private void GetAllPatentes(List<Acceso> accesos, List<Patente> patentesReturn)
        {
            foreach (var acceso in accesos)
            {
                // Condición de corte: si es un elemento de tipo Leaf (Patente)
                if (acceso.GetCount() == 0)
                {
                    // Evitar duplicados
                    if (!patentesReturn.Any(o => o.Id == acceso.Id))
                        patentesReturn.Add(acceso as Patente);
                }
                else
                {
                    // Tratar el acceso como una familia
                    GetAllPatentes((acceso as Familia).Accesos, patentesReturn);
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de familias asociadas al usuario.
        /// </summary>
        /// <returns>Lista de familias.</returns>
        public List<Familia> GetFamilias()
        {
            List<Familia> familias = new List<Familia>();
            GetAllFamilias(Accesos, familias);
            return familias;
        }

        /// <summary>
        /// Método recursivo que obtiene todas las familias de una lista de accesos.
        /// </summary>
        /// <param name="accesos">Lista de accesos a procesar.</param>
        /// <param name="famililaReturn">Lista de familias a llenar.</param>
        private void GetAllFamilias(List<Acceso> accesos, List<Familia> famililaReturn)
        {
            foreach (var acceso in accesos)
            {
                // Condición de corte: si es un elemento de tipo Composite (Familia)
                if (acceso.GetCount() > 0)
                {
                    // Evitar duplicados
                    if (!famililaReturn.Any(o => o.Id == acceso.Id))
                        famililaReturn.Add(acceso as Familia);

                    GetAllFamilias((acceso as Familia).Accesos, famililaReturn);
                }
            }
        }
    } // end User
}
