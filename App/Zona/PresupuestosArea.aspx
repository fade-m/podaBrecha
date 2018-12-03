<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PresupuestosArea.aspx.cs" 
    Inherits="PodaProject.App.Zona.AreaPresupuestos" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
            <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
            Presupuestos de area
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
            Presupuestos asignados al area seleccionada
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

        <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">Recursos asignados a las áreas de la zona</h3>
        </div>
        <div class="box-body">
            <table id="zonas" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Área</th>
                        <th>Presupuesto</th>
                        <th>Ejercicio</th>
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
        });
    </script>

</asp:Content>