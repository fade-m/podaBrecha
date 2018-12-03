using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class PresupuestoDivisionDAO
    {
        public static PresupuestoDivision Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoDivision PresupuestoDivision = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoDivision = new PresupuestoDivision();
                            PresupuestoDivision.Clave = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoDivision.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoDivision.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoDivision;
        }

        public static List<PresupuestoDivision> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<PresupuestoDivision> PresupuestoDivisiones = new List<PresupuestoDivision>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            PresupuestoDivision PresupuestoDivision = new PresupuestoDivision();
                            PresupuestoDivision.Clave = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoDivision.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoDivision.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);

                            PresupuestoDivisiones.Add(PresupuestoDivision);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoDivisiones;
        }

        public static PresupuestoDivision Insertar(PresupuestoDivision Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoDivision PresupuestoDivision = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoInsertar", Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                       
                            PresupuestoDivision = new PresupuestoDivision();
                            PresupuestoDivision.Clave = Convert.ToInt32(Reader["cvePresupuesto"]);
                            PresupuestoDivision.Monto = Convert.ToDouble(Reader["monto"]);
                            PresupuestoDivision.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoDivision;
        }

        public static PresupuestoDivision Actualizar(int ClavePresupuesto, PresupuestoDivision Presupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            PresupuestoDivision PresupuestoDivision = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PresupuestoActualizar",ClavePresupuesto, Presupuesto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        PresupuestoDivision = new PresupuestoDivision();
                        PresupuestoDivision.Clave = Convert.ToInt32(Reader["cvePresupuesto"]);
                        PresupuestoDivision.Monto = Convert.ToDouble(Reader["monto"]);
                        PresupuestoDivision.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PresupuestoDivision;
        }

        public static int Eliminar(int ClavePresupuesto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PresupuestoEliminar", ClavePresupuesto);
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