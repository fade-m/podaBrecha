using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class AumentoCircuito
    {
        public int Clave { get; set; }
        public double Cantidad { get; set; }

        public Circuito Circuito { get; set; }
        public int ClaveCircuito { get; set; }
        
        public AumentoDetalle DetalleAumento { get; set; }
        public int ClaveDetalleAumento { get; set; }

        public AumentoCircuito Rellenar()
        {
            try
            {
                Circuito = CircuitoDAO.Get(ClaveCircuito);
                DetalleAumento = AumentoDetalleDAO.Get(ClaveDetalleAumento);
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public object[] ToParams()
        {
            return new object[] { Cantidad, ClaveCircuito, ClaveDetalleAumento };
        }

        public override string ToString()
        {
            return string.Format("%.2f", Cantidad);
        }
    }
}