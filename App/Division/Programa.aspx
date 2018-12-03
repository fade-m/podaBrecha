<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Programa.aspx.cs" Inherits="PodaProject.App.Division.Programa" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
            <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Programa de ejecucion
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
        Visualizacion del programa de ejecucion correspondiente a la necesidad seleccionada
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
        <div class="box box-pane">
         <div class="box-body">
             <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
                    <div class="table-responsive">
                        <H4>Datos del programa</H4>
                        <table id="datos" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Fecha de creacion del programa</th>
                                    <th>Fecha de la necesidad a la que se atiende</th>
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
                        <H4>Detalles de la programacion</H4>
                        <table id="detalles" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Cantidad</th>
                                    <th>Fecha de inicio</th>
                                    <th>Precio unitario</th>
                                    <th>Circuito</th>
                                    <th>Contrato</th>
                                    <th>Concepto</th>
                                    <th>Tipo concepto</th>
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
