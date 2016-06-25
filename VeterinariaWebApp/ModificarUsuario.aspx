<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.ModificarUsuario" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Modificar Usuario</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Modificar Usuario</h1>
        <div class="form-group">
            <asp:Label ID="lblListaUsuario" runat="server" Text="Usuarios"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLUsuarios" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary" OnClick="btnModificar_Click" />
        </div>
    </div>
</asp:Content>

