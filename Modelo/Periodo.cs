using PodaProject.DataAccess;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Periodo
    {
        public int Clave { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }

        public Division Division { get; set; }
        public int ClaveDivision { get; set; }

        public EstatusPeriodo Estatus { get; set; }
        public int ClaveEstatus { get; set; }

        public List<PresupuestoDivision> Presupuestos { get; set; } = new List<PresupuestoDivision>();
        public List<Necesidad> Necesidades { get; set; } = new List<Necesidad>();


        public Periodo Rellenar()
        {
            try
            {
                Division = DivisionDAO.Get(ClaveDivision);
                Estatus = EstatusPeriodoDAO.Get(ClaveEstatus);
                Presupuestos = PresupuestoDivisionDAO.Listar().Where(p => p.ClavePeriodo == Clave).ToList();
                Necesidades = NecesidadDAO.Listar().Where(n => n.ClavePeriodo == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        public PresupuestoDivision ConsultarPresupuestoActual()
        {
            Presupuestos = PresupuestoDivisionDAO.Listar().Where(p => p.ClavePeriodo == Clave).ToList();
            return Presupuestos.FirstOrDefault() ?? new PresupuestoDivision();
        }

        public object[] ToParams()
        {
            return new object[] { FechaInicio.ToShortDateString(), FechaFin.ToShortDateString(), Descripcion,
                EsActivo, ClaveEstatus, ClaveDivision };
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public string[] GetDatosGrafica()
        {
            return new string[] { Descripcion, ConsultarPresupuestoActual()?.ToString() };
        }
    }
}