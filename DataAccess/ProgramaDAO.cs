using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ProgramaDAO
    {
        public static Programa Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programa Programa = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Programa = new Programa();
                            Programa.Clave = Convert.ToInt32(Reader["cvePrograma"]);
                            Programa.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                            Programa.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);

                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Programa;
        }

        public static List<Programa> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Programa> Programas = new List<Programa>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Programa Programa = new Programa();
                            Programa.Clave = Convert.ToInt32(Reader["cvePrograma"]);
                            Programa.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                            Programa.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                      
                            Programas.Add(Programa);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Programas;
        }

        public static Programa Insertar(Programa Programa)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programa ProgramaInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaInsertar", Programa.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        ProgramaInsertado = new Programa();
                        ProgramaInsertado.Clave = Convert.ToInt32(Reader["cvePrograma"]);
                        ProgramaInsertado.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                        ProgramaInsertado.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                    
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaInsertado;
        }

        public static Programa Actualizar(int ClavePrograma, Programa Programa)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Programa ProgramaInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaActualizar",ClavePrograma, Programa.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        ProgramaInsertado = new Programa();
                        ProgramaInsertado.Clave = Convert.ToInt32(Reader["cvePrograma"]);
                        ProgramaInsertado.FechaCreacion = Convert.ToDateTime(Reader["fechaCreacion"]);
                        ProgramaInsertado.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaInsertado;
        }

        public static int Eliminar(int ClavePrograma)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ProgramaEliminar", ClavePrograma);
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