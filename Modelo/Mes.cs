using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodaProject.Modelo
{
    public class Mes
    {
        public int Clave { get; set; }
        public bool Activo { get; set; }
        public int NumeroMes { get; set; }

        public string NombreMes { get; set; }

        public ProgramaDetalle DetallePrograma { get; set; }
        public int ClaveDetallePrograma { get; set; }

        public List<Programacion> Programaciones { get; set; } = new List<Programacion>();

        public Mes Rellenar()
        {
            try
            {

                DetallePrograma = ProgramaDetalleDAO.Get(ClaveDetallePrograma);
                Programaciones = ProgramacionDAO.Listar().Where(p => p.ClaveMes == Clave).ToList();

                return this;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Activo, NumeroMes, ClaveDetallePrograma, NombreMes };
        }

        public override string ToString()
        {
            return NombreMes.ToString();
        }
    }
}