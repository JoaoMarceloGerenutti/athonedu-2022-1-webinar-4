<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="View-Users.aspx.cs" Inherits="Xispirito.View.AdminOptions.Admin_Options" %>
<asp:Content ID="HeaderFooter" ContentPlaceHolderID="HeaderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Eventos - Xispirito </title>

        <link rel="stylesheet" href="View-Users.css" />
        <link rel="stylesheet" href="print.css" media="print" />

    </head>
    <body>
        <section class="users-list">
            <h3 style="text-align: center; color: white;">Lista de Palestrantes</h3>
            <div class="create-speaker">
                <input type="text" class="users-filter-input" placeholder="Pesquisar Palestrantes" />
                <button class="create-speaker-button">Cadastrar Palestrante</button>
            </div>
            <table class="users-list-table">
                <tr>
                    <th>Nome</th>
                    <th>Email</th>
                    <th>Profissão</th>
                    <th>Ações</th>
                </tr>
                <tr>
                    <td>Vinícius Martins Granso</td>
                    <td>viniciusmartinsg@hotmail.com</td>
                    <td>Faz programa 😏</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>João Marcelo Gerenutti</td>
                    <td>joaozinhogamer721@stackoverflow.macoratti.com</td>
                    <td>Faz programa com C#</td>
                    <td>
                        <div class="buttons-actions">
                            <button class="button-edit">Editar</button>
                            <button class="button-delete">Excluir</button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>Mathias Matheus Alves de Souza</td>
                    <td>mathiasmatheuszinho2002</td>
                    <td>Maninho que da drop na tabela de usuários na prod</td>
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
