using Services.Datos.Contracts;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Facade
{
    /// <summary>
    /// Proporciona servicios relacionados con la gestión de idiomas, incluyendo la traducción de claves
    /// y la suscripción de observadores para notificaciones de cambios en el idioma.
    /// </summary>
    public static class LanguageService
    {
        private static List<ILanguageObserver> observers = new List<ILanguageObserver>();

        /// <summary>
        /// Suscribe un observador para recibir notificaciones de cambios en el idioma.
        /// </summary>
        /// <param name="observer">El observador que se desea suscribir.</param>
        public static void Subscribe(ILanguageObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        /// <summary>
        /// Desuscribe un observador para dejar de recibir notificaciones de cambios en el idioma.
        /// </summary>
        /// <param name="observer">El observador que se desea desuscribir.</param>
        public static void Unsubscribe(ILanguageObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Notifica a todos los observadores sobre un cambio en el idioma.
        /// </summary>
        private static void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.UpdateLanguage();  // notificar al observador de la UI (form)
            }
        }

        /// <summary>
        /// Traduce una clave específica utilizando la lógica de traducción.
        /// </summary>
        /// <param name="key">La clave que se desea traducir.</param>
        /// <returns>La traducción correspondiente a la clave.</returns>
        public static string Translate(string key)
        {
            return LanguageLogic.Translate(key);
        }

        /// <summary>
        /// Obtiene un diccionario de idiomas disponibles.
        /// </summary>
        /// <returns>Un diccionario donde las claves son los códigos de idioma y los valores son los nombres de los idiomas.</returns>
        public static Dictionary<string, string> GetLanguages()
        {
            return LanguageLogic.GetLanguages();
        }

        /// <summary>
        /// Guarda el idioma del usuario y notifica a los observadores sobre el cambio.
        /// </summary>
        /// <param name="languageCode">El código del idioma que se desea guardar.</param>
        public static void SaveUserLanguage(string languageCode)
        {
            LanguageLogic.SaveUserLanguage(languageCode);
            NotifyObservers();  // Notificar cuando cambia el idioma
        }

        /// <summary>
        /// Carga el idioma guardado en la configuración.
        /// </summary>
        /// <returns>El código del idioma guardado.</returns>
        public static string LoadUserLanguage()
        {
            return LanguageLogic.LoadUserLanguage();
        }

        /// <summary>
        /// Traduce un formulario completo.
        /// </summary>
        /// <param name="control">El control que representa el formulario a traducir.</param>
        public static void TranslateForm(Control control)
        {
            LanguageLogic.TranslateForm(control);
        }
    }
}



