<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="PodaProject.App.Perfil" %>

<asp:Content ID="cabecera" ContentPlaceHolderID="cabecera" runat="server">
    Mi perfil
</asp:Content>

<asp:Content ID="descripcion" ContentPlaceHolderID="descripcion" runat="server">
    Información del usuario en sesión
</asp:Content>

<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <div class="row">
        <div class="col-xs-12 col-md-6">
            <div class="box box-info">
                <div class="box-header">
                    <h3 class="box-title">Datos personales</h3>
                </div>

                <div class="box-body">
                    <form role="form">
                        <div class="form-group">
                            <label>Nombre</label>
                            <input type="text" class="form-control" value="<%= Usuario.Nombre %>" disabled="disabled" />
                        </div>

                        <div class="form-group">
                            <label>Apellidos</label>
                            <input type="text" class="form-control" value="<%= Usuario.Apellidos %>" disabled="disabled" />
                        </div>

                        <div class="form-group">
                            <label>R.P.E.</label>
                            <input type="text" class="form-control" value="<%= Usuario.Codigo %>" disabled="disabled" />
                        </div>

                        <div class="form-group">
                            <label>Correo electrónico</label>
                            <input type="text" class="form-control" value="<%= Usuario.Correo %>" disabled="disabled" />
                        </div>

                        <div class="form-group">
                            <label>Rol</label>
                            <input type="text" class="form-control" value="<%= Usuario.Rol.Nombre %>" disabled="disabled" />
                        </div>

                    </form>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-md-6">
            <div class="box box-success">
                <div class="box-header">
                    <h3 class="box-title">Actualizar contraseña</h3>
                </div>
                <div class="box-body">
                    <form runat="server" role="form">
                        <div class="form-group">
                            <label>Contraseña actual</label>
                            <asp:TextBox ID="txtActual" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Nueva contraseña</label>
                            <asp:TextBox ID="txtNueva" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Confirmar contraseña</label>
                            <asp:TextBox ID="txtConfirmar" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                        </div>

                        <asp:LinkButton ID="btnActualizarPassword" runat="server" CssClass="btn btn-primary">
                        <span class="fa fa-save"></span>
                        Guardar cambios
                        </asp:LinkButton>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
