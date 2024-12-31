using Services.Datos.Contracts;
using Services.Datos;
using Services.Domain.Exceptions;
using Services.Facade;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Datos.Implementations.Texto;
using System.Collections.Generic;

namespace Services.Logic
{
    /// <summary>
    /// Clase que gestiona la lógica de traducción de textos en la aplicación.
    /// </summary>
    internal static class LanguageLogic
    {
        /// <summary>
        /// Traduce una clave de texto a su correspondiente traducción.
        /// </summary>
        /// <param name="key">La clave de texto a traducir.</param>
        /// <returns>La traducción correspondiente o la clave original si ocurre un error.</returns>
        public static string Translate(string key)
        {
            try
            {
                return LanguageRepository.Translate(key);
            }
            catch (Exception ex)
            {
                // registrar errores de traduccion o de encontrar palabras
                Console.WriteLine(ex.Message);
                LoggerService.WriteException(ex);
            }

            return key; // Si ocurre un error, se retorna la clave original
        }

        /// <summary>
        /// Traduce todos los controles en un formulario.
        /// </summary>
        /// <param name="control">El control contenedor que contiene otros controles a traducir.</param>
        public static void TranslateForm(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl.Tag != null && !string.IsNullOrEmpty(ctrl.Tag.ToString()))
                {
                    ctrl.Text = Translate(ctrl.Tag.ToString());
                }

                // Traducir recursivamente subcontroles
                if (ctrl.HasChildren)
                {
                    TranslateForm(ctrl);
                }
            }
        }

        /// <summary>
        /// Obtiene un diccionario de idiomas disponibles.
        /// </summary>
        /// <returns>Un diccionario con los códigos de idioma y sus nombres.</returns>
        public static Dictionary<string, string> GetLanguages()
        {
            return LanguageRepository.GetLanguages();   
        }

        /// <summary>
        /// Guarda el idioma seleccionado por el usuario en la configuración.
        /// </summary>
        /// <param name="languageCode">El código del idioma a guardar.</param>
        public static void SaveUserLanguage(string languageCode)
        {
            LanguageRepository.SaveUserLanguage(languageCode);
        }

        /// <summary>
        /// Carga el idioma seleccionado por el usuario desde la configuración.
        /// </summary>
        /// <returns>El código del idioma cargado.</returns>
        public static string LoadUserLanguage()
        {
            return LanguageRepository.LoadUserLanguage();
        }

    }
}


