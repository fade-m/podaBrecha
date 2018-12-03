<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SeleccionReporteDeEjecucionArea.aspx.cs" Inherits="PodaProject.App.Division.SeleccionReporteDeEjecucionArea" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
        <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Reporte de ejecucion
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Detalles del reporte de ejecucion del area señeccionada
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