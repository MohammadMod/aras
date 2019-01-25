<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="Aras.Suppliers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="EditButton" runat="server" Text="Edit" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" OnClick="CreateButton_Click" Text="Create" />
        </p>
        <div>
        </div>
        <asp:GridView ID="ViewSuppliersGridView" runat="server" OnRowEditing="ViewSuppliersGridView_RowEditing" OnRowUpdating="ViewSuppliersGridView_RowUpdating" OnPageIndexChanging="ViewSuppliersGridView_PageIndexChanging" OnRowCancelingEdit="ViewSuppliersGridView_RowCancelingEdit" AllowPaging="true" PageSize="10" AllowSorting="true" OnSorting="ViewSuppliersGridView_Sorting">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            
        </asp:GridView>
    </form>
</body>
</html>
