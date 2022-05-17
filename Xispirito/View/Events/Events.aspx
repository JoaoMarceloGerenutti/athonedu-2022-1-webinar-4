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

        <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css" />
        <script src="https://unpkg.com/swiper/swiper-bundle.js"></script>
        <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>
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
                <div class="event-form">
                    <div class="event-div-first-line">
                        <div class="event-div-first-line-search">
                            <input class="event-input-first-line-search-input" type="text" placeholder="Pesquisar por eventos" />
                        </div>
                        <div class="event-div-first-line-button">
                            <input class="event-input-first-line-search-button" type="button" placeholder="Botão" />
                        </div>
                    </div>
                    <div class="event-div-second-line">
                        <div class="event-div-second-line-search">
                            <input class="event-input-second-line-search-input" type="text" placeholder="Pesquisar por eventos" />
                        </div>
                        <div class="event-div-second-line-button">
                            <input class="event-input-second-line-search-button" type="button" placeholder="Botão" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="events-list">
                <div class="events-list-title">
                    <h3 class="events-list-title-h3">Próximos Eventos</h3>
                </div>
                <section class="section">
                    <div class="recent-carousel">
                        <div class="swiper">
                            <div class="swiper-wrapper">
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded1" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded1" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded2" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded2" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded3" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded3" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded4" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded4" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded5" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded5" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded6" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded6" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded7" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded7" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded8" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded8" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded9" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded9" runat="server" CssClass="name"></asp:Label>
                                </div>
                                <div class="swiper-slide">
                                    <asp:ImageButton ID="ImageRecentlyAdded10" AlternateText="Não Encontrado" runat="server" />
                                    <asp:Label ID="lblRecentlyAdded10" runat="server" CssClass="name"></asp:Label>
                                </div>
                            </div>
                            <div class="swiper-button-prev"></div>
                            <div class="swiper-button-next"></div>
                        </div>
                    </div>
                </section>

                <script>
                    var swiper = new Swiper('.swiper', {
                        slidesPerView: 6,
                        spaceBetween: 60,
                        slidesPerGroup: 2,
                        loop: true,
                        loopFillGroupWithBlank: true,
                        pagination: {
                            el: '.swiper-pagination',
                            clickable: true,
                        },
                        navigation: {
                            nextE1: '.swiper-button-next',
                            prevE1: '.swiper-button-prev',
                        }
                    });
                </script>
            </div>
        </section>
    </body>
    </html>
</asp:Content>
