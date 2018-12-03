<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SeleccionReporteDeEjecucionZona.aspx.cs" Inherits="PodaProject.App.Division.SeleccionReporteDeEjecucionZona" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
            <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
        Reporte de ejecucion
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
        Visualizar el reporte de ejecucion de las areas de distribución.
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <div class="box box-pane">
         <div class="box-body">
                    <div class="table-responsive">
                        <table id="areas" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Codigo</th>
                                    <th></th>
                                   
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="litTBody"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
        </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">

     <!-- DATATABLES -->
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#areas').dataTable({
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