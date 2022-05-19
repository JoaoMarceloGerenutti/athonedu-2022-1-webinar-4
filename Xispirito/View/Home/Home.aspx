<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Xispirito.View.HomeWithMaster.Home" %>

<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Home - Xispirito </title>

        <link rel="stylesheet" href="Home-responsive.css" media="screen and (max-width: 630px)" />
        <link rel="stylesheet" href="Home-style.css" />
        <link rel="stylesheet" href="print.css" media="print" />
    </head>
    <body>
        <section class="hero">
            <div class="container">
                <div>
                    <h2>
                        <b>Cadastrar-se em um evento nunca foi tão simples.
                        </b>
                    </h2>
                    <p>
                        Uma poderosa ferramenta para organização de eventos. Ganhe TEMPO e aumente a PRODUTIVIDADE ao eliminar todo o trabalho manual.
                    </p>
                    <a href="../Events/Events.aspx" class="button">ENCONTRAR UM EVENTO DE GRAÇA</a>
                </div>
                <image src="/View/Images/Presentation.png"></image>
            </div>
        </section>

        <main>
            <section class="cards">
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage1" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent1" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent1" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent1" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage2" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent2" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent2" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent2" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage3" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent3" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent3" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent3" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage4" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent4" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent4" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent4" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage5" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent5" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent5" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent5" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="UpcomingEventImage6" runat="server" />
                    </div>
                    <div class="content">
                        <asp:Label ID="TitleUpcomingEvent6" runat="server" class="title text--medium"> </asp:Label>

                        <div class="info">
                            <asp:Label ID="TypeUpcomingEvent6" runat="server" class="type text--medium"></asp:Label>
                            <asp:Label ID="TimeUpcomingEvent6" runat="server" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </main>
    </body>
    </html>
</asp:Content>
