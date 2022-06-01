<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="Xispirito.View.Profile_Viewer.Profile_Viewer" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Viewer.css" />
        <link rel="stylesheet" href="print.css" media="print" />
    </head>
    <body>
        <section class="profile">
            <div class="profile-label">
                <h3 style="color: white;">Editar Perfil do Aluno</h3>
            </div>
            <div class="profile-form">
                <div class="profile-form-left">
                    <h4 style="color: white;">Informações da sua Conta:</h4>
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="NameViewer" runat="server" class="input-text" placeholder="Informe o Nome" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="EmailViewer" runat="server" class="input-text" placeholder="Informe o E-mail" ReadOnly="True" />
                </div>
                <div class="profile-form-left">
                    <h4 style="color: white;">Alterar a Senha:</h4>
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="PasswordViewer" runat="server" class="input-text" placeholder="Informe a Senha" TextMode="Password" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="RepeatPasswordViewer" runat="server" class="input-text" placeholder="Informe a Senha Novamente" TextMode="Password" />
                </div>
                <div class="profile-form-pic-viewer" shape="round">
                    <asp:Image ID="ImageViewer" runat="server" CssClass="profile-picture"/>
                </div>
                <div class="profile-form-set-photo-button">
                    <button class="chose-photo btn btn-primary fs-4">
                        Anexar uma foto
                    </button>
                </div>
                <div class="profile-form-retire-photo-button">
                    <button class="delete-photo">
                        Remover foto
                    </button>
                </div>
            </div>
            <div class="profile-form-submit">
                <button class="submit-button px-5 py-2 btn btn-success fs-4" value="submitButton">
                    Salvar
                </button>
            </div>
        </section>
    </body>
</html>
</asp:Content>
