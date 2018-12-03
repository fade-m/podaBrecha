using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario Usuario = (Usuario)Session["usuario"];
            if (Usuario != null)
            {
                Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
            }

            if (!IsPostBack)
            {
                litMensaje.Text = "";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Correo = txtCorreo.Text;
            string Password = txtPassword.Text;
            
            try
            {
                Usuario Usuario = UsuarioDAO.Login(Correo, Password)?.Rellenar();
                if (Usuario == null)
                {
                    Mensaje Mensaje = new Mensaje
                    {
                        Titulo = "Usuario no encontrado",
                        Contenido = "No se ha encontrado un usuario con estas credenciales",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);

                    return;
                }

                Session["usuario"] = Usuario;

                Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
            }
            catch(Exception ex)
            {
                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "Error al iniciar sesión",
                    Contenido = ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }
            
        }
    }
}