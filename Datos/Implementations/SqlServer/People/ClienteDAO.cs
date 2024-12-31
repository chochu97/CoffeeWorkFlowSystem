using Datos.Contracts.People;
using Datos.IDGenerator;
using Domain;
using Domain.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.People
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad CLIENTE.
    /// </summary>
    public class ClienteDAO : IClienteRepository
    {
        #region singleton
        private static readonly ClienteDAO instance = new ClienteDAO();

        /// <summary>
        /// Obtiene la instancia única de ClienteDAO.
        /// </summary>
        public static ClienteDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo cliente a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto CLIENTE a agregar.</param>
        public void Agregar(CLIENTE obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                obj.ID_CLIENTE = GuidGenerator.NewGuid();
                context.CLIENTE.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina un cliente de la base de datos.
        /// </summary>
        /// <param name="id">El ID del cliente a eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var client = context.CLIENTE.SingleOrDefault(c => c.ID_CLIENTE == id);
                if (client != null)
                {
                    context.CLIENTE.Remove(client);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        /// <param name="id">El ID del cliente a obtener.</param>
        /// <returns>El objeto CLIENTE correspondiente.</returns>
        public CLIENTE GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var client = context.CLIENTE.SingleOrDefault(c => c.ID_CLIENTE == id);
                return client;
            }
        }

        /// <summary>
        /// Modifica un cliente existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto CLIENTE con los nuevos valores.</param>
        public void Modificar(CLIENTE obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var clientExistente = context.CLIENTE.SingleOrDefault(c => c.ID_CLIENTE == obj.ID_CLIENTE);
                if (clientExistente != null)
                {
                    context.Entry(clientExistente).CurrentValues.SetValues(obj);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene todos los clientes de la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos CLIENTE.</returns>
        public List<CLIENTE> GetAll()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var lista = context.CLIENTE.OrderBy(c => c.NOMBRE).ToList();
                return lista;
            }
        }

        /// <summary>
        /// Obtiene un cliente por su DNI.
        /// </summary>
        /// <param name="dni">El DNI del cliente a obtener.</param>
        /// <returns>El objeto CLIENTE correspondiente.</returns>
        public CLIENTE GetOneClientDNI(int dni)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var client = context.CLIENTE.SingleOrDefault(c => c.DNI.Equals(dni));
                return client;
            }
        }

        /// <summary>
        /// Obtiene una lista de clientes que coinciden con el DNI especificado y están habilitados.
        /// </summary>
        /// <param name="dni">El DNI del cliente a buscar.</param>
        /// <returns>Una lista de objetos ClienteDTO que representan los clientes encontrados.</returns>
        public List<ClienteDTO> GetClienteByDNI(int dni)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var client = context.CLIENTE
                    .Where(c => c.DNI.Equals(dni) && c.ESTADO != false)
                    .Select(c => new ClienteDTO
                    {
                        Id = c.ID_CLIENTE,
                        Nombre = c.NOMBRE,
                        Apellido = c.APELLIDO,
                        DNI = c.DNI,
                        Puntos = c.PEDIDO.Count(),
                        Estado = c.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderBy(c => c.Nombre)
                    .ToList();

                return client;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes habilitados en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos ClienteDTO que representan todos los clientes habilitados.</returns>
        public List<ClienteDTO> GetClientes()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var clientes = context.CLIENTE
                    .Where(c => c.ESTADO != false)
                    .Select(c => new ClienteDTO
                    {
                        Id = c.ID_CLIENTE,
                        Nombre = c.NOMBRE,
                        Apellido = c.APELLIDO,
                        DNI = c.DNI,
                        Puntos = c.PEDIDO.Count(),
                        Estado = c.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderBy(c => c.Nombre)
                    .ToList();

                return clientes;
            }
        }
    }
}
