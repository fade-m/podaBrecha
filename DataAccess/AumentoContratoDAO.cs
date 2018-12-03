using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class AumentoContratoDAO
    {
        /// <summary>
        /// Obtiene un aumento de contrato
        /// </summary>
        /// <param name="Clave">Clave del aumento a oobtener</param>
        /// <returns>El aumento de contrato</returns>
        public static AumentoContrato Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoContrato Aumento = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoContratoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Aumento = new AumentoContrato();
                        Aumento.Clave = Convert.ToInt32(Reader["cveAumento"].ToString());
                        Aumento.Porcentaje = Convert.ToDouble(Reader["porcentaje"].ToString());
                        Aumento.FechaCreacion = (DateTime)Reader["fechaCreacion"];

                        Aumento.ClaveContrato = Convert.ToInt32(Reader["cveContrato"].ToString());
                        Aumento.ClaveEstatus = Convert.ToInt32(Reader["cveEstatus"].ToString());
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Aumento;
        }

        /// <summary>
        /// Obtiene todos los aumentos de contratos
        /// </summary>
        /// <returns>Todos los aumentos de contrato</returns>
        public static List<AumentoContrato> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<AumentoContrato> Aumentos = new List<AumentoContrato>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoContratoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            AumentoContrato Aumento = new AumentoContrato();
                            Aumento.Clave = Convert.ToInt32(Reader["cveAumento"].ToString());
                            Aumento.Porcentaje = Convert.ToDouble(Reader["porcentaje"].ToString());
                            Aumento.FechaCreacion = (DateTime)Reader["fechaCreacion"];

                            Aumento.ClaveContrato = Convert.ToInt32(Reader["cveContrato"].ToString());
                            Aumento.ClaveEstatus = Convert.ToInt32(Reader["cveEstatus"].ToString());

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
        /// Inerta un aumento de contrato
        /// </summary>
        /// <param name="Aumento">El aumento de contrato a insertar</param>
        /// <returns>El aumento de contrato insertado</returns>
        public static AumentoContrato Insertar(AumentoContrato Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoContrato AumentoInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoContratoInsertar", Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AumentoInsertado = new AumentoContrato();
                        AumentoInsertado.Clave = Convert.ToInt32(Reader["cveAumento"].ToString());
                        AumentoInsertado.Porcentaje = Convert.ToDouble(Reader["porcentaje"].ToString());
                        AumentoInsertado.FechaCreacion = (DateTime)Reader["fechaCreacion"];

                        AumentoInsertado.ClaveContrato = Convert.ToInt32(Reader["cveContrato"].ToString());
                        AumentoInsertado.ClaveEstatus = Convert.ToInt32(Reader["cveEstatus"].ToString());
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
        /// Actualiza un aumento de contrato
        /// </summary>
        /// <param name="ClaveAumento">Clave del aumento a actualizar</param>
        /// <param name="Aumento">Aumento con los nuevos campos</param>
        /// <returns>El aumento de contrato actualizado</returns>
        public static AumentoContrato Actualizar(int ClaveAumento, AumentoContrato Aumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            AumentoContrato AumentoActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("AumentoConratoActualizar", ClaveAumento, Aumento.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        AumentoActualizado = new AumentoContrato();
                        AumentoActualizado.Clave = Convert.ToInt32(Reader["cveAumento"].ToString());
                        AumentoActualizado.Porcentaje = Convert.ToDouble(Reader["porcentaje"].ToString());
                        AumentoActualizado.FechaCreacion = (DateTime)Reader["fechaCreacion"];

                        AumentoActualizado.ClaveContrato = Convert.ToInt32(Reader["cveContrato"].ToString());
                        AumentoActualizado.ClaveEstatus = Convert.ToInt32(Reader["cveEstatus"].ToString());
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
        /// Elimina un aumento de contrato
        /// </summary>
        /// <param name="ClaveAumento">Clave del aumento a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveAumento)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("AumentoContratoEliminar", ClaveAumento);
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