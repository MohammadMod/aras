<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="Aras.Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            From WareHouse:&nbsp;
            &nbsp;&nbsp;<asp:DropDownList ID="fromWareHouseDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="fromWareHouseDropDownList_SelectedIndexChanged1">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To:&nbsp;&nbsp;
            <asp:DropDownList ID="toWareHouseDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            Amount in warehouse:<asp:TextBox ID="AmountInWareHouseTextBox" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            Transfer Amount:<asp:TextBox ID="TranseferAmountTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Button" />
            <br />
        </div>
    </form>
</body>
</html>
