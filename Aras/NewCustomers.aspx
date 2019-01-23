<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCustomers.aspx.cs" Inherits="Aras.NewCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            Customer Name:<asp:TextBox ID="CostumerNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Resturant Name:<asp:TextBox ID="ResturantNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Location:<asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone Number:
            <asp:TextBox ID="PhoneNumberTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Money in dept:<asp:TextBox ID="MoneyInDeptTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="DisablesCheckBox" runat="server" Text="Disabled ?" />
            <br />
            <br />
            <asp:Button ID="CreateCustomerButton" runat="server" OnClick="CreateCustomerButton_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
