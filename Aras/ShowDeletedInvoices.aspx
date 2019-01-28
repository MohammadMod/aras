<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDeletedInvoices.aspx.cs" Inherits="Aras.ShowDeletedInvoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;Search:&nbsp;
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:GridView ID="ViewDeletedInvoicesGridView" runat="server" AllowPaging="True" PageSize="10" AllowSorting="True">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
