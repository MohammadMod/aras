<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateWareHouse.aspx.cs" Inherits="Aras.CreateWareHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ware House name:<asp:TextBox ID="WareHouseNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone Number:<asp:TextBox ID="WareHousePhoneTextBox0" runat="server"></asp:TextBox>
            <br />
            <br />
            Address:<asp:TextBox ID="WareHouseAddressTextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            parint ware house ID:<asp:TextBox ID="WareHouseIDTextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            is group:
            <asp:CheckBox ID="isGroupCheckBox" runat="server" />
            <br />
            <br />
            disabled:<asp:CheckBox ID="disabledCheckBox" runat="server" />
            <br />
            <br />
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
