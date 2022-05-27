<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile-Speaker.aspx.cs" Inherits="Xispirito.View.Profile_Speaker.Profile_Speaker" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Profile-speaker.css" />
        <link rel="stylesheet" href="print.css" media="print" />

        <!-- Bootstrap Start -->

            <!-- CSS only -->
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" 
            rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
        
            <!-- JavaScript Bundle with Popper -->
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

        <!-- Bootstrap End -->
    </head>
    <body>
        <section class="profile">
            <div class="profile-label">
                <h3>Editar Perfil de Palestrante</h3>
            </div>
            <div class="profile-form">
                <div class="profile-form-left">
                    <asp:TextBox ID="NameSpeaker" runat="server" class="input-text" placeholder="Informe o Nome" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="EmailSpeaker" runat="server" class="input-text" placeholder="Informe o E-mail" ReadOnly="True" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="ProfissionSpeaker" runat="server" class="input-text" placeholder="Informe a Profissão" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="PasswordSpeaker" runat="server" class="input-text" placeholder="Informe a Senha" TextMode="Password" />
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="RepeatPasswordSpeaker" runat="server" class="input-text" placeholder="Informe a Senha Novamente" TextMode="Password" />
                </div>
                <div class="profile-form-pic-speaker" shape="round">
                    <asp:Image ID="ImageSpeaker" runat="server" />
                </div>
                <div class="profile-form-set-photo-button">
                    <button class="chose-photo btn btn-primary fs-4">
                        Anexar uma foto
                    </button>
                </div>
                <div class="profile-form-retire-photo-button">
                    <button class="btn btn-secondary fs-4">
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
