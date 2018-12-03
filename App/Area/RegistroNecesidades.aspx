<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" 
    CodeBehind="RegistroNecesidades.aspx.cs" Inherits="PodaProject.App.Area.RegistroNecesidades" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
        <!-- DATEPICKER -->
    <link href="../../bootstrap/plugins/datepicker/datepicker3.css" rel="stylesheet" />

      <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Registro de necesidades 

</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    del area 
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

     <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Nueva necesidad</h3>
        </div>

        <div class="box-body">
            <form role="form" runat="server">

                <div class="form-group">
                    <label>Fecha de inicio</label>

                    <asp:RequiredFieldValidator ID="ValFechaInicio" runat="server"
                        ErrorMessage="Fecha obligatoria"
                        ControlToValidate="txtFechaCreacion"
                        Text="*"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValInicioRegex" runat="server"
                        ErrorMessage="Formato de fecha incorrecto"
                        ControlToValidate="txtFechaCreacion"
                        ValidationExpression="^\s*(3[01]|[12][0-9]|0?[1-9])/(1[012]|0?[1-9])/((?:19|20)\d{2})\s*$"
                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaCreacion" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" Enabled="false"></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>


                </div>

                <div class="form-group">
                    <label>Estatus</label>
                    <asp:DropDownList ID="cmbEstatus" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>
                </div>

                 <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

                 <asp:LinkButton runat="server" ID="btnRegistrarNecesidad" CssClass="btn btn-primary" 
                    OnClick="btnRegistrarNecesidad_Click">
                    <span class="fa fa-save"></span>
                    Crear Necesidad
                </asp:LinkButton>

                                
            </form>           
        </div>
    </div>


    <div class="box box-pane">
         <div class="box-body">
                    <div class="table-responsive">
                        <H4>Necesidades creadas</H4>
                        <table id="ejercicios" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Fecha de creacion</th>
                                    <th>Periodo</th>
                                    <th>Estatus</th>
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
    <!-- INPUT MASK -->
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <!-- DATEPICKER -->
    <script src="../../bootstrap/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../../bootstrap/plugins/datepicker/locales/bootstrap-datepicker.es.js"></script>

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
