<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="Aras.Expenses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Amount:<asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox>
            <br />
            Details:<asp:TextBox ID="detailsTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" />
    </form>
</body>
</html>
