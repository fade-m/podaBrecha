<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegistroNecesidadDetalle.aspx.cs" Inherits="PodaProject.App.Area.RegistroNecesidadDetalle" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Detalles de la necesidad
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    detalles en volumen y precio unitario para el area
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Detalles de la necesidad creada</h3>
        </div>

        <div class="box-body">
            <form role="form" runat="server">

                <div class="form-group">
                    <label>Concepto</label>
                    <asp:DropDownList ID="cmbConcepto" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbConcepto_SelectedIndexChanged">
                    </asp:DropDownList>

                </div> 



                <div class="form-group">
                    <label>Tipo de Concepto</label>
                    <asp:DropDownList ID="cmbTipoConcepto" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>

                </div>


                <div class="form-group">
                    <label>Volumen</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtVolumen" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>

                <div class="form-group">
                    <label>Precio Unitario</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-dollar"></i>
                        </div>
                        <asp:TextBox ID="txtPrecioU" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>
                    </div>
                </div>


                

                <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

                <asp:LinkButton runat="server" ID="btnRegistrarNecesidad" CssClass="btn btn-primary"
                    OnClick="btnRegistrarNecesidadDetalle_Click">
                                <span class="fa fa-save"></span>
                                Crear Necesidad
                </asp:LinkButton>

                <asp:LinkButton runat="server" ID="btnEnivar" CssClass="btn btn-primary"
                    OnClick="btnEnivar_Click">
                    <span class="fa fa-save"></span>
                    Enivar a revision
                </asp:LinkButton>
            </form>

        </div>


    </div>


    <div class="box box-success">
        <div class="box-header">
            <h3 class="box-title">Detalles agregados exitosamente</h3>
        </div>

        <div class="form-group">
            <asp:Literal runat="server" ID="LitimporteTotal"></asp:Literal>
        </div>

        <div class="box-body">
            <table id="anteriores" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Volumen</th>
                        <th>Precio unitario</th>
                        <th>Subtotal</th>
                        <th>Concepto</th>
                        <th>Tipo Concepto</th>
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
            /*
            * INPUT MASK
            */
            $('#txtVolumen, #LitimporteTotal').inputmask("decimal", {
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