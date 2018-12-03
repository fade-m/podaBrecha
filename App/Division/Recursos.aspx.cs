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
    public partial class Recursos : Page
    {
        public Usuario Usuario = null;
        public List<Periodo> Periodos = new List<Periodo>();

        protected List<Periodo> PeriodosAnteriores = new List<Periodo>();
        protected Periodo PeriodoActual = new Periodo();

        protected PresupuestoDivision PresupuestoActual = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            Periodos = Usuario.ConsultarPeriodos();

            PeriodoActual = Periodos.FirstOrDefault(p => p.EsActivo);
            PeriodosAnteriores = Periodos.Where(p => !p.EsActivo).OrderByDescending(p => p.Clave).ToList();

            ChecarMensaje();

            if (PeriodoActual == null)
            {
                Mensaje MensajeAlerta = new Mensaje
                {
                    Titulo = "No se encontró un ejercicio activo",
                    Contenido = "El sistema no ha encontrado un ejercicio activo",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = MensajeAlerta;
                Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
            }

            PresupuestoActual = PeriodoActual.ConsultarPresupuestoActual();

            if (!IsPostBack)
            {
                LlenarTablaAnteriores();
                LlenarGraficaBarras();
            }
        }
        
        private void LlenarTablaAnteriores()
        {
            litTablaBody.Text = Disenio.GenerarTabla(PeriodosAnteriores, p =>
            {
                p.Rellenar();
                string Url = ResolveUrl("~/App/Division/RecursoDivisional.aspx?id=" + p.ConsultarPresupuestoActual().Clave);

                return new string[]
                {
                    p.Descripcion,
                    p.ConsultarPresupuestoActual().ToString(),
                    "<a href='" + Url + "' class='btn btn-default btn-block'>Ver detalles</a>"
                };
            });
        }

        private void LlenarGraficaBarras()
        {
            List<Periodo> UltimosPeriodos = Utilerias.TomarUltimos(Periodos, 5);

            litScriptChart.Text = Disenio.GenerarDatosGraficaDeBarras(UltimosPeriodos, p =>
            {
                return new string[] { p.Descripcion, p.ConsultarPresupuestoActual().Monto.ToString() };
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