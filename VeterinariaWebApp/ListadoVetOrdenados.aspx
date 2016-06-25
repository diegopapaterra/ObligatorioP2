<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="ListadoVetOrdenados.aspx.cs" Inherits="VeterinariaWebApp.ListadoVetOrdenados" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Listado Veterinarios Ordenados</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listado-container">
        <h1>Listado de Veterinarios Ordenados</h1>
        <p class="align-center">Orden descendente por cantidad de cuadros clinicos en los que participa</p>
        <div class="form-group">
            <asp:ListBox ID="listVeterinario" runat="server"></asp:ListBox>
        </div>
    </div>
</asp:Content>