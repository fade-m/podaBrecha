using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class NecesidadDAO
    {
        public static Necesidad Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Necesidad Necesidad = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Necesidad = new Necesidad();
                            Necesidad.Clave = Convert.ToInt32(Reader["cveNecesidad"]);
                            Necesidad.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                            Necesidad.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                            Necesidad.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                            Necesidad.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }



            return Necesidad;
        }

        public static List<Necesidad> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Necesidad> Necesidades = new List<Necesidad>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Necesidad Necesidad = new Necesidad();
                            Necesidad.Clave = Convert.ToInt32(Reader["cveNecesidad"]);
                            Necesidad.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                            Necesidad.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                            Necesidad.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                            Necesidad.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusNecesidad"]);
                            Necesidades.Add(Necesidad);
                        }
                    }

                    DataSource.Cerrar();
               }
            }catch(Exception e)
            {
                throw e;
            }
                
            

            return Necesidades;
        }

        public static Necesidad Insertar(Necesidad Necesidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Necesidad NecesidadInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadInsertar", Necesidad.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        NecesidadInsertada = new Necesidad();
                        NecesidadInsertada.Clave = Convert.ToInt32(Reader["cveNecesidad"]);
                        NecesidadInsertada.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                        NecesidadInsertada.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                        NecesidadInsertada.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                        NecesidadInsertada.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusNecesidad"]);

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }



            return NecesidadInsertada;
        }

        public static Necesidad Actualizar(int ClaveNecesidad, Necesidad Necesidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Necesidad NecesidadInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadActualizar",ClaveNecesidad, Necesidad.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        NecesidadInsertada = new Necesidad();
                        NecesidadInsertada.Clave = Convert.ToInt32(Reader["cveNecesidad"]);
                        NecesidadInsertada.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                        NecesidadInsertada.ClaveArea = Convert.ToInt32(Reader["cveArea"]);
                        NecesidadInsertada.ClavePeriodo = Convert.ToInt32(Reader["cvePeriodo"]);
                        NecesidadInsertada.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusNecesidad"]);


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }



            return NecesidadInsertada;
        }

        public static int Eliminar(int ClaveNecesidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("NecesidadEliminar", ClaveNecesidad);
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