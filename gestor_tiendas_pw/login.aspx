<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="gestor_tiendas_pw.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
 <link href="styles/geneic.css" rel="stylesheet" type="text/css">
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row my-5 justify-content-center">
                <img class="store" src="img/login.png"/>
            </div>
            <div class="row justify-content-center">
            <div class="col-6 input-group mb-3 ">
                <label class="label_login">Usuario</label>
                <asp:TextBox class="login_txt form-control" ID="txtUser" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-6 input-group mb-3">
                <label class="label_login">Contraseña</label>
                <asp:TextBox class="login_txt form-control" ID="txtPass" runat="server"></asp:TextBox>
            </div>
        </div>
            <div class="row row justify-content-center"">
                <asp:RadioButtonList ID="radioS" runat="server" AutoPostBack="True">
                    <asp:ListItem>Administrador</asp:ListItem>
                    <asp:ListItem class="pl-3">Empleado</asp:ListItem>
                </asp:RadioButtonList>

            </div>
            <div class="row justify-content-center">
            <div class="col-4 mt-3">
                <asp:Button ID="btnLogin" class="btn btn-outline-primary" runat="server" Text="INGRESAR" OnClick="Button1_Click" />
            </div>
        </div>
        </div>
    </form>
</body>
</body>
</html>
