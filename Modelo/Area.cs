using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Area
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public Zona Zona { get; set; }
        public int ClaveZona { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<PresupuestoArea> Presupuestos { get; set; } = new List<PresupuestoArea>();
        public List<PermisoArea> Permisos { get; set; } = new List<PermisoArea>();
        public List<Circuito> Circuitos { get; set; } = new List<Circuito>();
        public List<Necesidad> Necesidades { get; set; } = new List<Necesidad>();

        public Area Rellenar()
        {
            try
            {
                Zona = ZonaDAO.Get(ClaveZona);
                Usuarios = UsuarioDAO.Listar().Where(u => u.ClaveArea == Clave).ToList();
                Presupuestos = PresupuestoAreaDAO.Listar().Where(p => p.ClaveArea == Clave).ToList();
                Permisos = PermisoAreaDAO.Listar().Where(p => p.ClaveArea == Clave).ToList();
                Circuitos = CircuitoDAO.Listar().Where(c => c.ClaveArea == Clave).ToList();
                Necesidades = NecesidadDAO.Listar().Where(n => n.ClaveArea == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
             
        }
        
        public PresupuestoArea PresupuestoActual(int ClavePresupuestoZona)
        {
            if (Presupuestos.Count == 0)
            {
                Presupuestos = PresupuestoAreaDAO.Listar().Where(p => p.ClaveArea == Clave).ToList();
            }

            return Presupuestos.FirstOrDefault(p => p.ClavePresupuestoZona == ClavePresupuestoZona);
        }

        public Necesidad NecesidadActual (int ClavePeriodo)
        {
            if (Necesidades.Count == 0)
            {
                Necesidades = NecesidadDAO.Listar().Where(n => n.ClaveArea == Clave).ToList();
            }

            return Necesidades.FirstOrDefault(n => n.ClavePeriodo == ClavePeriodo);
        }

        public Necesidad NecesidadInicial (int ClavePeriodo)
        {
            Necesidad Actual = NecesidadActual(ClavePeriodo);
            return Necesidades.FirstOrDefault(n => n.ClavePeriodo == ClavePeriodo && n.Clave != Actual?.Clave) ?? Actual;
        }

        public object[] ToParams()
        {
            return new object[] { Nombre, Codigo, ClaveZona };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}