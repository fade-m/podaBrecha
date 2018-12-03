<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RecursoZona.aspx.cs"
    Inherits="PodaProject.App.Division.RecursoZona" CodeFile="~/App/Division/RecursoZona.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
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
    Recursos asignados a zona
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Presupuesto de zona
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <div class="row equal">
        <div class="col-xs-12 col-md-6 equal">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">Recurso asignado a la zona</h3>
                </div>

                <div class="box-body">
                    <form role="form" runat="server">
                        <div class="form-group">
                            <label>Ejercicio</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                                <input type="text" class="form-control" value="<%= Periodo.Descripcion %>" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Zona</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                                <input type="text" class="form-control" value="<%= PresupuestoSeleccionado.Zona.Nombre %>" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Presupuesto</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <asp:TextBox ID="presupuesto" ClientIDMode="Static" runat="server"
                                    Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Presupuesto disponible</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <asp:TextBox ID="disponible" ClientIDMode="Static" runat="server"
                                    Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-md-6">
            <div class="box box-success">
                <div class="box-header with-border">
                    <i class="fa fa-bar-chart-o"></i>
                    <h3 class="box-title">Presupuesto designado a las áreas de la zona</h3>
                </div>
                <div class="box-body">
                    <div id="donut-chart" style="height: 300px; padding: 0px; position: relative;"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">Recursos asignados a las áreas de la zona</h3>
        </div>
        <div class="box-body">
            <table id="zonas" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Ejercicio</th>
                        <th>Área</th>
                        <th>Presupuesto</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="litTablaBody" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <!-- FLOT CHART -->
    <script src="../../bootstrap/plugins/flot/jquery.flot.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.resize.min.js"></script>
    <script src="../../bootstrap/plugins/flot/jquery.flot.pie.min.js"></script>

    <!-- DATATABLES -->
    <script src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#presupuesto, #disponible').inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            });

            $('#zonas').dataTable({
                "lengthMenu": [[10, 20, -1], [10, 20, "Todos"]],
                "autoWidth": true,
                "order": [[1, "asc"]],
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

    <asp:Literal ID="litScriptChart" runat="server"></asp:Literal>
</asp:Content>
