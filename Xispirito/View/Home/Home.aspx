<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Xispirito.View.HomeWithMaster.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home - Xispirito </title>

    <link rel="stylesheet" href="Home-style.css" />
    <link rel="stylesheet" href="responsive.css" media="screen and (max-width: 768px)" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

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
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage4" runat="server" />
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            Encontro Holístico - Passo Fundo
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento4" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento4" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage5" runat="server" />
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            VIII Congresso de Gestalt-terapia do Estado de Rio de Janeiro
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento5" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento5" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="image">
                        <asp:Image ID="CardImage6" runat="server" />
                    </div>
                    <div class="content">
                        <p class="title text--medium">
                            35º Congresso Odontológico de Bauru
                        </p>
                        <div class="info">
                            <asp:Label ID="lblTipoEvento6" runat="server" Text="Evento Online" class="type text--medium"></asp:Label>
                            <asp:Label ID="lblTempoEvento6" runat="server" Text="00 Min" class="time text--medium"></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </main>
        <section id="footer">
                <div class="form-group">
                    <div class="left-footer">
                        <p class="text--medium">
                            Sobre Nós
                            <br />
                            Somos uma empresa de tecnologia a desenvolvimento de software.
                            <br />
                            Para suporte e assistência, entre em contato conosco atáves do e-mail:
                            <br />
                            suporte@xispirito.com.br
                        </p>
                    </div>
                    <div class="line">
                    </div>
                    <div class="right-footer">
                        <p class="text--medium">
                            Ajuda
                        </p>

                        <p class="text--medium">
                            Fazer Cadastro
                        </p>

                        <p class="text--medium">
                            Encontrar um Evento
                        </p>

                        <p class="text--medium">
                            Certificados
                        </p>
                    </div>
                </div>
            </section>
        </body>
    </html>
</asp:Content>
