<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="VerHistoriaClinica.aspx.cs" Inherits="VeterinariaWebApp.VerHistoriaClinica" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <title>Veterinaria - Historia Mascota</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Historia Mascota</h1>

        <asp:Panel ID="panelSocio" runat="server" Visible="false">
            <asp:Label ID="lblSocio" runat="server" Text="Label"></asp:Label>
        </asp:Panel>

        <asp:Panel ID="panelFull" runat="server" Visible="false">
            <div class="form-group">
                <asp:Label ID="lblSocios" runat="server" Text="Socios"></asp:Label>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="DDLSocios" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSocio_SelectedIndexChangedCuadro" AutoPostBack="True"></asp:DropDownList>
            </div>
        </asp:Panel>

        <div class="form-group">
            <asp:Label ID="lblMascotasSocio" runat="server" Text="Mascotas"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLMascotasSocio" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnEnviar" runat="server" Text="Ver Todos los Cuadros" class="btn btn-primary" OnClick="btnEnviar_Click"  />
        </div>

        <div class="form-group">
            <asp:DropDownList ID="DDLlistaCuadroClinico" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Button ID="btnVerAcciones" runat="server" Text="Ver Acciones" class="btn btn-primary" OnClick="btnAcciones_Click"  />
        </div>
        
        <div class="form-group">
            <asp:ListBox ID="txtlistAcciones" runat="server"></asp:ListBox>
        </div>

        <asp:Panel ID="panelFinalizado" runat="server" Visible="false">
            <div class="form-group">
                <asp:Label ID="lblFinalizado" runat="server" Text="Motivo de Finalizacion"></asp:Label>
                <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </asp:Panel>

        <div class="form-group">
             <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

