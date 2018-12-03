using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodaProject.Util
{
    /// <summary>
    /// Clase que representa el mensaje a mostar en la interfaz gráfica
    /// por medio de la clase Disenio
    /// </summary>
    public class Mensaje
    {

        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public TipoMensaje Tipo { get; set; }
        
        public Mensaje()
        {

        }

        /// <summary>
        /// Crea un mensaje para ser mostrado en los web forms
        /// </summary>
        /// <param name="Titulo">Título del mensaje</param>
        /// <param name="Contenido">Contenido del mensaje</param>
        /// <param name="Tipo">Tipo de mensaje</param>
        public Mensaje(string Titulo, string Contenido, TipoMensaje Tipo)
        {
            this.Titulo = Titulo;
            this.Contenido = Contenido;
            this.Tipo = Tipo;
        }
    }
}