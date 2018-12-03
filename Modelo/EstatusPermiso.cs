using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class EstatusPermiso
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<PermisoArea> PermisosDeAreas { get; set; } = new List<PermisoArea>();

        public EstatusPermiso Rellenar()
        {
            try
            {
                PermisosDeAreas = PermisoAreaDAO.Listar().Where(p => p.ClaveEstatus == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Descripcion };
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}