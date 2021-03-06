﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrearContratista.aspx.cs" Inherits="PodaProject.App.Area.CrearContratista" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
     <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Dar de alta a contratista
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Ingresar los datos del contratista al sistema para despues asignarle contratos
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

     <div class="box box-primary">
        <div class="box-body">

          <asp:Literal ID="litMensaje" runat ="server"></asp:Literal>

          <form role="form" runat="server">
              <div class="box-header">
                <h3 class="box-title">Nuevo contratista</h3>
             </div>

            <div class="form-group">

                <div class="form-group">
                    <label>Nombre</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label>Razón social</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox ID="txtRazonSocial" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <asp:LinkButton runat="server" ID="btnCrearContratista" CssClass="btn btn-primary" OnClick="btnCrearContratista_Click">
                  <span class="fa fa-save"></span> Crear
                </asp:LinkButton>

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
    <script src="../../bootstrap/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>

        <!-- DATEPICKER -->
    <script src="../../bootstrap/plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../../bootstrap/plugins/datepicker/locales/bootstrap-datepicker.es.js"></script>

    <script type="text/javascript">
        $(function () {
            /*
            * INPUT MASK
            */
            $('#cantidadProg, #precioUnit').inputmask("decimal", {
                radixPoint: ".",
                groupSeparator: ",",
                digits: 2,
                autoGroup: true,
                prefix: '$',
                rightAlignNumerics: false
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