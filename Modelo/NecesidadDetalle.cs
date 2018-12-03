using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class NecesidadDetalle
    {
        public int Clave { get; set; }
        public double Volumen { get; set; }
        public double PrecioUnitario { get; set; }

        public Necesidad Necesidad { get; set; }
        public int ClaveNecesidad { get; set; }

        public Concepto Concepto { get; set; }
        public int ClaveConcepto { get; set; }

        public TipoConcepto TipoConcepto { get; set; }
        public int? ClaveTipoConcepto { get; set; }

        public NecesidadDetalle Rellenar()
        {
            try
            {

                Necesidad = NecesidadDAO.Get(ClaveNecesidad);
                Concepto = ConceptoDAO.Get(ClaveConcepto);
                TipoConcepto = TipoConceptoDAO.Get(ClaveTipoConcepto);
                return this;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public double CalcularImporte()
        {
            return Volumen * PrecioUnitario;
        }

        public object[] ToParams()
        {
            return new object[] { Volumen, PrecioUnitario, ClaveNecesidad, ClaveConcepto, ClaveTipoConcepto };
        }

        public override string ToString()
        {
            return Volumen.ToString();
        }
    }
}