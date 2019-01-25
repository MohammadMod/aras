<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSalesInvoice.aspx.cs" Inherits="Aras.ShowSalesInvoice" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="NewInvoiceButton" runat="server" Text="New Invoice" OnClick="NewInvoiceButton_Click" />
            <br />
            <br />
            <br />
        </div>
        <asp:GridView ID="ShowSalesInvoicesGridView" runat="server" OnRowEditing="ShowSalesInvoicesGridView_RowEditing" OnRowUpdating="ShowSalesInvoicesGridView_RowUpdating" Width="384px" OnRowCancelingEdit="ShowSalesInvoicesGridView_RowCancelingEdit">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="Pay">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Pay !" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           
        </asp:GridView>
    </form>
</body>
</html>
