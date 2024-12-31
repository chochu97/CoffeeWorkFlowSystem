using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Datos.Contracts
{
    /// <summary>
    /// Interfaz que define los métodos para el control de acceso en el sistema.
    /// </summary>
    public interface IControlAccess
    {
        /// <summary>
        /// Establece los accesos para un usuario basado en una lista de patentes.
        /// </summary>
        /// <param name="patentesUsuario">Lista de patentes que representan los accesos del usuario.</param>
        void SetAccess(List<Patente> patentesUsuario);
    }
}


