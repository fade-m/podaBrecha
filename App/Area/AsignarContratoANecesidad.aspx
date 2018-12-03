<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AsignarContratoANecesidad.aspx.cs" Inherits="PodaProject.App.Area.AsignarContratoANecesidad" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Asignar contrato
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    Asignarle un contrato dado de alta en el sistema a un programa previamente establecido 
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">
    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">Programas disponibles</h3>
        </div>

        <div class="box-body">
            <asp:Literal ID="litMensaje" runat ="server"></asp:Literal>

            <form role="form" runat="server">
                    <asp:DropDownList ID="cmbContrato" runat="server"  CssClass="form-control" 
                        DataValueField="Clave" DataTextField="codigo" ClientIDMode="Static"
                        AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="cmbContrato_SelectedIndexChanged">
                    </asp:DropDownList>
                    
                    <asp:LinkButton runat="server" ID="btnVincular" CssClass="btn btn-primary" OnClick="btnVincular_Click">
                                <span class="fa fa-save"></span>
                                Vincular
                    </asp:LinkButton>
            </form>

        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">

</asp:Content>