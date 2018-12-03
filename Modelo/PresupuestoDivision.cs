using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PodaProject.Modelo
{
    public class PresupuestoDivision
    {
        public int Clave { get; set; }
        public double Monto { get; set; }

        public Periodo Periodo { get; set; }
        public int ClavePeriodo { get; set; }

        public List<PresupuestoZona> PresupuestosZona { get; set; } = new List<PresupuestoZona>();

        public PresupuestoDivision Rellenar()
        {
            try
            {
                Periodo = PeriodoDAO.Get(ClavePeriodo);
                PresupuestosZona = PresupuestoZonaDAO.Listar().Where(p => p.ClavePresupuestoDivisional == Clave).ToList();
                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public double PresupuestoDisponible()
        {
            double TotalZonas = 0.0;
            
            if (Periodo == null)
            {
                Periodo = PeriodoDAO.Get(ClavePeriodo).Rellenar();
            }

            Division Division = Periodo?.Rellenar()?.Division;
            List<Zona> Zonas = Division?.Rellenar()?.Zonas ?? new List<Zona>();

            foreach (Zona z in Zonas)
            {
                TotalZonas += z.PresupuestoActual(Clave)?.Monto ?? 0.0;
            }

            return Monto - TotalZonas;
        }

        public object[] ToParams()
        {
            return new object[] { Monto, ClavePeriodo };
        }
        
        public override string ToString()
        {
            return Monto.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}