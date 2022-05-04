<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Xispirito.View.Home.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Home - Xispirito </title>

    <link rel="stylesheet" href="Home-style.css" />
    <link rel="stylesheet" href="responsive.css" media="screen and (max-width: 768px)" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="print.css" media="print" />
</head>
<body>
    <form id="frmHome" runat="server">
        <header>
            <div class="container">
                <nav>
                    <ul>
                        <li>
                            <img src="\View\Images\Xispirito.png" alt="Xispirito" />
                        </li>
                        <li class="logo">
                            <a href="#"><b>Xispirito</b></a>
                        </li>
                        <li class="athon">
                            <a href="https://athonedu.com.br">Powered by Athon</a>
                        </li>
                    </ul>
                </nav>
                <div class="menu-section">
                    <div class="menu-toggle">
                        <div class="one"></div>
                        <div class="two"></div>
                        <div class="three"></div>
                    </div>
                    <nav>
                        <ul>
                            <li>
                                <a href="#">Ajuda</a>
                            </li>
                            <li>
                                <a href="#" class="two">Econtrar Palestra</a>
                            </li>
                            <li>
                                <a href="#" class="three">Login</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
        </header>
        <section class="hero">
            <div class="container">
                <div>
                    <h2>
                        <b>
                            Cadastrar-se em um evento nunca foi tão simples.
                        </b>
                    </h2>
                    <p>
                        Uma poderosa ferramenta para organização de eventos. Ganhe TEMPO e aumente a PRODUTIVIDADE ao eliminar todo o trabalho manual.
                    </p>
                    <a href="~" class="button">ENCONTRAR UM EVENTO DE GRAÇA</a>
                </div>
                <img
                    src="\View\Images\Presentation.png"
                    alt="" style="max-width: 40%;" />
            </div>
        </section>

        <main>
            <section class="cards">
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage1" runat="server"/>
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
                        <asp:Image ID="CardImage2" runat="server"/>
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Palestra 2
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento2" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento2" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage3" runat="server"/>
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Palestra 3
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento3" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento3" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage4" runat="server"/>
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Palestra 4
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento4" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento4" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage5" runat="server"/>
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Palestra 5
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento5" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento5" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage6" runat="server"/>
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Palestra 6
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento6" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento6" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </main>

        <section id="form">
            <div class="form-group">
                <nav>
                    <ul>
                        <li>
                            <p class="text--medium">
                                Sobre Nós
                            </p>
                        </li>
                        <li>
                            <p class="text--medium">
                                Somos uma empresa de tecnologia a desenvolvimento de software.
                            </p>
                        </li>
                        <li>
                            <p class="text--medium">
                                Para suporte e assistência, entre em contato conosco atáves do e-mail:
                            </p>
                        </li>
                        <li>
                            <p class="text--medium">
                                suporte@xispirito.com.br
                            </p>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="form-group">
                <p class="text--medium">
                    TESTE !@34124124123123
                </p>
            </div>
        </section>
    </form>

    <div class="modal-overlay">
            <div class="modal">
                <a class="close-modal">
                    <svg viewBox="0 0 20 20">
                        <path
                            fill="#000000"
                            d="M15.898,4.045c-0.271-0.272-0.713-0.272-0.986,0l-4.71,4.711L5.493,4.045c-0.272-0.272-0.714-0.272-0.986,0s-0.272,0.714,0,0.986l4.709,4.711l-4.71,4.711c-0.272,0.271-0.272,0.713,0,0.986c0.136,0.136,0.314,0.203,0.492,0.203c0.179,0,0.357-0.067,0.493-0.203l4.711-4.711l4.71,4.711c0.137,0.136,0.314,0.203,0.494,0.203c0.178,0,0.355-0.067,0.492-0.203c0.273-0.273,0.273-0.715,0-0.986l-4.711-4.711l4.711-4.711C16.172,4.759,16.172,4.317,15.898,4.045z">
                        </path>
                    </svg>
                </a>
                <div class="modal-content">
                    <div class="video-background">
                        <div class="video-foreground">
                            <iframe src="" frameborder="0" allowfullscreen=""></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="scripts.js"></script>
        <script src="menu.js"></script>
</body>
</html>
