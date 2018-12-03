using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class Avance
    {
        public int Clave { get; set; }
        public double Ejecutado { get; set; }
        public string Observacioens { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Programacion Programacion { get; set; }
        public int ClaveProgramacion { get; set; }

        public Avance Rellenar()
        {
            try
            {
                Programacion = ProgramacionDAO.Get(ClaveProgramacion);
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

        public object[] ToParams()
        {
            return new object[] { Ejecutado, Observacioens, FechaCreacion.ToShortDateString(), ClaveProgramacion };
        }

        public override string ToString()
        {
            return string.Format("%.2f", Ejecutado);
        }
    }
}