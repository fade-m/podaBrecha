using System;
using System.Web.UI;

namespace PodaProject.App
{
    public partial class Salir : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(ResolveUrl("~/Login.aspx"));
        }
    }
}