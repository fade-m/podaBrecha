<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarContrato.aspx.cs" Inherits="PodaProject.App.Area.AsignarContrato" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
         <!-- DATATABLES -->
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Asigna un contrato a un plan de ejecucion creado
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Seleccione un programa para asignarle el contrato
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

    
    <div class="box box-info">
        <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
        <div class="box-header">
            <h3 class="box-title">Necesidades disponibles</h3>
        </div>

        <div class="box-body">
           <div class="table-responsive">
                        <H4>Programas disponibles</H4>
                        <table id="ejercicios" class="table table-bordered table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>Creacion del programa</th>
                                    <th>Creacion de la necesidad</th>
                                    <th>Area</th>
                                    <th>Periodo</th>
                                    <th>Estatus</th>
                                    <th>Contrato</th>
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
