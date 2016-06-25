<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioUsuario.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.CambioUsuario" %>

<asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">

     <%--Validaciones JS--%>

     <script type="text/javascript">

         function validarsiEsVacio() {

           <%-- var nombre = document.getElementById("<%=txtNombreUsuario.ClientID%>");--%>

             var pass = document.getElementById("<%=txtPass.ClientID%>");

             if (pass.value == "") {

                 swal("Debe ingresar una nueva contraseña");
                 return false;
                 
             } else { return true;}
         }

      </script>




     <title>Veterinaria - Modificar Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Modificar Usuario</h1>
        <div class="form-group">
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario"></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblContrasenia" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" class="form-control" TextMode="password"></asp:TextBox>
        </div>
        <asp:Button ID="btnModificarUsuario" runat="server" OnClientClick="return validarsiEsVacio();" class="btn btn-primary" Text="Modificar" OnClick="btnModificarUsuario_Click" />
        <div class="form-group">
            <asp:Label ID="resultadoUsuario" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
