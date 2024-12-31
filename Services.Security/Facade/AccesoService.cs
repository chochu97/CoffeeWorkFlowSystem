using Services.Domain.Composite;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Security.Facade
{
    /// <summary>
    /// Proporciona servicios relacionados con el acceso de usuarios a controles específicos.
    /// </summary>
    public static class AccesoService
    {
        /// <summary>
        /// Aplica los controles de acceso a un usuario específico.
        /// </summary>
        /// <param name="user">El usuario al que se le aplicarán los controles de acceso.</param>
        /// <param name="controles">Una lista de controles que se aplicarán al usuario.</param>
        public static void AplicarAcceso(Usuario user, List<Control> controles)
        {
            AccesoLogic.AplicarAccesoUsuario(user, controles);
        }
    }
}
