<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReporteNecesidades.aspx.cs" 
    Inherits="PodaProject.App.Zona.ReporteNecesidades" CodeFile="~/App/Zona/ReporteNecesidades.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .equal {
            display: flex;
            display: -webkit-flex;
            flex-wrap: wrap;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Reporte de necesidades
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Reportes por concepto
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

    <div class="row equal">
        <div class="col-xs-12 col-md-6 equal">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">Generalidades</h3>
                </div>
                <div class="box-body">
                    <form role="form">
                        <div class="form-group">
                            <label>Ejercicio</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                                <input type="text" class="form-control" value="<%= PeriodoSeleccionado.Descripcion %>" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Recurso de zona</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <input type="text" id="presupuesto" class="form-control" value="<%= RecursoZona.Monto %>" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Necesidad total de las áreas</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <input type="text" id="necesidad" class="form-control" value="<%= NecesidadTotal %>" disabled="disabled" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
         
        <div class="col-xs-12 col-md-6 equal">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <i class="fa fa-bar-chart-o"></i>
                    <h3 class="box-title">Gráfica de importes por concepto</h3>
                </div>
                <div class="box-body">
                    <div id="donut-chart" style="height: 300px;"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Reporte de necesidades por concepto</h3>
        </div>
        <div class="box-body">
            <asp:Literal ID="litReporte" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <!-- DATATABLES -->
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <!-- FLOT CHARTS -->
    <script src="../../bootstrap/plugins/flot/jquery.flot.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.pie.min.js"></script>


    <asp:Literal ID="litScriptChart" runat="server"></asp:Literal>

    <script type="text/javascript">
        $(function () {

            /*  INPUT MASK  */
            var options = {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            };

            $('#presupuesto, #necesidad').inputmask("decimal", options);

            /*  DATATABLES */
            $('.table').dataTable({
                "searching": false,
                "lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
                "info": false,
                "search": false,
                "autoWidth": false,
                "paging": false,
                "language": {
                    "emptyTable": "Sin registros",
                    "info": "Registros _START_ a _END_. Total: _TOTAL_",
                    "infoEmpty": "Sin registros por mostrar",
                    "infoFiltered": "(_MAX_ registros filtrados)",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "No se encontraron resultados",
                    "paginate": {
                        "first": "Inicio",
                        "last": "Fin",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                }
            });

        });
    </script>
</asp:Content>
