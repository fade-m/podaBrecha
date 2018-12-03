using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class ProgramaDetalle
    {
        public int Clave { get; set; }
        public DateTime FechaInicio { get; set; }
        public double Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Programa Programa { get; set; }
        public int ClavePrograma { get; set; }

        public Circuito Circuito { get; set; }
        public int ClaveCircuito { get; set; }

        public Contrato Contrato { get; set; }
        public int? ClaveContrato { get; set; }

        public Concepto Concepto { get; set; }
        public int ClaveConcepto { get; set; }

        public TipoConcepto TipoConcepto { get; set; }
        public int ClaveTipoConcepto { get; set; }

        public List<Mes> Meses { get; set; } = new List<Mes>();

        public ProgramaDetalle Rellenar()
        {
            try
            {

                Programa = ProgramaDAO.Get(ClavePrograma);
                Circuito = CircuitoDAO.Get(ClaveCircuito);
                Contrato = ContratoDAO.Get(ClaveContrato);
                Concepto = ConceptoDAO.Get(ClaveConcepto);
                TipoConcepto = TipoConceptoDAO.Get(ClaveTipoConcepto);
                Meses = MesDAO.Listar().Where(m => m.ClaveDetallePrograma == Clave).ToList();
                return this;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Cantidad, FechaInicio.ToShortDateString(), PrecioUnitario, ClavePrograma,
                ClaveCircuito, ClaveContrato, ClaveConcepto, ClaveTipoConcepto };
        }

        public override string ToString()
        {
            return Cantidad.ToString();
        }
    }
}