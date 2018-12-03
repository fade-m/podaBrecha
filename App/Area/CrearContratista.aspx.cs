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
    public partial class CrearContratista : System.Web.UI.Page
    {
        private Usuario Usuario = null;
        private Periodo Periodo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            Periodo = Usuario.ConsultarPeriodoActual();

            if (!IsPostBack)
            {
                try
                {

                }
                catch (Exception Ex)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error en el proceso del crear contratista ",
                        Contenido = Ex.Message,
                        Tipo = TipoMensaje.ERROR
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }

            }

        }


        protected void btnCrearContratista_Click(object sender, EventArgs e)
        {

            try
            {
                Contratista contratista = new Contratista();
                contratista.Nombre = txtNombre.Text;
                contratista.RazonSocial = txtRazonSocial.Text;

                Contratista nuevoContratista = ContratistaDAO.Insertar(contratista);

                if(nuevoContratista != null)
                {

                }else
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error al insertar contratista",
                        Contenido = "Error,  Para más información consulte al administrador del sistema",
                        Tipo = TipoMensaje.ERROR
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }
            }
            catch (Exception exc)
            {

            }


        }

    }
}