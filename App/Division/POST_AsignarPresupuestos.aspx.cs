using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Division
{
    public partial class POST_AsignarPresupuestos : Page
    {
        public Usuario Usuario = null;

        private string[] LlavesZonas = new string[] { };

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            LlavesZonas = Request.QueryString.AllKeys.Where(s => s.StartsWith("prepz")).ToArray();

            if (LlavesZonas.Length == 0)
            {
                Response.Redirect(ResolveUrl("~/App/Division/AsignarPresupuestos.aspx"));
            }

            if (!PuedeActualizarse())
            {
                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "No se puede actualizar los presupeustos de las zonas",
                    Contenido = "El total del recurso asignado a las zonas no debe superar al recurso asignado de la división",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/AsignarPresupuestos.aspx"));
            }

            int Actualizados = 0;
            foreach(string k in LlavesZonas)
            {
                int ClavePresupuesto = Convert.ToInt32(k.Split('z')[1]);

                PresupuestoZona Presupuesto = PresupuestoZonaDAO.Get(ClavePresupuesto);
                Presupuesto.Monto = Convert.ToDouble(Request.QueryString[k]);

                PresupuestoZona Actualizado = PresupuestoZonaDAO.Actualizar(ClavePresupuesto, Presupuesto);
                if (Actualizado != null)
                {
                    Actualizados++;
                }
            }

            //Todos se actualizaron
            if (Request.QueryString.Count - 1 == Actualizados)
            {
                Mensaje MensajeExito = new Mensaje
                {
                    Titulo = "Presupuestos de zonas actualizadas",
                    Contenido = "Se definieron los recursos de zonas exitósamente",
                    Tipo = TipoMensaje.EXITO
                };

                Session["mensaje"] = MensajeExito;
                Response.Redirect(ResolveUrl("~/App/Division/AsignarPresupuestos.aspx"));
            }
            else
            {
                Mensaje MensajeAlerta = new Mensaje
                {
                    Titulo = "¡Atención!",
                    Contenido = "Puede que algunos recursos no se hayan designado correctamente",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = MensajeAlerta;
                Response.Redirect(ResolveUrl("~/App/Division/AsignarPresupuestos.aspx"));
            }
        }

        public bool PuedeActualizarse()
        {
            string MontoDivisional = Request.QueryString["prepd"];
            if (MontoDivisional == null)
            {
                return false;
            }

            double MontoDivision = Convert.ToDouble(MontoDivisional);
            double MontoZonas = 0.0;

            foreach(string k in LlavesZonas)
            {
                MontoZonas += Convert.ToDouble(Request.QueryString[k]);
            }

            return MontoDivision >= MontoZonas;
        }
    }
}