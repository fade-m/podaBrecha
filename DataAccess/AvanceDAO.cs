using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PodaProject.Util;

namespace PodaProject.DataAccess
{
    public class AvanceDAO
    {
        public static Avance Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Avance Avance = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AvanceSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Avance = new Avance();
                        Avance.Clave = Convert.ToInt32(Reader["cveAvance"].ToString());
                        Avance.Ejecutado = Convert.ToDouble(Reader["ejecutado"].ToString());
                        Avance.Observacioens = Reader["observaciones"].ToString();
                        Avance.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"].ToString());
                        Avance.ClaveProgramacion = Convert.ToInt32(Reader["cveProgramacion"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Avance;
        }

        public static List<Avance> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Avance> Avances = new List<Avance>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AvanceListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Avance Avance = new Avance();
                            Avance.Clave = Convert.ToInt32(Reader["cveAvance"].ToString());
                            Avance.Ejecutado = Convert.ToDouble(Reader["ejecutado"].ToString());
                            Avance.Observacioens = Reader["observaciones"].ToString();
                            Avance.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"].ToString());
                            Avance.ClaveProgramacion = Convert.ToInt32(Reader["cveProgramacion"].ToString());

                            Avances.Add(Avance);
                        }

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Avances;
        }

        public static Avance Insertar(Avance Avance)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Avance AvanceInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AvanceInsertar", Avance.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AvanceInsertado = new Avance();
                        AvanceInsertado.Clave = Convert.ToInt32(Reader["cveAvance"].ToString());
                        AvanceInsertado.Ejecutado = Convert.ToDouble(Reader["ejecutado"].ToString());
                        AvanceInsertado.Observacioens = Reader["observaciones"].ToString();
                        AvanceInsertado.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"].ToString());
                        AvanceInsertado.ClaveProgramacion = Convert.ToInt32(Reader["cveProgramacion"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch (Exception e)
            {
                throw e;
            }

            return AvanceInsertado;
        }

        public static Avance Actualizar(int ClaveAvance, Avance Avance)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Avance AvanceActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AvanceActualizar", ClaveAvance, Avance.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AvanceActualizado = new Avance();
                        AvanceActualizado.Clave = Convert.ToInt32(Reader["cveAvance"].ToString());
                        AvanceActualizado.Ejecutado = Convert.ToDouble(Reader["ejecutado"].ToString());
                        AvanceActualizado.Observacioens = Reader["observaciones"].ToString();
                        AvanceActualizado.FechaCreacion = Utilerias.ParsearFecha(Reader["fechaCreacion"].ToString());
                        AvanceActualizado.ClaveProgramacion = Convert.ToInt32(Reader["cveProgramacion"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return AvanceActualizado;
        }

        public static int Eliminar(int ClaveAvance)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("AvanceEliminar", ClaveAvance);
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