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
    public partial class Necesidades : System.Web.UI.Page
    {

        private Usuario Usuario = null;
        private List<PresupuestoZona> PresupuestosZona = new List<PresupuestoZona>();
        private List<Necesidad> NecesidadesZona = new List<Necesidad>();
        private List<NecesidadDetalle> NecesidadZonaDetalle = new List<NecesidadDetalle>();
        private List<double> totalesNecesidades = new List<double>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {

                Periodo Periodo = Usuario.ConsultarPeriodoActual();
                periodoActual.Text = Periodo.Descripcion.ToString();
             

                PresupuestosZona = Usuario.Rellenar().Zona.Rellenar().Presupuestos;
                foreach (PresupuestoZona p in PresupuestosZona)
                {
                    if (p.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
                        presupuestoDivision.Text = p.Monto.ToString();
                        break;
                    }
                }


               
                List<Modelo.Area> AreasZona = new List<Modelo.Area>();
                AreasZona = Usuario.Zona.Rellenar().Areas;
                foreach (Modelo.Area a in AreasZona)
                {
                    List<Necesidad> aux = NecesidadDAO.Listar().Where(p => p.ClaveArea == a.Clave && p.ClaveEstatus == 4 && p.ClavePeriodo == Periodo.Clave).ToList();
                    if (aux.Count != 0 && aux.Count<1)
                    {
                        NecesidadesZona.Add(aux[0]);
                    }else if (aux.Count != 0)
                    {
                        foreach(Necesidad z in aux)
                        {
                            NecesidadesZona.Add(z);
                        }
                    }
                }
                foreach(Necesidad n in NecesidadesZona)
                {
                    List<NecesidadDetalle> aux = NecesidadDetalleDAO.Listar().Where(p => p.ClaveNecesidad == n.Clave).ToList();
                    if (aux.Count != 0 && aux.Count<1)
                    {
                        NecesidadZonaDetalle.Add(aux[0]);

                        double totales = 0;
                        foreach (NecesidadDetalle a in aux)
                        {
                            double totalArea = a.Volumen * a.PrecioUnitario;
                            totales += totalArea;
                            NecesidadZonaDetalle.Add(a);
                        }
                        totalesNecesidades.Add(totales);

                    }
                    else if(aux.Count != 0)
                    {
                        double totales = 0;
                        foreach(NecesidadDetalle a in aux)
                        {
                            double totalArea = a.Volumen * a.PrecioUnitario;
                            totales += totalArea;
                            NecesidadZonaDetalle.Add(a);
                        }
                        totalesNecesidades.Add(totales);
                    }

                }

                double total = 0;
                foreach (NecesidadDetalle n in NecesidadZonaDetalle)
                {
                    double totalArea = 0;
                    totalArea = n.Volumen * n.PrecioUnitario;
                    total += totalArea;
                    
                }
                necesidadTotal.Text = total.ToString();

                string Filas = "";
                int x = 0;
                foreach (Modelo.Necesidad r in NecesidadesZona)
                {
                    r.Rellenar();
                    string url = ResolveUrl("~/App/Zona/NecesidadesArea.aspx?id=" + r.Clave);
                    Filas += Disenio.GenerarFilaTabla(r.Area.Rellenar().Nombre,
                        "$ " + totalesNecesidades[x].ToString(),
                        "<a href='" + url + "' class='btn btn-default btn-block'>Detalles</a>");
                    x++;
                }
                litTBody.Text = Filas;


            }


        }
    }
}