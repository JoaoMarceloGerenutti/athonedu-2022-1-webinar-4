<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Lecture-CRUD.aspx.cs" Inherits="Xispirito.View.Lectures.CRUD.Lecture_CRUD" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Lecture-CRUD.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="lecture">
            <div class="lecture-label">
                <asp:Label ID="ActionLecture" runat="server" class="lecture-action">Criar Palestra</asp:Label>
            </div>
            <div class="lecture-form">
                <div class="lecture-form-left">
                    <asp:TextBox ID="NameLecture" runat="server" class="input-text" placeholder="Informe o Nome" />
                </div>
                <div class="lecture-form-description">
                    <asp:TextBox ID="DescriptionLecture" runat="server" TextMode="MultiLine" class="input-text" rows="7" placeholder="Informe a Descrição" />
                </div>
                <div class="lecture-form-left">
                    <asp:TextBox ID="DateLecture" runat="server" class="input-text" placeholder="Informe a Data" />
                </div>
                <div class="lecture-form-left">
                    <h3 style="color: white;">Tempo da Palestra</h3>
                    <div class="centralize-time">
                        <h5>Início</h5>
                        <h5>Fim</h5>
                    </div>
                </div>
                <div class="lecture-form-left">
                    <div class="lecture-date-display">
                        <div class="lecture-date">
                            <input type="time" class="lecture-date-input" value="startLecture" />
                        </div>
                        <div class="lecture-date">
                            <input type="time" class="lecture-date-input" value="endLecture" />
                        </div>
                    </div>
                </div>
                <div class="lecture-address-input">
                    <asp:TextBox ID="AddressLecture" runat="server" class="input-text" placeholder="Informe o Endereço" />
                </div>
                <div class="lecture-form-left">
                    <asp:TextBox ID="LimitLecture" runat="server" class="input-text" placeholder="Informe o Limite de pessoas" />
                </div>
                <div class="lecture-form-pic" shape="round">
                    <asp:Image ID="ImageLecture" runat="server" CssClass="lecture-picture"/>
                </div>
                <div class="lecture-form-left">
                    <div class="lecture-modality">
                        <h3 style="color: white;">Informe a Modalidade</h3>
                        <select class="input-text">
                            <option value="presencial">Presencial</option>
                            <option value="online">Online</option>
                            <option value="Hibrido">Hibrido</option>
                        </select>
                    </div>
                </div>
                <div class="lecture-form-set-photo-button">
                    <button class="chose-photo">
                        Anexar uma foto
                    </button>
                </div>
                <div class="lecture-form-retire-photo-button">
                    <button class="delete-photo">
                        Remover foto
                    </button>
                </div>
            </div>
            <div class="lecture-form-submit">
                <button class="submit-button" value="submitButton">
                    Salvar
                </button>
            </div>
        </section>
    </body>
</html>
</asp:Content>
