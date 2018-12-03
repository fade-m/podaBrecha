using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ConceptoDAO
    {
        public static Concepto Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Concepto Concepto = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ConceptoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Concepto = new Concepto();
                        Concepto.Clave = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        Concepto.Descripcion = Reader["descripcion"].ToString();
                        Concepto.MedidaAbreviacion = Reader["medidaAbreviacion"].ToString();
                        Concepto.MedidaPlural = Reader["medidaPlural"].ToString();
                        Concepto.MedidaSingular = Reader["medidaSingular"].ToString();
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Concepto;
        }

        public static List<Concepto> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Concepto> Conceptos = new List<Concepto>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ConceptoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Concepto Concepto = new Concepto();
                            Concepto.Clave = Convert.ToInt32(Reader["cveConcepto"].ToString());
                            Concepto.Descripcion = Reader["descripcion"].ToString();
                            Concepto.MedidaAbreviacion = Reader["medidaAbreviacion"].ToString();
                            Concepto.MedidaPlural = Reader["medidaPlural"].ToString();
                            Concepto.MedidaSingular = Reader["medidaSingular"].ToString();

                            Conceptos.Add(Concepto);
                        }

                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Conceptos;
        }

        public static Concepto Insertar(Concepto Concepto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Concepto ConceptoInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ConceptoInsertar", Concepto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ConceptoInsertado = new Concepto();
                        ConceptoInsertado.Clave = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        ConceptoInsertado.Descripcion = Reader["descripcion"].ToString();
                        ConceptoInsertado.MedidaAbreviacion = Reader["medidaAbreviacion"].ToString();
                        ConceptoInsertado.MedidaPlural = Reader["medidaPlural"].ToString();
                        ConceptoInsertado.MedidaSingular = Reader["medidaSingular"].ToString();
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ConceptoInsertado;
        }

        public static Concepto Actualizar(int ClaveConcepto, Concepto Concepto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Concepto ConceptoActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ConceptoActualizar", Concepto.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ConceptoActualizado = new Concepto();
                        ConceptoActualizado.Clave = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        ConceptoActualizado.Descripcion = Reader["descripcion"].ToString();
                        ConceptoActualizado.MedidaAbreviacion = Reader["medidaAbreviacion"].ToString();
                        ConceptoActualizado.MedidaPlural = Reader["medidaPlural"].ToString();
                        ConceptoActualizado.MedidaSingular = Reader["medidaSingular"].ToString();
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ConceptoActualizado;
        }

        public static int Eliminar(int ClaveConcepto)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ConceptoEliminar", ClaveConcepto);
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