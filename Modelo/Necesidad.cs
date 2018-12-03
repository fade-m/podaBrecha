using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Necesidad
    {
        public int Clave { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Area Area { get; set; }
        public int ClaveArea { get; set; }

        public Periodo Periodo { get; set; }
        public int ClavePeriodo { get; set; }

        public EstatusNecesidad Estatus { get; set; }
        public int ClaveEstatus { get; set; }

        public List<NecesidadDetalle> Detalles { get; set; } = new List<NecesidadDetalle>();
        public List<Programa> Programas { get; set; } = new List<Programa>();

        public Necesidad Rellenar()
        {
            try
            {

                Area = AreaDAO.Get(ClaveArea);
                Periodo = PeriodoDAO.Get(ClavePeriodo);
                Estatus = EstatusNecesidadDAO.Get(ClaveEstatus);
                Detalles = NecesidadDetalleDAO.Listar().Where(n => n.ClaveNecesidad == Clave).ToList();
                Programas = ProgramaDAO.Listar().Where(p => p.ClaveNecesidad == Clave).ToList();
                return this;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public double CalcularImporte()
        {
            double Importe = 0.0;

            if (Detalles.Count == 0)
            {
                Detalles = NecesidadDetalleDAO.Listar().Where(n => n.ClaveNecesidad == Clave).ToList();
            }

            foreach(NecesidadDetalle d in Detalles)
            {
                Importe += d.CalcularImporte();
            }

            return Importe;
        }

        public object[] ToParams()
        {
            return new object[] { FechaCreacion.ToShortDateString(), ClaveArea, ClavePeriodo, ClaveEstatus };
        }

        public override string ToString()
        {
            return Clave.ToString();
        }
    }
}