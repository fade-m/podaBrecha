<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Ejercicios.aspx.cs"
    Inherits="PodaProject.App.Division.Ejercicios" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="cabecera" ContentPlaceHolderID="cabecera" runat="server">
    Ejercicios de necesidades
</asp:Content>

<asp:Content ID="descripcion" ContentPlaceHolderID="descripcion" runat="server">
    Lista de ejercicios
</asp:Content>

<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <asp:Literal runat="server" ID="litMensaje"></asp:Literal>
    <div class="row" runat="server">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header" runat="server">
                    <h3 class="box-title">Lista de ejercicios de necesidades</h3>
                    <a href="../../App/Division/NuevoEjercicio.aspx" class="btn btn-primary pull-right">
                        <span class="fa fa-plus-circle"></span>
                        Nuevo ejercicio
                    </a>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="table-responsive">
                        <table id="ejercicios" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Fecha de inicio</th>
                                    <th>Fecha de fin</th>
                                    <th>Descripción</th>
                                    <th>Estatus</th>
                                    <th style="width:100px;"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="litTablaBody"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
                <!-- /.box-body -->

            </div>
            <!-- /.box -->
        </div>
        <!-- /.col-xs-12 -->
    </div>
    <!-- /.row -->
</asp:Content>

<asp:Content ID="scripts" ContentPlaceHolderID="scripts" runat="server">
    <!-- DATATABLES -->
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#ejercicios').dataTable({
                "lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
                "autoWidth": false,
                "order": [[2, "desc"]],
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
