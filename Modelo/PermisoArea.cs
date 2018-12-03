using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class PermisoArea
    {
        public int Clave { get; set; }
        public DateTime FechaOtorgado { get; set; }

        public Area Area { get; set; }
        public int ClaveArea { get; set; }

        public EstatusPermiso Estatus { get; set; }
        public int ClaveEstatus { get; set; }

        public Permiso Permiso { get; set; }
        public int ClavePermiso { get; set; }

        public PermisoArea Rellenar()
        {
            try
            {
                Area = AreaDAO.Get(ClaveArea);
                Estatus = EstatusPermisoDAO.Get(ClaveEstatus);
                Permiso = PermisoDAO.Get(ClavePermiso);
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { FechaOtorgado.ToShortDateString(), ClaveArea, ClaveEstatus, ClavePermiso };
        }

        public override string ToString()
        {
            return Clave.ToString();
        }
    }
}