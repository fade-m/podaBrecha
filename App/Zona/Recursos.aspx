﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Recursos.aspx.cs"
    Inherits="PodaProject.App.Zona.Recursos" %>

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
    Recursos asignados
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Presupuesto de zona
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <div class="row equal">
        <div class="col-xs-12 col-md-6 equal">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">Ejercicio actual</h3>

                    <a href="RecursoZona.aspx" class="btn btn-primary pull-right">
                        <span class="fa fa-info-circle"></span>
                        Detalles
                    </a>
                </div>

                <div class="box-body">
                    <form id="form1" runat="server">
                        <div class="form-group">

                           <label>Ejercicio</label>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="periodoActual" Enabled="false"> </asp:TextBox>
                         
                                </div>

                        </div>

                        <div class="form-group">
                            <label>Presupuesto asignado por la division</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                <asp:Literal runat="server" ID="litPrep"></asp:Literal>
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
            <table id="anteriores" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Ejercicio</th>
                        <th>Presupuesto</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="litTBody"></asp:Literal>
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
            $('#presupuesto, .numero').inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            });

            $('#anteriores').dataTable({
                "lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
                "autoWidth": true,
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





