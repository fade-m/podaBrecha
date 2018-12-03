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
    public partial class RegistroNecesidadDetalle : System.Web.UI.Page
    {
        private Usuario Usuario = null;
        protected List<Concepto> Conceptos = new List<Concepto>();
        protected List<TipoConcepto> TiposConceptos = new List<TipoConcepto>();

        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {
                string clave = Request.QueryString["id"];
                string claveDetalle = Request.QueryString["idNecesidadDetalle"];
                string tipo = Request.QueryString["tipo"];
                string Filas = "";

                try
                {
                  
                        Necesidad Necesidad = new Necesidad();
                        Necesidad = NecesidadDAO.Get(Convert.ToInt32(clave));

                    if (Necesidad.ClaveEstatus == 2 )
                        {
                            btnEnivar.Visible = false;
                        btnRegistrarNecesidad.Visible = false;
                        }
                    

                    if (claveDetalle != null && tipo == "editar")
                    {
                        NecesidadDetalle NecesidadDetalle = new NecesidadDetalle();
                        NecesidadDetalle = NecesidadDetalleDAO.Get(Convert.ToInt32(claveDetalle));
                        txtVolumen.Text = NecesidadDetalle.Volumen.ToString();
                        txtPrecioU.Text = NecesidadDetalle.PrecioUnitario.ToString();
                        Conceptos = new List<Concepto>();
                        Conceptos.Add(NecesidadDetalle.Rellenar().Concepto);
                        cmbConcepto.DataSource = Conceptos;
                        cmbConcepto.DataBind();
                        cmbConcepto.Enabled = false;
                        TiposConceptos = new List<TipoConcepto>();
                        TiposConceptos.Add(NecesidadDetalle.Rellenar().TipoConcepto);
                        cmbTipoConcepto.DataSource = TiposConceptos;
                        cmbTipoConcepto.DataBind();
                        cmbTipoConcepto.Enabled = false;



                    }
                    else if (claveDetalle != null && tipo == "eliminar")
                    {
                        int resultado = NecesidadDetalleDAO.Eliminar(Convert.ToInt32(claveDetalle));
                        if (resultado == 0)
                        {
                            Mensaje Mensaje = new Mensaje()
                            {
                                Titulo = "Algo salió mal",
                                Contenido = "La Necesidad no pudo guardarse. Para más información consulte al administrador del sistema",
                                Tipo = TipoMensaje.ALERTA
                            };
                            litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                            return;
                        }

                        Response.Redirect(ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + clave));

                    }
                    else
                    {
                        Conceptos = ConceptoDAO.Listar();
                        cmbConcepto.DataSource = Conceptos;
                        cmbConcepto.DataBind();

                        Concepto Concepto = new Concepto();
                        Concepto = ConceptoDAO.Get(Convert.ToInt32(cmbConcepto.SelectedValue));
                        TiposConceptos = Concepto.Rellenar().Tipos;
                        cmbTipoConcepto.DataSource = TiposConceptos;
                        cmbTipoConcepto.DataBind();
                    }
                    double importeTotal = 0;
                    List<NecesidadDetalle> NecesidadesDetalle = new List<NecesidadDetalle>();
                    NecesidadesDetalle = NecesidadDetalleDAO.Listar().Where(p => p.ClaveNecesidad == Convert.ToInt32(clave)).ToList();
                    foreach (NecesidadDetalle p in NecesidadesDetalle)
                    {
                        p.Rellenar();

                        string urlEdit = ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + clave + "&idNecesidadDetalle=" + p.Clave + "&tipo=editar");
                        string urlDelete = ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + clave + "&idNecesidadDetalle=" + p.Clave + "&tipo=eliminar");

                        if(p.TipoConcepto == null)
                        {
                            Filas += Disenio.GenerarFilaTabla(p.Volumen.ToString(),
                            p.PrecioUnitario.ToString(),
                            Utilerias.ToCurrency(p.CalcularImporte()),
                            p.Concepto.ToString(),
                            "",
                             "<a href='" + urlEdit + "' class='btn btn-default btn-block'>Editar</a>",
                             "<a href='" + urlDelete + "' class='btn btn-default btn-block'>Eliminar</a>");

                            importeTotal += p.Volumen * p.PrecioUnitario;
                        }else
                        {
                            Filas += Disenio.GenerarFilaTabla(p.Volumen.ToString(),
                            p.PrecioUnitario.ToString(),
                            Utilerias.ToCurrency(p.CalcularImporte()),
                            p.Concepto.ToString(),
                            p.TipoConcepto.ToString(),
                             "<a href='" + urlEdit + "' class='btn btn-default btn-block'>Editar</a>",
                             "<a href='" + urlDelete + "' class='btn btn-default btn-block'>Eliminar</a>");
                            importeTotal += p.Volumen * p.PrecioUnitario;
                        }
                        

                    }
                    litTBody.Text = Filas;
                    LitimporteTotal.Text = "IMPORTE TOTAL = $ " + importeTotal.ToString();
                }
                catch (Exception Ex)
                {

                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error al mostrar el detalle",
                        Contenido = Ex.Message,
                        Tipo = TipoMensaje.ERROR
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);

                }
            }
        }

        protected void btnRegistrarNecesidadDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string clave = Request.QueryString["id"];
                string tipo = Request.QueryString["tipo"];
                string claveDetalle = Request.QueryString["idNecesidadDetalle"];

                if (tipo == "editar" && claveDetalle != null)
                {
                    NecesidadDetalle NecesidadDetalle = new NecesidadDetalle();
                    NecesidadDetalle.Volumen = Convert.ToDouble(txtVolumen.Text);
                    NecesidadDetalle.PrecioUnitario = Convert.ToDouble(txtPrecioU.Text);
                    NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(clave);
                    NecesidadDetalle.ClaveConcepto = Convert.ToInt32(cmbConcepto.SelectedValue);
                    if (!(cmbTipoConcepto.SelectedValue == ""))
                        NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(cmbTipoConcepto.SelectedValue);
                    else NecesidadDetalle.ClaveTipoConcepto = null;


                    NecesidadDetalle NecesidadNueva = NecesidadDetalleDAO.Actualizar(Convert.ToInt32(claveDetalle), NecesidadDetalle);
                    if (NecesidadNueva == null)
                    {
                        Mensaje Mensaje = new Mensaje()
                        {
                            Titulo = "Algo salió mal",
                            Contenido = "La Necesidad no pudo guardarse. Para más información consulte al administrador del sistema",
                            Tipo = TipoMensaje.ALERTA
                        };
                        litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                        return;
                    }

                    Response.Redirect(ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + clave));
                }
                else
                {
                    NecesidadDetalle NecesidadDetalle = new NecesidadDetalle();
                    NecesidadDetalle.Volumen = Convert.ToDouble(txtVolumen.Text);
                    NecesidadDetalle.PrecioUnitario = Convert.ToDouble(txtPrecioU.Text);
                    NecesidadDetalle.ClaveNecesidad = Convert.ToInt32(clave);
                    NecesidadDetalle.ClaveConcepto = Convert.ToInt32(cmbConcepto.SelectedValue);
                    if (!(cmbTipoConcepto.SelectedValue == ""))
                        NecesidadDetalle.ClaveTipoConcepto = Convert.ToInt32(cmbTipoConcepto.SelectedValue);
                    else NecesidadDetalle.ClaveTipoConcepto = null;


                    NecesidadDetalle NecesidadNueva = NecesidadDetalleDAO.Insertar(NecesidadDetalle);
                    if (NecesidadNueva == null)
                    {
                        Mensaje Mensaje = new Mensaje()
                        {
                            Titulo = "Algo salió mal",
                            Contenido = "La Necesidad no pudo guardarse. Para más información consulte al administrador del sistema",
                            Tipo = TipoMensaje.ALERTA
                        };
                        litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                        return;
                    }

                    Response.Redirect(ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + clave));
                }



            }
            catch (Exception Ex)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error al guardar ejercicio",
                    Contenido = Ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }

        }

        protected void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Concepto Concepto = new Concepto();
            Concepto = ConceptoDAO.Get(Convert.ToInt32(cmbConcepto.SelectedValue));
            TiposConceptos = Concepto.Rellenar().Tipos;
            cmbTipoConcepto.DataSource = TiposConceptos;
            cmbTipoConcepto.DataBind();
        }



        protected void btnEnivar_Click(object sender, EventArgs e)
        {
            string clave = Request.QueryString["id"];

            Necesidad Necesidad = NecesidadDAO.Get(Convert.ToInt32(clave));
            Necesidad.ClaveEstatus = 4;
            Necesidad NecesidadNueva = NecesidadDAO.Actualizar(Convert.ToInt32(clave),Necesidad);

            if (NecesidadNueva == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Algo salió mal",
                    Contenido = "La Necesidad no pudo guardarse. Para más información consulte al administrador del sistema",
                    Tipo = TipoMensaje.ALERTA
                };
                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                return;
            }else
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Necesidad enviada!",
                    Contenido = "La Necesidad fue enviada a la zona con exito, notifique a su jefe de zona",
                    Tipo = TipoMensaje.EXITO
                };
                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }

        }
    }
}