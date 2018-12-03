<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidePassword.aspx.cs" Inherits="PodaProject.OlvidePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <title>Olvidé mi contraseña
    </title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />

    <link href="~/bootstrap/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap/fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="~/bootstrap/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />

</head>
<body class="login-page">
    <div class="row">
        <div class="lockscreen-wrapper">
            <img class="center-block" src="images/oficial/logo.png" width="40" height="40" />
            <div class="lockscreen-logo">

                <a href="Login.aspx"><b>Sistema de control de Brecha y Poda</b></a>
            </div>
            <br />
            <div class="lockscreen-item">
                <div class="lockscreen-image">
                    <img src="images/iconos/X.png" alt="user image" />
                </div>

                <form class="lockscreen-credentials" runat="server">
                    <div class="input-group">
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" MaxLength="30" Width="220px"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:ImageButton ID="btnEnviar" runat="server" CssClass="btn" ImageUrl="images/iconos/flecha.png"
                                OnClick="btnEnviar_Click" />
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="ValCorreo" runat="server"
                        ControlToValidate="txtCorreo"
                        ErrorMessage="El correo no puede estar vacío"
                        Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="ValCorreoRegex" runat="server"
                        ControlToValidate="txtCorreo"
                        ErrorMessage="El correo debe tener la siguiente estructura: usuario@dominio.com"
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                        Display="Dynamic" />
                </form>
            </div>
            <div class="help-block text-center">
                Ingresa el correo registrado en donde se enviará la contraseña
            </div>
            <div class="text-center">
                <a class="btn btn-social-icon btn-bitbucket" href="Login.aspx">
                    <i class="fa fa-reply"></i>
                </a>
            </div>

            <div class="text-center">
                <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
            </div>

        </div>
    </div>

    <script src="bootstrap/plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <script src="bootstrap/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
