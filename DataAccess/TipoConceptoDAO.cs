using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class TipoConceptoDAO
    {
        public static TipoConcepto Get(int? Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            TipoConcepto TipoConcepto = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("TipoConceptoSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            TipoConcepto = new TipoConcepto();
                            TipoConcepto.Clave = Convert.ToInt32(Reader["cveTipoConcepto"]);
                            TipoConcepto.Descripcion = Reader["descripcion"].ToString();
                            TipoConcepto.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return TipoConcepto;
        }

        public static List<TipoConcepto> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<TipoConcepto> TipoConceptos = new List<TipoConcepto>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("TipoConceptoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            TipoConcepto TipoConcepto = new TipoConcepto();
                            TipoConcepto.Clave = Convert.ToInt32(Reader["cveTipoConcepto"]);
                            TipoConcepto.Descripcion = Reader["descripcion"].ToString();
                            TipoConcepto.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);

                            TipoConceptos.Add(TipoConcepto);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return TipoConceptos;
        }

        public static TipoConcepto Insertar(TipoConcepto Tipo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            TipoConcepto TipoConcepto = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("TipoConceptoInsertar", Tipo.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                       
                            TipoConcepto = new TipoConcepto();
                            TipoConcepto.Clave = Convert.ToInt32(Reader["cveTipoConcepto"]);
                            TipoConcepto.Descripcion = Reader["descripcion"].ToString();
                            TipoConcepto.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return TipoConcepto;
        }

        public static TipoConcepto Actualizar(int ClaveTipo, TipoConcepto Tipo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            TipoConcepto TipoConcepto = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("TipoConceptoActualizar",ClaveTipo, Tipo.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        TipoConcepto = new TipoConcepto();
                        TipoConcepto.Clave = Convert.ToInt32(Reader["cveTipoConcepto"]);
                        TipoConcepto.Descripcion = Reader["descripcion"].ToString();
                        TipoConcepto.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return TipoConcepto;
        }

        public static int Eliminar(int ClaveTipo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("TipoConceptoEliminar", ClaveTipo);
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