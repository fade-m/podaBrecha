<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrearProgramacion.aspx.cs" Inherits="PodaProject.App.Area.CrearProgramacion" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Crear programacion
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Crear la programacion a la cual se le dará control y seguimiento en el periodo activo
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
     <div class="box box-pane">
         <div class="box-body">
             <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
             <asp:Literal runat="server" ID="advertencia"></asp:Literal>

                    <div class="table-responsive">
                        <H4>Detalles del programa de ejecucion inicial</H4>
                        <table id="datos" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Cantidad</th>
                                    <th>Fecha de inicio</th>
                                    <th>Precio unitario</th>
                                    <th>Circuito</th>
                                    <th>Contrato</th>
                                    <th>Concepto</th>
                                    <th>Tipo concepto</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="litTBody"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
         
            <div class="box-body">
            <form role="form" runat="server">

                <div class="form-group">
                    <label>Numero de mes</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtNumeroMes" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>

                
                <div class="form-group">
                    <label>Seleccionar fila de programacion</label>
                    <asp:DropDownList ID="cmbProgramacion" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="cantidad" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>

                </div>


                <div class="form-group">
                    <label>Nombre del mes</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtNombreMes" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>

                <div class="form-group">
                    <label>Cantidad a programar</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtCantidadProgramada" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>

                <asp:LinkButton runat="server" ID="btnRegistrarProgramacion" CssClass="btn btn-primary"
                    OnClick="btnRegistrarProgramacion_Click">
                                <span class="fa fa-save"></span>
                                Registrar
                </asp:LinkButton>

            </form>

        </div>

         <div class="box box-pane">
         <div class="box-body">
                    <div class="table-responsive">
                        <H4>Programacion</H4>
                        <table id="detalles" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Mes</th>
                                    <th>Programado</th>
                                    <th>Circuito</th>
                                    <th>Concepto</th>
                                    <th>Tipo concepto</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="litTBody2"></asp:Literal>
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
            $('#detalles').dataTable({
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
