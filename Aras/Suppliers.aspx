<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="Aras.Suppliers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" OnClick="CreateButton_Click" Text="Create" />
        </p>
        <div>
        </div>
        <asp:GridView ID="ViewSuppliersGridView" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
