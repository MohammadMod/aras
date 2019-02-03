<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDeletedInvoices.aspx.cs" Inherits="Aras.ShowDeletedInvoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="SearchInGrids.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;Search:&nbsp;
            <asp:TextBox ID="SearchTextBox" runat="server" onkeyup="Search_Gridview(this, 'ViewDeletedInvoicesGridView')"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:GridView ID="ViewDeletedInvoicesGridView" runat="server" AllowPaging="True" PageSize="10" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ShowDeletedInvoice" Height="16px" Width="157px">
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                    <asp:BoundField DataField="Amout" HeaderText="Amout" SortExpression="Amout" />
                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="ShowDeletedInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [deketed_invoice]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
