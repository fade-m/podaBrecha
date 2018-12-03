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
    public partial class Ejercicios : Page
    {
        public Usuario Usuario = null;

        protected List<Periodo> Periodos = new List<Periodo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {
                ChecarMensaje();
                LlenarTabla();
            }
        }

        private void ChecarMensaje()
        {
            Mensaje Mensaje = (Mensaje)Session["mensaje"];
            if (Mensaje != null)
            {
                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                Session["mensaje"] = null;
            }
        }

        private void LlenarTabla()
        {
            Periodos = Usuario.ConsultarPeriodos().OrderBy(p => p.FechaInicio).ToList();

            litTablaBody.Text = Disenio.GenerarTabla(Periodos, p =>
            {
                p.Rellenar();
                string Url = ResolveUrl("~/App/Division/EjercicioDetalle.aspx?id=" + p.Clave);

                return new string[]
                {
                    p.FechaInicio.ToShortDateString(),
                    p.FechaFin.ToShortDateString(),
                    p.Descripcion,
                    p.Estatus.Descripcion,
                    "<a href='" + Url + "' class='btn btn-default btn-block'>Detalles</a>"
                };
            });
        }
    }
}