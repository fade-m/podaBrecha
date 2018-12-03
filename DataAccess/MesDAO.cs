using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class MesDAO
    {
        public static Mes Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Mes Mes = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MesSeleccionar", Clave))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Mes = new Mes();
                            Mes.Clave = Convert.ToInt32(Reader["cveMes"]);
                            Mes.Activo = Convert.ToBoolean(Reader["activo"]);
                            Mes.NumeroMes = Convert.ToInt32(Reader["numeroMes"]);
                            Mes.NombreMes = Reader["NombreMes"].ToString(); 
                            Mes.ClaveDetallePrograma = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Mes;
        }

        public static List<Mes> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Mes> Meses = new List<Mes>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MesListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Mes Mes = new Mes();
                            Mes.Clave = Convert.ToInt32(Reader["cveMes"]);
                            Mes.Activo = Convert.ToBoolean(Reader["activo"]);
                            Mes.NumeroMes = Convert.ToInt32(Reader["numeroMes"]);
                            Mes.NombreMes = Reader["NombreMes"].ToString();
                            Mes.ClaveDetallePrograma = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            Meses.Add(Mes);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Meses;
        }

        public static Mes Insertar(Mes Mes)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Mes MesInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MesInsertar", Mes.ToParams()))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            MesInsertado = new Mes();
                            MesInsertado.Clave = Convert.ToInt32(Reader["cveMes"]);
                            MesInsertado.Activo = Convert.ToBoolean(Reader["activo"]);
                            MesInsertado.NumeroMes = Convert.ToInt32(Reader["numeroMes"]);
                            MesInsertado.ClaveDetallePrograma = Convert.ToInt32(Reader["cveProgramaDetalle"]);
                            MesInsertado.NombreMes = Reader["NombreMes"].ToString();

                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return MesInsertado;
        }

        public static Mes Actualizar(int ClaveMes, Mes Mes)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Mes MesInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("MesActualizar", ClaveMes, Mes.ToParams()))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            MesInsertado = new Mes();
                            MesInsertado.Clave = Convert.ToInt32(Reader["cveMes"]);
                            MesInsertado.Activo = Convert.ToBoolean(Reader["activo"]);
                            MesInsertado.NumeroMes = Convert.ToInt32(Reader["numeroMes"]);
                            MesInsertado.NombreMes = Reader["NombreMes"].ToString();
                            MesInsertado.ClaveDetallePrograma = Convert.ToInt32(Reader["cveProgramaDetalle"]);

                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return MesInsertado;

        }

        public static int Eliminar(int ClaveMes)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("MesEliminar", ClaveMes);
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