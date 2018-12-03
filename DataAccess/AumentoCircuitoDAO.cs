using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class AumentoCircuitoDAO
    {
        /// <summary>
        /// Obtiene un aumento de circuito
        /// </summary>
        /// <param name="Clave">Clave del aumento a obtener</param>
        /// <returns>El aumento del circuito</returns>
        public static AumentoCircuito Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoCircuito Aumento = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoCircuitoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Aumento = new AumentoCircuito();
                        Aumento.Clave = Convert.ToInt32(Reader["cveAumentoCircuito"]);
                        Aumento.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                        Aumento.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                        Aumento.ClaveDetalleAumento = Convert.ToInt32(Reader["cveAumentoDetalle"]);
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Aumento;
        }

        /// <summary>
        /// Obtiene todos los aumentos de ciruito
        /// </summary>
        /// <returns>Todos loa aumetos de circuito</returns>
        public static List<AumentoCircuito> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<AumentoCircuito> Aumentos = new List<AumentoCircuito>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoCircuitoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            AumentoCircuito Aumento = new AumentoCircuito();
                            Aumento.Clave = Convert.ToInt32(Reader["cveAumentoCircuito"]);
                            Aumento.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                            Aumento.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                            Aumento.ClaveDetalleAumento = Convert.ToInt32(Reader["cveAumentoDetalle"]);

                            Aumentos.Add(Aumento);
                        }
                    }

                    DataSource.Cerrar();
                }

            }
            catch(Exception e)
            {
                throw e;
            }

            return Aumentos;
        }

        /// <summary>
        /// Inserta un aumento de circuito
        /// </summary>
        /// <param name="Aumento">El aumento con los campos a insertar</param>
        /// <returns>El aumento insertado</returns>
        public static AumentoCircuito Insertar(AumentoCircuito Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoCircuito AumentoInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoCircuitoInsertar", Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AumentoInsertado = new AumentoCircuito();
                        AumentoInsertado.Clave = Convert.ToInt32(Reader["cveAumentoCircuito"]);
                        AumentoInsertado.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                        AumentoInsertado.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                        AumentoInsertado.ClaveDetalleAumento = Convert.ToInt32(Reader["cveAumentoDetalle"]);
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return AumentoInsertado;
        }

        /// <summary>
        /// Actualiza un aumento de circuito
        /// </summary>
        /// <param name="ClaveAumento">La clave del aumento a actualizar</param>
        /// <param name="Aumento">El aumento con los nuevos campos</param>
        /// <returns>El aumento actualizado</returns>
        public static AumentoCircuito Actualizar(int ClaveAumento, AumentoCircuito Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoCircuito AumentoActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoCircuitoActualizar", ClaveAumento, Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AumentoActualizado = new AumentoCircuito();
                        AumentoActualizado.Clave = Convert.ToInt32(Reader["cveAumentoCircuito"]);
                        AumentoActualizado.Cantidad = Convert.ToDouble(Reader["cantidad"]);
                        AumentoActualizado.ClaveCircuito = Convert.ToInt32(Reader["cveCircuito"]);
                        AumentoActualizado.ClaveDetalleAumento = Convert.ToInt32(Reader["cveAumentoDetalle"]);
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }


            return AumentoActualizado;
        }

        /// <summary>
        /// Elimina un aumento de circuito
        /// </summary>
        /// <param name="ClaveAumento">La clave del aumento a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveAumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("AumentoCircuitoEliminar", ClaveAumento);
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