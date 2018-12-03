<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CrearProgramaDetalle.aspx.cs" Inherits="PodaProject.App.Area.CrearProgramaDetalle" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
     <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
       <!-- DATEPICKER -->
    <link href="../../bootstrap/plugins/datepicker/datepicker3.css" rel="stylesheet" />

    
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Detalles del programa de ejecucion

</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Determina los detalles para el programa de ejecucion 

</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

     <div class="box box-primary">
         <div class="box-body">
             <asp:Literal ID="litPrueba" runat ="server"></asp:Literal>
             <asp:Literal ID="litMensaje" runat ="server"></asp:Literal>
             <form role="form" runat="server">

                  <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">Detalles de la necesidad a programar</h3>
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

                    <div class="box-header">
                        <h3 class="box-title">Acciones para la programación</h3>
                    </div>
                    <div class="box-header">
                        <h7 class="box-title">Cree los detalles por circuito del programa de ejecución para incluirlos en un mes</h7>
                    </div>

                    <asp:label runat="server">Concepto</asp:label>
                    <asp:DropDownList ID="cmbConcepto" runat="server" 
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbConcepto_SelectedIndexChanged">
                    </asp:DropDownList>

                 <br />
                 <br />
 
  
                    <asp:label runat="server">Tipo de Concepto</asp:label>
                    <asp:DropDownList ID="cmbTipoConcepto" runat="server" 
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>

                 <br />
                 <br />        


                 <asp:Label runat="server">Cantidad</asp:Label>
                 <asp:TextBox runat="server" ID="cantidadProg"  ClientIDMode="Static"></asp:TextBox>

                 <br />
                 <br />
                 
                 <asp:Label runat="server">Precio unitario</asp:Label>
                 <asp:TextBox runat="server" ID="precioUnit"  ClientIDMode="Static"></asp:TextBox> 
                 
                 <br />
                 <br />


                  <asp:label runat="server">Fecha aproximada de inicio</asp:label>
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
           
                        <asp:TextBox ID="txtFechaCreacion" ClientIDMode="Static" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" ></asp:TextBox>



                 <br />
                 <br />

                 <asp:Label runat="server">Circuito</asp:Label>
                 <asp:DropDownList ID="cmbCircuito" runat="server" 
                        DataValueField="Clave" DataTextField="Descripcion" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbCircuito_SelectedIndexChanged">
                    </asp:DropDownList>

                    <br /> <br />
                    
                    <asp:LinkButton runat="server" ID="btnAgregarMes" CssClass="btn btn-primary" OnClick="btnAgregarMes_Click">
                                <span class="fa fa-save"></span>
                                Agregar
                    </asp:LinkButton>
             </form>

         </div>
     </div>

    
     <div class="box box-primary">
         <div class="box-body">
             <h3>Detalles creados</h3>

             <div class="box-body">
            <table id="detalle" class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Cantidad</th>
                        <th>Fecha aproximada de inicio</th>
                        <th>Precio unitario</th>
                        <th>Circuito</th>
                        <th>Concepto</th>
                        <th>Tipo concepto</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="LitDetalles"></asp:Literal>
                </tbody>
            </table>

        </div>


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