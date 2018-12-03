using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Programa
    {
        public int Clave { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Necesidad Necesidad { get; set; }
        public int ClaveNecesidad { get; set; }

        public List<ProgramaDetalle> Detalles { get; set; } = new List<ProgramaDetalle>();

        public Programa Rellenar()
        {
            try
            {
                Necesidad = NecesidadDAO.Get(ClaveNecesidad);
                Detalles = ProgramaDetalleDAO.Listar().Where(p => p.ClavePrograma == Clave).ToList();
                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { FechaCreacion.ToShortDateString(), ClaveNecesidad };
        }

        public override string ToString()
        {
            return Clave.ToString();
        }
    }
}