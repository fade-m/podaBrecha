using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class EstatusContratoDAO
    {
        public static EstatusContrato Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusContrato EstatusContrato = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusContratoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusContrato = new EstatusContrato();
                            EstatusContrato.Clave = Convert.ToInt32(Reader["cveEstatusContrato"]);
                            EstatusContrato.Descripcion = Reader["descripcion"].ToString();
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusContrato;
        }

        public static List<EstatusContrato> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<EstatusContrato> EstatusContratos = new List<EstatusContrato>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusContratoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusContrato EstatusContrato = new EstatusContrato();
                            EstatusContrato.Clave = Convert.ToInt32(Reader["cveEstatusContrato"]);
                            EstatusContrato.Descripcion = Reader["descripcion"].ToString();
                            EstatusContratos.Add(EstatusContrato);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusContratos;
        }

        public static EstatusContrato Insertar(EstatusContrato Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusContrato EstatusContrato = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusContratoInsertar", Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            EstatusContrato = new EstatusContrato();
                            EstatusContrato.Clave = Convert.ToInt32(Reader["cveEstatusContrato"]);
                            EstatusContrato.Descripcion = Reader["descripcion"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusContrato;
        }

        public static EstatusContrato Actualizar(int ClaveEstatus, EstatusContrato Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusContrato EstatusContrato = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusContratoActualizar", ClaveEstatus, Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        EstatusContrato = new EstatusContrato();
                        EstatusContrato.Clave = Convert.ToInt32(Reader["cveEstatusContrato"]);
                        EstatusContrato.Descripcion = Reader["descripcion"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusContrato;
        }

        public static int Eliminar(int ClaveEstatus)
        {

            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("EstatusContratoEliminar", ClaveEstatus);
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