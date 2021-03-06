﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RequerimientosArea.aspx.cs"
    Inherits="PodaProject.App.Division.RequerimientosArea" CodeFile="~/App/Division/RequerimientosArea.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Requerimientos de área
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Requerimientos de brecha y poda
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <div class="box box-danger">
        <div class="box-header">
            <h3 class="box-title">Necesidades de brecha y poda</h3>
        </div>
        <div class="box-body">
           <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
            <form role="form" runat="server">
                <div class="form-group">
                    <label>Ejercicio</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <input type="text" class="form-control" value="<%= PeriodoSeleccionado.Descripcion %>" disabled="disabled" />
                    </div>
                </div>
                <div class="form-group">
                    <label>Zona</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                        <input type="text" class="form-control" value="<%= Area.Zona.Nombre %>" disabled="disabled" />
                    </div>
                </div>
                <div class="form-group">
                    <label>Área</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                        <input type="text" class="form-control" value="<%= Area.Nombre %>" disabled="disabled" />
                    </div>
                </div>
                <div class="form-group">
                    <label>Presupuesto asignado a la área</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox ID="presupuesto" ClientIDMode="Static" runat="server"
                            Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label>Necesidad total actual</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox ID="necesidad" ClientIDMode="Static" runat="server"
                            Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-primary" OnClick="btnAprobar_Click">
                    <span class="fa fa-save"></span>
                    Aprobar necesidad
                </asp:LinkButton>
            </form>
        </div>
    </div>

    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Detalles de la necesidad</h3>
        </div>
        <div class="box-body">
            <div class="table-responsive">
                <table id="detalles" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Concepto</th>
                            <th>Tipo concepto</th>
                            <th>Unidad de medida</th>
                            <th>Volúmen</th>
                            <th>Precio unitario</th>
                            <th>Subtotal</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="litTablaDetalles" runat="server"></asp:Literal>
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

    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#detalles').dataTable({
                "lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
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

            /*
            * INPUT MASK
            */
            var options = {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            };

            $('#presupuesto').inputmask("decimal", options);
            $('#necesidad').inputmask("decimal", options);
        });
    </script>
</asp:Content>
