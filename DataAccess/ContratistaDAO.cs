using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class ContratistaDAO
    {
        public static Contratista Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Contratista Contratista = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratistaSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Contratista = new Contratista();
                        Contratista.Clave = Convert.ToInt32(Reader["cveContratista"].ToString());
                        Contratista.Nombre = Reader["nombre"].ToString();
                        Contratista.RazonSocial = Reader["razonSocial"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Contratista;
        }

        public static List<Contratista> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Contratista> Contratistas = new List<Contratista>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratistaListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Contratista Contratista = new Contratista();
                            Contratista.Clave = Convert.ToInt32(Reader["cveContratista"].ToString());
                            Contratista.Nombre = Reader["nombre"].ToString();
                            Contratista.RazonSocial = Reader["razonSocial"].ToString();

                            Contratistas.Add(Contratista);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Contratistas;
        }

        public static Contratista Insertar(Contratista Contratista)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Contratista ContratistaInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratistaInsertar", Contratista.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ContratistaInsertado = new Contratista();
                        ContratistaInsertado.Clave = Convert.ToInt32(Reader["cveContratista"].ToString());
                        ContratistaInsertado.Nombre = Reader["nombre"].ToString();
                        ContratistaInsertado.RazonSocial = Reader["razonSocial"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ContratistaInsertado;
        }

        public static Contratista Actualizar(int ClaveContratista, Contratista Contratista)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Contratista ContratistaActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("ContratistaActualizar", ClaveContratista, Contratista.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        ContratistaActualizado = new Contratista();
                        ContratistaActualizado.Clave = Convert.ToInt32(Reader["cveContratista"].ToString());
                        ContratistaActualizado.Nombre = Reader["nombre"].ToString();
                        ContratistaActualizado.RazonSocial = Reader["razonSocial"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return ContratistaActualizado;
        }

        public static int Eliminar(int ClaveContratista)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("ContratistaEliminar", ClaveContratista);
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