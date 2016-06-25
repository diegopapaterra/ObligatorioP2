<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPatologia.aspx.cs" MasterPageFile="~/PaginaMaestra.Master" Inherits="VeterinariaWebApp.AltaPatologia" %>


<asp:Content ID="Content"  ContentPlaceHolderID="head" runat="server">

      <%--Validaciones JS--%>

        <script type="text/javascript">

            function validarSiEsVacio() {

                var titulo = document.getElementById("<%=txtTituloPatologia.ClientID%>");
                var desc = document.getElementById("<%=txtDescripcion.ClientID%>");

                if (titulo.value == "" || desc.value == "") {

                    swal("Todos los datos son requeridos");
                    return false;

                } else { return true;}
            }
        </script>



        <title>Veterinaria - Alta Patologia</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alta-container">
        <h1>Alta de Patologia</h1>
        <div class="form-group">
            <asp:Label ID="lblTituloPatologia" runat="server" Text="Título"></asp:Label>
            <asp:TextBox ID="txtTituloPatologia" runat="server" class="form-control" ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" class="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button ID="btnEnviarPatologia" OnClientClick ="return validarSiEsVacio();" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnEnviarPatologia_Click" />
        </div>
        <div class="form-group">
            <asp:Label ID="resultadoPatologia" runat="server" Text=""></asp:Label>
        </div>

    </div>
</asp:Content>

