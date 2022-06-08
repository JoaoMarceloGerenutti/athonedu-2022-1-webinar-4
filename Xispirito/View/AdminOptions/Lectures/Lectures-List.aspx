<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Lectures-List.aspx.cs" Inherits="Xispirito.View.AdminOptions.Lectures.Lectures_List" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="Lectures-List.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="lectures-list">
            <h3 style="text-align: center; color: white;">Lista de Palestras</h3>
            <div class="create-lecture">
                <input type="text" class="lectures-filter-input" placeholder="Pesquisar Palestras" />
                <button class="create-lecture-button">Cadastrar Palestra</button>
            </div>
            <table class="lectures-list-table">
                <tr>
                    <th>Nome</th>
                    <th>Data</th>
                    <th>Modalidade</th>
                    <th>Ações</th>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>35º Congresso Odontológico de Bauru</td>
                    <td>07/09/2022</td>
                    <td>Presencial</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
            </table>
        </section>
    </body>
    </html>
</asp:Content>
