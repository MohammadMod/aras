<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Aras.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            Search:
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" Text="Create" OnClick="CreateButton_Click" />
            <br />
            <br />
        </div>
        <asp:GridView ID="CustomersGridView" runat="server" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="Select to delete">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" style="text-align: center" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
        <div>
        </div>
</body>
</html>
