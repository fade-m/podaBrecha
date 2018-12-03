using PodaProject.DataAccess;
using System;

namespace PodaProject.Modelo
{
    public class DocumentoPeriodo
    {
        public Periodo Periodo { get; set; }
        public int ClavePeriodo { get; set; }

        public Documento Documento { get; set; }
        public int ClaveDocumento { get; set; }

        public DocumentoPeriodo Rellenar()
        {
            try
            {
                Periodo = PeriodoDAO.Get(ClavePeriodo);
                Documento = DocumentoDAO.Get(ClaveDocumento);

                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object[] ToParams ()
        {
            return new object[] { ClavePeriodo, ClaveDocumento };
        }

        public override string ToString()
        {
            return ClaveDocumento.ToString();
        }
    }
}