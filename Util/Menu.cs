using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PodaProject.Util
{
    /// <summary>
    /// Representa una opción de menú que se encontrará dentro 
    /// la etiqueta aside de la master page
    /// </summary>
    public class Menu
    {
        public int Clave { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }

        public Menu Padre { get; set; }
        public int? ClavePadre { get; set; }

        public List<Menu> Hijos { get; set; } = new List<Menu>();

        /// <summary>
        /// Jerarquiza los menús encontrados en el procedimiento MenuListarPorRol
        /// añandiéndolos en forma de árbol
        /// </summary>
        /// <param name="Menus">Los menús que se van a jerarquizar</param>
        /// <returns>Los menús padres jerarquizados</returns>
        public static List<Menu> JerarquizarMenus(List<Menu> Menus)
        {
            List<Menu> Padres = new List<Menu>();

            foreach (Menu Menu in Menus)
            {
                //Si el menú no tiene padre
                if (!Menu.EsHijo())
                {
                    Padres.Add(Menu);
                    continue;
                }

                AgregarHijo(Padres, Menu);
            }

            return Padres.OrderBy(menu => menu.Orden).ToList();
        }

        /// <summary>
        /// Función recursiva utilizada por el método JerarquizarMenus para
        /// encontrar el padre de un menú y ser agregado como hijo
        /// </summary>
        /// <param name="Menus">La lista de menus donde posiblemente se encuentre el padre</param>
        /// <param name="Hijo">El menú hijo que será agregado</param>
        private static void AgregarHijo(List<Menu> Menus, Menu Hijo)
        {
            Menus.ForEach(menu =>
            {
                if (menu.Clave == Hijo.ClavePadre)
                {
                    menu.Hijos.Add(Hijo);
                    return;
                }

                AgregarHijo(menu.Hijos, Hijo);
            });
        }

        /// <summary>
        /// Verifica que el menú sea padre, es decir, que
        /// el menú tenga al menos un hijo
        /// </summary>
        /// <returns>true si tiene más de un hijo, de lo contrario false</returns>
        public bool EsPadre ()
        {
            return Hijos.Count > 0;
        }

        /// <summary>
        /// Verifica que el menú sea un hijo, es decir, que el padre 
        /// o la clave del padre del menú no sea nulo
        /// </summary>
        /// <returns>true si existe el padre, de lo contrario false</returns>
        public bool EsHijo()
        {
            return Padre != null || ClavePadre != null;
        }

        public override string ToString()
        {
            return URL;
        }

        /// <summary>
        /// Retorna una representación del menú en html respecto a la 
        /// plantilla LTE Admin
        /// </summary>
        /// <param name="Activo"></param>
        /// <returns>El código html del menú</returns>
        public string Html(Func<string, string> ToUrl)
        {
            string Clase = (EsPadre() ? "treeview" : ""); //+ (Activo ? " active" : "");

            string Html = "<li class='" + Clase + "'>";

            Html += "<a href='" + ToUrl(URL != null ? URL : "#") + "'>";
            Html += Icono != null ? "<i class='fa fa-" + Icono + "'></i>" : "";

            Html += "<span>" + Titulo + "</span>";

            Html += EsPadre() ? "<i class='fa fa-angle-left pull-right'></i>" : "";

            if (EsPadre())
            {
                Html += "<ul class='treeview-menu'>";

                Hijos
                    .OrderBy(menu => menu.Orden)
                    .ToList()
                    .ForEach(menu => Html += menu.Html(ToUrl));

                Html += "</ul>";
            }
            
            Html += "</a>";

            return Html + "</li>";
        }
    }
}