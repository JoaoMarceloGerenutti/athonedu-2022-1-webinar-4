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
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage1" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent1" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent1" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent1" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage2" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent2" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent2" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent2" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage3" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent3" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent3" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent3" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage4" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent4" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent4" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent4" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage5" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent5" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent5" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent5" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage6" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent6" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent6" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent6" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage7" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent7" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent7" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent7" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage8" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent8" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent8" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent8" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage9" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent9" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent9" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent9" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="swiper-slide">
                                    <div class="card">
                                        <div class="image">
                                            <asp:Image ID="UpcomingEventImage10" runat="server" AlternateText="Imagem não encontrada" />
                                        </div>
                                        <div class="content">
                                            <asp:Label ID="TitleUpcomingEvent10" runat="server" class="title text--medium"> </asp:Label>

                                            <div class="info">
                                                <asp:Label ID="TypeUpcomingEvent10" runat="server" class="type text--medium"></asp:Label>
                                                <asp:Label ID="TimeUpcomingEvent10" runat="server" class="time text--medium"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="swiper-button-prev"></div>
                            <div class="swiper-button-next"></div>
                        </div>
                    </div>
                </section>

                <script>
                    var swiper = new Swiper('.swiper', {
                        slidesPerView: 4,
                        spaceBetween: 20,
                        slidesPerGroup: 1,
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
