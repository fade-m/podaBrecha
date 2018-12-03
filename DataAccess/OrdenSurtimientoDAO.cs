using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class OrdenSurtimientoDAO
    {
        public static OrdenSurtimiento Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            OrdenSurtimiento OrdenSurtimiento = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("OrdenSurtimientoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            OrdenSurtimiento = new OrdenSurtimiento();
                            OrdenSurtimiento.Clave = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                            OrdenSurtimiento.Descripcion = Reader["descripcion"].ToString();
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return OrdenSurtimiento;
        }

        public static List<OrdenSurtimiento> Listar()
        {

            DataSource DataSource = DataSource.GetInstancia();
            List<OrdenSurtimiento> OrdenSurtimientos = new List<OrdenSurtimiento>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("OrdenSurtimientoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            OrdenSurtimiento OrdenSurtimiento = new OrdenSurtimiento();
                            OrdenSurtimiento.Clave = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                            OrdenSurtimiento.Descripcion = Reader["descripcion"].ToString();
                            OrdenSurtimientos.Add(OrdenSurtimiento);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return OrdenSurtimientos;
        }

        public static OrdenSurtimiento Insertar(OrdenSurtimiento Orden)
        {
            DataSource DataSource = DataSource.GetInstancia();
            OrdenSurtimiento OrdenSurtimiento = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("OrdenSurtimientoInsertar", Orden.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                       
                            OrdenSurtimiento = new OrdenSurtimiento();
                            OrdenSurtimiento.Clave = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                            OrdenSurtimiento.Descripcion = Reader["descripcion"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return OrdenSurtimiento;
        }

        public static OrdenSurtimiento Actualizar(int ClaveOrden, OrdenSurtimiento Orden)
        {
            DataSource DataSource = DataSource.GetInstancia();
            OrdenSurtimiento OrdenSurtimiento = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("OrdenSurtimientoActualizar", ClaveOrden, Orden.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        OrdenSurtimiento = new OrdenSurtimiento();
                        OrdenSurtimiento.Clave = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                        OrdenSurtimiento.Descripcion = Reader["descripcion"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return OrdenSurtimiento;
        }

        public static int Eliminar(int ClaveOrden)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("OrdenSurtimientoEliminar", ClaveOrden);
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