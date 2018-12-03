using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class EstatusAumento
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<AumentoContrato> Aumentos { get; set; } = new List<AumentoContrato>();

        public EstatusAumento Rellenar()
        {
            try
            {
                Aumentos = AumentoContratoDAO.Listar().Where(a => a.ClaveEstatus == Clave).ToList();
                return this;

            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        public object[] ToParams()
        {
            return new object[] { Descripcion };
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}