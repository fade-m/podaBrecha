using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Rol
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Plaza { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public Rol Rellenar()
        {
            try
            {

                Usuarios = UsuarioDAO.Listar().Where(u => u.ClaveRol == Clave).ToList();
                return this;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Retorna un arreglo de objetos que representa las propiedades de la clase en forma de
        /// parametros para ejecutar en procedimiento almacenado
        /// </summary>
        /// <returns>Arreglo de propiedades de la clase</returns>
        public object[] ToParams()
        {
            return new object[] { Nombre, Descripcion, Plaza };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}