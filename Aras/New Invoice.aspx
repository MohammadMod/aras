﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New Invoice.aspx.cs" Inherits="Aras.New_Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/HamaScripts.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            Select Customer Name:<asp:DropDownList ID="SelectCustomerDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Series:<asp:DropDownList ID="SeriesDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Kilo:<asp:TextBox ID="KiloTextBox" runat="server" onkeyup="getValues()" required="true"></asp:TextBox>
            <br />
            <br />
            Cost of Kilo:<asp:TextBox ID="CostOfKiloTextBox" onkeyup="getValues()" runat="server" required ="true"></asp:TextBox>
            <br />
            <br />
            Total:<asp:TextBox ID="TotallTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Disscount:<asp:TextBox ID="DiscountTextBox" onkeyup="getValues()" runat="server" required="true"></asp:TextBox>
            <br />
            <br />
            Totall all:<asp:TextBox ID="TotallAllTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="SubmitNewInvoiceButton" runat="server" Text="Submit" />
        </div>
    </form>

</body>


</html>
