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
    public partial class ReporteDeEjecucion : System.Web.UI.Page
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

            Mensaje mensaje = new Mensaje()
            {
                Titulo = "ADVERTENCIA!",
                Contenido = "SEA CUIDADOSO AL REGISTRAR EL AVANCE YA QUE NO PODRÁ SER MODIFICADO",
                Tipo = TipoMensaje.ERROR
            };
            litMensaje.Text = Disenio.GenerarMensaje(mensaje);

           

            if (!IsPostBack)
            {
                int necesidadC = NecesidadDAO.Listar().Where(r => r.ClaveArea == usuario.ClaveArea && r.ClavePeriodo == periodo.Clave).Count();

                if(necesidadC == 0)
                {

                    Mensaje m = new Mensaje()
                    {
                        Titulo = "ADVERTENCIA!",
                        Contenido = "No hay una necesidad creada o aprobada para el periodo en curso",
                        Tipo = TipoMensaje.ERROR
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(m);
                }else
                {
                    Necesidad necesidad = NecesidadDAO.Listar().Where(r => r.ClaveArea == usuario.ClaveArea && r.ClavePeriodo == periodo.Clave).First();
                    int id = necesidad.Rellenar().Clave;
                    programa = ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == Convert.ToInt32(id)).First();
                    programaDetalles = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == programa.Clave).ToList();

                    txtFechaCreacion.Text = DateTime.Today.ToShortDateString();
                    txtFechaCreacion.ReadOnly = true;

                    string Fila = "";
                    string Fila2 = "";
                    foreach (ProgramaDetalle p in programaDetalles)
                    {
                        p.Rellenar();
                        int mesC = MesDAO.Listar().Where(r => r.ClaveDetallePrograma == p.Clave).Count();
                        if (mesC == 0) break;
                        Mes mes = MesDAO.Listar().Where(r => r.ClaveDetallePrograma == p.Clave).First();
                        meses.Add(mes);
                        int programC = ProgramacionDAO.Listar().Where(x => x.ClaveMes == mes.Rellenar().Clave).Count();
                        if (programC == 0) break;
                        Programacion program = ProgramacionDAO.Listar().Where(x => x.ClaveMes == mes.Rellenar().Clave).First();

                        int av = AvanceDAO.Listar().Where(r => r.ClaveProgramacion == program.Clave).Count();
                        if (av != 0)
                        {
                            Avance avances = AvanceDAO.Listar().Where(r => r.ClaveProgramacion == program.Rellenar().Clave).First();
                            Fila2 += Disenio.GenerarFilaTabla(
                                    avances.Ejecutado.ToString(),
                                    avances.Observacioens,
                                    avances.FechaCreacion.ToString(),
                                    mes.Rellenar().NombreMes
                                );
                        }


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

                    litTBody.Text = Fila;
                    litTBody2.Text = Fila2;
                    cmbMes.DataSource = meses;
                    cmbMes.DataBind();

                }
                
            }
        }

        protected void btnRegistrarAvance_Click(object sender, EventArgs e)
        {
            Avance avance = new Avance();
            avance.Ejecutado = Convert.ToInt32(txtEjecutado.Text);
            avance.Observacioens = txtObservaciones.Text;
            avance.FechaCreacion = Utilerias.ParsearFecha(txtFechaCreacion.Text);
            string claveMes = cmbMes.SelectedValue;
            Programacion programacion = ProgramacionDAO.Listar().Where(r => r.ClaveMes == Convert.ToInt32(claveMes)).First();
            avance.ClaveProgramacion = programacion.Clave;

            Avance nuevoAvance = AvanceDAO.Insertar(avance);

            if (nuevoAvance == null)
            {
                Mensaje m = new Mensaje()
                {
                    Titulo = "ERROR!",
                    Contenido = "El avance no se pudo registrar en la base de datos",
                    Tipo = TipoMensaje.ERROR
                };
                litMensaje.Text = Disenio.GenerarMensaje(m);
            }else
            {
                Mensaje m = new Mensaje()
                {
                    Titulo = "Exito!",
                    Contenido = "El avance fue registrado correctamente",
                    Tipo = TipoMensaje.EXITO
                };
                litMensaje.Text = Disenio.GenerarMensaje(m);
            }
        }
    }
}