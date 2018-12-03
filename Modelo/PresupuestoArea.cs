using PodaProject.DataAccess;
using System;
using System.Globalization;

namespace PodaProject.Modelo
{
    public class PresupuestoArea
    {
        public int Clave { get; set; }
        public double Monto { get; set; }

        public PresupuestoZona PresupuestoZona { get; set; }
        public int ClavePresupuestoZona { get; set; }

        public Area Area { get; set; }
        public int ClaveArea { get; set; }

        public PresupuestoArea Rellenar()
        {
            try
            {

                PresupuestoZona = PresupuestoZonaDAO.Get(ClavePresupuestoZona);
                Area = AreaDAO.Get(ClaveArea);
                return this;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Monto, ClavePresupuestoZona, ClaveArea };
        }

        public override string ToString()
        {
            return Monto.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}