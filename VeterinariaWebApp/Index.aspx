<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VeterinariaWebApp.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Veterinaria Web</title>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="icon" type="image/png" href="img/vet.png" />
    <link rel="stylesheet" type="text/css" href="styles/bootstrap.css"/>
    <link rel="stylesheet" type="text/css" href="styles/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-container">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"></asp:Login>
        <div class="form-group">
            <asp:Label ID="resultadoUsuario" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
    <script src="scripts/jQuery2.2.4.js"></script>
    <script src="scripts/bootstrap.js"></script>
</body>
</html>
