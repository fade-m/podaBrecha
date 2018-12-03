<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarPresupuestos.aspx.cs"
    Inherits="PodaProject.App.Division.AsignarPresupuestos" CodeFile="~/App/Division/AsignarPresupuestos.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Asignar presupuestos
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

    <div class="box box-primary">
        <div class="box-header">
            <h3 class="box-title">Presupuesto divisional</h3>
        </div>

        <div class="box-body">
            <form role="form" runat="server">
                <div class="form-group">
                    <label>Ejercicio</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <input type="text" class="form-control" value="<%= PeriodoActivo.Descripcion %>" disabled="disabled" />
                    </div>

                </div>
                <div class="form-group">
                    <label>Recurso divisional asignado</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <input type="text" class="form-control prep" value="<%= PresupuestoActual.Monto %>" disabled="disabled" />
                    </div>
                </div>
                <div class="form-group">
                    <label>Recurso asignado a las zonas</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <input type="text" class="form-control prep" value="<%= PresupuestoActual.Monto - PresupuestoDisponible %>" disabled="disabled" />
                    </div>
                </div>

                <div class="form-group">
                    <label>Recurso disponible</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <input type="text" class="form-control prep" value="<%= PresupuestoDisponible %>" disabled="disabled" />
                    </div>
                </div>

                <div class="form-group">
                    <label>Nuevo presupuesto divisional</label>
                    <asp:RequiredFieldValidator ID="ValPresupuesto" ControlToValidate="presupuesto" Text="*"
                        ForeColor="Red" Display="Dynamic" runat="server"></asp:RequiredFieldValidator>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox ID="presupuesto" ClientIDMode="Static" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-primary" OnClick="btnActualizar_Click">
                    <span class="fa fa-save"></span>
                    Guardar
                </asp:LinkButton>
            </form>
        </div>
    </div>

    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Presupuesto de zonas</h3>
        </div>

        <div class="box-body">
            <form role="form" action="POST_AsignarPresupuestos.aspx">
                <input type="hidden" name="prepd" value="<%= PresupuestoActual.Monto %>" />
                <div class="table-responsive">
                    <table class="table table-bordered table-hover" id="zonas">
                        <thead>
                            <tr>
                                <th>Zona</th>
                                <th>Recurso asignado</th>
                                <th>Necesidad total</th>
                                <th>Asigar recurso</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal ID="litTablaBody" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>

                <br />
                <button type="submit" class="btn btn-primary">
                    <span class="fa fa-save"></span>
                    &nbsp; Guardar
                </button>
            </form>
        </div>
    </div>

    <asp:Literal ID="litModales" runat="server"></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <!-- DATATABLES -->
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../bootstrap/plugins/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>


    <script type="text/javascript">
        $(function () {
            $('#presupuesto, .prep').inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            });

            $('#zonas').dataTable({
                //"lengthMenu": [[5, 10, -1], [5, 10, "Todos"]],
                "filter": false,
                "lengthChange": false,
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

            $(".prep").each(function () {
                var input = $(this);
                input.on('keyup change blur', function () {
                    setTimeout(function () {
                        if (input.val().trim().length === 0) {
                            input.val(0);
                        }
                    }, 1000);
                });
            });
        });

    </script>
</asp:Content>
