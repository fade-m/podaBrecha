using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class AumentoDetalle
    {
        public int Clave { get; set; }

        public AumentoContrato Aumento { get; set; }
        public int ClaveAumento { get; set; }

        public Concepto Concepto { get; set; }
        public int ClaveConcepto { get; set; }

        public TipoConcepto TipoConcepto { get; set; }
        public int ClaveTipoConcepto { get; set; }

        public List<AumentoCircuito> Aumentos { get; set; } = new List<AumentoCircuito>();

        public AumentoDetalle Rellenar()
        {
            try
            {
                Aumento = AumentoContratoDAO.Get(ClaveAumento);
                Concepto = ConceptoDAO.Get(ClaveConcepto);
                TipoConcepto = TipoConceptoDAO.Get(ClaveTipoConcepto);
                Aumentos = AumentoCircuitoDAO.Listar().Where(a => a.ClaveDetalleAumento == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
      
        }

        public object[] ToParams()
        {
            return new object[] { ClaveAumento, ClaveConcepto, ClaveTipoConcepto };
        }

        public override string ToString()
        {
            return Clave.ToString();
        }
    }
}