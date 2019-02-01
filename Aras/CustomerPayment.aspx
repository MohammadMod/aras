<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPayment.aspx.cs" Inherits="Aras.CustomerPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/HamaScripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Select Supplier:
            <asp:DropDownList ID="SelectCustomerDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectCustomerDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Para la hisabi:<asp:TextBox ID="MoneyInAccountTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <br />
            Para dan:<asp:TextBox ID="ReciveFromSupplierTextBox" runat="server"  onkeyup="calculateCustomer()"></asp:TextBox>
            <br />
            <br />
            Parai wasl - para la hisab:<asp:TextBox ID="RecivePlusInAccountTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="salesInvoiceHasNoPayment">
            <Columns>
                <asp:CommandField ShowSelectButton="True" HeaderText="Pay" SelectText="Pay" />
                <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
                <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="Totall_All" HeaderText="Totall_All" SortExpression="Totall_All" />
                <asp:BoundField DataField="discount" HeaderText="discount" SortExpression="discount" />
                <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                <asp:BoundField DataField="Totall" HeaderText="Totall" SortExpression="Totall" />
                <asp:BoundField DataField="posting_date" HeaderText="posting_date" SortExpression="posting_date" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="salesInvoiceHasNoPayment" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="sales_invoies_have_no_payment_entry" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="SelectCustomerDropDownList" Name="customer" PropertyName="SelectedIndex" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" />
    </form>
</body>
</html>
