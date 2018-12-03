<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Recursos.aspx.cs"
    Inherits="PodaProject.App.Area.Recursos" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Recursos asignados
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Presupuesto asignado por la zona
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">



    <div class="box box-danger">
        <div class="box-header">
            <h3 class="box-title">Ejercicio actual</h3>
        </div>

        <div class="box-body">
            <form role="form" runat="server">
                <div class="form-group">
                    <label>Ejercicio</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox ID="txtAno" MaxLength="6" ClientIDMode="Static"
                            CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                    </div>

                </div>
                <div class="form-group">
                    <label>Presupuesto</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox ID="txtPresupuesto" MaxLength="15" ClientIDMode="Static"
                            CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </form>
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

    <script type="text/javascript">
        $(function () {
            $('#presupuesto').inputmask("decimal", {
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
