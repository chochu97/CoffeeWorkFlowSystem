using Services.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Facade;
using Services.Datos.Contracts;
using static Services.Logic.AccesoLogic;
using System.Collections;

namespace Services.Logic
{
    /// <summary>
    /// Clase estática que gestiona el acceso a controles y pestañas en la interfaz de usuario.
    /// </summary>
    public static class AccesoLogic // si es control cae en ControlDeco, si es tab cae en TabPageDeco
    {
        /// <summary>
        /// Decorador para controles que implementa la interfaz IControlAccess.
        /// </summary>
        public class ControlDecorator : IControlAccess // decorador para comparar permisos con todos los tipos de control
        {
            private readonly Control _control;
            private readonly string _requiredPatente;

            /// <summary>
            /// Constructor de la clase <see cref="ControlDecorator"/>.
            /// Inicializa el decorador de control con el control y la patente requerida.
            /// </summary>
            /// <param name="control">El <see cref="Control"/> que se va a decorar.</param>
            /// <param name="requiredPatente">La patente requerida para acceder al <see cref="Control"/>.</param>
            public ControlDecorator(Control control, string requiredPatente) 
            {
                _control = control;
                _requiredPatente = requiredPatente;
            }

            /// <summary>
            /// Establece el acceso al control basado en las patentes del usuario.
            /// </summary>
            /// <param name="patentesUsuario">Lista de patentes del usuario.</param>
            public void SetAccess(List<Patente> patentesUsuario)
            {
                // habilita o desabilita a partir del permiso.. esta bien ver?
                _control.Enabled = patentesUsuario.Any(p => p.DataKey == _requiredPatente);
                
            }
        }

        /// <summary>
        /// Decorador para TabPages que implementa la interfaz IControlAccess.
        /// </summary>
        public class TabPageDecorator : IControlAccess // decorador para comparar permisos con los tabPages 
        {
            private readonly TabPage _tabPage;
            private readonly string _requiredPatente;

            /// <summary>
            /// Constructor de la clase <see cref="TabPageDecorator"/>.
            /// Inicializa el decorador de la tabPage con la tabPage y la patente requerida.
            /// </summary>
            /// <param name="tab">La <see cref="TabPage"/> que se va a decorar.</param>
            /// <param name="requiredPatente">La patente requerida para acceder a la <see cref="TabPage"/>.</param>
            public TabPageDecorator(TabPage tab, string requiredPatente)
            {
                _tabPage = tab;
                _requiredPatente = requiredPatente;
            }

            /// <summary>
            /// Establece el acceso a la pestaña basado en las patentes del usuario.
            /// </summary>
            /// <param name="patentesUsuario">Lista de patentes del usuario.</param>
            public void SetAccess(List<Patente> patentesUsuario)
            {
                bool hasAccess = patentesUsuario.Any(p => p.DataKey == _requiredPatente);

                _tabPage.Enabled = hasAccess; 

                if (_tabPage.Parent is TabControl tabControl) // todo bien pero si no tiene permiso se remueve
                {
                    if(!hasAccess && tabControl.TabPages.Contains(_tabPage))
                    {
                        tabControl.TabPages.Remove(_tabPage);
                    }

                    if(hasAccess && !tabControl.TabPages.Contains(_tabPage))
                    {
                        tabControl.TabPages.Add(_tabPage);
                    }
                }

            }
        }


        /// <summary>
        /// Aplica el acceso a los controles para un usuario específico.
        /// </summary>
        /// <param name="user">El usuario para el que se aplicará el acceso.</param>
        /// <param name="controles">Lista de controles a los que se aplicará el acceso.</param>
        public static void AplicarAccesoUsuario(Usuario user, List<Control> controles)
        {
            List<Patente> patentes = user.GetPatentes();

            foreach(var control in controles)
            {
                IControlAccess decorator = ObtenerDecoradorAdecuado(control);
                decorator?.SetAccess(patentes);
            }
        }

        /// <summary>
        /// Obtiene el decorador adecuado para un control dado.
        /// </summary>
        /// <param name="control">El control para el que se obtendrá el decorador.</param>
        /// <returns>Un objeto que implementa IControlAccess.</returns>
        public static IControlAccess ObtenerDecoradorAdecuado(Control control)
        {
            if(control is TabPage tabpage)
            {
                return new TabPageDecorator(tabpage, tabpage.Name);
            }
            else
            {
                return new ControlDecorator(control, control.Name);
            }
        } 
    }
}
