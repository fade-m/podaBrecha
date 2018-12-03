using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario Usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario == null)
            {
                Response.Redirect(ResolveUrl("~/Login.aspx"));
            }
        }
    }
}