<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Create-Speaker.aspx.cs" Inherits="Xispirito.View.AdminOptions.Users.Create_User.Create_Speaker" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Create-Speaker.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="create-speaker-admin">
            <h3 style="text-align: center; color: white; font-size: 3rem; font-weight: bold;">Cadastrar Informações Básicas do Palestrante</h3>
            <div style="width: 75%">
                <div class="back-button-inline">
                    <asp:ImageButton ID="Return" runat="server" CssClass="back-button" ImageUrl="~/View/Images/Return.png" PostBackUrl="~/View/AdminOptions/Users/View-Users.aspx" />
                </div>
            </div>
            <div style="width: 100%; padding-top: 5rem;">
                <div class="speaker-inputs-admin">
                    <input type="text" class="input-text" placeholder="Informe o email do Palestrante"/>
                    <button class="create-password">Gerar Senha</button>
                </div>
            </div>
        </section>
    </body>
    </html>
</asp:Content>
