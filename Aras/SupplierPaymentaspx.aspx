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
            <br />
            Para dan:<asp:TextBox ID="PayToSupplierTextBox" runat="server" OnTextChanged="PayToSupplierTextBox_TextChanged" onkeyup="calculateSupplier()"></asp:TextBox>
            <br />
            <br />
            Parai wasl - para la hisab:<asp:TextBox ID="PayPlusInAccountTextBox" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            Search:
            <asp:TextBox ID="searchTextBox" runat="server" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox>
            <br />
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="10" AllowSorting="True" DataSourceID="PurchaseInvoiceHasNoPaymentEntry" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="Pay" SelectText="Pay" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="PurchaseInvoiceHasNoPaymentEntry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="show_purchase_Invoices" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </p>
    </form>
</body>
</html>
