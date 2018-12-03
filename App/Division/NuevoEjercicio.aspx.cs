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
    public partial class NuevoEjercicio : Page
    {
        public Usuario Usuario = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);

            if (!IsPostBack)
            {
                litMensaje.Text = "";
                
                cmbEstatus.DataSource = EstatusPeriodoDAO.Listar();
                cmbEstatus.DataBind();
            }
            
        }

        protected void btnRegistrarEjercicio_Click(object sender, EventArgs e)
        {
            try
            {
                Periodo Periodo = new Periodo();
                Periodo.ClaveEstatus = Convert.ToInt32(cmbEstatus.SelectedValue);
                Periodo.FechaInicio = Utilerias.ParsearFecha(txtFechaInicio.Text);
                Periodo.FechaFin = Utilerias.ParsearFecha(txtFechaFin.Text);
                Periodo.Descripcion = txtDescripcion.Text;
                Periodo.EsActivo = cmbEstatus.SelectedItem.Text == "Activo";
                Periodo.ClaveDivision = Usuario.ClaveDivision ?? 0;

                if (Periodo.FechaInicio.Date > Periodo.FechaFin.Date)
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


                Periodo Agregado = PeriodoDAO.Insertar(Periodo);
                if (Agregado == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Algo salió mal",
                        Contenido = "El ejercicio no pudo guardarse. Para más información consulte al administrador del sistema",
                        Tipo = TipoMensaje.ALERTA
                    };

                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    return;
                }

                Mensaje MensajeExito = new Mensaje()
                {
                    Titulo = "Ejercicio registrado",
                    Contenido = "Se ha registrado el ejercicio correctamente",
                    Tipo = TipoMensaje.EXITO
                };

                Session["mensaje"] = MensajeExito;

                Response.Redirect(ResolveUrl("~/App/Division/Ejercicios.aspx"));
            }
            catch(Exception Ex)
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
    }
}