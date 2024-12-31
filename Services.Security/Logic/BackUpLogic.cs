using Services.Datos.Factory;
using Services.Security.Datos.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.Logic
{
    /// <summary>
    /// Clase que gestiona la lógica de copias de seguridad y restauración de bases de datos.
    /// </summary>
    public class BackUpLogic
    {
        private readonly IBackUpRepository _repository;

        /// <summary>
        /// Constructor de la clase <see cref="BackUpLogic"/>.
        /// Inicializa el repositorio de respaldo utilizando el patrón Factory.
        /// </summary>
        public BackUpLogic()
        {
            _repository = FactoryDAO.GetBackUp();
        }

        /// <summary>
        /// Realiza copias de seguridad de las bases de datos configuradas.
        /// </summary>
        public void RealizarBackUp()
        {
            var databases = new List<(string Name, string BackUpPath)>
            {
                ("CoffeeSecurity", ConfigurationManager.AppSettings["BackUpSecurityPath"]),
                ("GestionWorkFlow", ConfigurationManager.AppSettings["BackUpMainPath"])
            };

            foreach(var (name, path) in databases)
            {
                _repository.BackUpDataBase(name, path);
            }
        }

        /// <summary>
        /// Restaura las bases de datos desde las copias de seguridad configuradas.
        /// </summary>
        public void RealizarRestore()
        {
            var databases = new List<(string Name, string BackUpPath)>
            {
                ("CoffeeSecurity", ConfigurationManager.AppSettings["BackUpSecurityPath"]),
                ("GestionWorkFlow", ConfigurationManager.AppSettings["BackUpMainPath"])
            };

            foreach(var(name, path) in databases)
            {
                _repository.RestoreDataBase(name, path);
            }
        }
    }
}
