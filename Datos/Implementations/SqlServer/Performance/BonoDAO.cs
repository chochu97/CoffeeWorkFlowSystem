using Datos.Contracts.Performance;
using Datos.IDGenerator;
using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.SqlServer.Performance
{
    /// <summary>
    /// Clase que implementa el repositorio para la entidad BONO.
    /// </summary>
    public class BonoDAO : IBonoRepository
    {
        #region singleton
        private static readonly BonoDAO instance = new BonoDAO();

        /// <summary>
        /// Obtiene la instancia única de BonoDAO.
        /// </summary>
        public static BonoDAO Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Agrega un nuevo bono a la base de datos.
        /// </summary>
        /// <param name="obj">El objeto BONO a agregar.</param>
        public void Agregar(BONO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                obj.ID_BONO = GuidGenerator.NewGuid(); // Genera un nuevo ID para el bono
                context.BONO.Add(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina un bono de la base de datos.
        /// </summary>
        /// <param name="id">El ID del bono a eliminar.</param>
        public void Eliminar(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var bono = context.BONO.SingleOrDefault(b => b.ID_BONO == id);

                if (bono != null)
                {
                    context.BONO.Remove(bono);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los bonos en la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos BONO.</returns>
        public List<BONO> GetAll()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                return context.BONO.OrderBy(b => b.CATEGORIA).ToList();
            }
        }

        /// <summary>
        /// Obtiene un bono por su ID.
        /// </summary>
        /// <param name="id">El ID del bono a obtener.</param>
        /// <returns>El objeto BONO correspondiente.</returns>
        public BONO GetOne(Guid id)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var bono = context.BONO.SingleOrDefault(b => b.ID_BONO == id);
                return bono;
            }
        }

        // DTOS

        /// <summary>
        /// Obtiene una lista de bonos en formato DTO.
        /// </summary>
        /// <returns>Una lista de objetos BonoDTO que representan todos los bonos.</returns>
        public List<BonoDTO> GetBonos()
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var bonos = context.BONO
                    .Select(b => new BonoDTO
                    {
                        Id = b.ID_BONO,
                        Categoria = b.CATEGORIA,
                        Monto = b.MONTO,
                        Tareas_Minimas = b.MINIMO_TAREAS,
                        Estado = b.ESTADO ? "Habilitado" : "Deshabilitado"
                    })
                    .OrderByDescending(b => b.Monto)
                    .ToList();

                return bonos;
            }
        }

        // Método no utilizado

        /// <summary>
        /// Modifica un bono existente en la base de datos.
        /// </summary>
        /// <param name="obj">El objeto BONO con los nuevos valores.</param>
        public void Modificar(BONO obj)
        {
            using (var context = new GestionWorkFlowEntities())
            {
                var inter = obj.ID_BONO;
                var bonoExistente = context.BONO.SingleOrDefault(b => b.ID_BONO == inter);

                if (bonoExistente != null)
                {
                    context.Entry(bonoExistente).CurrentValues.SetValues(obj);
                    context.SaveChanges();
                }
            }
        }
    }
}
