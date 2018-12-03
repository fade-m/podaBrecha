using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ProgramacionDAO
    {
        public static Programacion Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programacion Programacion = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramacionSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Programacion = new Programacion();
                            Programacion.Clave = Convert.ToInt32(Reader["cveProgramacion"]);
                            Programacion.Programado = Convert.ToDouble(Reader["programado"]);
                            Programacion.ClaveMes = Convert.ToInt32(Reader["cveMes"]);
                            Programacion.ClaveOrden = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Programacion;
        }

        public static List<Programacion> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Programacion> Programaciones = new List<Programacion>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramacionListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Programacion Programacion = new Programacion();
                            Programacion.Clave = Convert.ToInt32(Reader["cveProgramacion"]);
                            Programacion.Programado = Convert.ToDouble(Reader["programado"]);
                            Programacion.ClaveMes = Convert.ToInt32(Reader["cveMes"]);
                            Programacion.ClaveOrden = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                            
                            Programaciones.Add(Programacion);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Programaciones;
        }

        public static Programacion Insertar(Programacion Programacion)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programacion ProgramacionInsertada = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramacionInsertar", Programacion.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                      
                            ProgramacionInsertada = new Programacion();
                            ProgramacionInsertada.Clave = Convert.ToInt32(Reader["cveProgramacion"]);
                            ProgramacionInsertada.Programado = Convert.ToDouble(Reader["programado"]);
                            ProgramacionInsertada.ClaveMes = Convert.ToInt32(Reader["cveMes"]);
                            ProgramacionInsertada.ClaveOrden = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramacionInsertada;
        }

        public static Programacion Actualizar(int ClaveProgramacion, Programacion Programacion)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programacion ProgramacionInsertada = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramacionActualizar",ClaveProgramacion, Programacion.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                           ProgramacionInsertada = new Programacion();
                           ProgramacionInsertada.Clave = Convert.ToInt32(Reader["cveProgramacion"]);
                           ProgramacionInsertada.Programado = Convert.ToDouble(Reader["programado"]);
                           ProgramacionInsertada.ClaveMes = Convert.ToInt32(Reader["cveMes"]);
                           ProgramacionInsertada.ClaveOrden = Convert.ToInt32(Reader["cveOrdenSurtimiento"]);
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramacionInsertada;
        }

        public static int Eliminar(int ClaveProgramacion)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ProgramacionEliminar", ClaveProgramacion);
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