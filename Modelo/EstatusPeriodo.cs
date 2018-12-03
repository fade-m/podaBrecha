using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class EstatusPeriodo
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<Periodo> Periodos { get; set; } = new List<Periodo>();

        public EstatusPeriodo Rellenar()
        {
            try
            {
                Periodos = PeriodoDAO.Listar().Where(p => p.ClaveEstatus == Clave).ToList();
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