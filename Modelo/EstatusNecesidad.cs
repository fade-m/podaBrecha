using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class EstatusNecesidad
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<Necesidad> Necesidades { get; set; } = new List<Necesidad>();

        public EstatusNecesidad Rellenar()
        {
            try
            {
                Necesidades = NecesidadDAO.Listar().Where(n => n.ClaveEstatus == Clave).ToList();
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