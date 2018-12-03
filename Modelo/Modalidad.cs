using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Modalidad
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }

        public List<Contrato> Contratos { get; set; } = new List<Contrato>();

        public Modalidad Rellenar()
        {
            try
            {

                Contratos = ContratoDAO.Listar().Where(c => c.ClaveModalidad == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Nombre };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}