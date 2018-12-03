using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Area
{
    public partial class CrearProgramaDetalle : System.Web.UI.Page
    {
        private Usuario Usuario = null;
        private Periodo Periodo = null;
        private List<NecesidadDetalle> detallesNecesidad = new List<NecesidadDetalle>();
        private List<TipoConcepto> TiposConceptos = new List<TipoConcepto>();
        private List<Concepto> Conceptos = new List<Concepto>();
        private List<Circuito> Circuitos = new List<Circuito>();
        private string claveProg;
        private string claveNec;
        private List<Concepto> conceptosDisponibles = new List<Concepto>();
        private List<TipoConcepto> tipoConceptoDisponible = new List<TipoConcepto>();

        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario = Utilerias.FiltrarUsuario(this);
            Periodo = Usuario.ConsultarPeriodoActual();

            string claveProgramaDetalle = Request.QueryString["idPD"];

            string clave = Request.QueryString["id"];
            claveProg = clave;
            string necId = Request.QueryString["idNec"];
            claveNec = necId;
            string tipo = Request.QueryString["tipo"];
            string Filas = "";

            if (!IsPostBack)
            {
                try
                {
                    detallesNecesidad = NecesidadDetalleDAO.Listar().Where(w => w.ClaveNecesidad == Convert.ToInt32(necId)).ToList();

                    if (clave != null && tipo == "eliminar")
                    {
                        int resultado = ProgramaDetalleDAO.Eliminar(Convert.ToInt32(claveProgramaDetalle));
                        if (resultado == 0)
                        {
                            Mensaje Mensaje = new Mensaje()
                            {
                                Titulo = "Algo salió mal",
                                Contenido = "El programa no pudo eliminarse. Para más información consulte al administrador del sistema",
                                Tipo = TipoMensaje.ALERTA
                            };
                            litPrueba.Text = Disenio.GenerarMensaje(Mensaje);
                            return;
                        }

                        Response.Redirect(ResolveUrl("~/App/Area/CrearProgramaDetalle.aspx?id=" + clave + "&idNec="+necId));

                    }
                    else if(clave != null)
                    {

                        foreach (NecesidadDetalle det in detallesNecesidad)
                        {
                            det.Rellenar();

                            if (det.TipoConcepto == null)
                            {
                                Filas += Disenio.GenerarFilaTabla(det.Volumen.ToString(),
                                det.PrecioUnitario.ToString(),
                                Utilerias.ToCurrency(det.CalcularImporte()),
                                det.Concepto.ToString(),
                                "");
                                conceptosDisponibles.Add(det.Concepto);
                            }
                            else
                            {
                                Filas += Disenio.GenerarFilaTabla(det.Volumen.ToString(),
                                det.PrecioUnitario.ToString(),
                                Utilerias.ToCurrency(det.CalcularImporte()),
                                det.Concepto.ToString(),
                                det.TipoConcepto.ToString());
                                tipoConceptoDisponible.Add(det.TipoConcepto);
                            }
                        }

                        litTBody.Text = Filas;



                        Conceptos = ConceptoDAO.Listar().ToList();

                        cmbConcepto.DataSource = Conceptos;
                        cmbConcepto.DataBind();
                        Concepto Concepto = new Concepto();
                        Concepto = ConceptoDAO.Get(Convert.ToInt32(cmbConcepto.SelectedValue));
                        TiposConceptos = Concepto.Rellenar().Tipos;
                        cmbTipoConcepto.DataSource = TiposConceptos;
                        cmbTipoConcepto.DataBind();

                        Circuitos = CircuitoDAO.Listar().Where(z => z.ClaveArea == Usuario.ClaveArea).ToList();
                        cmbCircuito.DataSource = Circuitos;
                        cmbCircuito.DataBind();


                        List<ProgramaDetalle> progDets = ProgramaDetalleDAO.Listar().Where(p => p.ClavePrograma == Convert.ToInt32(clave)).ToList();
                        string FilasDetalles = "";

                        foreach (ProgramaDetalle p in progDets)
                        {
                            p.Rellenar();
                  

                            string urlDelete = ResolveUrl("~/App/Area/CrearProgramaDetalle.aspx?idPD="+p.Clave+"&id=" + clave + "&idNec=" + necId + "&tipo=eliminar");


                            if (p.TipoConcepto == null)
                            {
                                FilasDetalles += Disenio.GenerarFilaTabla(
                                p.Cantidad.ToString(),
                                p.FechaInicio.ToString(),
                                p.PrecioUnitario.ToString(),
                                p.Circuito.Descripcion.ToString(),
                                p.Concepto.ToString(),
                                "",
                                "<a href='" + urlDelete + "' class='btn btn-default btn-block'>Eliminar</a>");

                            }
                            else
                            {
                                FilasDetalles += Disenio.GenerarFilaTabla(
                                p.Cantidad.ToString(),
                                p.FechaInicio.ToString(),
                                p.PrecioUnitario.ToString(),
                                p.Circuito.Descripcion.ToString(),
                                p.Concepto.ToString(),
                                p.TipoConcepto.ToString(),
                                "<a href='" + urlDelete + "' class='btn btn-default btn-block'>Eliminar</a>"
                                );
                            }
                        }

                        LitDetalles.Text = FilasDetalles;

                    }

                }
                    

                   
                catch (Exception Ex)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error en el proceso del detalle de programa de ejecucion",
                        Contenido = Ex.Message,
                        Tipo = TipoMensaje.ERROR
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }

            }
            
        }

        private void disminuirVolumen(ProgramaDetalle progDetalle)
        {

            foreach(NecesidadDetalle necesidad in detallesNecesidad)
            {
                if(necesidad.TipoConcepto != null)
                {
                    if(necesidad.ClaveConcepto == progDetalle.ClaveConcepto && necesidad.ClaveTipoConcepto == progDetalle.ClaveTipoConcepto)
                    {
                        necesidad.Volumen = necesidad.Volumen - progDetalle.Cantidad;
                    }

                }
                else
                {
                    if (necesidad.ClaveConcepto == progDetalle.ClaveConcepto)
                    {
                        necesidad.Volumen = necesidad.Volumen - progDetalle.Cantidad;
                    }
                }
            }

            string Filas = "";
            litTBody.Text = Filas;
            foreach (NecesidadDetalle det in detallesNecesidad)
            {
                det.Rellenar();

                if (det.Volumen == 0) { btnAgregarMes.Visible = false; }
                else btnAgregarMes.Visible = true;

                if (det.TipoConcepto == null)
                {
                    Filas += Disenio.GenerarFilaTabla(det.Volumen.ToString(),
                    det.PrecioUnitario.ToString(),
                    Utilerias.ToCurrency(det.CalcularImporte()),
                    det.Concepto.ToString(),
                    "");
                    conceptosDisponibles.Add(det.Concepto);

                }
                else
                {
                    Filas += Disenio.GenerarFilaTabla(det.Volumen.ToString(),
                    det.PrecioUnitario.ToString(),
                    Utilerias.ToCurrency(det.CalcularImporte()),
                    det.Concepto.ToString(),
                    det.TipoConcepto.ToString());
                    tipoConceptoDisponible.Add(det.TipoConcepto);

                }


            }
            litTBody.Text = Filas;

        }
        
        protected void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Concepto Concepto = new Concepto();
            Concepto = ConceptoDAO.Get(Convert.ToInt32(cmbConcepto.SelectedValue));
            TiposConceptos = Concepto.Rellenar().Tipos;
            cmbTipoConcepto.DataSource = TiposConceptos;
            cmbTipoConcepto.DataBind();
        }

        protected void cmbCircuito_SelectedIndexChanged(object sender, EventArgs e)
        {
            Concepto Concepto = new Concepto();
            Concepto = ConceptoDAO.Get(Convert.ToInt32(cmbConcepto.SelectedValue));
            TiposConceptos = Concepto.Rellenar().Tipos;
            cmbTipoConcepto.DataSource = TiposConceptos;
            cmbTipoConcepto.DataBind();
        }

        protected void btnAgregarMes_Click(object sender, EventArgs e)
        {

            try
            {


                detallesNecesidad = NecesidadDetalleDAO.Listar().Where(w => w.ClaveNecesidad == Convert.ToInt32(claveNec)).ToList();

                ProgramaDetalle programaDetalle = new ProgramaDetalle();
                programaDetalle.Cantidad = Convert.ToDouble(cantidadProg.Text);
                programaDetalle.FechaInicio = Utilerias.ParsearFecha(txtFechaCreacion.Text);
                programaDetalle.PrecioUnitario = Convert.ToDecimal(precioUnit.Text);
                programaDetalle.ClavePrograma = Convert.ToInt32(claveProg);
                programaDetalle.ClaveCircuito = Convert.ToInt32(cmbCircuito.SelectedValue);
                programaDetalle.ClaveContrato = null;
                programaDetalle.ClaveConcepto = Convert.ToInt32(cmbConcepto.SelectedValue);
                programaDetalle.ClaveTipoConcepto = Convert.ToInt32(cmbTipoConcepto.SelectedValue);


                    ProgramaDetalle programaNuevo = ProgramaDetalleDAO.Insertar(programaDetalle);
                    if (programaNuevo == null)
                    {
                        Mensaje Mensaje = new Mensaje()
                        {
                            Titulo = "Algo salió mal",
                            Contenido = "La Necesidad no pudo guardarse. Para más información consulte al administrador del sistema",
                            Tipo = TipoMensaje.ALERTA
                        };
                        litPrueba.Text = Disenio.GenerarMensaje(Mensaje);
                        return;
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("~/App/Area/CrearProgramaDetalle.aspx?id=" + claveProg + "&idNec=" + claveNec));
                    }
              
            }
            catch (Exception Ex)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error al crear el programa",
                    Contenido = Ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }

        }
    }
}