using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class PresupuestoAreaDAO
    {
        public static PresupuestoArea Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoArea PresupuestoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoAreaSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoArea = new PresupuestoArea();
                            PresupuestoArea.Clave = Convert.ToInt32(Reader["cvePresupuestoArea"]);
                            PresupuestoArea.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoArea.ClavePresupuestoZona = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoArea;
        }

        public static List<PresupuestoArea> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<PresupuestoArea> PresupuestoAreas = new List<PresupuestoArea>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoAreaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoArea PresupuestoArea = new PresupuestoArea();
                            PresupuestoArea.Clave = Convert.ToInt32(Reader["cvePresupuestoArea"]);
                            PresupuestoArea.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoArea.ClavePresupuestoZona = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);

                            PresupuestoAreas.Add(PresupuestoArea);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoAreas;
        }

        public static PresupuestoArea Insertar(PresupuestoArea Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoArea PresupuestoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoAreaInsertar", Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                            PresupuestoArea = new PresupuestoArea();
                            PresupuestoArea.Clave = Convert.ToInt32(Reader["cvePresupuestoArea"]);
                            PresupuestoArea.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoArea.ClavePresupuestoZona = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoArea;
        } 

        public static PresupuestoArea Actualizar(int ClavePresupuesto, PresupuestoArea Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoArea PresupuestoArea = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoAreaActualizar",ClavePresupuesto, Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        PresupuestoArea = new PresupuestoArea();
                        PresupuestoArea.Clave = Convert.ToInt32(Reader["cvePresupuestoArea"]);
                        PresupuestoArea.Monto = Convert.ToDouble(Reader["monto"]);
                        PresupuestoArea.ClavePresupuestoZona = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                        PresupuestoArea.ClaveArea = Convert.ToInt32(Reader["cveArea"]);

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoArea;
        }

        public static int Eliminar(int ClavePresupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PresupuestoAreaEliminar", ClavePresupuesto);
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