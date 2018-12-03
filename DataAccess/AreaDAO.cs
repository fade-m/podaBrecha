using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class AreaDAO
    {
        /// <summary>
        /// Retorna una área
        /// </summary>
        /// <param name="Clave">Clave de la área a encontrar</param>
        /// <returns>El área encontrada</returns>
        public static Area Get(int? Clave)
        {

            DataSource DataSource = DataSource.GetInstancia();
            Area Area = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AreaSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Area = new Area();
                        Area.Clave = Convert.ToInt32(Reader["cveArea"].ToString());
                        Area.Codigo = Reader["codigo"].ToString();
                        Area.Nombre = Reader["nombre"].ToString();
                        Area.ClaveZona = Convert.ToInt32(Reader["cveZona"].ToString());

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Area;

        }

        /// <summary>
        /// Retorna todas las áreas
        /// </summary>
        /// <returns>Todas las áreas</returns>
        public static List<Area> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Area> Areas = new List<Area>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AreaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Area Area = new Area();
                            Area.Clave = Convert.ToInt32(Reader["cveArea"].ToString());
                            Area.Codigo = Reader["codigo"].ToString();
                            Area.Nombre = Reader["nombre"].ToString();
                            Area.ClaveZona = Convert.ToInt32(Reader["cveZona"].ToString());

                            Areas.Add(Area);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return Areas;
        }

        /// <summary>
        /// Inserta una área
        /// </summary>
        /// <param name="Area">Área a insertar</param>
        /// <returns>El área insertada</returns>
        public static Area Insertar(Area Area)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Area AreaInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AreaInsertar", Area.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AreaInsertada = new Area();
                        AreaInsertada.Clave = Convert.ToInt32(Reader["cveArea"].ToString());
                        AreaInsertada.Codigo = Reader["codigo"].ToString();
                        AreaInsertada.Nombre = Reader["nombre"].ToString();
                        AreaInsertada.ClaveZona = Convert.ToInt32(Reader["cveZona"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return AreaInsertada;
        }

        /// <summary>
        /// Actualiza los datos de una área
        /// </summary>
        /// <param name="ClaveArea">Clave de la área a actualizar</param>
        /// <param name="Area">Área con los nuevos campos</param>
        /// <returns>El área actualizada</returns>
        public static Area Actualizar(int ClaveArea, Area Area)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Area AreaActualizada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AreaActualizar", ClaveArea, Area.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AreaActualizada = new Area();
                        AreaActualizada.Clave = Convert.ToInt32(Reader["cveArea"].ToString());
                        AreaActualizada.Codigo = Reader["codigo"].ToString();
                        AreaActualizada.Nombre = Reader["nombre"].ToString();
                        AreaActualizada.ClaveZona = Convert.ToInt32(Reader["cveZona"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return AreaActualizada;
        }
        
        /// <summary>
        /// Elimina una área
        /// </summary>
        /// <param name="ClaveArea">Clave de la área a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveArea)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int FilasAfectadas = 0;

            try
            {
                FilasAfectadas = DataSource.EjecutarProcedimiento("AreaEliminar", ClaveArea);
                DataSource.Cerrar();
            }
            catch(Exception e)
            {
                throw e;
            } 

            return FilasAfectadas;
        }
    }
}