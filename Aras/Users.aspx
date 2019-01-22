<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Aras.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" OnClick="CreateButton_Click" Text="Create" />
            <br />
            <br />
        </div>
        <asp:GridView ID="ViewUsersGridView" runat="server">
            <Columns>
                <asp:CheckBoxField />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
