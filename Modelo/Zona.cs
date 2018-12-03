using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Zona
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public Division Division { get; set; }
        public int ClaveDivision { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<PresupuestoZona> Presupuestos { get; set; } = new List<PresupuestoZona>();
        public List<Area> Areas { get; set; } = new List<Area>();

        public Zona Rellenar()
        {
            try
            {
                Division = DivisionDAO.Get(ClaveDivision);
                Usuarios = UsuarioDAO.Listar().Where(u => u.ClaveZona == Clave).ToList();
                Presupuestos = PresupuestoZonaDAO.Listar().Where(p => p.ClaveZona == Clave).ToList();
                Areas = AreaDAO.Listar().Where(a => a.ClaveZona == Clave).ToList();
                return this;

            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public object[] ToParams()
        {
            return new object[] { Nombre, Codigo, ClaveDivision };
        }

        public PresupuestoZona PresupuestoActual(int ClavePresupuestoDivison)
        {
            if (Presupuestos.Count == 0)
            {
                Presupuestos = PresupuestoZonaDAO.Listar().Where(p => p.ClaveZona == Clave).ToList();
            }

            return Presupuestos.FirstOrDefault(p => p.ClavePresupuestoDivisional == ClavePresupuestoDivison);
        }

        public double NecesidadTotal(int ClavePeriodo)
        {
            double NecesidadTotal = 0.0;

            if (Areas.Count == 0)
            {
                Areas = AreaDAO.Listar().Where(a => a.ClaveZona == Clave).ToList();
            }

            foreach (Area a in Areas)
            {
                NecesidadTotal += a.NecesidadActual(ClavePeriodo)?.CalcularImporte() ?? 0.0;
            }

            return NecesidadTotal;
        }

        public double NecesidadInicial(int ClavePeriodo)
        {
            double NecesidadInicial = 0.0;

            if (Areas.Count == 0)
            {
                Areas = AreaDAO.Listar().Where(a => a.ClaveZona == Clave).ToList();
            }

            foreach (Area a in Areas)
            {
                NecesidadInicial = a.NecesidadInicial(ClavePeriodo)?.CalcularImporte() ?? 0.0;
            }

            return NecesidadInicial;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}