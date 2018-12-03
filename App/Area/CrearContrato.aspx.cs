using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Area
{
    public partial class CrearContrato : System.Web.UI.Page
    {

        List<EstatusContrato> estatusContrato;
        List<Contratista> contratistas;
        List<Modalidad> modalidades;
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                estatusContrato = new List<EstatusContrato>();
                estatusContrato = EstatusContratoDAO.Listar();
                cmbEstatus.DataSource = estatusContrato;
                cmbEstatus.DataBind();

                contratistas = new List<Contratista>();
                contratistas = ContratistaDAO.Listar();
                cmbContratista.DataSource = contratistas;
                cmbContratista.DataBind();

                modalidades = new List<Modalidad>();
                modalidades = ModalidadDAO.Listar();
                cmbModalidad.DataSource = modalidades;
                cmbModalidad.DataBind();

            }

        }

        protected void cmbEstatusContrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbContratista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnCrearContrato_Click(object sender, EventArgs e)
        {

            try
            {
                Contrato contrato = new Contrato();
                contrato.Codigo = txtCodigo.Text;
                contrato.FechaAdjudicacion = Utilerias.ParsearFecha(txtFechaAdjudicacion.Text);
                contrato.FechaInicio = Utilerias.ParsearFecha(txtFechaInicio.Text);
                contrato.FechaCreacion = Utilerias.ParsearFecha(txtFechaCreacion.Text);
                contrato.Pdf = "";
                contrato.ClaveContratista = Convert.ToInt32(cmbContratista.SelectedValue);
                contrato.ClaveEstatus = Convert.ToInt32(cmbEstatus.SelectedValue);
                contrato.ClaveModalidad = Convert.ToInt32(cmbModalidad.SelectedValue);

                Contrato nuevoContrato = ContratoDAO.Insertar(contrato);

                if (nuevoContrato == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error al insertar contrato",
                        Contenido = "Error,  Para más información consulte al administrador del sistema",
                        Tipo = TipoMensaje.ERROR
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }else
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Contrato creado!",
                        Contenido = "El contrato ya está dado de alta en el sistema",
                        Tipo = TipoMensaje.EXITO
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }
            }
            catch (Exception exc)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error al insertar contrato",
                    Contenido = "Error,  Para más información consulte al administrador del sistema, " + exc,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }


        }

    }
}