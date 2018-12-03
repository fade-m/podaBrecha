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
    public partial class NecesidadesAreas : System.Web.UI.Page
    {

        private Usuario Usuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {
                string clave = Request.QueryString["id"];

                string Filas = "";
                List<NecesidadDetalle> NecesidadesDetalle = new List<NecesidadDetalle>();
                NecesidadesDetalle = NecesidadDetalleDAO.Listar().Where(p => p.ClaveNecesidad == Convert.ToInt32(clave)).ToList();
                foreach (NecesidadDetalle p in NecesidadesDetalle)
                {
                    p.Rellenar();

                    if (p.TipoConcepto == null)
                    {
                        Filas += Disenio.GenerarFilaTabla(p.Volumen.ToString(),
                        p.PrecioUnitario.ToString(),
                        p.Concepto.ToString(),
                        "");
                    }
                    else
                    {
                        Filas += Disenio.GenerarFilaTabla(p.Volumen.ToString(),
                        p.PrecioUnitario.ToString(),
                        p.Concepto.ToString(),
                        p.TipoConcepto.ToString());
                    }


                }
                litTBody.Text = Filas;

            }
            

        }
    }
}