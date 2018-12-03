using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class PermisoDAO
    {
        public static Permiso Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Permiso Permiso = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Permiso = new Permiso();
                            Permiso.Clave = Convert.ToInt32(Reader["cvePermiso"]);
                            Permiso.Descripcion = Reader["descripcion"].ToString();
                            Permiso.Codigo = Reader["codigo"].ToString();

                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Permiso;
        }

        public static List<Permiso> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Permiso> Permisos = new List<Permiso>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Permiso Permiso = new Permiso();
                            Permiso.Clave = Convert.ToInt32(Reader["cvePermiso"]);
                            Permiso.Descripcion = Reader["descripcion"].ToString();
                            Permiso.Codigo = Reader["codigo"].ToString();

                            Permisos.Add(Permiso);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Permisos;
        }

        public static Permiso Insertar(Permiso Permiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Permiso PermisoInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoInsertar", Permiso.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        PermisoInsertado = new Permiso();
                        PermisoInsertado.Clave = Convert.ToInt32(Reader["cvePermiso"]);
                        PermisoInsertado.Descripcion = Reader["descripcion"].ToString();
                        PermisoInsertado.Codigo = Reader["codigo"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoInsertado;
        }

        public static Permiso Actualizar(int ClavePermiso, Permiso Permiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Permiso PermisoInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PermisoActualizar", ClavePermiso, Permiso.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        PermisoInsertado = new Permiso();
                        PermisoInsertado.Clave = Convert.ToInt32(Reader["cvePermiso"]);
                        PermisoInsertado.Descripcion = Reader["descripcion"].ToString();
                        PermisoInsertado.Codigo = Reader["codigo"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return PermisoInsertado;
        }

        
        public static int Eliminar(int ClavePermiso)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PermisoEliminar", ClavePermiso);
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