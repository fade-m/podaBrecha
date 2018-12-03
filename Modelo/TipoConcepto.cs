using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class TipoConcepto
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        
        public Concepto Concepto { get; set; }
        public int ClaveConcepto { get; set; }

        public List<ProgramaDetalle> DetallesPrograma { get; set; } = new List<ProgramaDetalle>();
        public List<NecesidadDetalle> DetallesNecesidad { get; set; } = new List<NecesidadDetalle>();

        public List<AumentoDetalle> DetallesAumento { get; set; } = new List<AumentoDetalle>();

        public TipoConcepto Rellenar()
        {
            try
            {

                Concepto = ConceptoDAO.Get(ClaveConcepto);
                DetallesPrograma = ProgramaDetalleDAO.Listar().Where(d => d.ClaveTipoConcepto == Clave).ToList();
                DetallesNecesidad = NecesidadDetalleDAO.Listar().Where(n => n.ClaveTipoConcepto == Clave).ToList();
                DetallesAumento = AumentoDetalleDAO.Listar().Where(a => a.ClaveTipoConcepto == Clave).ToList();
                return this;

            }
            catch (Exception e)
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
                List<NecesidadDetalle> Detalles = n?.Detalles.Where(d => d.ClaveTipoConcepto == Clave).ToList() ?? new List<NecesidadDetalle>();

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
                List<NecesidadDetalle> Detalles = n?.Detalles.Where(d => d.ClaveTipoConcepto == Clave).ToList() ?? new List<NecesidadDetalle>();

                foreach (NecesidadDetalle d in Detalles)
                {
                    ImporteTotal += d.CalcularImporte();
                }
            }

            return ImporteTotal;
        }


        public object[] ToParams()
        {
            return new object[] { Descripcion, ClaveConcepto };
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}