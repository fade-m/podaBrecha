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
    public partial class Programa : System.Web.UI.Page
    {

        private Usuario usuario = null;
        private Periodo periodo = null;
        private Modelo.Programa programa = new Modelo.Programa();
        private List<ProgramaDetalle> programaDetalles = new List<ProgramaDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();

            string idNecesidad = Request.QueryString["id"];

            if(!IsPostBack)
            {
                programa = ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == Convert.ToInt32(idNecesidad)).First();
                
                string Filas = "";
               
                programa.Rellenar();
                Filas += Disenio.GenerarFilaTabla(
                    programa.FechaCreacion.ToShortDateString(),
                    programa.Necesidad.Rellenar().FechaCreacion.ToShortDateString());
                litTBody.Text = Filas;

                programaDetalles = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == programa.Clave).ToList();

                Filas = "";
                foreach (ProgramaDetalle p in programaDetalles)
                {
                    if(p.Rellenar().Contrato != null)
                    {
                        if (p.Rellenar().TipoConcepto != null)
                        {
                            p.Rellenar();
                            string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                            Filas += Disenio.GenerarFilaTabla(
                                p.Cantidad.ToString(),
                                p.FechaInicio.ToShortDateString(),
                                p.PrecioUnitario.ToString(),
                                p.Circuito.Rellenar().Descripcion,
                                p.Contrato.Rellenar().Codigo,
                                p.Concepto.Rellenar().Descripcion,
                                p.TipoConcepto.Rellenar().Descripcion);
                        }
                        else
                        {
                            p.Rellenar();
                            string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                            Filas += Disenio.GenerarFilaTabla(
                                p.Cantidad.ToString(),
                                p.FechaInicio.ToShortDateString(),
                                p.PrecioUnitario.ToString(),
                                p.Circuito.Rellenar().Descripcion,
                                p.Contrato.Rellenar().Codigo,
                                p.Concepto.Rellenar().Descripcion,
                                "");
                        }
                    }else
                    {
                        Mensaje Mensaje = new Mensaje()
                        {
                            Titulo = "Error!",
                            Contenido = "Esta necesidad no tiene un contrato asignado",
                            Tipo = TipoMensaje.ERROR
                        };

                        litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    }
                   
                    
                }
                litTBody2.Text = Filas;

            }
        }
    }
}