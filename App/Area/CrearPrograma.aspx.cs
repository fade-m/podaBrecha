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
    public partial class CrearPrograma : System.Web.UI.Page
    {
        private Usuario Usuario = null;
        private Periodo Periodo = null;
        private List<Necesidad> Necesidades = new List<Necesidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Utilerias.FiltrarUsuario(this);
            Periodo = Usuario.ConsultarPeriodoActual();
           
            

            if (!IsPostBack)
            {
                
                Modelo.Area Area = AreaDAO.Get(Convert.ToInt32(Usuario.ClaveArea)).Rellenar();
                Necesidad NecesidadActual = Area.NecesidadActual(Periodo.Clave) ?? new Necesidad();

                txtFechaCreacion.Text = DateTime.Today.Date.ToShortDateString();
                //falta agregar que solamente la necesidad aprobada sea a la que se le signara el programa de ejecucion  && r.ClaveEstatus == 1
                Necesidades = NecesidadDAO.Listar().Where(r => r.ClaveArea == Usuario.ClaveArea).ToList();
                
                txtNecesidad.Text = NecesidadActual.FechaCreacion.ToString();
                List<Programa> Programas = new List<Programa>();
                

                foreach(Necesidad nec in Necesidades)
                {
                    try
                    {
                       Programas.Add(ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == nec.Clave).First());
                    }
                    catch(Exception ex)
                    {
                        break;
                    }
                   
                }
               


                if(NecesidadActual.ClaveEstatus != 1)
                {
                    btnCrearPrograma.Visible = false;
                }else if (NecesidadActual.ClaveEstatus == 1)
                {
                    btnCrearPrograma.Visible = true;
                }

                string Filas = "";

                if(Programas.Count != 0)
                {
                    foreach (Programa p in Programas)
                    {
                        string url = ResolveUrl("~/App/Area/CrearProgramaDetalle.aspx?id=" + p.Clave + "&idNec=" + p.ClaveNecesidad);
                        Necesidad Necesidad = NecesidadDAO.Get(p.ClaveNecesidad);
                        Filas += Disenio.GenerarFilaTabla(p.FechaCreacion.ToShortDateString(),
                            Necesidad.FechaCreacion.ToShortDateString(),
                             "<a href='" + url + "' class='btn btn-default btn-block'>Editar</a>");

                    }
                }

               

                litTBody.Text = Filas;
            }


        }

        protected void btnCrearPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                Programa Programa = new Programa();
                Programa.FechaCreacion = Utilerias.ParsearFecha(txtFechaCreacion.Text);
                //falta agregar que solamente la necesidad aprobada sea a la que se le signara el programa de ejecucion  && r.ClaveEstatus == 1
                Modelo.Area Area = AreaDAO.Get(Convert.ToInt32(Usuario.ClaveArea)).Rellenar();
                Necesidad NecesidadActual = Area.NecesidadActual(Periodo.Clave) ?? new Necesidad();

                Necesidades = NecesidadDAO.Listar().Where(r => r.ClaveArea == Usuario.ClaveArea).ToList();
                Programa.ClaveNecesidad = NecesidadActual.Clave;

                Programa ProgramaNuevo = ProgramaDAO.Insertar(Programa);

                if (ProgramaNuevo == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Algo salió mal",
                        Contenido = "El programa no pudo guardarse. Para más información consulte al administrador del sistema",
                        Tipo = TipoMensaje.ALERTA
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                    return;
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/App/Area/CrearProgramaDetalle.aspx?id=" + ProgramaNuevo.Clave + "&idNec=" + NecesidadActual.Clave));
                }

            }
            catch (Exception Ex)
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error al guardar el programa",
                    Contenido = Ex.Message,
                    Tipo = TipoMensaje.ERROR
                };

                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);   
            }

        }
    }
}