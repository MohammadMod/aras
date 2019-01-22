<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Aras.Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/HamaScripts.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            Supplier:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Kilo: <asp:TextBox ID="KiloTextBox" runat="server" oninput="calculate()"></asp:TextBox>
            <br />
            <br />
            Cost:<asp:TextBox ID="CostTextBox" runat="server" oninput="calculate()"></asp:TextBox>
            <br />
            <br />
            Total all:
            <asp:TextBox ID="TotallAllTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp; dateTime:<asp:TextBox ID="dateTimeTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="PurchaseButton" runat="server" Text="Submit" />
        </div>
    </form>
</body>
</html>
