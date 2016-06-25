<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaHistoriaClinica.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaHistoriaClinica" %>

<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <%--Validaciones JS--%>

        <script type="text/javascript">

            function validarFormulario() {

                var txtPrimeraRevision = document.getElementById("<%=txtPrimeraRevision.ClientID%>");
                
                if (txtPrimeraRevision.value == "") {

                    swal("Todos los datos son requeridos");
                    return false;

                } else { return true; }
                
            }

         </script>
        <title>Veterinaria - Alta Historia Clinica</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta Historia Clinica</h1>

        <div class="form-group">
            <asp:Label ID="lblListaSocios" runat="server" Text="Socios"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLSocios" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSocio_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMascotasSocio" runat="server" Text="Mascotas"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLMascotasSocio" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMascotas_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de Ingreso"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Calendar ID="txtFechaIngreso" runat="server"></asp:Calendar>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPrimeraRevision" runat="server" Text="Primera Revision"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPrimeraRevision" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblVeterinario" runat="server" Text="Primer Veterinario"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPrimerVeterinario" runat="server" disabled CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnHistoriaClinica" runat="server" Text="Ingresar Historia Clinica" class="btn btn-primary" OnClientClick="return validarFormulario();" OnClick="btnHistoriaClinica_Click"/>
        </div>

        <div class="form-group">
             <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

