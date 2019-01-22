<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSalesInvoice.aspx.cs" Inherits="Aras.ShowSalesInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Search:
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="NewInvoiceButton" runat="server" Text="New Invoice" />
            <br />
            <br />
            <br />
        </div>
        <asp:GridView ID="ShowSalesInvoicesGridView" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
