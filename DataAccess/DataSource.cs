using System;
using System.Data.SqlClient;
using System.Configuration;

using PodaProject.Util;

namespace PodaProject.DataAccess
{
    public class DataSource
    {
        private const string ServerName = "PodaProjectConnectionString";
        public static string ServerPath = ConfigurationManager.ConnectionStrings[ServerName].ConnectionString;

        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Reader;

        private static object Lock = new object();

        /// <summary>
        /// Instancia del singleton
        /// </summary>
        private static DataSource Instancia = null;

        /// <summary>
        /// Obtiene la instancia del objeto singleton
        /// </summary>
        /// <returns></returns>
        public static DataSource GetInstancia()
        {
            if (Instancia == null)
            {
                lock (Lock)
                {
                    if (Instancia == null)
                    {
                        Instancia = new DataSource();
                        
                    }
                }
            }

            return Instancia;
        }

        /// <summary>
        /// No permite construir un nuevo objeto de este tipo (Patrón singleton)
        /// </summary>
        private DataSource()
        {

        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado de tipo SELECT
        /// </summary>
        /// <param name="Nombre">Nombre del procedimiento almacenado</param>
        /// <param name="Parametros">Parametros del procedimiento almacenado</param>
        /// <returns>Resultado de ejecutar el procedimiento almacenado</returns>
        public SqlDataReader ConsultarProcedimiento(string Nombre, params object[] Parametros)
        {
            string Sql = "Exec " + Nombre + " " + Utilerias.FormatearParametros(Parametros);
   
            try
            {
                Conexion = new SqlConnection(ServerPath);
                Comando = new SqlCommand(Sql, Conexion);
                Conexion.Open();
                
                Reader = Comando.ExecuteReader();
               
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return Reader;
        }

        /// <summary>
        /// Realiza una consulta sql a la base de datos
        /// </summary>
        /// <param name="Sql">Comando sql a ejecutar</param>
        /// <returns>Resultado de ejecutar el comando sql</returns>
        public SqlDataReader ConsultarSql(string Sql)
        {
            try
            {
                Conexion = new SqlConnection(ServerPath);
                Comando = new SqlCommand(Sql, Conexion);
                Conexion.Open();
                Reader = Comando.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }

            return Reader;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado de tipo UPDATE, DELETE e INSERT
        /// </summary>
        /// <param name="Nombre">Nombre del procedimiento almacenado</param>
        /// <param name="Parametros">Parametros del procedimiento almacenado</param>
        /// <returns>El número de filas afectadas por el procedimiento</returns>
        public int EjecutarProcedimiento(string Nombre, params object[] Parametros)
        {
            string Sql = "Exec " + Nombre + " " + Utilerias.FormatearParametros(Parametros);
            int filasAfectadas = 0;

            try
            {
                Conexion = new SqlConnection(ServerPath);
                Comando = new SqlCommand(Sql, Conexion);
                Conexion.Open();
                filasAfectadas = Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Ejecuta un comando sql en la base de datos
        /// </summary>
        /// <param name="Sql">Comando sql a ejecutar</param>
        /// <returns>Número de filas afectadas por el comando sql</returns>
        public int EjecutarNonQuery(string Sql)
        {
            int filasAfectadas = 0;

            try
            {
                Conexion = new SqlConnection(ServerPath);
                Comando = new SqlCommand(Sql, Conexion);
                filasAfectadas = Comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Lbera todos los recuros utlizados por la instancia
        /// </summary>
        public void Cerrar()
        {
            if (Reader != null && !Reader.IsClosed)
            {
                Reader.Close();
            }

            if (Comando != null)
            {
                Comando.Dispose();
            } 

            if (Conexion != null)
            {
                Conexion.Dispose();
                Conexion.Close();
            }
        }
    }

}