<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WatchLecture.aspx.cs" Inherits="Xispirito.View.Lectures.ViewLectures.WatchLecture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Assistir Palestra - Xispirito</title>

    <link rel="stylesheet" href="WatchLecture.css" />
</head>
<body>
    <form id="frmWatchLecture" runat="server">
        <section class="lecture-view">
            <div class="action">
                <div class="lecture-view-button" onclick="menuToggle();">
                    <asp:ImageButton ID="Menu" runat="server" CssClass="lecture-view-button-options" ImageUrl="~/View/Images/Menu.png" />
                </div>
                <div class="menu">

                </div>
            </div>

            <%--<h3 style="text-align: center; color: white;">Assistir Palestra</h3>
            <div class="back-button-line">
                <button class="back-button">Sair da Palestra</button>
            </div>--%>

            <div class="lecture-view-iframe">
                <iframe #iframe src="https://www.youtube.com/embed/6Qq2OMFh8Pc" width="100%" height="100%" allowfullscreen></iframe>
            </div>
        </section>

        <script>
            function menuToggle() {
                const toggleMenu = document.querySelector('.menu');
                toggleMenu.classList.toggle('active');
            }
        </script>
    </form>
</body>
</html>
