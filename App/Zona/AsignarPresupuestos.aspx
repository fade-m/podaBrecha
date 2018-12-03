<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
    CodeBehind="AsignarPresupuestos.aspx.cs" Inherits="PodaProject.App.Zona.AsignarPresupuestos"  CodeFile="~/App/Zona/AsignarPresupuestos.aspx.cs"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Asignar presupuestos
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Asignar el recurso correspondiente a cada area
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
    <div class="box box-danger">
        <div class="box-body">
            <form role="form" runat="server">
                <div class="form-group">
                    <label>Ejercicio</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="periodoActual" Enabled="false"></asp:TextBox>
                    </div>

                </div>


                <div class="form-group">
                    <label>Presupuesto de zona</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="prepZona" Enabled="false"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <label>Presupuesto disponible</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <input type="text" name="presupeustoDisponible" class="form-control" value="<%= prepD %>" Disabled="disabled"/>
                    </div>
                </div>


                <div class="form-group">
                    <label>Presupuesto asigando a las areas</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <input type="text" name="presupeustoDisponible" class="form-control"value="<%= prepdZona.Monto - prepD %>" Disabled="disabled"/>
                    </div>
                </div>

                <div class="callout callout-info">
                    <h4>Nota:</h4>
                    <p>
                        Tome en cuenta que debe distribuir en sus areas el 100% de su recurso disponible, incluyendo los centavos 
                    </p>
                </div>

            </form>

        </div>
    </div>


    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">Recursos asignados a las áreas de la zona</h3>
        </div>
        <div class="box-body">
            <form role="form" action="POST_AsignarPresupuestos.aspx">
                <input type="hidden" name="prepd" value="<%= prepdZona.Monto %>" />
                <table id="zonas" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Área</th>
                            <th>Necesidad del area</th>
                            <th>Presupuesto anterior</th>
                            <th>Nuevo presupuesto</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal runat="server" ID="litTBody"></asp:Literal>
                    </tbody>
                </table>

                <div class="input-group">
                    <button type="submit" class="btn btn-primary">
                    <span class="fa fa-save"></span>
                    &nbsp; Guardar
                </button>
                </div>
            </form>

        </div>



    </div>


</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>

    <script type="text/javascript">

        const PREP = $("#prepZona").val();

        function presupuesto(input) {
            var presupuestosAreas = $("input[id='txtprep']");
            var total = 0;
            for (var x = 0; x < presupuestosAreas.length; x++) {
                if (presupuestosAreas[x].value == "") {
                    total = parseInt(total) + parseInt(0);
                }
                else {
                    total = parseInt(total) + parseInt(presupuestosAreas[x].value);
                }
            }
            var suma = parseInt(PREP) - parseInt(total);
            if (suma < 0) {
                var str = $(input).val();
                alert("presupuesto excedido");
                $(input).val(str.substring(0, (str.length) - 1));
                presupuesto(input); //recursividad necesaria para asegurar lo maixmo posible que los nuevos presupuestos no excedan el total permitido
            } else {
                $("#prepZona").val(suma);
            }

        }

    </script>

    <script type="text/javascript">
        $(function () {
            $("#presupuesto, input[name='prepArea']").inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: "",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
            });
        });

        $(function () {
            $('#presupuesto01, .numero').inputmask("decimal", {
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
