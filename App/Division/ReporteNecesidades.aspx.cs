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
    public partial class ReporteNecesidades : Page
    {
        public Usuario Usuario = null;

        protected Periodo PeriodoSeleccionado = null;
        protected List<Modelo.Area> Areas = new List<Modelo.Area>();
        protected PresupuestoDivision RecursoDivisional = null;
        protected List<Concepto> Conceptos = new List<Concepto>();

        protected double NecesidadTotal = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {

                PeriodoSeleccionado = Usuario.ConsultarPeriodoActual();
                Areas = Usuario.Division.ListarAreas();
                RecursoDivisional = Usuario.Division.PresupuestoActual(PeriodoSeleccionado.Clave);
                Conceptos = ConceptoDAO.Listar();

                NecesidadTotal = Usuario.Division.NecesidadTotal(PeriodoSeleccionado.Clave);

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