using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ProgramaDetalleDAO
    {
        public static ProgramaDetalle Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            ProgramaDetalle ProgramaDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaDetalleSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            ProgramaDetalle = new ProgramaDetalle();
                            ProgramaDetalle.Clave = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            ProgramaDetalle.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                            ProgramaDetalle.FechaInicio = Convert.ToDateTime(Reader["fechaInicio"]);
                            ProgramaDetalle.PrecioUnitario = Convert.ToDecimal(Reader["precioUnitario"]);
                            ProgramaDetalle.ClavePrograma = Convert.ToInt32(Reader["cvePrograma"]);
                            ProgramaDetalle.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                            string contrat = (Reader["cveContrato"]).ToString();
                            if ((contrat == ""))
                                ProgramaDetalle.ClaveContrato = null;
                            else ProgramaDetalle.ClaveContrato = Convert.ToInt32(Reader["cveContrato"]);
                            ProgramaDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            ProgramaDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);
                        }
                    }
                   
                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaDetalle;
        }

        public static List<ProgramaDetalle> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<ProgramaDetalle> ProgramaDetalles = new List<ProgramaDetalle>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaDetalleListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            ProgramaDetalle ProgramaDetalle = new ProgramaDetalle();
                            ProgramaDetalle.Clave = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            ProgramaDetalle.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                            ProgramaDetalle.FechaInicio = Convert.ToDateTime(Reader["fechaInicio"]);
                            ProgramaDetalle.PrecioUnitario = Convert.ToDecimal(Reader["precioUnitario"]);
                            ProgramaDetalle.ClavePrograma = Convert.ToInt32(Reader["cvePrograma"]);
                            ProgramaDetalle.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                            string contrat = (Reader["cveContrato"]).ToString();
                            if ((contrat == ""))
                                ProgramaDetalle.ClaveContrato = null;
                            else ProgramaDetalle.ClaveContrato = Convert.ToInt32(Reader["cveContrato"]);
                            ProgramaDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            ProgramaDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);

                            ProgramaDetalles.Add(ProgramaDetalle);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaDetalles;
        }

        public static ProgramaDetalle Insertar(ProgramaDetalle Detalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            ProgramaDetalle ProgramaDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaDetalleInsertar", Detalle.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        
                            ProgramaDetalle = new ProgramaDetalle();
                            ProgramaDetalle.Clave = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            ProgramaDetalle.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                            ProgramaDetalle.FechaInicio = Convert.ToDateTime(Reader["fechaInicio"]);
                            ProgramaDetalle.PrecioUnitario = Convert.ToDecimal(Reader["precioUnitario"]);
                            ProgramaDetalle.ClavePrograma = Convert.ToInt32(Reader["cvePrograma"]);
                            ProgramaDetalle.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                            string contrat = (Reader["cveContrato"]).ToString();
                            if ((contrat == ""))
                                ProgramaDetalle.ClaveContrato = null;
                            else ProgramaDetalle.ClaveContrato = Convert.ToInt32(Reader["cveContrato"]);
                            ProgramaDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            ProgramaDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);
                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaDetalle;
        }

        public static ProgramaDetalle Actualizar(int ClaveDetalle, ProgramaDetalle Detalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            ProgramaDetalle ProgramaDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ProgramaDetalleActualizar",ClaveDetalle, Detalle.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        ProgramaDetalle = new ProgramaDetalle();
                        ProgramaDetalle.Clave = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                        ProgramaDetalle.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                        ProgramaDetalle.FechaInicio = Convert.ToDateTime(Reader["fechaInicio"]);
                        ProgramaDetalle.PrecioUnitario = Convert.ToDecimal(Reader["precioUnitario"]);
                        ProgramaDetalle.ClavePrograma = Convert.ToInt32(Reader["cvePrograma"]);
                        ProgramaDetalle.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                        string contrat = (Reader["cveContrato"]).ToString();
                        if ((contrat == ""))
                            ProgramaDetalle.ClaveContrato = null;
                        else ProgramaDetalle.ClaveContrato = Convert.ToInt32(Reader["cveContrato"]);
                        ProgramaDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                        ProgramaDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProgramaDetalle;
        }

        public static int Eliminar(int ClaveDetalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ProgramaDetalleEliminar", ClaveDetalle);
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