<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Necesidades.aspx.cs"
    Inherits="PodaProject.App.Zona.Necesidades" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../../bootstrap/plugins/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="cabecera" runat="server">
    Necesidades
</asp:Content>

<asp:Content ContentPlaceHolderID="descripcion" runat="server">
    de brecha y poda
</asp:Content>

<asp:Content ContentPlaceHolderID="contenido" runat="server">

    <form id="form1" runat="server">

        <div class="box box-danger">
            <div class="box-body">
                <div class="form-group">
                    <label>Ejercicio</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-file-text-o"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="periodoActual" Enabled="false"></asp:TextBox>
                    </div>

                </div>
                <div class="form-group">
                    <label>Presupuesto asignado por la division</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="presupuestoDivision" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label>Necesidad total de las areas</label>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                        <asp:TextBox runat="server" CssClass="form-control" ID="necesidadTotal" Enabled="false"></asp:TextBox>
                    </div>
                </div>

            </div> <!--box body -->
        </div> <!--box -->


        <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">Necesidades de las áreas</h3>
            </div>
            <div class="box-body">
                <table id="zonas" class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Área</th>
                            <th>Necesidad del area</th>
                            <th>Ver detalles</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal runat="server" ID="litTBody"></asp:Literal>
                    </tbody>
                </table>


            </div>



        </div>
    </form>




</asp:Content>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
</asp:Content>

