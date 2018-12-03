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
    public partial class AsignarPresupuestos : Page
    {
        public Usuario Usuario = null;

        protected Periodo PeriodoActivo = null;
        protected PresupuestoDivision PresupuestoActual = null;
        protected List<Modelo.Zona> Zonas = new List<Modelo.Zona>();

        protected double PresupuestoDisponible = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            ChecarMensaje();

            try
            {
                PeriodoActivo = Usuario.ConsultarPeriodoActual();
                if (PeriodoActivo == null)
                {
                    Mensaje Mensaje = new Mensaje
                    {
                        Titulo = "No se ha encontrado ejercicio activo",
                        Contenido = "El sistema no ha podido encontrar un ejercicio de necesidades activo",
                        Tipo = TipoMensaje.ALERTA
                    };

                    Session["mensaje"] = Mensaje;
                    Response.Redirect(ResolveUrl("~/App/Inicio.aspx"));
                }

                PresupuestoActual = PeriodoActivo.ConsultarPresupuestoActual().Rellenar();
            }
            catch (Exception ex)
            {
                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "Error al cargar presupuestos",
                    Contenido = ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }


            if (!IsPostBack)
            {
                presupuesto.Text = PresupuestoActual.Monto.ToString();

                
                Zonas = Usuario.Division.Rellenar().Zonas;
                PresupuestoDisponible = PresupuestoActual.PresupuestoDisponible();
                
                LlenarTablaZonas();
                GenerarModales();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                double Presupuesto = Convert.ToDouble(presupuesto.Text);

                PresupuestoDivision Nuevo = new PresupuestoDivision();
                Nuevo.ClavePeriodo = PeriodoActivo.Clave;
                Nuevo.Monto = Presupuesto;

                PresupuestoDivision Actualizado = PresupuestoDivisionDAO.Actualizar(PresupuestoActual.Clave, Nuevo);
                if (Actualizado == null)
                {
                    Mensaje MensajeAlerta = new Mensaje
                    {
                        Titulo = "Algo salió mal",
                        Contenido = "No se ha podido actualizar el presupuesto divisional",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(MensajeAlerta);
                    return;
                }


                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "Presupuesto actualizado",
                    Contenido = "Se ha actualizado el presupuesto divisional correctamente",
                    Tipo = TipoMensaje.EXITO
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/AsignarPresupuestos.aspx"));
            }
            catch (Exception ex)
            {
                Mensaje Mensaje = new Mensaje
                {
                    Titulo = "Error al actualizar presupuesto",
                    Contenido = ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }
        }
        
        private void ChecarMensaje()
        {
            Mensaje Mensaje = (Mensaje)Session["mensaje"];
            if (Mensaje != null)
            {
                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                Session["mensaje"] = null;
            }
        }

        private void LlenarTablaZonas()
        {

            litTablaBody.Text = Disenio.GenerarTabla(Zonas, z =>
            {
                PresupuestoZona PresupuestoZona = z.PresupuestoActual(PresupuestoActual.Clave);
                string Input = @"<div class='input-group'>
                                    <span class='input-group-addon'><i class='fa fa-dollar'></i></span>
                                    <input type='text' value='" + PresupuestoZona.Monto + "' name='prepz" + PresupuestoZona.Clave + @"' class='form-control prep'/>
                                </div>";

                string Boton = @"<button type='button' class='btn btn-default' data-toggle='modal' data-target='#modal" + z.Clave + @"'>
                        <span class='fa fa-info'></span></button>";

                string Div = "<div>"+ Input + Boton + "</div>";
                string NecesidadTotal = Utilerias.ToCurrency(z.NecesidadTotal(PeriodoActivo.Clave));

                return new string[] { z.Nombre, PresupuestoZona.ToString(), NecesidadTotal, Div };
            });
        }

        private void GenerarModales()
        {
            foreach (Modelo.Zona z in Zonas)
            {
                PresupuestoZona Actual = z.PresupuestoActual(PresupuestoActual.Clave);
                List<PresupuestoZona> Anteriores = z.Presupuestos
                    .Where(p => p.ClavePresupuestoDivisional == PresupuestoActual.Clave && p.Clave != Actual.Clave)
                    .OrderByDescending(p => p.Clave)
                    .ToList();

                string Id = "modal" + z.Clave;
                string Titulo = "HISTORIAL DE PRESUPUESTOS DE " + z.Nombre;
                string Contenido = "<h3 align='center'>Ejercicio: " + PeriodoActivo.Descripcion + "</h3>";
                
                Contenido += "<table class='table table-bordered'><thead><tr><th>Recurso actual asignado</th></tr></thead><tbody><tr><td>" + Actual.ToString() + 
                    "</td></tr></tbody></table>";

                Contenido += "<br/> <table class='table table-bordered table-striped'><thead><tr><th>Recursos anteriores</th></tr></thead><tbody>" +
                    Disenio.GenerarTabla(Anteriores, pz => new string[] { pz.ToString() }) +
                    "</tbody></table>";

                litModales.Text += Disenio.GenerarModal(Id, Titulo, Contenido);
            }
        }
    }
}