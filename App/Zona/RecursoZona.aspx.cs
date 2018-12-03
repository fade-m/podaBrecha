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
    public partial class RecursoZona : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        List<Modelo.Area> Areas = new List<Modelo.Area>();
        PresupuestoZona PresupuestoZonaActivo = new PresupuestoZona();
        List<PresupuestoZona> PresupuestosZona = new List<PresupuestoZona>();
        List<PresupuestoArea> PresupuestosAreas = new List<PresupuestoArea>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            
            if (!IsPostBack)
            {

                Periodo Periodo = Usuario.ConsultarPeriodoActual();
                periodoActual.Text = Periodo.Descripcion.ToString();

                PresupuestosZona = Usuario.Zona.Rellenar().Presupuestos;
                Areas = Usuario.Zona.Rellenar().Areas;
              
                foreach (PresupuestoZona p in PresupuestosZona)
                {
                    if (p.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
                        litPrep.Text = p.Monto.ToString();
                        PresupuestoZonaActivo = p;
                        break;
                    }
                    
                }
                string Filas = "";
                foreach (Modelo.Area a in Areas)
                {
                    List<PresupuestoArea> aux = a.Rellenar().Presupuestos.Where(p => p.ClavePresupuestoZona == PresupuestoZonaActivo.Clave).ToList();
                    PresupuestosAreas.Add(aux[0]);
                }
                
                if (PresupuestoZonaActivo.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                {
                    foreach (Modelo.PresupuestoArea r in PresupuestosAreas)
                    {
                        r.Rellenar();
                        string url = ResolveUrl("~/App/Zona/PresupuestosArea.aspx?id=" + r.Area.Clave);
                        Periodo periodo = r.PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo;
                        Filas += Disenio.GenerarFilaTabla(periodo.Descripcion,
                            r.Area.Nombre,
                            "$ " + r.Monto.ToString(),
                            "<a href='" + url + "' class='btn btn-default btn-block'>Historial</a>");
                    }
                }
                litTBody.Text = Filas;
                GenerarGraficaPastel();
            }
        }

  
        private void GenerarGraficaPastel()
        {
            litScriptChart.Text = Disenio.GenerarDatosGraficaPastel(Areas, z =>
            {
                return new string[] { z.Nombre, z.PresupuestoActual(PresupuestoZonaActivo.Clave).Monto.ToString() };
            });
        }

    }
}