using PodaProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodaProject.Modelo
{
    public class Documento
    {
        public int Clave { get; set; }
        public string Path { get; set; }
        public string Nombre { get; set; }
        public bool EsPdf { get; set; }
        public bool EsImagen { get; set; }
        public bool EsExcel { get; set; }
        public string Descripcion { get; set; }

        public List<Periodo> Periodos { get; set; } = new List<Periodo>();

        public Documento Rellenar()
        {
            try
            {
                Periodos = DocumentoPeriodoDAO.Listar()
                    .Where(dp => dp.ClaveDocumento == Clave)
                    .Select(dp => dp.Rellenar().Periodo)
                    .ToList();

                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams()
        {
            return new object[] { Path, Nombre, EsPdf, EsImagen, EsExcel, Descripcion };
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}