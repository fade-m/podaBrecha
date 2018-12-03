using PodaProject.Modelo;
using PodaProject.Util;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PodaProject.DataAccess
{
    public class UsuarioDAO
    {
        /// <summary>
        /// Recupera un usuario
        /// </summary>
        /// <param name="Correo">Correo del usuario a buscar</param>
        /// <param name="Password">Contraseña del usuario a buscar</param>
        /// <returns>El usuario encontrado</returns>
        public static Usuario Login(string Correo, string Password)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Usuario Usuario = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioLogin", Correo, Password))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Usuario = new Usuario();
                        Usuario.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                        Usuario.Nombre = Reader["nombre"].ToString();
                        Usuario.Apellidos = Reader["apellidos"].ToString();
                        Usuario.Codigo = Reader["codigo"].ToString();
                        Usuario.Correo = Reader["email"].ToString();
                        Usuario.Password = Reader["password"].ToString();
                        Usuario.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                        Usuario.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                        Usuario.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                        Usuario.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                        Usuario.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                        Usuario.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                        Usuario.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                        Usuario.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            

            return Usuario;
        }

        /// <summary>
        /// Encuentra un usuario con base a su correo
        /// </summary>
        /// <param name="Correo">El correo del usuario a buscar</param>
        /// <returns>El usuario encontrado</returns>
        public static Usuario BuscarPorCorreo(string Correo)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Usuario Usuario = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioBuscarPorCorreo", Correo))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Usuario = new Usuario();
                        Usuario.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                        Usuario.Nombre = Reader["nombre"].ToString();
                        Usuario.Apellidos = Reader["apellidos"].ToString();
                        Usuario.Codigo = Reader["codigo"].ToString();
                        Usuario.Correo = Reader["email"].ToString();
                        Usuario.Password = Reader["password"].ToString();
                        Usuario.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                        Usuario.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                        Usuario.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                        Usuario.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                        Usuario.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                        Usuario.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                        Usuario.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                        Usuario.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            

            return Usuario;
        }

        /// <summary>
        /// Retorna todos los usuarios
        /// </summary>
        /// <returns>Todos los usuarios</returns>
        public static List<Usuario> Listar()
        {
            DataSource DataSource = DataSource.GetInstancia();
            List<Usuario> Usuarios = new List<Usuario>();

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioListar"))
                {
                    if (Reader != null)
                    {
                        while (Reader.Read())
                        {
                            Usuario Usuario = new Usuario();
                            Usuario.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                            Usuario.Nombre = Reader["nombre"].ToString();
                            Usuario.Apellidos = Reader["apellidos"].ToString();
                            Usuario.Codigo = Reader["codigo"].ToString();
                            Usuario.Correo = Reader["email"].ToString();
                            Usuario.Password = Reader["password"].ToString();
                            Usuario.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                            Usuario.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                            Usuario.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                            Usuario.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                            Usuario.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                            Usuario.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                            Usuario.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                            Usuario.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);

                            Usuarios.Add(Usuario);
                        }
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            

            return Usuarios;
        }

        /// <summary>
        /// Retorna un usuario
        /// </summary>
        /// <param name="ClaveUsuario">Clave del usuario a encontrar</param>
        /// <returns>Usuario encontrado</returns>
        public static Usuario Get(int ClaveUsuario)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Usuario Usuario = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioSeleccionar", ClaveUsuario))
                {
                    if (Reader != null && Reader.Read())
                    {
                        Usuario = new Usuario();
                        Usuario.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                        Usuario.Nombre = Reader["nombre"].ToString();
                        Usuario.Apellidos = Reader["apellidos"].ToString();
                        Usuario.Codigo = Reader["codigo"].ToString();
                        Usuario.Correo = Reader["email"].ToString();
                        Usuario.Password = Reader["password"].ToString();
                        Usuario.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                        Usuario.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                        Usuario.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                        Usuario.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                        Usuario.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                        Usuario.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                        Usuario.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                        Usuario.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return Usuario;
        }

        /// <summary>
        /// Inserta un usuario
        /// </summary>
        /// <param name="Usuario">usuario a insertar</param>
        /// <returns>El usuario insertado</returns>
        public static Usuario Insertar(Usuario Usuario)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Usuario UsuarioInsertado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioInsertar", Usuario.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        UsuarioInsertado = new Usuario();
                        UsuarioInsertado.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                        UsuarioInsertado.Nombre = Reader["nombre"].ToString();
                        UsuarioInsertado.Apellidos = Reader["apellidos"].ToString();
                        UsuarioInsertado.Codigo = Reader["codigo"].ToString();
                        UsuarioInsertado.Correo = Reader["email"].ToString();
                        UsuarioInsertado.Password = Reader["password"].ToString();
                        UsuarioInsertado.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                        UsuarioInsertado.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                        UsuarioInsertado.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                        UsuarioInsertado.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                        UsuarioInsertado.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                        UsuarioInsertado.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                        UsuarioInsertado.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                        UsuarioInsertado.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return UsuarioInsertado;
        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="ClaveUsuario">Clave del usuario a actualizar</param>
        /// <param name="Nuevo">Usuario con los nuevos campos</param>
        /// <returns>El usuario atualizado</returns>
        public static Usuario Actualizar(int ClaveUsuario, Usuario Usuario)
        {
            DataSource DataSource = DataSource.GetInstancia();
            Usuario UsuarioActualizado = null;

            try
            {
                using (SqlDataReader Reader =
                    DataSource.ConsultarProcedimiento("UsuarioActualizar", ClaveUsuario, Usuario.ToParams()))
                {
                    if (Reader != null && Reader.Read())
                    {
                        UsuarioActualizado = new Usuario();
                        UsuarioActualizado.Clave = Convert.ToInt32(Reader["cveUsuario"]);
                        UsuarioActualizado.Nombre = Reader["nombre"].ToString();
                        UsuarioActualizado.Apellidos = Reader["apellidos"].ToString();
                        UsuarioActualizado.Codigo = Reader["codigo"].ToString();
                        UsuarioActualizado.Correo = Reader["email"].ToString();
                        UsuarioActualizado.Password = Reader["password"].ToString();
                        UsuarioActualizado.ClaveRol = Convert.ToInt32(Reader["cveRol"]);
                        UsuarioActualizado.ClaveDivision = Utilerias.ParsearNullable(Reader["cveDivision"].ToString());
                        UsuarioActualizado.ClaveZona = Utilerias.ParsearNullable(Reader["cveZona"].ToString());
                        UsuarioActualizado.ClaveArea = Utilerias.ParsearNullable(Reader["cveArea"].ToString());
                        UsuarioActualizado.EsJefeDivision = Convert.ToBoolean(Reader["esJefeDivision"]);
                        UsuarioActualizado.EsJefeZona = Convert.ToBoolean(Reader["esJefeZona"]);
                        UsuarioActualizado.EsJefeArea = Convert.ToBoolean(Reader["esJefeArea"]);
                        UsuarioActualizado.EsAdmin = Convert.ToBoolean(Reader["esAdmin"]);
                    }

                    DataSource.Cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return UsuarioActualizado;
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="ClaveUsuario">Clave del usuario a eliminar</param>
        /// <returns>El número de filas afectadas por el query</returns>
        public static int Eliminar(int ClaveUsuario)
        {
            DataSource DataSource = DataSource.GetInstancia();
            int FilasAfectadas = 0;

            try
            {
                FilasAfectadas = DataSource.EjecutarProcedimiento("UsuarioEliminar", ClaveUsuario);
                DataSource.Cerrar();
            }
            catch (Exception e)
            {
                throw e;
            }

            return FilasAfectadas;
        }
    }
}