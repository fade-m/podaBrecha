using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.Modelo;
using PodaProject.DataAccess;
using PodaProject.Util;

namespace PodaProject.App.Area
{
    public partial class CrearProgramacion : System.Web.UI.Page
    {
        private Usuario usuario = null;
        private Periodo periodo = null;
        private Modelo.Programa programa = new Modelo.Programa();
        private List<ProgramaDetalle> programaDetalles = new List<ProgramaDetalle>();
        private List<Mes> meses = new List<Mes>();
        private List<Programacion> programaciones = new List<Programacion>();

        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = Utilerias.FiltrarUsuario(this);
            periodo = usuario.ConsultarPeriodoActual(); 
            
              
            
    

            if (!IsPostBack)
            {

                Mensaje m = new Mensaje()
                {
                    Titulo = "ADVERTENCIA!",
                    Contenido = "SEA CUIDADOSO AL CREAR UNA PROGRAMACION YA QUE NO PODRÁ SER MODIFICADA UNA VES QUE SE REGISTRE, si comete un error contacte al administrador",
                    Tipo = TipoMensaje.ALERTA
                };
                advertencia.Text = Disenio.GenerarMensaje(m);

                int necesidadC = NecesidadDAO.Listar().Where(r => r.ClaveArea == usuario.ClaveArea && r.ClavePeriodo == periodo.Clave).Count();
                if(necesidadC == 0)
                {
                    Mensaje me = new Mensaje()
                    {
                        Titulo = "ADVERTENCIA!",
                        Contenido = "no hay necesidades registradas o aprobadas para el periodo en curso",
                        Tipo = TipoMensaje.ALERTA
                    };
                    advertencia.Text = Disenio.GenerarMensaje(me);
                }else
                {
                    Necesidad necesidad = NecesidadDAO.Listar().Where(r => r.ClaveArea == usuario.ClaveArea && r.ClavePeriodo == periodo.Clave).First();
                    int id = necesidad.Rellenar().Clave;

                    programa = ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == Convert.ToInt32(id)).First();

                    programaDetalles = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == programa.Clave).ToList();

                    string Filas = "";
                    foreach (ProgramaDetalle p in programaDetalles)
                    {
                        if (p.Rellenar().Contrato != null)
                        {
                            if (p.Rellenar().TipoConcepto != null)
                            {
                                p.Rellenar();
                                string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                                Filas += Disenio.GenerarFilaTabla(
                                    p.Cantidad.ToString(),
                                    p.FechaInicio.ToShortDateString(),
                                    p.PrecioUnitario.ToString(),
                                    p.Circuito.Rellenar().Descripcion,
                                    p.Contrato.Rellenar().Codigo,
                                    p.Concepto.Rellenar().Descripcion,
                                    p.TipoConcepto.Rellenar().Descripcion);
                            }
                            else
                            {
                                p.Rellenar();
                                string url = ResolveUrl("~/App/Division/Programa.aspx?id=" + p.Clave);
                                Filas += Disenio.GenerarFilaTabla(
                                    p.Cantidad.ToString(),
                                    p.FechaInicio.ToShortDateString(),
                                    p.PrecioUnitario.ToString(),
                                    p.Circuito.Rellenar().Descripcion,
                                    p.Contrato.Rellenar().Codigo,
                                    p.Concepto.Rellenar().Descripcion,
                                    "");
                            }
                        }
                        else
                        {
                            Mensaje Mensaje = new Mensaje()
                            {
                                Titulo = "Error!",
                                Contenido = "Esta necesidad no tiene un contrato asignado",
                                Tipo = TipoMensaje.ERROR
                            };

                            litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                        }


                    }
                    litTBody.Text = Filas;

                    cmbProgramacion.DataSource = programaDetalles;
                    cmbProgramacion.DataBind();

                    string Fila = "";
                    foreach (ProgramaDetalle p in programaDetalles)
                    {
                        p.Rellenar();
                        int mesC = MesDAO.Listar().Where(r => r.ClaveDetallePrograma == p.Clave).Count();
                        if (mesC == 0) break;
                        Mes mes = MesDAO.Listar().Where(r => r.ClaveDetallePrograma == p.Clave).First();
                        int programC = ProgramacionDAO.Listar().Where(x => x.ClaveMes == mes.Rellenar().Clave).Count();
                        if (programC == 0) break;
                        Programacion program = ProgramacionDAO.Listar().Where(x => x.ClaveMes == mes.Rellenar().Clave).First();

                        if (p.TipoConcepto != null)
                        {
                            Fila += Disenio.GenerarFilaTabla(
                                    mes.NombreMes,
                                    program.Programado.ToString(),
                                    p.Circuito.Rellenar().Codigo,
                                    p.Concepto.Rellenar().Descripcion,
                                    p.TipoConcepto.Rellenar().Descripcion);
                        }
                        else
                        {
                            Fila += Disenio.GenerarFilaTabla(
                                   mes.NombreMes,
                                   program.Programado.ToString(),
                                   p.Circuito.Rellenar().Codigo,
                                   p.Concepto.Rellenar().Descripcion,
                                   "");
                        }


                    }

                    litTBody2.Text = Fila;
                }
               

               


            }
               
            

        }


        protected void btnRegistrarProgramacion_Click(object sender, EventArgs e)
        {
            Mes mes = new Mes();
            mes.Activo = true;
            mes.NumeroMes = Convert.ToInt32(txtNumeroMes.Text);
            mes.ClaveDetallePrograma = Convert.ToInt32(cmbProgramacion.SelectedValue);
            mes.NombreMes = txtNombreMes.Text;

            Mes nuevoMes = MesDAO.Insertar(mes);

            if(nuevoMes != null)
            {
                Programacion programa = new Programacion();
                programa.Programado = Convert.ToDouble(txtCantidadProgramada.Text);
                programa.ClaveMes = Convert.ToInt32(nuevoMes.Clave);
                programa.ClaveOrden = 1;

                Programacion nuevaProgramacion = ProgramacionDAO.Insertar(programa);

                if(nuevaProgramacion == null)
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Error!",
                        Contenido = "El programa no se pudo dar de alta en el sistema",
                        Tipo = TipoMensaje.ERROR
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }else
                {
                    Mensaje Mensaje = new Mensaje()
                    {
                        Titulo = "Exito!",
                        Contenido = "El programa se dio de alta en el sistema",
                        Tipo = TipoMensaje.EXITO
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
                }


            }else
            {
                Mensaje Mensaje = new Mensaje()
                {
                    Titulo = "Error!",
                    Contenido = "El mes no pudo ser insertado en la base de datos",
                    Tipo = TipoMensaje.ERROR
                };
                litMensaje.Text = Disenio.GenerarMensaje(Mensaje);
            }
        }
    }
}
