using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class Programacion
    {
        public int Clave { get; set; }
        public double Programado { get; set; }

        public Mes Mes { get; set; }
        public int ClaveMes { get; set; }

        public OrdenSurtimiento Orden { get; set; }
        public int ClaveOrden { get; set; }

        public Avance Avance { get; set; }
        public int ClaveAvance { get; set; }

        public Programacion Rellenar()
        {
            try
            {

                Mes = MesDAO.Get(ClaveMes);
                Orden = OrdenSurtimientoDAO.Get(ClaveOrden);
                Avance = AvanceDAO.Get(ClaveAvance);
                return this;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Programado, ClaveMes, ClaveOrden };
        }

        public override string ToString()
        {
            return string.Format("%.2f", Programado);
        }
    }
}