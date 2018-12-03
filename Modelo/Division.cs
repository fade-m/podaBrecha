using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Division
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Periodo> Periodos { get; set; } = new List<Periodo>();
        public List<Zona> Zonas { get; set; } = new List<Zona>();

        public Division Rellenar()
        {
            try
            {
                Usuarios = UsuarioDAO.Listar().Where(u => u.ClaveDivision == Clave).ToList();
                Periodos = PeriodoDAO.Listar().Where(p => p.ClaveDivision == Clave).ToList();
                Zonas = ZonaDAO.Listar().Where(z => z.ClaveDivision == Clave).ToList();
                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Retorna un arreglo de objetos que representa las propiedades de la clase en forma de
        /// parametros para ejecutar en procedimiento almacenado
        /// </summary>
        /// <returns>Arreglo de propiedades de la clase</returns>
        public object[] ToParams()
        {
            return new object[] { Nombre, Codigo };
        }

        public PresupuestoDivision PresupuestoActual(int ClavePeriodo)
        {
            if (Periodos.Count == 0)
            {
                Periodos = PeriodoDAO.Listar().Where(p => p.ClaveDivision == Clave).ToList();
            }

            Periodo Periodo = Periodos.FirstOrDefault(p => p.Clave == ClavePeriodo);
            List<PresupuestoDivision> Presupuestos = Periodo.Rellenar().Presupuestos;

            return Presupuestos.FirstOrDefault(p => p.ClavePeriodo == ClavePeriodo);
        }

        public List<Area> ListarAreas()
        {
            List<Area> Areas = new List<Area>();

            if (Zonas.Count == 0)
            {
                Zonas = ZonaDAO.Listar().Where(z => z.ClaveDivision == Clave).ToList();
            }

            foreach (Zona z in Zonas)
            {
                z.Rellenar();

                foreach (Area a in z.Areas)
                {
                    Areas.Add(a);
                }
            }

            return Areas;
        }

        public double NecesidadTotal (int ClavePeriodo)
        {
            double NecesidadTotal = 0.0;

            if (Zonas.Count == 0)
            {
                Zonas = ZonaDAO.Listar().Where(z => z.ClaveDivision == Clave).ToList();
            }

            foreach (Zona z in Zonas)
            {
                NecesidadTotal += z.NecesidadTotal(ClavePeriodo);
            }

            return NecesidadTotal;
        }

        public double NecesidadInicial(int ClavePeriodo)
        {
            double NecesidadInicial = 0.0;

            if (Zonas.Count == 0)
            {
                Zonas = ZonaDAO.Listar().Where(z => z.ClaveDivision == Clave).ToList();
            }

            foreach (Zona z in Zonas)
            {
                NecesidadInicial += z.NecesidadInicial(ClavePeriodo);
            }

            return NecesidadInicial;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}