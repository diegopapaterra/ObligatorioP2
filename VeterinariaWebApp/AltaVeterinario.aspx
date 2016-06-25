<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaVeterinario.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaVeterinario" %>

<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <%--Validaciones JS--%>

        <script type="text/javascript">

            function datosRequeridos() {

                var nroLicencia = document.getElementById("<%=txtLicencia.ClientID%>");
                var nombre = document.getElementById("<%=txtNombreVeterinario.ClientID%>");
                var fecha = document.getElementById("<%=txtFechaGraduacion.ClientID%>");
                var grado = document.getElementById("<%=txtGrado.ClientID%>");

                if (nroLicencia.value == "" || nombre.value == "" || fecha.value == "" || grado.value == "") {

                    swal("Todos los datos son obligatorios");

                    return false;

                } else {

                    return true;

                }
            }

        </script>
        <title>Veterinaria - Alta Veterinario</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta de Veterinario</h1>
        <p>Debe tener ingresado el Usuario primero</p>
        <div class="form-group">
            <asp:Label ID="lblLicencia" runat="server" Text="Número de Licencia"></asp:Label>
            <asp:TextBox ID="txtLicencia" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombreVeterinario" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreVeterinario" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFechaGraduacion" runat="server" Text="Fecha de Graduación"></asp:Label>
            <asp:Calendar ID="txtFechaGraduacion" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label ID="lblGrado" runat="server" Text="Grado"></asp:Label>
            <asp:TextBox ID="txtGrado" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAltaVeterinario" runat="server" Text="Guardar" OnClientClick="return datosRequeridos();" CssClass="btn btn-primary" OnClick="btnAltaVeterinario_Click" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblResultadoVeterinario" runat="server" Text=""></asp:Label>
        </div>
    </div>   

</asp:Content>