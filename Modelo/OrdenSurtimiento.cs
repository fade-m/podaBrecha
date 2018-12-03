using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class OrdenSurtimiento
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public List<Programacion> Programaciones { get; set; } = new List<Programacion>();

        public OrdenSurtimiento Rellenar()
        {
            try
            {
                Programaciones = ProgramacionDAO.Listar().Where(p => p.ClaveOrden == Clave).ToList();
                return this;
            }
            catch (Exception e)
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