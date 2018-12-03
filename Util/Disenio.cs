using PodaProject.DataAccess;
using PodaProject.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PodaProject.Util
{
    /// <summary>
    /// Clase que contiene métodos útiles para la construcción
    /// de componentes gráficos por medio de html
    /// </summary>
    public class Disenio
    {

        /// <summary>
        /// Genera código html correspondiente a los mensajes que aparecerán 
        /// en la página después de que ocurra un evento
        /// </summary>
        /// <param name="Mensaje">El mensaje que aparecerá</param>
        /// <returns>El código html del mensaje</returns>
        public static string GenerarMensaje(Mensaje Mensaje)
        {
            return @"<div class='alert alert-" + Mensaje.Tipo.Clase + @" alert-dismissable'>
                        <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>
                        <h4><i class='icon fa fa-" + Mensaje.Tipo.Icono + "'></i>" + Mensaje.Titulo + "</h4>" +
                        Mensaje.Contenido +
                    @"</div>";
        }

        /// <summary>
        /// Genera el menú vertical que se encuentra en la etiqueta aside de
        /// las master page Admin LTE con base a la lista proporcionada
        /// </summary>
        /// <param name="MenuLista">Lista de los menús jerarquizados a convertir</param>
        /// <returns>El código html</returns>
        public static string GenerarMenu(List<Menu> MenuLista, Func<string, string> ToUrl)
        {
            string Html = "";

            foreach (Menu menu in MenuLista)
            {
                Html += menu.Html(ToUrl);
            }

            return Html;
        }

        /// <summary>
        /// Genera el código de javascript que se plasmará en una página de web forms el cual
        /// permita generar una gráfica de barras con el plugin de flotchart
        /// </summary>
        /// <typeparam name="T">El tipo de dato de la lista de elementos a graficar</typeparam>
        /// <param name="Datos">La lista de elementos a graficar</param>
        /// <param name="GetData">La función que se encargará de extraer los valores necesarios para
        /// poder graficar las barras. Esta función recibe un parámetro de tipo T y devuelve un array
        /// de string de tamaño = 2, el cual el primer elemento es la etiqueta que se mostrará debajo 
        /// de la barra, y el segundo es el valor numérico que representa dicha etiqueta
        /// </param>
        /// <returns>El código javascript generado</returns>
        public static string GenerarDatosGraficaDeBarras<T>(List<T> Datos, Func<T, string[]> GetData)
        {
            string Js = "[";

            foreach (T tipo in Datos)
            {
                string[] datos = GetData(tipo);
                Js += "['" + datos[0] + "', " + datos[1] + "],";
            }

            //Elimina la última coma no deseable
            Js.Remove(Js.Length - 1);
            Js += "],";


            string Html = @"<script type='text/javascript'>
                    $(function() {
                        var bar_data = {
                            data: " + Js +
                            @"color: '#3c8dbc'
                        };

                        $.plot('#bar-chart', [bar_data], {
                            grid: {
                                borderWidth: 1,
                                borderColor: '#f3f3f3',
                                tickColor: '#f3f3f3'
                            },
                            series: {
                                bars: {
                                    show: true,
                                    barWidth: 0.5,
                                    align: 'center'
                                }
                            },
                            xaxis: {
                                mode: 'categories',
                                tickLength: 0,
                                axisLabel: 'Month',
                                axisLabelUseCanvas: true,
                                axisLabelFontSizePixels: 12,
                                axisLabelFontFamily: 'Verdana, Arial, Helvetica, Tahoma, sans-serif',
                                axisLabelPadding: 5
                            },
                            yaxis: {
                                axisLabel: 'Value',
                                axisLabelUseCanvas: true,
                                axisLabelFontSizePixels: 12,
                                axisLabelFontFamily: 'Verdana, Arial, Helvetica, Tahoma, sans-serif',
                                axisLabelPadding: 5
                            }
                        });
                    });
                </script>";

            return Html;
        }

        /// <summary>
        /// Genera el código de javascript que se plasmará en una página de web forms el cual
        /// permita generar una gráfica de pastel (o dona) con el plugin de flotchart
        /// </summary>
        /// <typeparam name="T">El tipo de dato de la lista de elementos a graficar</typeparam>
        /// <param name="Datos">La lista de elementos a graficar</param>
        /// <param name="GetData">La función que se encargará de extraer los valores necesarios para
        /// poder graficar las rebanadas del pastel. Esta función recibe un parámetro de tipo T y devuelve 
        /// un array de string de tamaño = 2, el cual el primer elemento es la etiqueta que se mostrará  
        /// encima de la rebanada, y el segundo es el valor numérico que representa dicha etiqueta
        /// </param>
        /// <returns>El código javascript generado</returns>
        public static string GenerarDatosGraficaPastel<T>(List<T> Datos, Func<T, string[]> GetData)
        {
            string Js = "[";

            foreach (T tipo in Datos)
            {
                string[] datos = GetData(tipo);
                Js += "{label: '" + datos[0] + "', data: " + datos[1] + "},";
            }

            Js.Remove(Js.Length - 1);
            Js += "];";

            string Html = @"<script type='text/javascript'>
                    $(function() {
                        var donutData = " + Js + @"

                        $.plot('#donut-chart', donutData, {
                            series: {
                                pie: {
                                    show: true,
                                    radius: 1,
                                    innerRadius: 0.5,
                                    combine: {
                                        color: '#999',
                                        threshold: 0.05,
                                        label: 'Otros'
                                    },
                                    label: {
                                        show: true,
                                        radius: 3 / 4,
                                        formatter: labelFormatter,
                                        color: '#000',
                                        background: {
                                            opacity: 0.5
                                        }
                                    }
                                }
                            },
                            grid: {
                                hoverable: true
                            }
                        });";

            Html += "function labelFormatter(label, series) {";
            Html += "return \"<div style='font-size:13px; text-align:center; padding:2px; color: #fff; font-weight: 600;'>\"";
            Html += @" + label
                                + '<br/>'
                                + Math.round(series.percent) + '%</div>';
                        }
                    });
                </script>";

            return Html;
        }

        /// <summary>
        /// Genera el código html para generar la fila de una tabla
        /// </summary>
        /// <param name="Columnas">Los valores de las columnas de la fila</param>
        /// <returns>El código html generado</returns>
        public static string GenerarFilaTabla(params string[] Columnas)
        {
            string Html = "<tr>";

            foreach (string col in Columnas)
            {
                Html += "<td>" + col + "</td>";
            }

            return Html;
        }

        /// <summary>
        /// Genera el código html de las filas de una tabla de un conjunto de elementos
        /// </summary>
        /// <typeparam name="T">El tipo de datos de la lista de elementos</typeparam>
        /// <param name="Lista">La lista de elementos que serán representados por fila</param>
        /// <param name="Atributos">La función que se encargará de obtener los valores de las
        /// columnas de cada elemento en la lista. Esta función recibe un parámetro de tipo T
        /// y devuelve un array de string con los valores a mostrar en las etiquetas 'td' en la tabla
        /// </param>
        /// <returns>El código html generado</returns>
        public static string GenerarTabla<T>(List<T> Lista, Func<T, string[]> Atributos)
        {
            string Html = "";

            foreach (T item in Lista)
            {
                string Fila = "<tr>";

                foreach (string attr in Atributos(item))
                {
                    Fila += "<td>" + attr + "</td>";
                }

                Fila += "</tr>";
                Html += Fila;
            }

            return Html;
        }

        public static string GenerarModal(string Id, string Titulo, string Contenido)
        {
            return @"<div class='modal fade' id='" + Id + @"'>
              <div class='modal-dialog'>
                <div class='modal-content'>
                  <div class='modal-header'>
                    <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>
                    <h4 class='modal-title'>" + Titulo + @"</h4>
                  </div>
                  <div class='modal-body'>" + Contenido + @"</div>
                  <div class='modal-footer'>
                    <button type='button' class='btn btn-default pull-left' data-dismiss='modal'>Cerrar</button>
                  </div>
                </div><!-- /.modal-content -->
              </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->";
        }

        /// <summary>
        /// Genera el código html para construir una tabla de un concepto con sus volúmenes e importes totales
        /// </summary>
        /// <param name="Concepto">El concepto del cual se generará el reporte</param>
        /// <param name="Areas">Las áreas que contemplará el reporte</param>
        /// <param name="ClavePeriodo">La clave del periodo del reporte</param>
        /// <returns></returns>
        public static string GenerarReporteConcepto(Concepto Concepto, List<Area> Areas, int ClavePeriodo)
        {
            List<TipoConcepto> Tipos = Concepto.Rellenar().Tipos;

            string Html = @"<div class='table-responsive'>
            <table class='table table-bordered'>
                <thead>
                    <tr>
                        <th colspan = '4' class='text-center'>" + Concepto.Descripcion + @"</th>
                    </tr>
                    <tr>" +
                        (Tipos.Count > 0 ? "<th>Tipo</th>" : "") + @"
                        <th>Unidad de medida</th>
                        <th>Volúmen</th>
                        <th>Importe</th>
                    </tr>
                </thead>
                <tbody>
                    " +
                    /*Si el concepto tiene subconceptos se genera una tabla de éstos y calcula
                    sus volúmenes y sus importes totales. De lo contrario se crea una fila con 
                    la unidad de mediad, y el volúmen e importe total del concepto
                     */
                    (Tipos.Count > 0 ? GenerarTabla(Tipos, t =>
                    {
                       return new string[]
                       {
                           t.Descripcion,
                           Concepto.MedidaAbreviacion,
                           t.CalcularVolumenTotal(Areas, ClavePeriodo).ToString("N"),
                           Utilerias.ToCurrency(t.CalcularImporteTotal(Areas, ClavePeriodo))
                       };
                    })
                    :
                    "<td>" + Concepto.MedidaAbreviacion + "</td>" +
                    "<td>" + Concepto.CalcularVolumenTotal(Areas, ClavePeriodo).ToString("N") + "</td>" +
                    "<td>" + Utilerias.ToCurrency(Concepto.CalcularImporteTotal(Areas, ClavePeriodo)) + "</td>"
                    )
            + @"    
                </tbody>" +
                /* Si el concepto tiene subconceptos se generará el pie de la tabla. 
                 * De lo contrario habrá pie de tabla
                 */
                (Tipos.Count > 0 ?
                @"<tfoot>
                    <tr>
                        <th colspan='2' class='text-right'>TOTAL: </th>
                        <td>" + Concepto.CalcularVolumenTotal(Areas, ClavePeriodo).ToString("N") + @"</td>
                        <td>" + Utilerias.ToCurrency(Concepto.CalcularImporteTotal(Areas, ClavePeriodo)) + @"</td>
                    </tr>
                </tfoot>"
                :
                ""
                ) +
            @"
            </table>
            </div>";


            return Html;
        }
    }

}