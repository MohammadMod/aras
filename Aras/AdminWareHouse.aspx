<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWareHouse.aspx.cs" Inherits="Aras.AdminWareHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="js/DeleteRows.js">

    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Search:
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete"  />
&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" Text="Create" />
            <br />
            <br />
        </div>
        <asp:GridView ID="AdminWareHouseGridView" runat="server" Width="585px" Height="297px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="viewWareHouses" >
            <Columns>
                
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="warehouse_name" HeaderText="warehouse_name" SortExpression="warehouse_name" />
                <asp:CheckBoxField DataField="disabled" HeaderText="disabled" SortExpression="disabled" />
                <asp:BoundField DataField="phone_no" HeaderText="phone_no" SortExpression="phone_no" />
                <asp:BoundField DataField="address_line_1" HeaderText="address_line_1" SortExpression="address_line_1" />
                <asp:BoundField DataField="parent_warehouse_ID" HeaderText="parent_warehouse_ID" SortExpression="parent_warehouse_ID" />
                <asp:CheckBoxField DataField="is_group" HeaderText="is_group" SortExpression="is_group" />
            </Columns>


        </asp:GridView>
        <asp:SqlDataSource ID="viewWareHouses" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [warehouse]"></asp:SqlDataSource>
    </form>
    <script type="text/javascript">

        var tablename = "AdminWareHouseGridView";
        var deletebtmName = "DeleteButton";


        var selected = [];
        var deleteBTM = document.getElementById(deletebtmName);
        appendColumn(tablename);
        deleteBTM.addEventListener('click', function () {
           deleteRows(tablename, "any");
        });
        

    </script>
</body>
</html>
