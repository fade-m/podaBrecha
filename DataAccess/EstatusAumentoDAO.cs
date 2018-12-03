using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class EstatusAumentoDAO
    {
        public static EstatusAumento Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusAumento EstatusAumento = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusAumentoSeleccionar",Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusAumento = new EstatusAumento();
                            EstatusAumento.Clave = Convert.ToInt32(Reader["cveEstatusAumento"]);
                            EstatusAumento.Descripcion = Reader["descripcion"].ToString();
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusAumento;
        }

        public static List<EstatusAumento> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<EstatusAumento> EstatusAumentos = new List<EstatusAumento>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusAumentoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusAumento EstatusAumento = new EstatusAumento();
                            EstatusAumento.Clave = Convert.ToInt32(Reader["cveEstatusAumento"]);
                            EstatusAumento.Descripcion = Reader["descripcion"].ToString();
                            EstatusAumentos.Add(EstatusAumento);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusAumentos;
        }

        public static EstatusAumento Insertar(EstatusAumento Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusAumento EstatusAumento = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusAumentoInsertar", Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            EstatusAumento = new EstatusAumento();
                            EstatusAumento.Clave = Convert.ToInt32(Reader["cveEstatusAumento"]);
                            EstatusAumento.Descripcion = Reader["descripcion"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusAumento;
        }

        public static EstatusAumento Actualizar(int ClaveEstatus, EstatusAumento Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusAumento EstatusAumento = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusAumentoActualizar", ClaveEstatus, Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        EstatusAumento = new EstatusAumento();
                        EstatusAumento.Clave = Convert.ToInt32(Reader["cveEstatusAumento"]);
                        EstatusAumento.Descripcion = Reader["descripcion"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusAumento;
        }

        public static int Eliminar(int ClaveEstatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("EstatusAumentoEliminar", ClaveEstatus);
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