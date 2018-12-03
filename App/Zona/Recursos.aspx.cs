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
    public partial class Recursos : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        private List<PresupuestoZona> presupuestos = new List<PresupuestoZona>();
        private List<PresupuestoZona> presupuestosAnteriores = new List<PresupuestoZona>();
        public List<Periodo> Periodos = new List<Periodo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {
                Periodo Periodo = Usuario.ConsultarPeriodoActual();
    
                periodoActual.Text = Periodo.Descripcion.ToString();

                string Filas = "";
                presupuestos = Usuario.Rellenar().Zona.Rellenar().Presupuestos;

                foreach (PresupuestoZona p in presupuestos)
                {
                    if (p.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
                        litPrep.Text = p.Monto.ToString();
                        break;
                    }
                }

                Periodo PeriodoSelec = Usuario.ConsultarPeriodoActual();

                

                Periodos = Usuario.ConsultarPeriodos();
                List<Periodo> PeriodosAnteriores = Periodos.Where(p => !p.EsActivo).OrderByDescending(p => p.Clave).ToList();

                foreach (Periodo p in PeriodosAnteriores)
                {
                    p.Rellenar();
                    PresupuestoDivision actual = Usuario.Division.PresupuestoActual(p.Clave);
                    PresupuestoZona PrepZona = Usuario.Rellenar().Zona.PresupuestoActual(actual.Clave);
                    presupuestosAnteriores.Add(PrepZona);
                }
                
                foreach (PresupuestoZona p in presupuestosAnteriores)
                {
                    p.Rellenar();
                    Filas += Disenio.GenerarFilaTabla(p.PresupuestoDivisional.Rellenar().Periodo.Descripcion,
                            "$ " + p.Monto.ToString());
                    
                }
                litTBody.Text = Filas;
                LlenarGraficaBarras();
            }
        }

        private void LlenarGraficaBarras()
        {
            List<Periodo> UltimosPeriodos = Utilerias.TomarUltimos(Periodos, 5);

            litScriptChart.Text = Disenio.GenerarDatosGraficaDeBarras(UltimosPeriodos, p =>
            {
                p.Rellenar();
                PresupuestoDivision actual = Usuario.Division.PresupuestoActual(p.Clave);
                PresupuestoZona PrepZona = Usuario.Rellenar().Zona.PresupuestoActual(actual.Clave);
                return new string[] { p.Descripcion, PrepZona.Monto.ToString() };
            });
        }

    }
}