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

    public partial class ProgramaEjecucionArea : System.Web.UI.Page
    {
        private Usuario usuario = null;
        private Periodo periodo = null;
        private List<Necesidad> necesidades = new List<Necesidad>();


        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();

            string idArea = Request.QueryString["id"];

            if (!IsPostBack)
            {
                necesidades = NecesidadDAO.Listar().Where(r => ((r.ClaveArea == Convert.ToInt32(idArea)) )).ToList();


                string Filas = "";
                foreach (Necesidad p in necesidades)
                {
                    if (ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == p.Clave).Count() != 0)
                    {
                        p.Rellenar();
                        string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                        Filas += Disenio.GenerarFilaTabla(
                            p.FechaCreacion.ToShortDateString(),
                            p.Area.Rellenar().Nombre,
                            p.Periodo.Rellenar().Descripcion,
                            p.Estatus.Rellenar().Descripcion,
                            "<a href='" + url + "' class='btn btn-default btn-block'>Seleccionar</a>");
                    }else
                    {
                        p.Rellenar();
                        string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                        Filas += Disenio.GenerarFilaTabla(
                            p.FechaCreacion.ToShortDateString(),
                            p.Area.Rellenar().Nombre,
                            p.Periodo.Rellenar().Descripcion,
                            p.Estatus.Rellenar().Descripcion,
                            "programa de ejecucion sin asignar");
                    }

                   

                }
                litTBody.Text = Filas;
            }

        }
    }
}