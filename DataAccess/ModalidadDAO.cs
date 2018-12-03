using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ModalidadDAO
    {
        public static Modalidad Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Modalidad Modalidad = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ModalidadSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Modalidad = new Modalidad();
                            Modalidad.Clave = Convert.ToInt32(Reader["cveModalidad"]);
                            Modalidad.Nombre = Reader["nombre"].ToString();
                           
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Modalidad;
        }

        public static List<Modalidad> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Modalidad> Modalidades = new List<Modalidad>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ModalidadListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Modalidad Modalidad = new Modalidad();
                            Modalidad.Clave = Convert.ToInt32(Reader["cveModalidad"]);
                            Modalidad.Nombre = Reader["nombre"].ToString();
                            Modalidades.Add(Modalidad);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Modalidades;
        }

        public static Modalidad Insertar(Modalidad Modalidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Modalidad ModalidadInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ModalidadInsertar", Modalidad.ToParams()))
                {
                    if (Reader != null && Reader.Read()) 
                    {

                        ModalidadInsertada = new Modalidad();
                        ModalidadInsertada.Clave = Convert.ToInt32(Reader["cveModalidad"]);
                        ModalidadInsertada.Nombre = Reader["nombre"].ToString();

                        
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ModalidadInsertada;
        }

        public static Modalidad Actualizar(int ClaveModalidad, Modalidad Modalidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Modalidad ModalidadInsertada = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ModalidadActualizar", ClaveModalidad, Modalidad.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {

                        ModalidadInsertada = new Modalidad();
                        ModalidadInsertada.Clave = Convert.ToInt32(Reader["cveModalidad"]);
                        ModalidadInsertada.Nombre = Reader["nombre"].ToString();


                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ModalidadInsertada;
        }

        public static int Eliminar(int ClaveModalidad)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ModalidadEliminar", ClaveModalidad);
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