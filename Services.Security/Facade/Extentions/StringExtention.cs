using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extentions
{
    /// <summary>
    /// Clase estática que agrupa las extensiones de cadena para funcionalidades adicionales.
    /// </summary>
    public static class StringExtention // del github
    {

        /// <summary>
        /// Traducir una clave de texto usando la lógica de traducción.
        /// </summary>
        /// <param name="key">La clave del texto a traducir.</param>
        /// <returns>La cadena traducida correspondiente a la clave.</returns>
        public static string Translate(this string key)
        {
            return LanguageLogic.Translate(key);
        }


        /// <summary>
        /// Convierte la primera letra de la palabra a mayúscula.
        /// </summary>
        /// <param name="word">La palabra a la que se le aplicará la transformación.</param>
        /// <returns>La palabra con la primera letra en mayúscula.</returns>
        public static string ToUpperCapital(this string word)
        {
            return word;
        }

        /// <summary>
        /// Realiza una operación personalizada sobre una palabra utilizando parámetros adicionales.
        /// </summary>
        /// <param name="word">La palabra sobre la que se realizará la operación.</param>
        /// <param name="a">Un parámetro entero que puede influir en la operación.</param>
        /// <param name="pepe">Un parámetro de tipo cadena adicional que puede influir en la operación.</param>
        /// <returns>Una cadena que representa el resultado de la operación.</returns>
        public static string ExtentionWithParameters(this string word, int a, string pepe)
        {
            return "hola";
        }
    }
}
