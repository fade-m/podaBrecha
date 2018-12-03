using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.DataAccess;
using PodaProject.Util;
using PodaProject.Modelo;

namespace PodaProject.App.Area
{
    public partial class AsignarContrato : System.Web.UI.Page
    {
        private Usuario usuario;
        private Periodo periodo;
        private List<Necesidad> necesidadesArea = new List<Necesidad>();
        private List<Programa> programas = new List<Programa>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();
            necesidadesArea = NecesidadDAO.Listar().Where(r => r.ClaveArea == usuario.ClaveArea).ToList();
           

            if (!IsPostBack)
            {
                string Filas = "";
                foreach (Necesidad n in necesidadesArea)
                {

                    List<Programa> programasAux = ProgramaDAO.Listar().Where(x => x.ClaveNecesidad == n.Clave).ToList();
                    foreach (Programa p in programasAux)
                    {
                        List<ProgramaDetalle> programaDetalle = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == p.Clave).ToList();
                        p.Rellenar();
                        n.Rellenar();
                        string url = ResolveUrl("~/App/Area/AsignarContratoANecesidad.aspx?id=" + p.Clave);

                        if(programaDetalle.Count == 0)
                        {
                            Mensaje mensaje = new Mensaje()
                            {
                                Titulo = "ERROR!",
                                Contenido = "No hay contratos para asignar",
                                Tipo = TipoMensaje.ERROR
                            };
                            litMensaje.Text = Disenio.GenerarMensaje(mensaje);
                            break;
                        }

                        if(programaDetalle.First().Rellenar().Contrato != null)
                        {
                            Filas += Disenio.GenerarFilaTabla(
                           p.FechaCreacion.ToShortDateString(),
                           n.FechaCreacion.ToShortDateString(),
                           n.Area.Rellenar().Nombre,
                           n.Periodo.Rellenar().Descripcion,
                           n.Estatus.Descripcion,
                           programaDetalle.First().Rellenar().Contrato.Rellenar().Codigo,
                           "<a href='" + url + "' class='btn btn-default btn-block'>Asignar contrato</a>");
                        }else
                        {
                            Filas += Disenio.GenerarFilaTabla(
                          p.FechaCreacion.ToShortDateString(),
                          n.FechaCreacion.ToShortDateString(),
                          n.Area.Rellenar().Nombre,
                          n.Periodo.Rellenar().Descripcion,
                          n.Estatus.Descripcion,
                          "contrato sin asignar",
                          "<a href='" + url + "' class='btn btn-default btn-block'>Asignar contrato</a>");
                        }
                       

                    }

                   
                }
                litTBody.Text = Filas;
            }

        }
    }
}