<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaUsuarios.aspx.cs" Inherits="VeterinariaWebApp.AltaUsuarios" %>
 <asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">

 <%--Validaciones JS--%>

        <script type="text/javascript">

            function datosRequeridos() {

                var nombreUsuario = document.getElementById("<%=txtNombreUsuario.ClientID%>");
                var password = document.getElementById("<%=txtPass.ClientID%>");

                <%--var rol1 = document.getElementById("<%=rbnAdmin.ClientID%>");
                var rol2 = document.getElementById("<%=rbnSocio.ClientID%>");
                var rol3 = document.getElementById("<%=rbnVeterinario.ClientID%>");--%>

                if (nombreUsuario.value == "" || password.value == "") {

                    swal("Todos los datos son obligatorios");

                    return false;

                } else {

                    return true;

                }
            }

        </script>
     <title>Veterinaria - Alta de Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta de Usuario</h1>
        <div class="form-group">
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario"></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" class="form-control" placeholder="Cedula o Numero de Licencia"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblContrasenia" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <p>Rol</p>
            <asp:RadioButton ID="rbnAdmin" Text ="Administrador" runat="server" GroupName="TipoUser" />
            <asp:RadioButton ID="rbnVeterinario"  text="Veterinario" runat="server" GroupName="TipoUser" />
            <asp:RadioButton ID="rbnSocio"  Text= "Socio" runat="server" GroupName="TipoUser" />
        </div>
        <asp:Button ID="btnEnviarUsuario" runat="server" class="btn btn-primary" Text="Guardar" OnClick="btnEnviarUsuario_Click" OnClientClick="return datosRequeridos();" />
        <div class="form-group">
            <asp:Label ID="resultadoUsuario" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
