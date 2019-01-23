<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSupplier.aspx.cs" Inherits="Aras.NewSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Full Name:<asp:TextBox ID="SupplierFullNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Depit Money:<asp:TextBox ID="NewSupplierDepitMoneyTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Location:<asp:TextBox ID="SupplierLocationTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone Number:
            <asp:TextBox ID="SupplierPhoneNumberTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:CheckBox ID="DisableCheckBox" runat="server" Text="Disables !" />
            <br />
            <br />
        </div>
        <asp:Button ID="CreateNewSupplierButton" runat="server" OnClick="CreateNewSupplierButton_Click" Text="Submit" />
    </form>
</body>
</html>
