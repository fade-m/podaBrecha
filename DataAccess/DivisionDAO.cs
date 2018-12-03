using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class DivisionDAO
    {
        /// <summary>
        /// Obtiene una división
        /// </summary>
        /// <param name="Clave">Clave de la división a encontrar</param>
        /// <returns>La división encontrada</returns>
        public static Division Get(int? Clave)
        {
            if (Clave == null) return null;

            DataSource DataSource = DataSource.GetInstancia();
            Division Division = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("DivisionSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Division = new Division();

                        Division.Clave = Convert.ToInt32(Reader["cveDivision"].ToString());
                        Division.Codigo = Reader["codigo"].ToString();
                        Division.Nombre = Reader["nombre"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Division;
        }

        /// <summary>
        /// Retorna todas las divisiones
        /// </summary>
        /// <returns>Todas las divisiones</returns>
        public static List<Division> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Division> Divisiones = new List<Division>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("DivisionListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Division Division = new Division();

                            Division.Clave = Convert.ToInt32(Reader["cveDivision"].ToString());
                            Division.Codigo = Reader["codigo"].ToString();
                            Division.Nombre = Reader["nombre"].ToString();

                            Divisiones.Add(Division);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Divisiones;
        }

        /// <summary>
        /// Inserta un usuario
        /// </summary>
        /// <param name="Division">Division a insertar</param>
        /// <returns>La división insertada</returns>
        public static Division Insertar(Division Division)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Division DivisionInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("DivisionInsertar", Division.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        DivisionInsertada = new Division();

                        DivisionInsertada.Clave = Convert.ToInt32(Reader["cveDivision"].ToString());
                        DivisionInsertada.Codigo = Reader["codigo"].ToString();
                        DivisionInsertada.Nombre = Reader["nombre"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return DivisionInsertada;
        }

        /// <summary>
        /// Actualiza una división
        /// </summary>
        /// <param name="ClaveDivision">Clave de la división</param>
        /// <param name="Division">División con los nuevos campos</param>
        /// <returns>La división actualizada</returns>
        public static Division Actualizar(int ClaveDivision, Division Division)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Division DivisionActualizada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("DivisionActualizar", ClaveDivision, Division.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        DivisionActualizada = new Division();

                        DivisionActualizada.Clave = Convert.ToInt32(Reader["cveDivision"].ToString());
                        DivisionActualizada.Codigo = Reader["codigo"].ToString();
                        DivisionActualizada.Nombre = Reader["nombre"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return DivisionActualizada;
        }

        /// <summary>
        /// Elimina una división
        /// </summary>
        /// <param name="ClaveDivision">Clave de la división a eliminar</param>
        /// <returns>El número de las filas afectadas por el query</returns>
        public static int Eliminar(int ClaveDivision)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("DivisionEliminar", ClaveDivision);
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