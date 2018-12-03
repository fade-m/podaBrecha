using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class EstatusPermisoDAO
    {
        public static EstatusPermiso Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPermiso EstatusPermiso = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPermisoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusPermiso = new EstatusPermiso();
                            EstatusPermiso.Clave = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            EstatusPermiso.Descripcion = Reader["descripcion"].ToString();
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPermiso;
        }

        public static List<EstatusPermiso> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<EstatusPermiso> EstatusPermisos = new List<EstatusPermiso>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPermisoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusPermiso EstatusPermiso = new EstatusPermiso();
                            EstatusPermiso.Clave = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            EstatusPermiso.Descripcion = Reader["descripcion"].ToString();

                            EstatusPermisos.Add(EstatusPermiso);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPermisos;
        }

        public static EstatusPermiso Insertar(EstatusPermiso Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPermiso EstatusPermiso = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPermisoInsertar", Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            EstatusPermiso = new EstatusPermiso();
                            EstatusPermiso.Clave = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                            EstatusPermiso.Descripcion = Reader["descripcion"].ToString();
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPermiso;
        }

        public static EstatusPermiso Actualizar(int ClaveEstatus, EstatusPermiso Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPermiso EstatusPermiso = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPermisoActualizar",ClaveEstatus, Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        EstatusPermiso = new EstatusPermiso();
                        EstatusPermiso.Clave = Convert.ToInt32(Reader["cveEstatusPermiso"]);
                        EstatusPermiso.Descripcion = Reader["descripcion"].ToString();

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPermiso;
        }

        public static int Eliminar(int ClaveEstatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("EstatusPermisoEliminar", ClaveEstatus);
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