using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PodaProject
{
    public partial class Main : MasterPage
    {
        /// <summary>
        /// El usuario logeado
        /// </summary>
        public Usuario Usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(Page);
            
            if (!IsPostBack)
            {
                List<Menu> Menus = MenuDAO.ListarPorRol(Usuario.ClaveRol);
                List<Menu> Padres = Menu.JerarquizarMenus(Menus);

                litMenu.Text = Disenio.GenerarMenu(Padres, ResolveUrl);

                if (Usuario.EsJefeDivision)
                {
                    litRol.Text = Usuario.Division.Nombre;
                }
                else if (Usuario.EsJefeZona)
                {
                    litRol.Text = "ZONA " + Usuario.Zona.Nombre;
                }
                else if (Usuario.EsJefeArea)
                {
                    litRol.Text = "ÁREA " + Usuario.Area.Nombre;
                }
            }
        }
    }
}