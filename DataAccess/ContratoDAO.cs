using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ContratoDAO
    {
        public static Contrato Get(int? Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Contrato Contrato = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Contrato = new Contrato();
                        Contrato.Clave = Convert.ToInt32(Reader["cveContrato"].ToString());
                        Contrato.Codigo = Reader["codigo"].ToString();
                        Contrato.FechaAdjudicacion = (DateTime)Reader["fechaAdjudicacion"];
                        Contrato.FechaInicio = (DateTime)Reader["fechaInicio"];
                        Contrato.FechaCreacion = (DateTime)Reader["fechaCreacion"];
                        Contrato.Pdf = Reader["pdf"].ToString();
                        Contrato.ClaveContratista = Convert.ToInt32(Reader["cveContratista"].ToString());
                        Contrato.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusContrato"].ToString());
                        Contrato.ClaveModalidad = Convert.ToInt32(Reader["cveModalidad"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Contrato;
        }

        public static List<Contrato> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Contrato> Contratos = new List<Contrato>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Contrato Contrato = new Contrato();
                            Contrato.Clave = Convert.ToInt32(Reader["cveContrato"].ToString());
                            Contrato.Codigo = Reader["codigo"].ToString();
                            Contrato.FechaAdjudicacion = (DateTime)Reader["fechaAdjudicacion"];
                            Contrato.FechaInicio = (DateTime)Reader["fechaInicio"];
                            Contrato.FechaCreacion = (DateTime)Reader["fechaCreacion"];
                            Contrato.Pdf = Reader["pdf"].ToString();
                            Contrato.ClaveContratista = Convert.ToInt32(Reader["cveContratista"].ToString());
                            Contrato.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusContrato"].ToString());
                            Contrato.ClaveModalidad = Convert.ToInt32(Reader["cveModalidad"].ToString());

                            Contratos.Add(Contrato);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Contratos;
        }

        public static Contrato Insertar(Contrato Contrato)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Contrato ContratoInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratoInsertar", Contrato.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ContratoInsertado = new Contrato();
                        ContratoInsertado.Clave = Convert.ToInt32(Reader["cveContrato"].ToString());
                        ContratoInsertado.Codigo = Reader["codigo"].ToString();
                        ContratoInsertado.FechaAdjudicacion = (DateTime)Reader["fechaAdjudicacion"];
                        ContratoInsertado.FechaInicio = (DateTime)Reader["fechaInicio"];
                        ContratoInsertado.FechaCreacion = (DateTime)Reader["fechaCreacion"];
                        Contrato.Pdf = Reader["pdf"].ToString();
                        ContratoInsertado.ClaveContratista = Convert.ToInt32(Reader["cveContratista"].ToString());
                        ContratoInsertado.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusContrato"].ToString());
                        ContratoInsertado.ClaveModalidad = Convert.ToInt32(Reader["cveModalidad"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ContratoInsertado;
        }

        public static Contrato Actualizar(int ClaveContrato, Contrato Contrato)
        {
            return null;
        }

        public static int Eliminar(int ClaveContrato)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ContratoEliminar", ClaveContrato);
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