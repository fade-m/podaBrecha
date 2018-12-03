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
    public partial class ProgramasEjecucion : System.Web.UI.Page
    {
        private Usuario usuario = null;
        private Periodo periodo = null;
        private List<Modelo.Zona> zonas = new List<Modelo.Zona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();

            if (!IsPostBack)
            {
                zonas = ZonaDAO.Listar().Where(r => r.ClaveDivision == usuario.ClaveDivision).ToList();

                string Filas = "";
                foreach (Modelo.Zona p in zonas)
                {
                    p.Rellenar();
                    string url = ResolveUrl("~/App/Division/ProgramasEjecucionZona.aspx?id=" + p.Clave);
                    Filas += Disenio.GenerarFilaTabla(p.Nombre,
                        p.Codigo,
                        "<a href='" + url + "' class='btn btn-default btn-block'>Seleccionar</a>");
                }
                litTBody.Text = Filas;
            }
        }
        
    }
}