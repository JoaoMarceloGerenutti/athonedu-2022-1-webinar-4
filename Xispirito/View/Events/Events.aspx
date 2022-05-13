<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Xispirito.View.Events.Events" %>

<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Events.css" />
        <link rel="stylesheet" href="print.css" media="print" />
    </head>
    <body>
        <section class="events-header">
            <div class="events-h1">
                <h1>Gerencie eventos</h1>
            </div>
            <div class="events-h3">
                <h3>Confira os eventos que vão ocorrer na Athon Descubra eventos de seu interesse ou crie os seus próprios utilizando a Xispirito
                </h3>
            </div>
        </section>
        <section class="events find-events">
            <div class="event-form-body">
                <form class="event-form">
                    <div class="event-div-first-line">
                        <div class="event-div-first-line-search">
                            <input class="event-input-first-line-search-input" type="text" placeholder="Pesquisar por eventos"/>
                        </div>
                        <div class="event-div-first-line-button">
                            <input class="event-input-first-line-search-button" type="button" placeholder="Botão"/>
                        </div>
                    </div>
                    <div class="event-div-second-line">
                        <div class="event-div-second-line-search">
                            <input class="event-input-second-line-search-input" type="text" placeholder="Pesquisar por eventos"/>
                        </div>
                        <div class="event-div-second-line-button">
                            <input class="event-input-second-line-search-button" type="button" placeholder="Botão"/>
                        </div>
                    </div>
                </form>
            </div>
            <div class="events-list">
                <div class="events-list-title">
                    <h3 class="events-list-title-h3">Eventos em destaque</h3>
                </div>
                <section class="cards">
                    <div class="card">
                        <div class="image">
                            <asp:Image ID="CardImage1" runat="server" />
                        </div>
                        <div class="content">
                            <p class="title text--medium">
                                IPVS2022 - 26º International Pig Veterinary Society Congress
                            </p>
                            <div class="info">
                                <asp:Label ID="lblTipoEvento1" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                                <asp:Label ID="lblTempoEvento1" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage2" runat="server" />
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            XIV Encontro Nacional de Educação Matemática
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento2" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento2" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage3" runat="server" />
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            XIV CASI
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento3" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento3" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                </section>
            </div>
        </section>
    </body>
    </html>
</asp:Content>
