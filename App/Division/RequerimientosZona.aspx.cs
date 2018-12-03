using PodaProject.DataAccess;
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
    public partial class RequerimientosZona : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        public Modelo.Zona Zona = null;

        protected List<Modelo.Area> Areas = new List<Modelo.Area>();
        protected Periodo PeriodoSeleccionado = null;
        protected PresupuestoZona PresupuestoZona = null;
        protected double NecesidadTotalAreas = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            string ZonaId = Request.QueryString["id"];
            if (ZonaId == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se eligió un zona",
                    Contenido = "No se ha elegido una zona",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Requerimientos.aspx"));
            }


            Zona = ZonaDAO.Get(Convert.ToInt32(ZonaId)).Rellenar();
            if (Zona == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se encontró la zona seleccionado",
                    Contenido = "El sistema no ha encontrado la zona seleccionado",
                    Tipo = TipoMensaje.ERROR
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Requerimientos.aspx"));
            }
            

            if (!IsPostBack)
            {
                PeriodoSeleccionado = Usuario.ConsultarPeriodoActual();

                PresupuestoDivision Actual = Usuario.Division.PresupuestoActual(PeriodoSeleccionado.Clave);
                PresupuestoZona = Zona.PresupuestoActual(Actual.Clave);

                NecesidadTotalAreas = Zona.NecesidadTotal(PeriodoSeleccionado.Clave);

                Areas = Zona.Areas;

                presupuesto.Text = PresupuestoZona.Monto.ToString();
                necesidad.Text = Utilerias.ToCurrency(NecesidadTotalAreas);

                GenerarTablaAreas();
            }
        }

        private void GenerarTablaAreas()
        {
            litTablaAreas.Text = Disenio.GenerarTabla(Areas, a =>
            {
                Necesidad NecesidadActualArea = (a.NecesidadActual(PeriodoSeleccionado.Clave) ?? new Necesidad()).Rellenar();
                Necesidad NecesidadInicialArea = a.NecesidadInicial(PeriodoSeleccionado.Clave) ?? new Necesidad();

                string NecesidadActual = Utilerias.ToCurrency(NecesidadActualArea.CalcularImporte());
                string NecesidadInicial = Utilerias.ToCurrency(NecesidadInicialArea.CalcularImporte());

                string Estatus = NecesidadActualArea.Estatus?.Descripcion ?? "Sin registro";

                string Url = "RequerimientosArea.aspx?id=" + a.Clave;

                return new string[] { a.Nombre, NecesidadActual, NecesidadInicial, Estatus, "<a href='" + Url + "' class='btn btn-default btn-block'>Ver detalles</a>" };
            });
        }    
    }
}