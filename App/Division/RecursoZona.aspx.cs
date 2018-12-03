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
    public partial class RecursoZona : Page
    {
        public Usuario Usuario = null;

        protected PresupuestoZona PresupuestoSeleccionado;
        protected List<Modelo.Area> Areas = new List<Modelo.Area>();

        protected Periodo Periodo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            string PresupuestoZonaId = Request.QueryString["id"];
            if (PresupuestoZonaId == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se eligió un presupuesto",
                    Contenido = "No se ha elegido un presupuesto",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Recursos.aspx"));
            }

            PresupuestoSeleccionado = PresupuestoZonaDAO.Get(Convert.ToInt32(PresupuestoZonaId)).Rellenar();
            if (PresupuestoSeleccionado == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se encontró el presupuesto seleccionado",
                    Contenido = "No se ha encontrado el presupuesto seleccionado",
                    Tipo = TipoMensaje.ERROR
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Recursos.aspx"));
            }

            Areas = PresupuestoSeleccionado.Zona.Rellenar().Areas;
            Periodo = PresupuestoSeleccionado.PresupuestoDivisional.Rellenar().Periodo;

            presupuesto.Text = PresupuestoSeleccionado.Monto.ToString();
            disponible.Text = PresupuestoSeleccionado.PresupuestoDisponible().ToString();

            GenerarTabla();
            GenerarGrafica();
        }


        private void GenerarTabla()
        {
            litTablaBody.Text = Disenio.GenerarTabla(Areas, a => {
                PresupuestoArea Presupuesto = a.PresupuestoActual(PresupuestoSeleccionado.Clave);
            
                return new string[] { Periodo.Descripcion, a.Nombre, Presupuesto.ToString()};
            });
        }


        private void GenerarGrafica()
        {
            litScriptChart.Text = Disenio.GenerarDatosGraficaPastel(Areas, a =>
            {
                return new string[] { a.Nombre, a.PresupuestoActual(PresupuestoSeleccionado.Clave).Monto.ToString()};
            });
        }

    }
}