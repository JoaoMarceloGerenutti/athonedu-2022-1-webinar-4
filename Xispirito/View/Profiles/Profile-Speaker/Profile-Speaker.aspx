﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile-Speaker.aspx.cs" Inherits="Xispirito.View.Profiles.Profile_Speaker.Profile_Speaker" %>
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

    </head>
    <body>
        <section class="profile">
            <div class="profile-label">
                <h3 style="color: white;">Editar Perfil de Palestrante</h3>
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
                    <h4 style="color: white;">Informe a senha:</h4>
                </div>
                <div class="profile-form-left">
                    <input class="input-text" id="password_speaker" placeholder="Informe a Senha"  type="password"/>
                </div>
                <div class="profile-form-left">
                    <asp:TextBox ID="RepeatPasswordSpeaker" runat="server" class="input-text" placeholder="Informe a Senha Novamente" TextMode="Password" />
                </div>
                <div class="profile-form-pic-speaker" shape="round">
                    <asp:Image ID="ImageSpeaker" runat="server" />
                </div>
                <div class="profile-form-set-photo-button">
                    <button class="chose-photo">
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
                <button class="submit-button" value="submitButton">
                    Salvar
                </button>
            </div>
        </section>
    </body>
</html>
</asp:Content>
