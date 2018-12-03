using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Division
{
    public partial class Requerimientos : Page
    {
        public Usuario Usuario = null;

        protected Periodo PeriodoActual = null;
        protected PresupuestoDivision PresupuestoActual = null;
        protected List<Modelo.Zona> Zonas = new List<Modelo.Zona>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            ChecarMensaje();

            if (!IsPostBack)
            {
                PeriodoActual = Usuario.ConsultarPeriodoActual();

                if (PeriodoActual == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Ejercicio no encontrado",
                        Contenido = "El sistema no ha encontrado un ejercicio activo",
                        Tipo = TipoMensaje.ALERTA
                    };

                    Session["mensaje"] = Mensaje;
                    Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
                }

                PresupuestoActual = Usuario.Division.PresupuestoActual(PeriodoActual.Clave);

                Zonas = Usuario.Division.Rellenar().Zonas;

                presupuesto.Text = PresupuestoActual.ToString();
                necesidad.Text = Usuario.Division.NecesidadTotal(PeriodoActual.Clave).ToString();


                LlenarTablaZonas();
            }
        }

        private void LlenarTablaZonas()
        {
            litTablaBody.Text = Disenio.GenerarTabla(Zonas, z =>
            {
                string NecesidadActual = Utilerias.ToCurrency(z.NecesidadTotal(PeriodoActual.Clave));
                string NecesidadInicial = Utilerias.ToCurrency(z.NecesidadInicial(PeriodoActual.Clave));

                string Url = "RequerimientosZona.aspx?id=" + z.Clave;

                return new string[] { z.Nombre, NecesidadActual, NecesidadInicial, "<a href='" + Url + "' class='btn btn-default btn-block'>Ver detalles</a>"};
            });
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

    }
}