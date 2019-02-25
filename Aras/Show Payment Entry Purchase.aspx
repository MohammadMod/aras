<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show Payment Entry Purchase.aspx.cs" Inherits="Aras.Show_Payment_Entry_Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Purchase_ID" DataSourceID="SupplierPaymentEntry">
            <Columns>
                <asp:BoundField DataField="Purchase_ID" HeaderText="Purchase_ID" InsertVisible="False" ReadOnly="True" SortExpression="Purchase_ID" />
                <asp:BoundField DataField="supplier" HeaderText="supplier" SortExpression="supplier" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                <asp:BoundField DataField="totall_amount" HeaderText="totall_amount" SortExpression="totall_amount" />
                <asp:BoundField DataField="satute" HeaderText="satute" SortExpression="satute" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SupplierPaymentEntry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="show_purchase_Invoices" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
