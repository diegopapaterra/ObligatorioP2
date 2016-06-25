<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="AltaAccionCuadroClinico.aspx.cs" Inherits="VeterinariaWebApp.AltaAccionCuadroClinico" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <%--Validaciones JS--%>

        <script type="text/javascript">

            function datosRequeridos() {

                var txtAccion = document.getElementById("<%=txtAccion.ClientID%>");

                if (txtAccion.value == "") {

                    swal("Debe Ingresar una Accion");

                    return false;

                } else {

                    return true;

                }
            }

        </script>
        <title>Veterinaria - Alta Accion al Cuadro Clinico</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta Accion al Cuadro Clinico</h1>
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
            <asp:Button ID="btnEnviar" runat="server" Text="Ver Cuadros en Curso" class="btn btn-primary" OnClick="btnEnviar_Click"  />
        </div>

        <div class="form-group">
            <asp:DropDownList ID="DDLlistaCuadroClinico" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAccion" runat="server" Text="Acción"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtAccion" runat="server" CssClass="form-control" placeholder="Ingrese la acción realizada"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAltaAccion" runat="server" Text="Agregar Accion" class="btn btn-primary" OnClick="btnAltaAccion_Click" OnClientClick="return datosRequeridos();"  />
        </div>

        <div class="form-group">
             <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

