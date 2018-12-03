<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PodaProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <title>
        <asp:Literal ID="litNombreSistema" runat="server"></asp:Literal></title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />

    <link href="~/bootstrap/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap/fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap/plugins/iCheck/square/blue.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
        <script src="bootstrap/Scripts/html5shiv.js"></script>
        <script src="bootstrap/Scripts/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-page">
    <form id="form2" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <div class=" col-lg-12">
                    <img width="60" height="60" src="images/oficial/logo.png" alt="logotipo" />
                </div>
                <p>
                    Sistema de Control de Brecha y Poda
                </p>
            </div>
            <div class="login-box-body">
                <p class="login-box-msg">Ingrese sus datos para acceder.</p>

                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtCorreo" class="form-control" placeholder="Correo" runat="server" MaxLength="30"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    <asp:RequiredFieldValidator ID="ValCorreo" runat="server"
                        ErrorMessage="El campo de correo no puede estar vacío"
                        ControlToValidate="txtCorreo"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValCorreoRegex" runat="server"
                        ErrorMessage="El correo debe tener la siguiente estructura: usuario@dominio.com"
                        ControlToValidate="txtCorreo"
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtPassword" class="form-control" placeholder="Contraseña" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    <asp:RequiredFieldValidator ID="ValPassword" runat="server"
                        ErrorMessage="El campo de contraseña no puede estar vacía"
                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
                <div class="row">
                    <div class="col-xs-4">
                        <asp:Button ID="btnIngresar" class="btn btn-primary btn-block btn-flat" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </div>
                </div>
                <a href="OlvidePassword.aspx">Olvide mi contraseña</a><br />
                <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
            </div>
        </div>
    </form>

    <script src="bootstrap/plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <script src="bootstrap/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
