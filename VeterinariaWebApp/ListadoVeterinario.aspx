<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoVeterinario.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.WebForm2" %>

<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Listado Veterinario</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listado-container">
        <h1>Listado de Veterinarios</h1>
        <div class="form-group">
            <asp:ListBox ID="listVeterinario" runat="server"></asp:ListBox>
        </div>
    </div>
</asp:Content>