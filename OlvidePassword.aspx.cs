using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject
{
    public partial class OlvidePassword : System.Web.UI.Page
    {
        public Usuario Usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario != null)
            {
                Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
            }

            if (!IsPostBack)
            {
                litMensaje.Text = "";
            }
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            Mensaje Mensaje = new Mensaje
            {
                Titulo = "Correo enviado exitósamente",
                Contenido = "Se ha enviado a su correo la información necesaria para recuperar su cuenta",
                Tipo = TipoMensaje.EXITO
            };

            litMensaje.Text = Disenio.GenerarMensaje(Mensaje); 
            /*
            string Correo = txtCorreo.Text;

            Usuario Usuario = UsuarioDAO.BuscarPorCorreo(Correo);
            if (Usuario == null)
            {

                return;
            }

            string Body = File.ReadAllText(HttpContext.Current.Server.MapPath("Plantillas/RecuperarPassword.html"))
                  .Replace("%Nombre%", Usuario.Nombre)
                  .Replace("%Apellidos%", Usuario.Apellidos)
                  .Replace("%Password%", Usuario.Password);

            Utilerias.EnviarEmail(Correo, "Recuperar Contraseña", Body);
            */
        }
    }
}