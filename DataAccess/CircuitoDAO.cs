using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class CircuitoDAO
    {
        public static Circuito Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Circuito Circuito = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("CircuitoSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Circuito = new Circuito();
                        Circuito.Clave = Convert.ToInt32(Reader["cveCircuito"].ToString());
                        Circuito.Codigo = Reader["codigo"].ToString();
                        Circuito.ClaveArea = Convert.ToInt32(Reader["cveArea"].ToString());
                        Circuito.Descripcion = Reader["descripcion"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Circuito;
        }

        public static List<Circuito> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Circuito> Circuitos = new List<Circuito>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("CircuitoListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Circuito Circuito = new Circuito();
                            Circuito.Clave = Convert.ToInt32(Reader["cveCircuito"].ToString());
                            Circuito.Codigo = Reader["codigo"].ToString();
                            Circuito.ClaveArea = Convert.ToInt32(Reader["cveArea"].ToString());
                            Circuito.Descripcion = Reader["descripcion"].ToString();

                            Circuitos.Add(Circuito);
                        }

                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Circuitos;
        }

        public static Circuito Insertar(Circuito Circuito)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Circuito CircuitoInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("CircuitoInsertar", Circuito.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        CircuitoInsertado = new Circuito();
                        CircuitoInsertado.Clave = Convert.ToInt32(Reader["cveCircuito"].ToString());
                        CircuitoInsertado.Codigo = Reader["codigo"].ToString();
                        CircuitoInsertado.ClaveArea = Convert.ToInt32(Reader["cveArea"].ToString());
                        Circuito.Descripcion = Reader["descripcion"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return CircuitoInsertado;
        }

        public static Circuito Actualizar(int ClaveCircuito, Circuito Circuito)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Circuito CircuitoActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("CircuitoActualizar", ClaveCircuito, Circuito.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        CircuitoActualizado = new Circuito();
                        CircuitoActualizado.Clave = Convert.ToInt32(Reader["cveCircuito"].ToString());
                        CircuitoActualizado.Codigo = Reader["codigo"].ToString();
                        CircuitoActualizado.ClaveArea = Convert.ToInt32(Reader["cveArea"].ToString());
                        Circuito.Descripcion = Reader["descripcion"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return CircuitoActualizado;
        }

        public static int Eliminar(int ClaveCircuito)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("CircuitoEliminar", ClaveCircuito);
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