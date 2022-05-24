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

        <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css" />
        
        <!-- Bootstrap Start -->

            <!-- CSS only -->
            <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" 
            rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
        
            <!-- JavaScript Bundle with Popper -->
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

        <!-- Bootstrap End -->

        <script src="https://unpkg.com/swiper/swiper-bundle.js"></script>
        <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>
    </head>
    <body>
        <section class="profile">
            <div class="profile-label">
                <h3>Editar/Cadastrar Usuário</h3>
            </div>
            <div class="profile-form">
                <div class="profile-form-left">
                    <input class="input-text" id="name_speaker" placeholder="Informe o Nome" type="text"/>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="email_speaker" placeholder="Informe o E-mail"  type="text"/>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="profissao_speaker" placeholder="Informe a Profissão"  type="text"/>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="password_speaker" placeholder="Informe a Senha"  type="password"/>
                </div>
                <div class="profile-form-pic-speaker" shape="round">
                    <img id="speaker-photo"/>
                </div>
                <div class="profile-form-set-photo-button">
                    <button class="btn btn-primary fs-4">
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
                <button class=" px-5 py-2 btn btn-success fs-4" value="submitButton">
                    Enviar
                </button>
            </div>
        </section>
    </body>
</html>
</asp:Content>
