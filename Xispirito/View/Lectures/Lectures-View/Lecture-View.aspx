﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Lecture-View.aspx.cs" Inherits="Xispirito.View.Lectures.Lectures_View.Lecture_View" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Lecture-View.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="lecture-view">
            <div class="lecture-view-button">
                <button class="lecture-view-button-options">__<br />__<br />__</button>
            </div>
            
            <h3 style="text-align: center; color: white;">Assistir Palestra</h3>

            <div class="lecture-view-iframe">
                <iframe #iframe src="https://www.youtube.com/embed/6Qq2OMFh8Pc" width="100%" height="100%" allowfullscreen></iframe>
            </div>
        </section>
    </body>
    </html>
</asp:Content>
