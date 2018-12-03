<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReporteDeEjecucion.aspx.cs" Inherits="PodaProject.App.Area.ReporteDeEjecucion" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
        <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Reporte de ejecucion
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Envíe el reporte de ejecución de un més seleccionado
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
         <div class="box box-pane">
         <div class="box-body">
             <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
                    <div class="table-responsive">
                        <H4>Detalles del programa de ejecucion inicial</H4>
                        <table id="datos" class="table table-bordered table-hover table-responsive">
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
                                <asp:Literal runat="server" ID="litTBody"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>


            <div class="box-body">
            <form role="form" runat="server">
                
                <div class="form-group">
                    <label>Seleccionar mes de la lista superior</label>
                    <asp:DropDownList ID="cmbMes" runat="server" CssClass="form-control"
                        DataValueField="Clave" DataTextField="NombreMes" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false">
                    </asp:DropDownList>

                </div>

                <div class="form-group">
                    <label>Ejecutado</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtEjecutado" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>


                <div class="form-group">
                    <label>Observaciones</label>
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-archive"></i>
                        </div>
                        <asp:TextBox ID="txtObservaciones" ClientIDMode="Static" CssClass="form-control" runat="server">
                        </asp:TextBox>

                    </div>
                </div>

                <div class="form-group">
                    <label>Fecha de registro del reporte</label>

                    
                    <div class="input-group">
                        <asp:TextBox ID="txtFechaCreacion" ClientIDMode="Static" CssClass="form-control" runat="server"
                            data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" ></asp:TextBox>
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                    </div>


                </div>

                <asp:LinkButton runat="server" ID="btnRegistrarAvance" CssClass="btn btn-primary"
                    OnClick="btnRegistrarAvance_Click">
                                <span class="fa fa-save"></span>
                                Registrar
                </asp:LinkButton>

            </form>

        </div>






         <div class="box box-pane">
         <div class="box-body">
                    <div class="table-responsive">
                        <H4>Reportes registrados</H4>
                        <table id="reportes" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Ejecutado</th>
                                    <th>Observaciones</th>
                                    <th>Fecha de creacion</th>
                                    <th>Mes</th>
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

      

</asp:Content>