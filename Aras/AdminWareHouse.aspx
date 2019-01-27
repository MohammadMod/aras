<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWareHouse.aspx.cs" Inherits="Aras.AdminWareHouse" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" Text="Create" />
            <br />
            <br />
        </div>
        <asp:GridView ID="AdminWareHouseGridView" runat="server" Width="585px" Height="297px">
        </asp:GridView>
    </form>
</body>
</html>
