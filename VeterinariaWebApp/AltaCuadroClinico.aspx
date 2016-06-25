<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaCuadroClinico.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaCuadroClinico" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <%--Validaciones JS--%>

        <script type="text/javascript">

            function datosRequeridos() {

                var txtMotivo = document.getElementById("<%=txtMotivo.ClientID%>");
                var txtDiagnostico = document.getElementById("<%=txtDiagnostico.ClientID%>");

                if (txtMotivo.value == "" || txtDiagnostico.value == "") {

                    swal("Todos los datos son obligatorios");

                    return false;

                } else {

                    return true;

                }
            }

        </script>
        <title>Veterinaria - Alta Cuadro Clinico</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta Cuadro Clinico</h1>
        <p>La Mascota ya debe estar ingresada en el sistema y poseer una Historia Clinica</p>

        <div class="form-group">
            <asp:Label ID="lblListaSocios" runat="server" Text="Socios"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLSocios" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSocio_SelectedIndexChangedCuadro" AutoPostBack="True"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMascotasSocio" runat="server" Text="Mascotas"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLMascotasSocio" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblFechaConsulta" runat="server" Text="Fecha de Consulta"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Calendar ID="txtFechaConsulta" runat="server"></asp:Calendar>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMotivo" runat="server" Text="Motivo"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblDiagnostico" runat="server" Text="Diagnostico"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtDiagnostico" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPosiblePatalogia" runat="server" Text="Patologia"></asp:Label>
        </div>
        <div class="form-group">
            <asp:DropDownList ID="DDLPosiblePatalogia" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblVeterinario" runat="server" Text="Primer Veterinario"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtVeterinario" runat="server" disabled CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnCuadroClinico" runat="server" Text="Ingresar Cuadro Clinico" class="btn btn-primary" OnClick="btnCuadroClinico_Click" OnClientClick="return datosRequeridos();" />
        </div>

        <div class="form-group">
             <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

