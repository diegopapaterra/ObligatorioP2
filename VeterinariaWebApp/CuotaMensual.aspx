<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CuotaMensual.aspx.cs" Inherits="VeterinariaWebApp.CuotaMensual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <title>Veterinaria - Cuota Mensual</title>

     <%--Validaciones JS--%>

        <script type="text/javascript">

            function validarMontoBaseVacio() {

                var montoBase = document.getElementById("<%=txtMontoBase.ClientID%>");

                if (montoBase.value == "") {

                    swal("Dato requerido");

                    return false;
                }

            }

            function validarDescuentoVacio() {

                var descuentoProtectoras = document.getElementById("<%=txtDescProtectoras.ClientID%>");

                if (descuentoProtectoras.value == "") {

                    swal("Dato requerido");

                    return false;
                }

            }
            
            
            
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alta-container">
        <h1>Establecer Valores</h1>

         <div class="form-group">
             <asp:Label ID="lblMontoBase" runat="server" Text="Monto base de cuota mensual"></asp:Label>
             <asp:TextBox ID="txtMontoBase" runat="server" class="form-control"></asp:TextBox>
          </div>

        <div class="form-group">
        <asp:Button ID="btnEnviarMontoBase" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnEnviarMontoBase_Click" OnClientClick ="return validarMontoBaseVacio();"/>
        </div>

        <div class ="form-group">
            <asp:Label ID="lblmensajeMonto" runat="server" Text=""></asp:Label>
        </div>

        <div class="form-group">
             <asp:Label ID="lblDescuentoProtectotra" runat="server" Text="Descuento para Protectoras"></asp:Label>
             <asp:TextBox ID="txtDescProtectoras" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
        <asp:Button ID="btnEnviarDescuento" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnEnviarDescuento_Click" OnClientClick ="return validarDescuentoVacio();"/>
        </div>

         <div class ="form-group">
            <asp:Label ID="lblMensajeDesc" runat="server" Text=""></asp:Label>
        </div>

     </div>
</asp:Content>
