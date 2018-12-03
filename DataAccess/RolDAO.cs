using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PodaProject.DataAccess
{
    public class RolDAO
    {
        /// <summary>
        /// Obtiene un rol
        /// </summary>
        /// <param name="Clave">Clave del rol a buscar</param>
        /// <returns>Rol encontrado</returns>
        public static Rol Get(int Clave)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Rol Rol = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("RolSeleccionar", Clave))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Rol = new Rol();
                        Rol.Clave = Convert.ToInt32(Reader["cveRol"].ToString());
                        Rol.Nombre = Reader["nombre"].ToString();
                        Rol.Descripcion = Reader["descripcion"].ToString();
                        Rol.Plaza = Reader["plaza"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return Rol;
        }

        /// <summary>
        /// Retorna todos los roles
        /// </summary>
        /// <returns>Lista de roles</returns>
        public static List<Rol> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Rol> Roles = new List<Rol>();

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("RolListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Rol Rol = new Rol();
                            Rol.Clave = Convert.ToInt32(Reader["cveRol"].ToString());
                            Rol.Nombre = Reader["nombre"].ToString();
                            Rol.Descripcion = Reader["descripcion"].ToString();
                            Rol.Plaza = Reader["plaza"].ToString();

                            Roles.Add(Rol);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Roles;
        }

        /// <summary>
        /// Inserta un rol
        /// </summary>
        /// <param name="Rol">Rol a insertar</param>
        /// <returns>El rol insertado</returns>
        public static Rol Insertar(Rol Rol)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Rol RolInsertado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("RolInsertar", Rol.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        RolInsertado = new Rol();
                        RolInsertado.Clave = Convert.ToInt32(Reader["cveRol"].ToString());
                        RolInsertado.Nombre = Reader["nombre"].ToString();
                        RolInsertado.Descripcion = Reader["descripcion"].ToString();
                        RolInsertado.Plaza = Reader["plaza"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return RolInsertado;
        }

        /// <summary>
        /// Actualiza un rol
        /// </summary>
        /// <param name="ClaveRol">Clave del rol a actualizar</param>
        /// <param name="Rol">Rol con los campos nuevos</param>
        /// <returns>El rol actualizado</returns>
        public static Rol Actualizar(int ClaveRol, Rol Rol) 
        {
            DataSource DataSource = DataSource.GetInstancia();
            Rol RolActualizado = null;

            try
            {

                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("RolActualizar", ClaveRol, Rol.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        RolActualizado = new Rol();
                        RolActualizado.Clave = Convert.ToInt32(Reader["cveRol"].ToString());
                        RolActualizado.Nombre = Reader["nombre"].ToString();
                        RolActualizado.Descripcion = Reader["descripcion"].ToString();
                        RolActualizado.Plaza = Reader["plaza"].ToString();
                    }

                    DataSource.Cerrar();
                }
            }catch(Exception e)
            {
                throw e;
            }

            return RolActualizado;
        }

        /// <summary>
        /// Elimina un rol
        /// </summary>
        /// <param name="ClaveRol">Clave del rol a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveRol)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int filasAfectadas = -1;

            try
            {
                filasAfectadas = DataSource.EjecutarProcedimiento("RolEliminar", ClaveRol);
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