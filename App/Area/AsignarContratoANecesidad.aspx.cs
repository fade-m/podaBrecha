using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.Modelo;
using PodaProject.DataAccess;
using PodaProject.Util;

namespace PodaProject.App.Area
{
    public partial class AsignarContratoANecesidad : System.Web.UI.Page
    {
        private Usuario usuario;
        private Periodo periodo;
        private List<Contrato> contratos = new List<Contrato>();
        private List<ProgramaDetalle> programasDetalle = new List<ProgramaDetalle>();
        private string claveP;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual();

            string clavePrograma = Request.QueryString["id"];

            if (!IsPostBack)
            {
               
                claveP = clavePrograma;

                contratos = ContratoDAO.Listar();
                cmbContrato.DataSource = contratos;
                cmbContrato.DataBind();
            }
        }

        protected void cmbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnVincular_Click(object sender, EventArgs e)
        {
            claveP = Request.QueryString["id"];
            programasDetalle = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == Convert.ToInt32(claveP)).ToList();

            foreach (ProgramaDetalle pd in programasDetalle)
            {
                pd.Rellenar();
                pd.ClaveContrato = Convert.ToInt32(cmbContrato.SelectedValue);
                try
                {
                    ProgramaDetalle programaActualizado = ProgramaDetalleDAO.Actualizar(pd.Clave, pd);

                    if (programaActualizado != null)
                    {
                        Mensaje Mensaje = new Mensaje()
                        {
                            Titulo = "Programa acutalizado",
                            Contenido = "El programa se vinculo correctamente con el contrato seleccionado",
                            Tipo = TipoMensaje.EXITO
                        };
                        litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    }
                }catch(Exception ex)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error con el programa acutalizado",
                        Contenido = "El programa no se vinculo correctamente con el contrato seleccionado" + ex.Message,
                        Tipo = TipoMensaje.ALERTA
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    return;
                }
               
            }
        }

    }
}