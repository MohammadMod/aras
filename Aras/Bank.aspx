<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="Aras.Bank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="ChildTextBox" runat="server"></asp:TextBox>
        <asp:TreeView ID="TreeView1" runat="server" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged">
        </asp:TreeView>
    </form>
</body>
</html>
