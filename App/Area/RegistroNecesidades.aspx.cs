using System;
using PodaProject.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.DataAccess;
using PodaProject.Util;

namespace PodaProject.App.Area
{
    public partial class RegistroNecesidades : System.Web.UI.Page
    {
        private Usuario Usuario = null;
        private Periodo Periodo = null;
        protected List<EstatusNecesidad> Estatus = new List<EstatusNecesidad>();
        protected List<EstatusNecesidad> aux = new List<EstatusNecesidad>();
        protected List<Necesidad> necesidadesArea = new List<Necesidad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            Periodo = Usuario.ConsultarPeriodoActual();

            if(!IsPostBack)
            {
                

                txtFechaCreacion.Text =  DateTime.Today.Date.ToShortDateString();
           
                Estatus = EstatusNecesidadDAO.Listar();
                aux.Add(Estatus[2]);
                cmbEstatus.DataSource = aux;
                cmbEstatus.DataBind();

                necesidadesArea =  Usuario.Area.Rellenar().Necesidades;

                string Filas = "";
                foreach (Necesidad p in necesidadesArea)
                {
                    p.Rellenar();
                    string url = ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + p.Clave);
                    Filas += Disenio.GenerarFilaTabla(p.FechaCreacion.ToShortDateString(),
                        p.Periodo.Descripcion,
                        p.Estatus.Descripcion,
                        "<a href='" + url + "' class='btn btn-default btn-block'>Editar</a>");
                    

                    if ((p.Estatus.Descripcion == "En revisión" && p.ClavePeriodo == Periodo.Clave) || p.Estatus.Descripcion == "Inicial" && p.ClavePeriodo == Periodo.Clave)
                    {
                        btnRegistrarNecesidad.Visible = false;
                    }
                }
                litTBody.Text = Filas;


           
            }

        }

        protected void btnRegistrarNecesidad_Click(object sender, EventArgs e)
        {
            try
            {
                Necesidad Necesidad = new Necesidad();
                DateTime fecha = Utilerias.ParsearFecha(txtFechaCreacion.Text);
                Necesidad.FechaCreacion = fecha;
                Necesidad.ClaveArea = Convert.ToInt32(Usuario.ClaveArea);
                Necesidad.ClavePeriodo = Convert.ToInt32(Periodo.Clave);
                Necesidad.ClaveEstatus = Convert.ToInt32(3);

                Necesidad NecesidadNueva = NecesidadDAO.Insertar(Necesidad);
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

                Response.Redirect(ResolveUrl("~/App/Area/RegistroNecesidadDetalle.aspx?id=" + NecesidadNueva.Clave));

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
    }
}