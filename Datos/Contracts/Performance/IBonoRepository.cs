using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.Performance
{
    /// <summary>
    /// Interfaz para el repositorio de bonos.
    /// Hereda de <see cref="IGenericInterface{BONO}"/> para operaciones CRUD.
    /// </summary>
    public interface IBonoRepository : IGenericInterface<BONO>
    {
        /// <summary>
        /// Obtiene una lista de todos los bonos.
        /// </summary>
        /// <returns>Una lista de <see cref="BonoDTO"/> que representan todos los bonos.</returns>
        List<BonoDTO> GetBonos();
    }
}
