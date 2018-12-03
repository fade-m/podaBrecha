using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class PermisoAreaDAO
    {
        public static PermisoArea Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PermisoArea PermisoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoAreaSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PermisoArea = new PermisoArea();
                            PermisoArea.Clave = Convert.ToInt32(Reader["cvePermisoArea"]);
                            PermisoArea.FechaOtorgado = Convert.ToDateTime(Reader["fechaOtorgado"]);
                            PermisoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                            PermisoArea.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            PermisoArea.ClavePermiso = Convert.ToInt32(Reader["cvePermiso"]);

                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoArea;
        }

        public static List<PermisoArea> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<PermisoArea> PermisoAreas = new List<PermisoArea>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoAreaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PermisoArea PermisoArea = new PermisoArea();
                            PermisoArea.Clave = Convert.ToInt32(Reader["cvePermisoArea"]);
                            PermisoArea.FechaOtorgado = Convert.ToDateTime(Reader["fechaOtorgado"]);
                            PermisoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                            PermisoArea.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            PermisoArea.ClavePermiso = Convert.ToInt32(Reader["cvePermiso"]);
                            
                            PermisoAreas.Add(PermisoArea);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoAreas;
        }

        public static PermisoArea Insertar(PermisoArea Permiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PermisoArea PermisoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoAreaInsertar", Permiso.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            PermisoArea = new PermisoArea();
                            PermisoArea.Clave = Convert.ToInt32(Reader["cvePermisoArea"]);
                            PermisoArea.FechaOtorgado = Convert.ToDateTime(Reader["fechaOtorgado"]);
                            PermisoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                            PermisoArea.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            PermisoArea.ClavePermiso = Convert.ToInt32(Reader["cvePermiso"]);

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoArea;
        }

        public static PermisoArea Actualizar(int ClavePermiso, PermisoArea Permiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PermisoArea PermisoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoAreaActualizar", ClavePermiso, Permiso.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        PermisoArea = new PermisoArea();
                        PermisoArea.Clave = Convert.ToInt32(Reader["cvePermisoArea"]);
                        PermisoArea.FechaOtorgado = Convert.ToDateTime(Reader["fechaOtorgado"]);
                        PermisoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                        PermisoArea.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                        PermisoArea.ClavePermiso = Convert.ToInt32(Reader["cvePermiso"]);


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoArea;
        }

        public static int Eliminar(int ClavePermiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PermisoAreaEliminar", ClavePermiso);
                DataSource.Cerrar();
            }
            catch (Exception)
            {
                return -1;
            }

            return filasAfectadas;
        }
    }
}