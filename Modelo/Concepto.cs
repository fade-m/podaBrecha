using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Concepto
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string MedidaAbreviacion { get; set; }
        public string MedidaPlural { get; set; }
        public string MedidaSingular { get; set; }

        public List<TipoConcepto> Tipos { get; set; } = new List<TipoConcepto>();
        public List<NecesidadDetalle> Necesidades { get; set; } = new List<NecesidadDetalle>();
        public List<ProgramaDetalle> Detalles { get; set; } = new List<ProgramaDetalle>();
        public List<AumentoDetalle> Aumentos { get; set; } = new List<AumentoDetalle>();

        public Concepto Rellenar()
        {
            try
            {
                Tipos = TipoConceptoDAO.Listar().Where(t => t.ClaveConcepto == Clave).ToList();
                Necesidades = NecesidadDetalleDAO.Listar().Where(n => n.ClaveConcepto == Clave).ToList();
                //Detalles = ProgramaDetalleDAO.Listar().Where(p => p.ClaveConcepto == Clave).ToList();
                Aumentos = AumentoDetalleDAO.Listar().Where(a => a.ClaveConcepto == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
       
        }

        public double CalcularVolumenTotal(List<Area> Areas, int ClavePeriodo)
        {
            double VolumenTotal = 0.0;

            foreach (Area a in Areas)
            {
                Necesidad n = a.NecesidadActual(ClavePeriodo)?.Rellenar();
                List<NecesidadDetalle> Detalles = n?.Detalles.Where(d => d.ClaveConcepto == Clave).ToList() ?? new List<NecesidadDetalle>();

                foreach (NecesidadDetalle d in Detalles)
                {
                    VolumenTotal += d.Volumen;
                }
            }

            return VolumenTotal;
        }

        public double CalcularImporteTotal(List<Area> Areas, int ClavePeriodo)
        {
            double ImporteTotal = 0.0;

            foreach (Area a in Areas)
            {
                Necesidad n = a.NecesidadActual(ClavePeriodo)?.Rellenar();
                List<NecesidadDetalle> Detalles = n?.Detalles.Where(d => d.ClaveConcepto == Clave).ToList() ?? new List<NecesidadDetalle>();

                foreach (NecesidadDetalle d in Detalles)
                {
                    ImporteTotal += d.CalcularImporte();
                }
            }

            return ImporteTotal;
        }

        public object[] ToParams()
        {
            return new object[] { Descripcion, MedidaAbreviacion, MedidaPlural, MedidaSingular };
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}