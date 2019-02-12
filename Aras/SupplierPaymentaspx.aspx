<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierPaymentaspx.aspx.cs" Inherits="Aras.SupplierPaymentaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/HamaScripts.js"></script>
    <script src="SearchInGrids.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Select Supplier:
            <asp:DropDownList ID="SelectSupplierDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectSupplierDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Para la hisabi:<asp:TextBox ID="MoneyInAccountTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Para dan:<asp:TextBox ID="PayToSupplierTextBox" runat="server" required="true" OnTextChanged="PayToSupplierTextBox_TextChanged" onkeyup="calculateSupplier()"></asp:TextBox>
            <br />
            <br />
            Parai wasl - para la hisab:<asp:TextBox ID="PayPlusInAccountTextBox" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            total all la naw wasl: <asp:TextBox ID="totalAllTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Search:
            <asp:TextBox ID="searchTextBox" runat="server" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox>
            <br />
            <br />
            <br /> 
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="salesInvoicehasnopaymententry" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField SelectText="Pay" ShowSelectButton="True" />
                <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
                <asp:BoundField DataField="Posting_date" HeaderText="Posting_date" SortExpression="Posting_date" />
                <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                <asp:BoundField DataField="totall_amount" HeaderText="totall_amount" SortExpression="totall_amount" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="salesInvoicehasnopaymententry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="Purchase_invoies_have_no_payment_entry" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="SelectSupplierDropDownList" Name="supplier" PropertyName="SelectedIndex" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="PurchaseInvoiceHasNoPaymentEntry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="show_purchase_Invoices" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </p>
    </form>
</body>
</html>
