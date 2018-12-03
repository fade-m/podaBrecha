using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodaProject.Util
{
    /// <summary>
    /// Enum que contiene los diferentes tipos de mensaje posibles
    /// que se puedan presentar en los formularios
    /// </summary>
    public sealed class TipoMensaje
    {
        public static readonly TipoMensaje EXITO = new TipoMensaje("success", "check");
        public static readonly TipoMensaje ALERTA = new TipoMensaje("warning", "warning");
        public static readonly TipoMensaje ERROR = new TipoMensaje("danger", "ban");
        public static readonly TipoMensaje INFORMACION = new TipoMensaje("info", "info");

        public readonly string Clase;
        public readonly string Icono;

        /// <summary>
        /// Crea un Tipo de Mensaje
        /// </summary>
        /// <param name="Clase">Clase de bootstrap</param>
        /// <param name="Icono">Icono de bootstrap</param>
        private TipoMensaje(string Clase, string Icono)
        {
            this.Clase = Clase;
            this.Icono = Icono;
        }

        public override string ToString()
        {
            return Clase;
        }
    }
}