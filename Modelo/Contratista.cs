using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Contratista
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }

        public List<Contrato> Contratos { get; set; } = new List<Contrato>();

        public Contratista Rellenar()
        {
            try
            {
                Contratos = ContratoDAO.Listar().Where(c => c.ClaveContratista == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        public object[] ToParams()
        {
            return new object[] { Nombre, RazonSocial };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}