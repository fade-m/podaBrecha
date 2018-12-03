<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrearContrato.aspx.cs" Inherits="PodaProject.App.Area.CrearContrato" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
      <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Crear contrato

</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Crear contrato adjudicado e indicar el contratista que atenderá este contrato
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">


     <div class="box box-primary">
        <div class="box-body">

          <asp:Literal ID="litMensaje" runat ="server"></asp:Literal>

          <form role="form" runat="server">
              <div class="box-header">
                <h3 class="box-title">Nuevo contrato</h3>
             </div>

            <div class="form-group">

                <div class="form-group">
                    <label>Codigo</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox ID="txtCodigo" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label>Fecha de adjudicacion</label>
                      <asp:RequiredFieldValidator ID="ValFechaAdjudicacion" runat="server"
                            ErrorMessage="Fecha obligatoria"
                            ControlToValidate="txtFechaAdjudicacion"
                            Text="*"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValInicioRegex" runat="server"
                            ErrorMessage="Formato de fecha incorrecto"
                            ControlToValidate="txtFechaAdjudicacion"
                            ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                            Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                        <div class="input-group">
                            <asp:TextBox ID="txtFechaAdjudicacion" ClientIDMode="Static" CssClass="form-control" runat="server"
                                data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" Enabled="True"></asp:TextBox>
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                        </div>
                </div>


                <div class="form-group">
                <label>Fecha de inicio</label>
                  <asp:RequiredFieldValidator ID="ValFechaInicio" runat="server"
                        ErrorMessage="Fecha obligatoria"
                        ControlToValidate="txtFechaInicio"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Formato de fecha incorrecto"
                        ControlToValidate="txtFechaInicio"
                        ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaInicio" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" Enabled="True"></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>

                </div>

                <div class="form-group">
                <label>Fecha de creacion</label>
                  <asp:RequiredFieldValidator ID="ValFechaCreacion" runat="server"
                        ErrorMessage="Fecha obligatoria"
                        ControlToValidate="txtFechaCreacion"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="Formato de fecha incorrecto"
                        ControlToValidate="txtFechaCreacion"
                        ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaCreacion" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" Enabled="True"></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>

                </div>


                <div class="form-group">
                    <label>Estatus contrato</label>
                    <asp:DropDownList ID="cmbEstatus" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbEstatusContrato_SelectedIndexChanged">
                    </asp:DropDownList>

                </div> 


                 <div class="form-group">
                    <label>Contratista</label>
                    <asp:DropDownList ID="cmbContratista" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="nombre" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbContratista_SelectedIndexChanged">
                    </asp:DropDownList>

                </div> 

                 <div class="form-group">
                    <label>Modalidad</label>
                    <asp:DropDownList ID="cmbModalidad" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="nombre" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbModalidad_SelectedIndexChanged">
                    </asp:DropDownList>

                </div> 


            </div>


               <asp:LinkButton runat="server" ID="btnCrearContrato" CssClass="btn btn-primary" OnClick="btnCrearContrato_Click">
                  <span class="fa fa-save"></span> Crear
                </asp:LinkButton>

          </form>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">

     <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.numeric.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>

        <!-- DATEPICKER -->
    <script src="../../bootstrap/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../../bootstrap/plugins/datepicker/locales/bootstrap-datepicker.es.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#txtFechaAdjudicacion").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            $("#txtFechaAdjudicacion").datepicker({
                "format": "dd/mm/yyyy",
                "language": "es",
                "todayBtn": true,
                "todayHighlight": true
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $("#txtFechaInicio").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            $("#txtFechaInicio").datepicker({
                "format": "dd/mm/yyyy",
                "language": "es",
                "todayBtn": true,
                "todayHighlight": true
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $("#txtFechaCreacion").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            $("#txtFechaCreacion").datepicker({
                "format": "dd/mm/yyyy",
                "language": "es",
                "todayBtn": true,
                "todayHighlight": true
            });
        });
    </script>



</asp:Content>
