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
    public partial class AsignarPresupuestos : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        private List<Modelo.Area> Areas = new List<Modelo.Area>();
        private PresupuestoZona PresupuestoZonaActivo = new PresupuestoZona();

        private List<PresupuestoZona> PresupuestosZona = new List<PresupuestoZona>();
        private List<PresupuestoArea> PresupuestosAreas = new List<PresupuestoArea>();

        private List<Necesidad> NecesidadesZona = new List<Necesidad>();
        private List<NecesidadDetalle> NecesidadZonaDetalle = new List<NecesidadDetalle>();
        private List<double> totalesNecesidades = new List<double>();
        protected PresupuestoZona prepdZona = null;
        protected double prepD = 0.0;

        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario = Utilerias.FiltrarUsuario(this);
            ChecarMensaje();

            if (!IsPostBack)
            {
                

                Periodo Periodo = Usuario.ConsultarPeriodoActual();
                PresupuestosZona = Usuario.Zona.Rellenar().Presupuestos;
                periodoActual.Text = Periodo.Descripcion.ToString();
                

                List<PresupuestoZona> presupuestos = Usuario.Rellenar().Zona.Rellenar().Presupuestos;
                foreach (PresupuestoZona p in presupuestos)
                {
                    if (p.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
                        prepZona.Text = p.Monto.ToString();
                        prepdZona = p;
                        prepD = prepdZona.PresupuestoDisponible();
                        break;
                    }
                }

                List<Modelo.Area> AreasZona = new List<Modelo.Area>();
                AreasZona = Usuario.Zona.Rellenar().Areas;
                foreach (Modelo.Area a in AreasZona)
                {
                    List<Necesidad> aux = NecesidadDAO.Listar().Where(p => p.ClaveArea == a.Clave && p.ClaveEstatus == 4).ToList();
                    if (aux.Count != 0)
                    {
                        foreach (Necesidad z in aux.Where(p=>p.ClavePeriodo == Periodo.Clave))
                        {
                            NecesidadesZona.Add(z);
                        }
                    }
                }
                foreach (Necesidad n in NecesidadesZona)
                {
                    List<NecesidadDetalle> aux = NecesidadDetalleDAO.Listar().Where(p => p.ClaveNecesidad == n.Clave).ToList();
                    if (aux.Count != 0)
                    {
                        double totales = 0;
                        foreach (NecesidadDetalle a in aux)
                        {
                            double totalArea = a.Volumen * a.PrecioUnitario;
                            totales += totalArea;
                            NecesidadZonaDetalle.Add(a);
                        }
                        totalesNecesidades.Add(totales);
                    }

                }


                PresupuestosZona = Usuario.Zona.Rellenar().Presupuestos;
                Areas = Usuario.Zona.Rellenar().Areas;


                foreach (PresupuestoZona p in PresupuestosZona)
                {
                    if (p.Rellenar().PresupuestoDivisional.Rellenar().Periodo.EsActivo)
                    {
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
                    int x = 0;
                    int bandera = totalesNecesidades.Count;
                    foreach (Modelo.PresupuestoArea r in PresupuestosAreas)
                    {
                        r.Rellenar();
                        Periodo periodo = r.PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo;
                        if (x < bandera)
                        {
                            Filas += Disenio.GenerarFilaTabla(r.Area.Nombre,
                                "$ " + totalesNecesidades[x].ToString(),
                                "$ " + r.Monto.ToString(),
                                "<div class='input-group'>" +
                                    "<span class='input-group-addon'><i class='fa fa-dollar'></i></span>" +
                                    "<input value ='" + r.Monto +"'"+" name='prepz" + r.Clave +"'"+ " id = 'txtprep'"+"type='text' class='form-control' value='' onkeyup='presupuesto(this);'/>" +
                                "</div>");
                            id++;
                            x++;
                        }
                        else
                        {
                            Filas += Disenio.GenerarFilaTabla(r.Area.Nombre,
                               "$ 0",
                               "$ " + r.Monto.ToString(),
                               "<div class='input-group'>" +
                                   "<span class='input-group-addon'><i class='fa fa-dollar'></i></span>" +
                                   "<input value ='" + r.Monto + "'" + " name='prepz" + r.Clave + "'" + " id = 'txtprep'" + "type='text' class='form-control' value='' onkeyup='presupuesto(this);'/>" +
                                "</div>");
                            id++;
                            x++;

                        }
                    }

                }
                litTBody.Text = Filas;
                
            }
           
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