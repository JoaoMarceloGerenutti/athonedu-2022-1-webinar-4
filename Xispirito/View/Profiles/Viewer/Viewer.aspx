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
                <h3 style="color: white;">Editar/Cadastrar Usuário</h3>
            </div>
            <div class="profile-form">
                <div class="profile-form-left">
                    <input class="input-text" id="name_viewer" placeholder="Informe o Nome" type="text"/>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="email_viewer" placeholder="Informe o E-mail"  type="text"/>
                </div>
                <div class="profile-form-left">
                    <h4 style="color: white;">Informe a senha:</h4>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="password_viewer" placeholder="Informe a Senha"  type="password"/>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="password_viewer_confirm" placeholder="Informe a Senha Novamente"  type="password"/>
                </div>
                <div class="profile-form-pic-viewer" shape="round">
                    <img id="viewer-photo"/>
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
                    Enviar
                </button>
            </div>
        </section>
    </body>
</html>
</asp:Content>
