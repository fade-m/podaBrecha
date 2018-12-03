using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ZonaDAO
    {
        public static Zona Get(int? Clave)
        {
            if (Clave == null) return null;

            DataSource DataSource = DataSource.GetInstancia();
            Zona Zona = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ZonaSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Zona = new Zona();
                        Zona.Clave = Convert.ToInt32(Reader["cveZona"].ToString());
                        Zona.Codigo = Reader["codigo"].ToString();
                        Zona.Nombre = Reader["nombre"].ToString();
                        Zona.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());

                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Zona;
        }

        /// <summary>
        /// Retorna todas las zonas
        /// </summary>
        /// <returns>Todas las zonas</returns>
        public static List<Zona> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Zona> Zonas = new List<Zona>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ZonaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Zona Zona = new Zona();
                            Zona.Clave = Convert.ToInt32(Reader["cveZona"].ToString());
                            Zona.Codigo = Reader["codigo"].ToString();
                            Zona.Nombre = Reader["nombre"].ToString();
                            Zona.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());

                            Zonas.Add(Zona);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Zonas;
        }

        /// <summary>
        /// Inserta una zona
        /// </summary>
        /// <param name="Zona">Zona a insertar</param>
        /// <returns>La zona insertada</returns>
        public static Zona Insertar (Zona Zona)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Zona ZonaInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ZonaInsertar", Zona.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ZonaInsertada = new Zona();
                        ZonaInsertada.Clave = Convert.ToInt32(Reader["cveZona"].ToString());
                        ZonaInsertada.Codigo = Reader["codigo"].ToString();
                        ZonaInsertada.Nombre = Reader["nombre"].ToString();
                        ZonaInsertada.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ZonaInsertada;
        }

        /// <summary>
        /// Actualiza una zona
        /// </summary>
        /// <param name="ClaveZona"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public static Zona Actualizar(int ClaveZona, Zona Zona)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Zona ZonaActualizada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ZonaActualizar", ClaveZona, Zona.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ZonaActualizada = new Zona();
                        ZonaActualizada.Clave = Convert.ToInt32(Reader["cveZona"].ToString());
                        ZonaActualizada.Codigo = Reader["codigo"].ToString();
                        ZonaActualizada.Nombre = Reader["nombre"].ToString();
                        ZonaActualizada.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ZonaActualizada;
        }

        /// <summary>
        /// Elimina una zona
        /// </summary>
        /// <param name="ClaveZona">Clave de la zona a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveZona)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int FilasAfectadas = 0;

            try
            {
                FilasAfectadas = DataSource.EjecutarProcedimiento("ZonaEliminar", ClaveZona);
                DataSource.Cerrar();
            }
            catch (Exception e)
            {
                throw e;
            }

            return FilasAfectadas;
        }
    }
}