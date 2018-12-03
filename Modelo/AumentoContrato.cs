using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class AumentoContrato
    {
        public int Clave { get; set; }
        public double Porcentaje { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Contrato Contrato { get; set; }
        public int ClaveContrato { get; set; }

        public EstatusAumento Estatus { get; set; }
        public int ClaveEstatus { get; set; }

        public List<AumentoDetalle> Detalles { get; set; } = new List<AumentoDetalle>();

        public AumentoContrato Rellenar()
        {
            try
            {
                Contrato = ContratoDAO.Get(ClaveContrato);
                Estatus = EstatusAumentoDAO.Get(ClaveEstatus);
                Detalles = AumentoDetalleDAO.Listar().Where(a => a.ClaveAumento == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

        public object[] ToParams()
        {
            return new object[] { Porcentaje, FechaCreacion, ClaveContrato, ClaveEstatus };
        }

        public override string ToString()
        {
            return string.Format("%.2f", Porcentaje);
        }
    }
}