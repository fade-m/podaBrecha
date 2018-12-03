using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class MenuDAO
    {
        public static Menu Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Menu Menu = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MenuSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Menu = new Menu();
                        Menu.Clave = Convert.ToInt32(Reader["cveMenu"]);
                        Menu.Titulo = Reader["titulo"].ToString();
                        Menu.URL = Reader["url"].ToString();
                        Menu.Orden = Convert.ToInt32(Reader["orden"]);
                        Menu.Icono = Reader["icono"].ToString();

                        Menu.ClavePadre = Utilerias.ParsearNullable(Reader["cvePadre"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Menu;
        }

        /// <summary>
        /// Retorna los menús padres que serán colocados en la etiqueta
        /// aside de la master page
        /// </summary>
        /// <param name="ClaveRol">Clave del rol</param>
        /// <returns>La lista de los menús padres</returns>
        public static List<Menu> ListarPorRol(int ClaveRol)
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Menu> Menus = new List<Menu>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MenuListarPorRol", ClaveRol))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Menu Menu = new Menu();
                            Menu.Clave = Convert.ToInt32(Reader["cveMenu"]);
                            Menu.Titulo = Reader["titulo"].ToString();
                            Menu.URL = Reader["url"].ToString();
                            Menu.Orden = Convert.ToInt32(Reader["orden"]);
                            Menu.Icono = Reader["icono"].ToString();

                            Menu.ClavePadre = Utilerias.ParsearNullable(Reader["cvePadre"].ToString());

                            Menus.Add(Menu);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return Menus;
        }
    }
}