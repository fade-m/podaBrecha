<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrearPrograma.aspx.cs" Inherits="PodaProject.App.Area.CrearPrograma" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
     <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Crear programa de ejecucion
</asp:Content>
<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Crear el programa de ejecucion para el ejercicio actual
</asp:Content>
<asp:Content ContentPlaceHolderID="contenido" runat="server">

    <div class="box box-primary">
        <div class="box-body">

          <form role="form" runat="server">
              <div class="box-header">
                <h3 class="box-title">Nuevo programa de ejecución</h3>
             </div>

            <div class="form-group">
                <label>Fecha de creacion</label>

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
                <label>Necesidad correspondiente al programa</label>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                    <asp:TextBox ID="txtNecesidad" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

              <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

               <asp:LinkButton runat="server" ID="btnCrearPrograma" CssClass="btn btn-primary" 
                    OnClick="btnCrearPrograma_Click">
                    <span class="fa fa-save"></span>
                    Crear Programa
                </asp:LinkButton>
          </form>
        </div>
    </div>


        <div class="box box-pane">
         <div class="box-body">
                    <div class="table-responsive">
                        <H4>Programas de ejecucion creados</H4>
                        <table id="programas" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Fecha de creacion</th>
                                    <th>Necesidad</th>
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
</asp:Content>
