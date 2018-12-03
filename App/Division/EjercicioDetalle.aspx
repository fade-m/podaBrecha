<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EjercicioDetalle.aspx.cs"
    Inherits="PodaProject.App.Division.EjercicioDetalle" CodeFile="~/App/Division/EjercicioDetalle.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <!-- DATEPICKER -->
    <link href="../../bootstrap/plugins/datepicker/datepicker3.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Detalle del ejercicio
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Información del ejercicio seleccionado
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

    <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Información del nuevo ejercicio</h3>
        </div>

        <div class="box-body">
            <form role="form" runat="server">
                <div class="form-group">
                    <label>Fecha de inicio</label>
                    <asp:RequiredFieldValidator ID="ValFechaInicio" runat="server"
                        ErrorMessage="Fecha obligatoria"
                        ControlToValidate="txtFechaInicio"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValInicioRegex" runat="server"
                        ErrorMessage="Formato de fecha incorrecto"
                        ControlToValidate="txtFechaInicio"
                        ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaInicio" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label>Fecha de fin</label>
                    <asp:RequiredFieldValidator ID="ValFechaFin" runat="server"
                        ErrorMessage="Fecha obligatoria"
                        ControlToValidate="txtFechaFin"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValFinRegex" runat="server"
                        ErrorMessage="Formato de fecha incorrecto"
                        ControlToValidate="txtFechaFin"
                        ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaFin" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label>Descripción</label>
                    <asp:RequiredFieldValidator ID="ValDescripcion" runat="server"
                        ErrorMessage="Descripción obligatoria"
                        ControlToValidate="txtDescripcion"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtDescripcion" MaxLength="60" ClientIDMode="Static"
                        CssClass="form-control" runat="server"></asp:TextBox>
                </div>


                <div class="form-group">
                    <label>Estatus</label>
                    <asp:DropDownList ID="cmbEstatus" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>
                </div>

                <div class="callout callout-warning">
                    <h4>¡Precaución!</h4>
                    <p>
                        Tome en cuenta que poner el estatus activo hará que el ejercicio que se encuentre 
                        activo actualmente se dará por finalizado.
                    </p>
                </div>

                <asp:LinkButton runat="server" ID="btnRegistrarEjercicio" CssClass="btn btn-primary"
                    OnClick="btnRegistrarEjercicio_Click">
                    <span class="fa fa-save"></span>
                    Guardar ejercicio
                </asp:LinkButton>
            </form>
        </div>

    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <!-- DATEPICKER -->
    <script src="../../bootstrap/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../../bootstrap/plugins/datepicker/locales/bootstrap-datepicker.es.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#txtFechaInicio").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            $("#txtFechaInicio").datepicker({
                "format": "dd/mm/yyyy",
                "language": "es",
                "todayBtn": true,
                "todayHighlight": true
            });

            $("#txtFechaFin").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            $("#txtFechaFin").datepicker({
                "format": "dd/mm/yyyy",
                "language": "es",
                "todayBtn": true,
                "todayHighlight": true
            });
        });
    </script>
</asp:Content>
