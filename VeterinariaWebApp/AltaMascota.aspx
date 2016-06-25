<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMascota.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaMascota" EnableEventValidation="false" %>

<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">

     <%--Validaciones JS--%>

        <script type="text/javascript">

            function validarFormularioAltaMascota() {

                var nombreMascota = document.getElementById("<%=txtNombre.ClientID%>");
                var especieMascota = document.getElementById("<%=txtEspecie.ClientID%>");
                var raza = document.getElementById("<%=txtRaza.ClientID%>");
                var sexo = document.getElementById("<%=txtSexo.ClientID%>");
                var fechaNac = document.getElementById("<%=txtFechaNacimiento.ClientID%>");

                if (nombreMascota.value == "" || especieMascota.value == "" || raza.value == "" || sexo.value == "" || fechaNac == "") {
                
                    swal("Todos los datos son requeridos");
                    return false;
                
                }

                if (cedulaSocio.value.length < 6 || cedulaSocio.value.length > 8) {

                    swal("La cédula debe tener de 6 a 8 caracteres");
                    return false;
                }

                return true;
            }

         </script>


        <title>Veterinaria - Alta Mascota</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta de Mascota</h1>
        <div class="form-group">
            <asp:DropDownList ID="DDLSocios" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombreMascota" runat="server" Text="Nombre Mascota"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEspecie" runat="server" Text="Especie Mascota"></asp:Label>
            <asp:TextBox ID="txtEspecie" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRaza" runat="server" Text="Raza Mascota"></asp:Label>
            <asp:TextBox ID="txtRaza" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSexo" runat="server" Text="Sexo Mascota"></asp:Label>
            <asp:TextBox ID="txtSexo" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento Mascota"></asp:Label>
            <asp:Calendar ID="txtFechaNacimiento" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFoto" runat="server" Text="Foto Mascota"></asp:Label>
            <asp:FileUpload ID="fileUploadMascota" runat="server" class="form-control" placeholder="Opcional" />
           </div>

        <div class="form-group">
            <asp:Button ID="btnEnviarMascota" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnEnviarMascota_Click" OnClientClick = "validarFormularioAltaMascota()"/>
        </div>
        <div class="form-group">
            <asp:Label ID="resultadoMascota" runat="server" Text=""></asp:Label>
        </div>

    </div>
</asp:Content>
