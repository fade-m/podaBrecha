<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Recursos.aspx.cs"
    Inherits="PodaProject.App.Division.Recursos" CodeFile="~/App/Division/Recursos.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
        .equal {
            display: flex;
            display: -webkit-flex;
            flex-wrap: wrap;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Recursos asignados
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Presupuesto divisonal
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

    <div class="row equal">
        <div class="col-xs-12 col-md-6 equal">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">Ejercicio actual</h3>
                    <a href="RecursoDivisional.aspx?id=<%= PresupuestoActual.Clave %>" class="btn btn-primary pull-right">
                        <span class="fa fa-info-circle"></span>
                         &nbsp;Ver detalles
                    </a>
                </div>

                <div class="box-body">
                    <form role="form">
                        <div class="form-group">
                            <label>Ejercicio</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                                <input type="text" class="form-control" value="<%= PeriodoActual.Descripcion %>" disabled="disabled" />
                            </div>

                        </div>
                        <div class="form-group">
                            <label>Recurso asignado</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <input id="presupuesto" type="text" class="form-control" value="<%= PresupuestoActual.Monto %>" disabled="disabled" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Presupuesto disponible</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <input id="presupuestoDisponible" type="text" class="form-control" value="<%= PresupuestoActual.PresupuestoDisponible() %>" disabled="disabled" />
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
                    <h3 class="box-title">Últimos 5 ejercicios</h3>
                </div>
                <div class="box-body">
                    <div id="bar-chart" style="height: 300px;"></div>
                </div>
                <!-- /.box-body-->
            </div>
            <!-- /.box -->

        </div>
    </div>

    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">Ejercicios anteriores</h3>
            <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
            </div>
        </div>
        <div class="box-body">
            <div class="table-responsive">
                <table id="anteriores" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Ejercicio</th>
                            <th>Presupuesto</th>
                            <th style="width:100px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="litTablaBody" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <!-- DATATABLES -->
    <script src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <!-- FLOT CHARTS -->
    <script src="../../bootstrap/plugins/flot/jquery.flot.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.categories.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.symbol.js"></script>

    <asp:Literal ID="litScriptChart" runat="server"></asp:Literal>

    <script type="text/javascript">
        $(function () {
            /*
            * INPUT MASK
            */
            $('#presupuesto, #presupuestoDisponible').inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            });

            /*
            * DATATABLES
            */
            $('#anteriores').dataTable({
                "lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
                "autoWidth": true,
                "order": [[0, "desc"]],
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
                    },
                    "thousands": ","
                }
            });
        });
    </script>
</asp:Content>
