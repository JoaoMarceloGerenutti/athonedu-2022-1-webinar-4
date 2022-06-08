<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminOptions.aspx.cs" Inherits="Xispirito.View.AdminOptions.AdminOptions" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Opções de Administrador - Xispirito </title>

        <link rel="stylesheet" href="AdminOptions.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="admin-options">
            <h3 style="text-align: center; color: white;">Listagem de Opções do Administrador</h3>
            <div class="admin-options-list">
                <div class="admin-options-list-left">
                    <h3 style="text-align: center; color: white;">Listagem de Palestrantes</h3>
                    <div class="align-image">
                        <img src="https://www.kindpng.com/picc/m/173-1731325_person-icon-png-transparent-png.png" class="admin-options-image"/>
                    </div>
                </div>
                <div class="admin-options-list-right">
                    <h3 style="text-align: center; color: white;">Listagem de Palestras</h3>
                    <div class="align-image">
                        <img src="https://icon-library.com/images/video-icon-flat/video-icon-flat-2.jpg" class="admin-options-image"/>
                    </div>
                </div>
            </div>
        </section>
    </body>
    </html>
</asp:Content>
