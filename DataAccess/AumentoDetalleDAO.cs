using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class AumentoDetalleDAO
    {
        public static AumentoDetalle Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoDetalle Detalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoDetalleSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Detalle = new AumentoDetalle();
                        Detalle.Clave = Convert.ToInt32(Reader["cveAumentoDetalle"].ToString());
                        Detalle.ClaveAumento = Convert.ToInt32(Reader["cveAumentoContrato"].ToString());
                        Detalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        Detalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Detalle;
        }

        public static List<AumentoDetalle> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<AumentoDetalle> Detalles = new List<AumentoDetalle>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoDetalleListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            AumentoDetalle Detalle = new AumentoDetalle();
                            Detalle.Clave = Convert.ToInt32(Reader["cveAumentoDetalle"].ToString());
                            Detalle.ClaveAumento = Convert.ToInt32(Reader["cveAumentoContrato"].ToString());
                            Detalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"].ToString());
                            Detalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"].ToString());

                            Detalles.Add(Detalle);
                        }

                        DataSource.Cerrar();
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Detalles;
        }

        public static AumentoDetalle Insertar(AumentoDetalle Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoDetalle Detalleinsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoDetalleInsertar", Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Detalleinsertado = new AumentoDetalle();
                        Detalleinsertado.Clave = Convert.ToInt32(Reader["cveAumentoDetalle"].ToString());
                        Detalleinsertado.ClaveAumento = Convert.ToInt32(Reader["cveAumentoContrato"].ToString());
                        Detalleinsertado.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        Detalleinsertado.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch (Exception e)
            {
                throw e;
            }

            return Detalleinsertado;
        }

        public static AumentoDetalle Actualizar(int ClaveAumento, AumentoDetalle Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoDetalle DetalleActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoDetalleActualizar", ClaveAumento, Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        DetalleActualizado = new AumentoDetalle();
                        DetalleActualizado.Clave = Convert.ToInt32(Reader["cveAumentoDetalle"].ToString());
                        DetalleActualizado.ClaveAumento = Convert.ToInt32(Reader["cveAumentoContrato"].ToString());
                        DetalleActualizado.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"].ToString());
                        DetalleActualizado.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }
            

            return DetalleActualizado;
        }

        public static int Eliminar(int ClaveAumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("AumentoDetalleEliminar", ClaveAumento);
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