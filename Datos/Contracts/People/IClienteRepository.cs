using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts.People
{
    /// <summary>
    /// Interfaz para el repositorio de clientes.
    /// Hereda de <see cref="IGenericInterface{CLIENTE}"/> para operaciones CRUD.
    /// </summary>
    public interface IClienteRepository : IGenericInterface<CLIENTE>
    {
        /// <summary>
        /// Obtiene una lista de clientes que coinciden con el DNI especificado.
        /// </summary>
        /// <param name="dni">El DNI del cliente a buscar.</param>
        /// <returns>Una lista de <see cref="ClienteDTO"/> que representan los clientes encontrados.</returns>
        List<ClienteDTO> GetClienteByDNI(int dni);

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una lista de <see cref="ClienteDTO"/> que representan todos los clientes.</returns>
        List<ClienteDTO> GetClientes();

        /// <summary>
        /// Obtiene un cliente específico por su DNI.
        /// </summary>
        /// <param name="dni">El DNI del cliente a buscar.</param>
        /// <returns>Un objeto <see cref="CLIENTE"/> que representa el cliente encontrado, o null si no se encuentra.</returns>
        CLIENTE GetOneClientDNI(int dni);
    }
}
