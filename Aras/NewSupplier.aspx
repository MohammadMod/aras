<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSupplier.aspx.cs" Inherits="Aras.NewSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Full Name:<br />
            <br />
            Depit Money:<br />
            <br />
            Location:<br />
            <br />
            Phone Number:
            <br />
            <br />
            <asp:CheckBox ID="DisableCheckBox" runat="server" Text="Disables !" />
            <br />
        </div>
        <asp:Button ID="CreateNewSupplierButton" runat="server" OnClick="CreateNewSupplierButton_Click" Text="Submit" />
    </form>
</body>
</html>
