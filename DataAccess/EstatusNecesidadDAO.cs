using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class EstatusNecesidadDAO
    {
        public static EstatusNecesidad Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusNecesidad EstatusNecesidad = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusNecesidadSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusNecesidad = new EstatusNecesidad();
                            EstatusNecesidad.Clave = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                            EstatusNecesidad.Descripcion = Reader["descripcion"].ToString();
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return EstatusNecesidad;
        }

        public static List<EstatusNecesidad> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<EstatusNecesidad> EstatusNecesidades = new List<EstatusNecesidad>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusNecesidadListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusNecesidad EstatusNecesidad = new EstatusNecesidad();
                            EstatusNecesidad.Clave = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                            EstatusNecesidad.Descripcion = Reader["descripcion"].ToString();
                            EstatusNecesidades.Add(EstatusNecesidad);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return EstatusNecesidades;
        }

        public static EstatusNecesidad Insertar(EstatusNecesidad Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusNecesidad EstatusNecesidad = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusNecesidadInsertar", Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            EstatusNecesidad = new EstatusNecesidad();
                            EstatusNecesidad.Clave = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                            EstatusNecesidad.Descripcion = Reader["descripcion"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return EstatusNecesidad;
        }

        public static EstatusNecesidad Actualizar(int ClaveEstatus, EstatusNecesidad Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusNecesidad EstatusNecesidad = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusNecesidadActualizar", ClaveEstatus, Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        EstatusNecesidad = new EstatusNecesidad();
                        EstatusNecesidad.Clave = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                        EstatusNecesidad.Descripcion = Reader["descripcion"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return EstatusNecesidad;
        }

        public static int Eliminar(int ClaveEstatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("EstatusNecesidadEliminar", ClaveEstatus);
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