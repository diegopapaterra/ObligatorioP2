<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PaginaMaestra.Master" CodeBehind="FinCuadroClinico.aspx.cs" Inherits="VeterinariaWebApp.FinCuadroClinico" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">
        <%--Validaciones JS--%>

        <script type="text/javascript">

            function datosRequeridos() {

                var txtMotivo = document.getElementById("<%=txtMotivo.ClientID%>");

                if (txtMotivo.value == "") {

                    swal("Ingrese el motivo");

                    return false;

                } else {

                    return true;

                }
            }

        </script>
        <title>Veterinaria - Finalizar Cuadro Clinico</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Finalizar Cuadro Clinico</h1>
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
            <asp:DropDownList ID="DDLMascotasSocio" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDLMascotasSocio_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnEnviar" runat="server" Text="Ver Cuadros en Curso" class="btn btn-primary" OnClick="btnEnviar_Click"  />
        </div>

        <div class="form-group">
            <asp:DropDownList ID="DDLlistaCuadroClinico" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblMotivo" runat="server" Text="Motivo"></asp:Label>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" placeholder="Ingrese el motivo de la finalizacion"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:CheckBox ID="checkFinalizado" runat="server" Text="Finalizado" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnFinCuadro" runat="server" Text="Finalizar Cuadro Clinico" class="btn btn-primary" OnClick="btnFinCuadro_Click" OnClientClick="return datosRequeridos();"  />
        </div>

        <div class="form-group">
             <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

