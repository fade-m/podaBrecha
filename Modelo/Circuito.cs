using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Circuito
    {
        public int Clave { get; set; }
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public Area Area { get; set; }
        public int ClaveArea { get; set; }

        public List<ProgramaDetalle> DetallesPrograma { get; set; } = new List<ProgramaDetalle>();
        public List<AumentoCircuito> Aumentos { get; set; } = new List<AumentoCircuito>();

        public Circuito Rellenar()
        {
            try
            {
                Area = AreaDAO.Get(ClaveArea);
                DetallesPrograma = ProgramaDetalleDAO.Listar().Where(p => p.ClaveCircuito == Clave).ToList();
                Aumentos = AumentoCircuitoDAO.Listar().Where(a => a.ClaveCircuito == Clave).ToList();

                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        
        }

        public object[] ToParams()
        {
            return new object[] { Codigo, ClaveArea };
        }

        public override string ToString()
        {
            return Codigo;
        }
    }
}