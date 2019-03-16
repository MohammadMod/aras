<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Aras.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            From:</div>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        To:<br />
        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
        Period:<br />
        <asp:DropDownList ID="periodDropDownList" runat="server" Width="100px">
            <asp:ListItem Selected="True">daily</asp:ListItem>
            <asp:ListItem>Monthly</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Statues:<br />
        <asp:DropDownList ID="statuesDropDownList" runat="server">
            <asp:ListItem>paid</asp:ListItem>
            <asp:ListItem>unpaid</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" />
    </form>
</body>
</html>
