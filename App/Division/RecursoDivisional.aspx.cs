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
    public partial class RecursoDivisional : Page
    {
        public Usuario Usuario = null;
        
        protected PresupuestoDivision PresupuestoSeleccionado = null;
        protected List<PresupuestoZona> PresupuestosZonas = new List<PresupuestoZona>();
        protected List<Modelo.Zona> Zonas = new List<Modelo.Zona>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            string PresupuestoDivisionID = Request.QueryString["id"];
            if (PresupuestoDivisionID == null)
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

            PresupuestoSeleccionado = PresupuestoDivisionDAO.Get(Convert.ToInt32(PresupuestoDivisionID)).Rellenar();
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
            
            Zonas = Usuario.Division.Rellenar().Zonas;
            presupuesto.Text = PresupuestoSeleccionado.Monto.ToString();
            presupuestoDisponible.Text = PresupuestoSeleccionado.PresupuestoDisponible().ToString();

            GenerarGraficaPastel();
            GenerarTablaZonas();
        }

        private void GenerarGraficaPastel()
        {
            litScriptChart.Text = Disenio.GenerarDatosGraficaPastel(Zonas, z =>
            {
                return new string[] { z.Nombre, z.PresupuestoActual(PresupuestoSeleccionado.Clave).Monto.ToString() };
            });
        }

        private void GenerarTablaZonas()
        {
            litTablaBody.Text = Disenio.GenerarTabla(Zonas, z =>
            {
                PresupuestoZona PresupuestoZona = z.PresupuestoActual(PresupuestoSeleccionado.Clave);
                string Url = "RecursoZona.aspx?id=" + PresupuestoZona.Clave;
                return new string[] { PresupuestoSeleccionado.Periodo.Descripcion, z.Nombre,
                    PresupuestoZona.ToString(), "<a href='" + Url + "' class='btn btn-block btn-md btn-default'>Ver detalles</a>" };
            });
        }
    }
}