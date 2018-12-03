using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Usuario
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool EsJefeDivision { get; set; }
        public bool EsJefeZona { get; set; }
        public bool EsJefeArea { get; set; }
        public bool EsAdmin { get; set; }

        public Rol Rol { get; set; }
        public int ClaveRol { get; set; }
        
        public Division Division { get; set; }
        public int? ClaveDivision { get; set; }

        public Zona Zona { get; set; }
        public int? ClaveZona { get; set; }
        
        public Area Area { get; set; }
        public int? ClaveArea { get; set; }

        /// <summary>
        /// Rellena los campos del usuario que tengan que ver con otras clases
        /// </summary>
        /// <returns>Este usuario</returns>
        public Usuario Rellenar()
        {
            try
            {

                Rol = RolDAO.Get(ClaveRol);
                Division = DivisionDAO.Get(ClaveDivision);
                Zona = ZonaDAO.Get(ClaveZona);
                Area = AreaDAO.Get(ClaveArea);

                return this;
            }
            catch(Exception e)
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
            return new object[] { Nombre, Apellidos, Codigo, Password, Correo, EsJefeDivision,
                EsJefeZona, EsJefeArea, EsAdmin, ClaveRol, ClaveDivision, ClaveZona, ClaveArea };
        }

        public string NombreCompleto()
        {
            return Nombre.Trim() + " " + Apellidos.Trim();
        }

        public string NombreCorto()
        {
            return Nombre.Split(' ').First() + " " + Apellidos.Split(' ').First();
        }

        public List<Periodo> ConsultarPeriodos()
        {
            Rellenar();

            if (Division != null)
            {
                return Division.Rellenar().Periodos;
            }

            if (Zona != null)
            {
                return Zona.Rellenar().Division.Rellenar().Periodos;
            }

            if (Area != null)
            {
                return Area.Rellenar().Zona.Rellenar().Division.Rellenar().Periodos;
            }

            return new List<Periodo>();
        }

        public Periodo ConsultarPeriodoActual()
        {
            return ConsultarPeriodos().FirstOrDefault(p => p.EsActivo);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}