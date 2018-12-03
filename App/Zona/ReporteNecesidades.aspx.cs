using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Zona
{
    public partial class ReporteNecesidades : System.Web.UI.Page
    {
        public Usuario Usuario = null;

        protected Periodo PeriodoSeleccionado = null;
        protected List<Modelo.Area> Areas = new List<Modelo.Area>();
        protected PresupuestoZona RecursoZona = null;
        protected List<Concepto> Conceptos = new List<Concepto>();

        protected double NecesidadTotal = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {

                PeriodoSeleccionado = Usuario.ConsultarPeriodoActual();
                Areas = Usuario.Zona.Rellenar().Areas;

                PresupuestoDivision RecursoDivision = Usuario.Division.PresupuestoActual(PeriodoSeleccionado.Clave);
                RecursoZona = Usuario.Zona.PresupuestoActual(RecursoDivision.Clave);
                Conceptos = ConceptoDAO.Listar();

                NecesidadTotal = Usuario.Zona.NecesidadTotal(PeriodoSeleccionado.Clave);

                //Generar reportes por concepto
                foreach (Concepto c in Conceptos)
                {
                    litReporte.Text += Disenio.GenerarReporteConcepto(c, Areas, PeriodoSeleccionado.Clave) + "<br />";
                }

                //Generar gráfica
                litScriptChart.Text = Disenio.GenerarDatosGraficaPastel(Conceptos, c =>
                {
                    return new string[] { c.Descripcion, c.CalcularImporteTotal(Areas, PeriodoSeleccionado.Clave).ToString() };
                });
            }

        }

        private void ChecarMensaje()
        {

        }

    }
}