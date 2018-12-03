using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PodaProject.Modelo
{
    public class PresupuestoZona
    {
        public int Clave { get; set; }
        public double Monto { get; set; }

        public PresupuestoDivision PresupuestoDivisional { get; set; }
        public int ClavePresupuestoDivisional { get; set; }

        public Zona Zona { get; set; }
        public int ClaveZona { get; set; }

        public List<PresupuestoArea> PresupuestoArea { get; set; } = new List<PresupuestoArea>();

        public PresupuestoZona Rellenar()
        {
            try
            {

                PresupuestoDivisional = PresupuestoDivisionDAO.Get(ClavePresupuestoDivisional);
                Zona = ZonaDAO.Get(ClaveZona);
                PresupuestoArea = PresupuestoAreaDAO.Listar().Where(p => p.ClavePresupuestoZona == Clave).ToList();
                return this;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public double PresupuestoDisponible()
        {
            double TotalAreas = 0.0;

            if (Zona != null)
            {
                Zona = ZonaDAO.Get(ClaveZona);
            }

            List<Area> Areas = Zona?.Rellenar()?.Areas ?? new List<Area>();

            foreach(Area a in Areas)
            {
                TotalAreas += a.PresupuestoActual(Clave)?.Monto ?? 0.0;
            }

            return Monto - TotalAreas;
        }

        public object[] ToParams()
        {
            return new object[] { Monto, ClavePresupuestoDivisional, ClaveZona };
        }

        public override string ToString()
        {
            return Monto.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}