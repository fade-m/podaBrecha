using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Contrato
    {
        public int Clave { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaAdjudicacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Pdf { get; set; }

        public Contratista Contratista { get; set; }
        public int ClaveContratista { get; set; }

        public EstatusContrato Estatus { get; set; }
        public int ClaveEstatus { get; set; }

        public Modalidad Modalidad { get; set; }
        public int ClaveModalidad { get; set; }

        public List<AumentoContrato> Aumentos { get; set; } = new List<AumentoContrato>();

        public Contrato Rellenar()
        {
            try
            {
                Contratista = ContratistaDAO.Get(ClaveContratista);
                Estatus = EstatusContratoDAO.Get(ClaveEstatus);
                Modalidad = ModalidadDAO.Get(ClaveModalidad);
                Aumentos = AumentoContratoDAO.Listar().Where(a => a.ClaveContrato == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        public object[] ToParams()
        {
            return new object[] { Codigo, FechaAdjudicacion.ToShortDateString(), FechaInicio.ToShortDateString(),
                FechaCreacion.ToShortDateString(), Pdf, ClaveContratista, ClaveEstatus, ClaveModalidad};
        }

        public override string ToString()
        {
            return Codigo;
        }
    }
}