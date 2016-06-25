<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaSocio.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaSocio" %>

<asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">

      <%--Validaciones JS--%>

        <script type="text/javascript">

            function validarFormularioAltaSocio() {

                var cedula = document.getElementById("<%=txtCedulaSocio.ClientID%>");
                var nombreSocio = document.getElementById("<%=txtNombreSocio.ClientID%>");
                var direccionSocio = document.getElementById("<%=txtDirecSocio.ClientID%>");
                var mailSocio = document.getElementById("<%=txtMailSocio.ClientID%>").value;
                var personaContacto = document.getElementById("<%=txtPersonaContacto.ClientID%>");
                var telefonoSocio = document.getElementById("<%=txtTelSocio.ClientID%>");


                if (cedula.value == "" || nombreSocio.value == "" || direccionSocio.value == "" || mailSocio.value == "" || personaContacto.value == "" || telefonoSocio.value == "") {

                   
                    swal("Todos los datos son obligatorios");

                    return false;

                } else if ((cedula.value).length < 6 || (cedula.value).length > 8) {

                    swal("La cédula sebe ser un numero entre 6 y 8 caracteres");

                    return false;

                } else if (isNaN(cedula.value) || isNaN(telefonoSocio.value)) {

                    swal("Los datos cédula y teléfono deben ser numéricos");

                    return false;

                } else if (!isNaN(nombreSocio.value) || !isNaN(personaContacto.value)) {

                    swal("Los datos nombre y persona de contacto no pueden contener números");

                    return false;

                } else {

                    return true;

                }           
            }

        </script>


    <title>Veterinaria - Alta Socio</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta de Socio</h1>
        <p>Debe tener ingresado el Usuario primero</p>
        <div class="form-group">
            <asp:Label ID="lblCedulaSocio" runat="server" Text="Cédula"></asp:Label>
            <asp:TextBox ID="txtCedulaSocio" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombreSocio" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreSocio" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDirSocio" runat="server" Text="Dirección"></asp:Label>
            <asp:TextBox ID="txtDirecSocio" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMailSocio" runat="server" Text="E-mail"></asp:Label>
            <asp:TextBox ID="txtMailSocio" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTelefonoSocio" runat="server" Text="Teléfono"></asp:Label>
            <asp:TextBox ID="txtTelSocio" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:RadioButton ID="rbnRegular" Text="Socio Regular" runat="server" GroupName="Tipo" Checked="true" AutoPostBack="true" OnCheckedChanged="rbnRegular_CheckedChanged" />
            <asp:RadioButton ID="rbnProtectora" Text="Socio Protectora de Animales" runat="server" GroupName="Tipo" AutoPostBack="true" OnCheckedChanged="rbnProtectora_CheckedChanged" />
        </div>

        <div class="form-group">
            <asp:Panel ID="PanelRegular" runat="server" Visible="true">
                <asp:RadioButton ID="rbnEfectivo" Text="Efectivo" runat="server" GroupName="FormaPago" Checked="true" />
                <asp:RadioButton ID="rbnTarjeta" Text="Tarjeta" runat="server" GroupName="FormaPago" />
            </asp:Panel>
            <asp:Panel ID="PanelProtectora" runat="server" Visible="False">
                <asp:Label ID="lblPersonaContacto" runat="server" Text="Persona de Contacto"></asp:Label>
                <asp:TextBox ID="txtPersonaContacto" runat="server" class="form-control"></asp:TextBox>
            </asp:Panel>
        </div>
        <div class="form-group">
            <asp:Button ID="btnEnviarSocio" runat="server" Text="Guardar" OnClientClick="return validarFormularioAltaSocio();" OnClick="btnEnviarSocio_Click" class="btn btn-primary" />
        </div>
        <div class="form-group">
            <asp:Label ID="resultadoSocio" runat="server" Text=""></asp:Label>
        </div>

        </div>
    
</asp:Content>

