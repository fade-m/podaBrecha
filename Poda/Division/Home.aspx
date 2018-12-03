<%@ Page Language="C#" MasterPageFile="~/Master/Division.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PodaProject.Poda.Division.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <!-- date-range-picker -->

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotificaciones" runat="Server">
    <asp:Literal ID="litListaNotificaciones" runat="server">
    </asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="Server">
    <asp:Literal ID="litMenu" runat="server">
    </asp:Literal>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphFila1" runat="Server">
<section class="content">
        <asp:Literal ID="litMensajes" runat="server"></asp:Literal>
        <asp:Literal ID="litTabla" runat="server"></asp:Literal>
    </section>





<div class="form-group">
<label>Date range:</label>
<div class="input-group">
    <div class="input-group-addon">
    <i class="fa fa-calendar"></i>
    </div>
    <input type="text" class="form-control pull-right" id="reservation"/>
</div><!-- /.input group -->
</div>


<%--semaforo--%>


<div class=" col-lg-1 col-md-1  col-sm-1 col-xs-1">




<li class="dropdown user user-menu">
<a href="#" class="dropdown-toggle" data-toggle="dropdown">
    <button  style=" background-color:Blue; width:25px; height:25px; border-radius:250px;"> </button>
</a>
<ul class="dropdown-menu">
    <li class="user-header">
    <p>
        Alexander Pierce - Web Developer
        <small>Member since Nov. 2012</small>
    </p>
    </li>
</ul>
</li>




</div>
<br />
<br />
<br />

<div class="row">

<asp:Literal ID="litSemaforo" runat="server"></asp:Literal>
   </div>                 






<br />
<br />
<br />

<div class="col-lg-2">
    <asp:Literal ID="litBarras" runat="server"></asp:Literal>
</div>



</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTabHogar" runat="Server">

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="cphTabConfiguracion" runat="Server">

</asp:Content>


<asp:Content ID="Content9" ContentPlaceHolderID="cphScriptFinales" runat="Server">
</asp:Content>

