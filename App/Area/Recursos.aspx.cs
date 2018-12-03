using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Area
{
    public partial class Recursos : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        List<PresupuestoArea> presupuestos = new List<PresupuestoArea>();
        private List<PresupuestoArea> presupuestosAnteriores = new List<PresupuestoArea>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if(!IsPostBack)
            {
                string Filas = "";
                presupuestos = Usuario.Rellenar().Area.Rellenar().Presupuestos;
                foreach(PresupuestoArea p in presupuestos)
                {
                    if (p.Rellenar().PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
                        Periodo Periodo = Usuario.ConsultarPeriodoActual();
                        txtAno.Text = Periodo.Descripcion.ToString();
                        txtPresupuesto.Text = p.Monto.ToString();
                        break;
                    }
                }


                List<Periodo> Periodos = Usuario.ConsultarPeriodos();
                List<Periodo> PeriodosAnteriores = Periodos.Where(p => !p.EsActivo).OrderByDescending(p => p.Clave).ToList();

                foreach (Periodo p in PeriodosAnteriores)
                {
                    p.Rellenar();
                    PresupuestoDivision actual = Usuario.Division.PresupuestoActual(p.Clave);
                    PresupuestoZona PrepZona = Usuario.Rellenar().Zona.PresupuestoActual(actual.Clave);
                    PresupuestoArea PrepArea = Usuario.Rellenar().Area.PresupuestoActual(PrepZona.Clave);
                    presupuestosAnteriores.Add(PrepArea);
                }

                foreach (PresupuestoArea p in presupuestosAnteriores)
                {
                    p.Rellenar();
                    Periodo periodo = p.Rellenar().PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo;
                    Filas += Disenio.GenerarFilaTabla(p.PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo.Descripcion,
                        "$ " + p.Monto.ToString());

                }
                litTBody.Text = Filas;

            }

        }
    }
}