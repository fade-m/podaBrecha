using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Permiso
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public List<PermisoArea> PermisosDeArea { get; set; } = new List<PermisoArea>();

        public Permiso Rellenar()
        {
            try
            {

                PermisosDeArea = PermisoAreaDAO.Listar().Where(p => p.ClavePermiso == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
        public object[] ToParams()
        {
            return new object[] { Descripcion, Codigo };
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}