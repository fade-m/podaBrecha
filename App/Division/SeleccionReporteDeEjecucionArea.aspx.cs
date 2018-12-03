using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PodaProject.Modelo;
using PodaProject.DataAccess;
using PodaProject.Util;


namespace PodaProject.App.Division
{
    public partial class SeleccionReporteDeEjecucionArea : System.Web.UI.Page
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
            string idArea = Request.QueryString["id"];


            if (!IsPostBack)
            {

                int necesidadC = NecesidadDAO.Listar().Where(r => r.ClaveArea == Convert.ToInt32(idArea) && r.ClavePeriodo == periodo.Clave).Count();
                if(necesidadC == 0)
                {
                    Mensaje mensaje = new Mensaje()
                    {
                        Titulo = "ADVERTENCIA!",
                        Contenido = "No hay necesidades registradas",
                        Tipo = TipoMensaje.ERROR
                    };
                    litMensaje.Text = Disenio.GenerarMensaje(mensaje);
                }else
                {
                    Necesidad necesidad = NecesidadDAO.Listar().Where(r => r.ClaveArea == Convert.ToInt32(idArea) && r.ClavePeriodo == periodo.Clave).First();
                    int id = necesidad.Rellenar().Clave;
                    int programaC = ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == Convert.ToInt32(id)).Count();
                    if(programaC == 0)
                    {
                        Mensaje mensaje = new Mensaje()
                        {
                            Titulo = "ADVERTENCIA!",
                            Contenido = "No hay programa de ejecucion registrado",
                            Tipo = TipoMensaje.ERROR
                        };
                        litMensaje.Text = Disenio.GenerarMensaje(mensaje);
                    }else
                    {
                        programa = ProgramaDAO.Listar().Where(r => r.ClaveNecesidad == Convert.ToInt32(id)).First();
                        programaDetalles = ProgramaDetalleDAO.Listar().Where(r => r.ClavePrograma == programa.Clave).ToList();


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
                    }
                    
                }
                

            }
        }
    }
}