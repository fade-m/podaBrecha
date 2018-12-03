using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class EstatusPeriodoDAO
    {
        public static EstatusPeriodo Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPeriodo EstatusPeriodo = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPeriodoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusPeriodo = new EstatusPeriodo();
                            EstatusPeriodo.Clave = Convert.ToInt32(Reader["cveEstatusPeriodo"]);
                            EstatusPeriodo.Descripcion = Reader["descripcion"].ToString();
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPeriodo;
        }

        public static List<EstatusPeriodo> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<EstatusPeriodo> EstatusPeriodos = new List<EstatusPeriodo>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPeriodoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            EstatusPeriodo EstatusPeriodo = new EstatusPeriodo();
                            EstatusPeriodo.Clave = Convert.ToInt32(Reader["cveEstatusPeriodo"]);
                            EstatusPeriodo.Descripcion = Reader["descripcion"].ToString();
                            EstatusPeriodos.Add(EstatusPeriodo);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPeriodos;
        }

        public static EstatusPeriodo Insertar(EstatusPeriodo Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPeriodo EstatusPeriodo = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPeriodoInsertar", Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                            EstatusPeriodo = new EstatusPeriodo();
                            EstatusPeriodo.Clave = Convert.ToInt32(Reader["cveEstatusPeriodo"]);
                            EstatusPeriodo.Descripcion = Reader["descripcion"].ToString();
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPeriodo;
        }

        public static EstatusPeriodo Actualizar(int ClaveEstatus, EstatusPeriodo Estatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            EstatusPeriodo EstatusPeriodo = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("EstatusPeriodoActualizar", ClaveEstatus, Estatus.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        EstatusPeriodo = new EstatusPeriodo();
                        EstatusPeriodo.Clave = Convert.ToInt32(Reader["cveEstatusPeriodo"]);
                        EstatusPeriodo.Descripcion = Reader["descripcion"].ToString();

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return EstatusPeriodo;
        }

        public static int Eliminar(int ClaveEstatus)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("EstatusPeriodoEliminar", ClaveEstatus);
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