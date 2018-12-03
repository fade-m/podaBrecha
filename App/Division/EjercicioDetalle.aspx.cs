using PodaProject.DataAccess;
using PodaProject.Modelo;
using PodaProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PodaProject.App.Division
{
    public partial class EjercicioDetalle : System.Web.UI.Page
    {
        public Usuario Usuario = null;

        protected Periodo Periodo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            string PeriodoId = Request.QueryString["id"];
            if (PeriodoId == null)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Algo salió mal",
                    Contenido = "No se ha elegido un ejercicio",
                    Tipo = TipoMensaje.ERROR
                };

                Session["mensaje"] = Mensaje;
                Response.Redirect(ResolveUrl("~/App/Division/Ejercicios.aspx"));
            }

            Periodo = PeriodoDAO.Get(Convert.ToInt32(PeriodoId));

            if (!IsPostBack)
            {
                cmbEstatus.DataSource = EstatusPeriodoDAO.Listar();
                cmbEstatus.DataBind();

                if (Periodo != null)
                {
                    Periodo.Rellenar();
                    txtFechaInicio.Text = Periodo.FechaInicio.ToShortDateString();
                    txtFechaFin.Text = Periodo.FechaFin.ToShortDateString();
                    txtDescripcion.Text = Periodo.Descripcion;

                    cmbEstatus.ClearSelection();
                    cmbEstatus.Items.FindByValue(Periodo.ClaveEstatus.ToString()).Selected = true;
                }
            }
        }

        protected void btnRegistrarEjercicio_Click(object sender, EventArgs e)
        {
            try
            {
                Periodo Nuevo = new Periodo();
                Nuevo.ClaveEstatus = Convert.ToInt32(cmbEstatus.SelectedValue);
                Nuevo.FechaInicio = Utilerias.ParsearFecha(txtFechaInicio.Text);
                Nuevo.FechaFin = Utilerias.ParsearFecha(txtFechaFin.Text);
                Nuevo.Descripcion = txtDescripcion.Text;
                Nuevo.EsActivo = cmbEstatus.SelectedItem.Text == "Activo";
                Nuevo.ClaveDivision = Usuario.ClaveDivision ?? 0;

                if (Nuevo.FechaInicio.Date > Nuevo.FechaFin.Date)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Ejercicio no válido",
                        Contenido = "La fecha de inicio no puede ser mayor a la fecha de fin",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    return;
                }

                Periodo Actualidado = PeriodoDAO.Actualizar(Periodo.Clave, Nuevo);
                if (Actualidado == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Algo salió mal",
                        Contenido = "El ejercicio no pudo actualizarse. Para más información consulte al administrador del sistema",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    return;
                }

                Mensaje MensajeExito = new Mensaje()
                {
                    Titulo = "Ejercicio actualizado",
                    Contenido = "Se ha actualizado el ejercicio correctamente",
                    Tipo = TipoMensaje.EXITO
                };

                Session["mensaje"] = MensajeExito;
                Response.Redirect(ResolveUrl("~/App/Division/Ejercicios.aspx"));
            }
            catch (Exception Ex)
            {

                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error al actualizar ejercicio",
                    Contenido = Ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }
        }
    }
}