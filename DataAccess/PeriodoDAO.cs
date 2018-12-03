using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PodaProject.DataAccess
{
    public class PeriodoDAO
    {
        /// <summary>
        /// Retorna un periodo
        /// </summary>
        /// <param name="Clave">Clave del periodo a encontrar</param>
        /// <returns>El periodo encontrado</returns>
        public static Periodo Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Periodo Periodo = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PeriodoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Periodo = new Periodo();
                        Periodo.Clave = Convert.ToInt32(Reader["cvePeriodo"].ToString());
                        Periodo.FechaInicio = (DateTime)Reader["fechaInicio"];
                        Periodo.FechaFin = (DateTime)Reader["fechaFin"];
                        Periodo.Descripcion = Reader["descripcion"].ToString();
                        Periodo.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                        Periodo.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPeriodo"].ToString());
                        Periodo.EsActivo = Convert.ToBoolean(Reader["esActivo"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Periodo;
        } 

        /// <summary>
        /// Retorna todos los periodos
        /// </summary>
        /// <returns>Todos los periodos</returns>
        public static List<Periodo> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Periodo> Periodos = new List<Periodo>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PeriodoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Periodo Periodo = new Periodo();
                            Periodo.Clave = Convert.ToInt32(Reader["cvePeriodo"].ToString());
                            Periodo.FechaInicio = (DateTime)Reader["fechaInicio"];
                            Periodo.FechaFin = (DateTime)Reader["fechaFin"];
                            Periodo.Descripcion = Reader["descripcion"].ToString();
                            Periodo.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                            Periodo.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPeriodo"].ToString());
                            Periodo.EsActivo = Convert.ToBoolean(Reader["esActivo"]);

                            Periodos.Add(Periodo);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Periodos;
        }

        /// <summary>
        /// inserta un periodo
        /// </summary>
        /// <param name="Periodo">Periodo a insertar</param>
        /// <returns>El periodo insertado</returns>
        public static Periodo Insertar(Periodo Periodo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Periodo PeriodoInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PeriodoInsertar", Periodo.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        PeriodoInsertado = new Periodo();
                        PeriodoInsertado.Clave = Convert.ToInt32(Reader["cvePeriodo"].ToString());
                        PeriodoInsertado.FechaInicio = (DateTime)Reader["fechaInicio"];
                        PeriodoInsertado.FechaFin = (DateTime)Reader["fechaFin"];
                        PeriodoInsertado.Descripcion = Reader["descripcion"].ToString();
                        PeriodoInsertado.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                        PeriodoInsertado.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPeriodo"].ToString());
                        PeriodoInsertado.EsActivo = Convert.ToBoolean(Reader["esActivo"]);
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return PeriodoInsertado;
        }

        /// <summary>
        /// Actualiza un periodo
        /// </summary>
        /// <param name="ClavePeriodo">Clave del periodo a actualizar</param>
        /// <param name="Periodo">Periodo con los nuevos campos</param>
        /// <returns>El periodo actualizado</returns>
        public static Periodo Actualizar(int ClavePeriodo, Periodo Periodo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Periodo PeriodoActualizado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("PeriodoActualizar", ClavePeriodo, Periodo.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        PeriodoActualizado = new Periodo();
                        PeriodoActualizado.Clave = Convert.ToInt32(Reader["cvePeriodo"].ToString());
                        PeriodoActualizado.FechaInicio = (DateTime)Reader["fechaInicio"];
                        PeriodoActualizado.FechaFin = (DateTime)Reader["fechaFin"];
                        PeriodoActualizado.Descripcion = Reader["descripcion"].ToString();
                        PeriodoActualizado.ClaveDivision = Convert.ToInt32(Reader["cveDivision"].ToString());
                        PeriodoActualizado.ClaveEstatus = Convert.ToInt32(Reader["cveEstatusPeriodo"].ToString());
                        PeriodoActualizado.EsActivo = Convert.ToBoolean(Reader["esActivo"]);
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return PeriodoActualizado;
        }

        /// <summary>
        /// Elimina un periodo
        /// </summary>
        /// <param name="ClavePeriodo">Clave del periodo a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClavePeriodo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("PeriodoEliminar", ClavePeriodo);
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