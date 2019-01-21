<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aras.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        User Name:
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
        <br />
        Passowrd:
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me!" />
        <br />
        <br />
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" />
    </form>
</body>
</html>
