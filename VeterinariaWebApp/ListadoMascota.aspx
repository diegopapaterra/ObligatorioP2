<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMascota.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.ListadoMascota" %>

<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Listado de Mascotas</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <div class="listado-container">
         <h1>Listado de Mascotas</h1>

    <div class="form-group">
            <asp:DropDownList ID="DDLSocios" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>    
        </div>
        <div class="form-group">
            <asp:Button ID="btnBuscarMascota" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarMascota_Click" />
        </div>
        <div class="form-group">
            <asp:ListBox ID="listMascota" runat="server"></asp:ListBox>
        </div>
        <div class="form-group">
            <asp:Label ID="resultadoListMascota" runat="server" Text=""></asp:Label>
        </div>        
    </div>
   
</asp:Content>
