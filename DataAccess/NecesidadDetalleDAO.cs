using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class NecesidadDetalleDAO
    {
        public static NecesidadDetalle Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            NecesidadDetalle NecesidadDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadDetalleSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            NecesidadDetalle = new NecesidadDetalle();
                            NecesidadDetalle.Clave = Convert.ToInt32(Reader["cveNecesidadDetalle"]);
                            NecesidadDetalle.Volumen = Convert.ToDouble(Reader["volumen"]);
                            NecesidadDetalle.PrecioUnitario = Convert.ToDouble(Reader["precioUnitario"]);
                            NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                            NecesidadDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            string tipoconcepto = (Reader["cveTipoConcepto"]).ToString();
                            if ((tipoconcepto == ""))
                                NecesidadDetalle.ClaveTipoConcepto = null;
                            else NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);


                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return NecesidadDetalle;
        }


        public static List<NecesidadDetalle> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<NecesidadDetalle> NecesidadDetalles = new List<NecesidadDetalle>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadDetalleListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            NecesidadDetalle NecesidadDetalle = new NecesidadDetalle();
                            NecesidadDetalle.Clave = Convert.ToInt32(Reader["cveNecesidadDetalle"]);
                            NecesidadDetalle.Volumen = Convert.ToDouble(Reader["volumen"]);
                            NecesidadDetalle.PrecioUnitario = Convert.ToDouble(Reader["precioUnitario"]);
                            NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                            NecesidadDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                            string tipoconcepto = (Reader["cveTipoConcepto"]).ToString();
                            if ((tipoconcepto == ""))
                                NecesidadDetalle.ClaveTipoConcepto = null;
                            else NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);
                            NecesidadDetalles.Add(NecesidadDetalle);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return NecesidadDetalles;
        }

        public static NecesidadDetalle Insertar(NecesidadDetalle Detalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            NecesidadDetalle NecesidadDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadDetalleInsertar", Detalle.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        NecesidadDetalle = new NecesidadDetalle();
                        NecesidadDetalle.Clave = Convert.ToInt32(Reader["cveNecesidadDetalle"]);
                        NecesidadDetalle.Volumen = Convert.ToDouble(Reader["volumen"]);
                        NecesidadDetalle.PrecioUnitario = Convert.ToDouble(Reader["precioUnitario"]);
                        NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                        NecesidadDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                        string tipoconcepto = (Reader["cveTipoConcepto"]).ToString();
                        if ((tipoconcepto == ""))
                            NecesidadDetalle.ClaveTipoConcepto = null;
                        else NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);


                        DataSource.Cerrar();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return NecesidadDetalle;
        }

        public static NecesidadDetalle Actualizar(int ClaveDetalle, NecesidadDetalle Detalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            NecesidadDetalle NecesidadDetalle = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("NecesidadDetalleActualizar", ClaveDetalle, Detalle.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        NecesidadDetalle = new NecesidadDetalle();
                        NecesidadDetalle.Clave = Convert.ToInt32(Reader["cveNecesidadDetalle"]);
                        NecesidadDetalle.Volumen = Convert.ToDouble(Reader["volumen"]);
                        NecesidadDetalle.PrecioUnitario = Convert.ToDouble(Reader["precioUnitario"]);
                        NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(Reader["cveNecesidad"]);
                        NecesidadDetalle.ClaveConcepto = Convert.ToInt32(Reader["cveConcepto"]);
                        string tipoconcepto = (Reader["cveTipoConcepto"]).ToString();
                        if ((tipoconcepto == ""))
                            NecesidadDetalle.ClaveTipoConcepto = null;
                        else NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(Reader["cveTipoConcepto"]);
                     
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return NecesidadDetalle;
        }

        public static int Eliminar(int ClaveDetalle)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("NecesidadDetalleEliminar", ClaveDetalle);
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