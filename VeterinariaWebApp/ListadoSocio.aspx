<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSocio.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.WebForm1" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Listado Socio</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listado-container">
        <h1>Listado de Socios</h1>
        <div class="form-group">
            <asp:ListBox ID="listCliente" runat="server" OnSelectedIndexChanged="listCliente_SelectedIndexChanged"></asp:ListBox>
        </div>
    </div>
</asp:Content>


