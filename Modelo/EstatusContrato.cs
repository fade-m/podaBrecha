using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class EstatusContrato
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<Contrato> Contratos { get; set; } = new List<Contrato>();

        public EstatusContrato Rellenar()
        {
            try
            {
                Contratos = ContratoDAO.Listar().Where(c => c.ClaveEstatus == Clave).ToList();
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