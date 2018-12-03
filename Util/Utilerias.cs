using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Text;
using PodaProject.Modelo;
using System.Web.UI;

namespace PodaProject.Util
{
    /// <summary>
    /// Clase que contiene métodos útiles que puedan ser
    /// reutilizados en cualquier parte del programa
    /// </summary>
    public class Utilerias
    {
        public const string CorreoSistema = "poda_brecha@cfe.gob.mx";
        public const string UsuarioSistema = "PODA CFE";
        public const string Host = "mail.cfemex.com";

        /// <summary>
        /// Obtiene el valor entero de una cadena de caracteres que posiblemente
        /// se encuentre vacia o sea nula
        /// </summary>
        /// <param name="Valor">Cadena a paresar</param>
        /// <returns>Valor obtenido de la cadena de caracteres</returns>
        public static int? ParsearNullable(string Valor)
        {
            int int_valor;
            return int.TryParse(Valor, out int_valor) ? int_valor : (int?) null;
        }

        /// <summary>
        /// Formatea una cadena de caracteres a una fecha local con patrón
        /// dd/MM/yyyy (dia/mes/año)
        /// </summary>
        /// <param name="Fecha">fecha a parsear</param>
        /// <returns>La fecha convertida</returns>
        public static DateTime ParsearFecha(string Fecha)
        {
            DateTime Date;
            try
            {
               Date = DateTime.ParseExact(Fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch 
            {
                throw;
            }

            return Date;
        }

        /// <summary>
        /// Envia un correo electrónico
        /// </summary>
        /// <param name="Correo">Correo destino</param>
        /// <param name="Asunto">Asunto del correo</param>
        /// <param name="Cuerpo">Cuerpo del correo</param>
        public static void EnviarEmail(string Correo, string Asunto, string Cuerpo) 
        {
            MailMessage Mail = new MailMessage();
            SmtpClient Cliente = new SmtpClient("smtp.gmail.com", 587);

            Mail.From = new MailAddress(CorreoSistema, UsuarioSistema, Encoding.UTF8);
            Mail.To.Add(Correo);

            Mail.IsBodyHtml = true;
            Mail.Priority = MailPriority.Normal;

            Mail.Subject = Asunto;
            Mail.Body = Cuerpo;

            Cliente.UseDefaultCredentials = false;
            Cliente.Send(Mail);
            
        }

        /// <summary>
        /// Retorna el formato de parámetros de un arreglo de objetos. Ejemplo:
        /// Parametros = ["param1", 2, true, "07/10/2017", null] se convierte a "'param1', '2', 'true', '07/10/2017', null"
        /// </summary>
        /// <param name="Parametros">Arreglos de parámetros a formatear</param>
        /// <returns>Cadena con parámetros formateados</returns>
        public static string FormatearParametros(params object[] Parametros)
        {
            return string.Join(Parametros.Length < 2 ? "" : ", ",
               Parametros.Select(param => param == null ? "null" 
                    : (param is object[] ? FormatearParametros((object[])param) : "'" + param + "'")));
        }

        /// <summary>
        /// Filtra el usuario de una página de web forms
        /// </summary>
        /// <param name="Pagina">La página de web forms de donde se filtrará el usuario</param>
        /// <returns>El usuario en sesión</returns>
        public static Usuario FiltrarUsuario(Page Pagina)
        {
            Usuario Usuario = (Usuario)Pagina.Session["usuario"];

            if (Usuario == null)
            {
                string UrlPeticion = Pagina.ResolveUrl(Pagina.AppRelativeVirtualPath);
                Pagina.Response.Redirect(Pagina.ResolveUrl("~/Login.aspx?ru=" + UrlPeticion));
            }

            return Usuario;
        }

        /// <summary>
        /// Toma los ultimos N elementos de una lista
        /// </summary>
        /// <typeparam name="T">El tipo de dato de la lista</typeparam>
        /// <param name="Lista">La lista de elementos de donde se tomarán los nuevos elementos</param>
        /// <param name="N">El número de los últimos elementos a tomar</param>
        /// <returns>Una lista de los últimos N elementos</returns>
        public static List<T> TomarUltimos<T>(List<T> Lista, int N)
        {
            return Lista.Skip(Math.Max(0, Lista.Count - N)).ToList(); 
        }

        /// <summary>
        /// Devuelve la representación de un número decimal en una cadena 
        /// de moneda. Ejemplo 6.25 -> $6.25, 759651 -> $759,651.00
        /// </summary>
        /// <param name="Valor">El número a formatear</param>
        /// <returns>La representación de la moneda en cadena</returns>
        public static string ToCurrency(double Valor)
        {
            return Valor.ToString("C", CultureInfo.CurrentCulture);
        }
        
    }
}