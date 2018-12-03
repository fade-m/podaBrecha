using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.Modelo;
using PodaProject.DataAccess;
using PodaProject.Util;


namespace PodaProject.App.Division
{
    public partial class ProgramasEjecucionZona : System.Web.UI.Page
    {
        private Usuario usuario = null;
        private Periodo periodo = null;
        private List<Modelo.Area> areas = new List<Modelo.Area>();

        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();
            string idZona = Request.QueryString["id"];
            
            if (!IsPostBack)
            {
                areas = AreaDAO.Listar().Where(r => r.ClaveZona == Convert.ToInt32(idZona)).ToList();

                string Filas = "";
                foreach (Modelo.Area p in areas)
                {
                    p.Rellenar();
                    string url = ResolveUrl("~/App/Division/ProgramaEjecucionArea.aspx?id=" + p.Clave);
                    Filas += Disenio.GenerarFilaTabla(
                        p.Nombre,
                        p.Codigo,
                        "<a href='" + url + "' class='btn btn-default btn-block'>Seleccionar</a>");
                }
                litTBody.Text = Filas;
            }

        }
    }
}