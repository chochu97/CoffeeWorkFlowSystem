using Services.Datos.Contracts;
using Services.Domain;
using Services.Domain.Composite;
using Services.Facade;
using Services.Logic;
using Services.Security.Facade;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static Services.Logic.AccesoLogic;
using System.IO;

namespace UI.Services
{
    /// <summary>
    /// Clase que representa el formulario de inicio de sesión.
    /// Implementa la interfaz <see cref="ILanguageObserver"/> para observar cambios en el idioma.
    /// </summary>
    public partial class LoginForm : Form, ILanguageObserver
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LoginForm"/>.
        /// Suscribe el formulario a los cambios de idioma y configura el idioma inicial.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            LanguageService.Subscribe(this);
            FillingLanguageComboBox(comboLanguage);
            UpdateLanguage();
            

        }

        UserService userService = new UserService();

        /// <summary>
        /// Actualiza el idioma del formulario utilizando el servicio de idioma.
        /// </summary>
        public void UpdateLanguage()
        {
            LanguageService.TranslateForm(this);
        }

        BackUpService backUpService = new BackUpService();

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se carga el formulario.
        /// Realiza la restauración de la base de datos y verifica la integridad de los usuarios.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                backUpService.Restore();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al realizar restore de base de datos: " + ex.Message);
            }

            var allUsers = userService.GetAllUsuarios();

            foreach(var user in allUsers)
            {
                var concatenated = user.UserName + user.Password + user.Estado;

                var verificador = CryptographyService.HashMd5(concatenated);

                if(verificador != user.Digit)
                {
                    MessageBox.Show("Hubo modificaciones en la base de datos durante la noche");
                }
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)  // Cambia F1 por la tecla que desees
            {
                // Asegúrate de usar la ruta correcta hacia tu archivo de ayuda
                string helpFilePath = Path.Combine(Application.StartupPath, "Help", "Manual de Ayuda.chm");

                if (File.Exists(helpFilePath))
                {
                    Process.Start(helpFilePath);
                }
                else
                {
                    MessageBox.Show("Algo salio mal");
                }
            }
        }

        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se está cerrando el formulario.
        /// Realiza una copia de seguridad de la base de datos y se desuscribe de los cambios de idioma.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void LoginForm_FormClosing(object sender,  FormClosingEventArgs e)
        {
            try
            {
                backUpService.BackUp();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar bakcup de base de datos: " + ex.Message);
            }

            LanguageService.Unsubscribe(this);
        }

        /// <summary>
        /// Manejador de eventos para el botón de inicio de sesión.
        /// Valida el usuario y abre el formulario secundario si las credenciales son correctas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = userService.ValidateUser(txtUserName.Text, txtPassword.Text);
                string name = txtUserName.Text;
                if (success)
                {
                    var user = userService.GetUsuarioByUsername(name);
                    string rol = user.GetFamilias().FirstOrDefault()?.Nombre ?? "Sin Rol asginado";

                    LoggerService.WriteLog(new Log($"El Usuario '{name}', con el rol '{rol}' inicio sesion.", TraceLevel.Info));

                    AbrirFormularioSecundario(user);
                }
                else
                {
                    throw new Exception("Usuario no existente");
                }
            }
            catch(Exception ex)
            {
                LoggerService.WriteException(ex);
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Abre el formulario secundario y oculta el formulario de inicio de sesión.
        /// </summary>
        /// <param name="user">El usuario que ha iniciado sesión.</param>
        private void AbrirFormularioSecundario(Usuario user)
        {
            Coffee MainForm = new Coffee(user, this);
            MainForm.Show();
            this.Hide();
        }


        /// <summary>
        /// Rellena el combo box de idiomas con los idiomas disponibles.
        /// </summary>
        /// <param name="combo">El combo box a rellenar.</param>
        public void FillingLanguageComboBox(ComboBox combo)
        {
            var availableLanguages = LanguageService.GetLanguages();
            
            combo.Items.Clear();

            foreach(var lang in availableLanguages)
            {
                combo.Items.Add(new KeyValuePair<string, string>(lang.Key, lang.Value));    
            }

            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";
        }


        /// <summary>
        /// Manejador de eventos que se ejecuta cuando se cambia la selección en el combo box de idiomas.
        /// Actualiza el idioma de la interfaz de usuario según el idioma seleccionado por el usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboLanguage.SelectedItem != null)
            {
                if(comboLanguage.SelectedItem is KeyValuePair<string, string> selectedLanguage)
                {
                    var selectedCode = selectedLanguage.Key;

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedCode);
                    LanguageService.SaveUserLanguage(selectedCode);
                }
            }
        }
    }
}
