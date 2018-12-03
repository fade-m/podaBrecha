using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class PresupuestoZonaDAO
    {
        public static PresupuestoZona Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoZona PresupuestoZona = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoZonaSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoZona = new PresupuestoZona();
                            PresupuestoZona.Clave = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoZona.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoZona.ClavePresupuestoDivisional = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoZona.ClaveZona = Convert.ToInt32(Reader["cveZona"]);
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoZona;
        }

        public static List<PresupuestoZona> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<PresupuestoZona> PresupuestoZonas = new List<PresupuestoZona>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoZonaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoZona PresupuestoZona = new PresupuestoZona();
                            PresupuestoZona.Clave = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoZona.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoZona.ClavePresupuestoDivisional = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoZona.ClaveZona = Convert.ToInt32(Reader["cveZona"]);

                            PresupuestoZonas.Add(PresupuestoZona);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoZonas;
        }

        public static PresupuestoZona Insertar(PresupuestoZona Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoZona PresupuestoZona = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoZonaInsertar", Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                       
                            PresupuestoZona = new PresupuestoZona();
                            PresupuestoZona.Clave = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                            PresupuestoZona.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoZona.ClavePresupuestoDivisional = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoZona.ClaveZona = Convert.ToInt32(Reader["cveZona"]);

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoZona;
        }

        public static PresupuestoZona Actualizar(int ClavePresupuesto, PresupuestoZona Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoZona PresupuestoZona = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoZonaActualizar", ClavePresupuesto, Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        PresupuestoZona = new PresupuestoZona();
                        PresupuestoZona.Clave = Convert.ToInt32(Reader["cvePresupuestoZona"]);
                        PresupuestoZona.Monto = Convert.ToDouble(Reader["monto"]);
                        PresupuestoZona.ClavePresupuestoDivisional = Convert.ToInt32(Reader["cvePresupuesto"]);
                        PresupuestoZona.ClaveZona = Convert.ToInt32(Reader["cveZona"]);


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoZona;
        }

        public static int Eliminar(int ClavePresupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PresupuestoZonaEliminar", ClavePresupuesto);
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