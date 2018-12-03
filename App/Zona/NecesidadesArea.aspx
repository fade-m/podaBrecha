<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NecesidadesArea.aspx.cs" 
    Inherits="PodaProject.App.Zona.NecesidadesAreas" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
        <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Necesidades de la area
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    en volumenes y precios unitarios
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">


    <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">Necesidades de las áreas</h3>
            </div>
            <div class="box-body">
                <table id="zonas" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Volumen</th>
                            <th>Precio unitario</th>
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

</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">

</asp:Content>
