<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Xispirito.View.Login.Login" %>

<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Home - Xispirito </title>

        <link rel="stylesheet" href="Login.css" />
        <link rel="stylesheet" href="responsive.css" media="screen and (max-width: 768px)" />

        <meta name="viewport" content="width=device-width, initial-scale=1.0" />

        <link rel="stylesheet" href="print.css" media="print" />
    </head>
    <body>
        <section class="login">
            <div class="login-title">
                <h3>Login</h3>
            </div>
            <div class="login-form-group">
                <div>
                    <label for="senha">Email:</label>
                    <input class="login-input-button" type="text" id="email" />
                </div>
                <div>
                    <label for="senha">Senha</label>
                    <input class="login-input-button" type="text" id="senha" />
                </div>
                <div class="login-sign">
                    <a href="#"><b>Cadastre-se aqui!</b></a>
                </div>
                <button class="login-input-button-enter" onclick="">Entrar</button>
            </div>
        </section>
    </body>
    </html>

</asp:Content>
