<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show Payment Entry.aspx.cs" Inherits="Aras.Show_Payment_Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Payment NO" DataSourceID="ShowPaymentEntry">
            <Columns>
                <asp:BoundField DataField="Payment NO" HeaderText="Payment NO" InsertVisible="False" ReadOnly="True" SortExpression="Payment NO" />
                <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ShowPaymentEntry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="Show_payment_entry" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
