using Datos.Contracts;
using Datos.Contracts.Items;
using Datos.IDGenerator;
using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.Items
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad PEDIDO.
    /// </summary>
    public class PedidoDAO : IPedidoRepository
    {
        #region singleton
        private static readonly PedidoDAO instance = new PedidoDAO();

        /// <summary>
        /// Obtiene la instancia única de PedidoDAO.
        /// </summary>
        public static PedidoDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo pedido a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto PEDIDO a agregar.</param>
        public void Agregar(PEDIDO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                obj.ID_PEDIDO = GuidGenerator.NewGuid();
                context.PEDIDO.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina un pedido de la base de datos marcándolo como cancelado.
        /// </summary>
        /// <param name="id">El ID del pedido a eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var obj = context.PEDIDO.SingleOrDefault(p => p.ID_PEDIDO == id);

                if (obj != null)
                {
                    obj.ESTADO = "Cancelado";
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("El pedido especificado no existe");
                }
            }
        }

        /// <summary>
        /// Obtiene un pedido por su ID.
        /// </summary>
        /// <param name="id">El ID del pedido a obtener.</param>
        /// <returns>El objeto PEDIDO correspondiente.</returns>
        public PEDIDO GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var pedido = context.PEDIDO.SingleOrDefault(p => p.ID_PEDIDO == id);
                return pedido;
            }
        }

        /// <summary>
        /// Procesa un pedido, cambiando su estado según su estado actual.
        /// </summary>
        /// <param name="pedido">El objeto PEDIDO a procesar.</param>
        public void ProcesarPedido(PEDIDO pedido)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                if (pedido.ESTADO == "Pendiente")
                {
                    pedido.ESTADO = "En Preparacion";
                }
                else if (pedido.ESTADO == "En Preparacion")
                {
                    pedido.ESTADO = "Finalizado";
                }

                context.Entry(pedido).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene una lista de pedidos completos, incluyendo información del cliente, empleado y productos.
        /// </summary>
        /// <returns>Una lista de objetos PedidoCompletoDTO que representan los pedidos.</returns>
        public List<PedidoCompletoDTO> ObtenerPedidos()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var pedidos = (from p in context.PEDIDO
                               join c in context.CLIENTE on p.ID_CLIENTE equals c.ID_CLIENTE
                               join e in context.EMPLEADO on p.COD_EMPLEADO equals e.COD_EMPLEADO
                               select new
                               {
                                   Pedido = p,
                                   ClienteNombre = c.NOMBRE + " " + c.APELLIDO,
                                   EmpleadoNombre = e.NOMBRE + " " + e.APELLIDO
                               }).ToList();

                var pedidoResumen = pedidos.Select(p => new PedidoCompletoDTO
                {
                    Id = p.Pedido.ID_PEDIDO,
                    Fecha_Hora = p.Pedido.FECHA_HORA,
                    Cliente = p.ClienteNombre,

                    // Obtiene la lista de productos del pedido y los formatea como una cadena
                    Productos = string.Join(", ", context.DETALLE_PEDIDO
                    .Where(dp => dp.ID_PEDIDO == p.Pedido.ID_PEDIDO)
                    .ToList() // Se carga en memoria para evitar problemas de ejecución
                    .Select(dp => $"{dp.PRODUCTO.NOMBRE} x{dp.CANTIDAD}")),

                    // Calcula el total del pedido sumando el precio de cada producto multiplicado por su cantidad
                    Total = context.DETALLE_PEDIDO
                    .Where(dp => dp.ID_PEDIDO == p.Pedido.ID_PEDIDO)
                    .ToList() // Se carga en memoria para evitar problemas de ejecución
                    .Sum(dp => dp.CANTIDAD * dp.PRODUCTO.PRECIO),

                    Empleado = p.EmpleadoNombre,
                    Estado = p.Pedido.ESTADO

                }).OrderByDescending(p => p.Fecha_Hora).ToList();

                return pedidoResumen;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de pedidos.
        /// Este método aún no está implementado.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="PEDIDO"/>.</returns>
        public List<PEDIDO> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifica un pedido existente.
        /// Este método aún no está implementado.
        /// </summary>
        /// <param name="obj">El objeto <see cref="PEDIDO"/> que se desea modificar.</param>
        public void Modificar(PEDIDO obj)
        {
            throw new NotImplementedException();
        }
    }
}
