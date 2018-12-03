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
    public partial class AreaPresupuestos : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        List<PresupuestoArea> PresupuestosArea = new List<PresupuestoArea>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);


            string AreaId = Request.QueryString["id"];

            string Filas = "";
            if(AreaId != null)
            {
                Modelo.Area Area = AreaDAO.Get(Convert.ToInt32(AreaId));
                PresupuestosArea =  Area.Rellenar().Presupuestos;

                foreach (PresupuestoArea a in PresupuestosArea)
                {
                    a.Rellenar();
                    Periodo periodo = a.PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo;
                    Filas += Disenio.GenerarFilaTabla(a.Area.Rellenar().Nombre,
                        "$ " + a.Monto.ToString(),a.Rellenar().PresupuestoZona.Rellenar().PresupuestoDivisional.Rellenar().Periodo.ToString());
                }
                
                litTBody.Text = Filas;
            }

        }
    }
}