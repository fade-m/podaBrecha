using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Division
{
    public partial class RequerimientosArea : System.Web.UI.Page
    {
        public Usuario Usuario = null;
        public Modelo.Area Area = null;

        protected Periodo PeriodoSeleccionado = null;
        protected PresupuestoArea PresupuestoArea = null;
        protected Necesidad NecesidadActual = null;

        protected List<NecesidadDetalle> Detalles = new List<NecesidadDetalle>();
        protected double NecesidadTotal = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            string ClaveArea = Request.QueryString["id"];
            if (ClaveArea == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se eligió una área",
                    Contenido = "No se ha determinado el área a consultar",
                    Tipo = TipoMensaje.ALERTA
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Requerimientos.aspx"));
            }

            Area = AreaDAO.Get(Convert.ToInt32(ClaveArea)).Rellenar();
            if (Area == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "No se encontró la área seleccionada",
                    Contenido = "El sistema no ha encontrado la área seleccionada",
                    Tipo = TipoMensaje.ERROR
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Requerimientos.aspx"));
            }

            if (!IsPostBack)
            {
                PeriodoSeleccionado = Usuario.ConsultarPeriodoActual();

                PresupuestoDivision PresupuestoDivisional = Usuario.Division.PresupuestoActual(PeriodoSeleccionado.Clave);
                PresupuestoZona PresupuestoZona = Area.Zona.PresupuestoActual(PresupuestoDivisional.Clave);
                PresupuestoArea = Area.PresupuestoActual(PresupuestoZona.Clave);
                presupuesto.Text = PresupuestoArea.Monto.ToString();

                NecesidadActual = Area.NecesidadActual(PeriodoSeleccionado.Clave) ?? new Necesidad();
                necesidad.Text = NecesidadActual.CalcularImporte().ToString();


                GenerarTablaDetalles();
            }

        }

        private void GenerarTablaDetalles()
        {
            List<NecesidadDetalle> Detalles = NecesidadActual.Rellenar().Detalles;

            litTablaDetalles.Text = Disenio.GenerarTabla(Detalles, d => {
                d.Rellenar();

                Concepto Concepto = d.Concepto.Rellenar();
                TipoConcepto TipoConcepto = d.TipoConcepto ?? new TipoConcepto();

                return new string[] { d.Concepto.Descripcion, TipoConcepto.Descripcion, Concepto.MedidaAbreviacion,
                    d.Volumen.ToString(), Utilerias.ToCurrency(d.PrecioUnitario), Utilerias.ToCurrency(d.CalcularImporte()) };
            });
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario = Utilerias.FiltrarUsuario(this);
                PeriodoSeleccionado = Usuario.ConsultarPeriodoActual();
                NecesidadActual = Area.NecesidadActual(PeriodoSeleccionado.Clave) ?? new Necesidad();
                NecesidadActual.ClaveEstatus = 1;
                Necesidad necesidad = NecesidadDAO.Actualizar(NecesidadActual.Clave, NecesidadActual);
                if(necesidad == null)
                {
                    Mensaje MensajeAlerta = new Mensaje
                    {
                        Titulo = "Algo salió mal",
                        Contenido = "No se ha podido actualizar el estatus",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(MensajeAlerta);
                    return;
                }else
                {
                    Mensaje MensajeAlerta = new Mensaje
                    {
                        Titulo = "Necesidad aprobada",
                        Contenido = "La necesidad fue aprobada",
                        Tipo = TipoMensaje.EXITO
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(MensajeAlerta);
                    return;
                }
            }
            catch(Exception ex)
            {

                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "Error al aprobar la necesidad",
                    Contenido = ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }
            

        }



    }
}