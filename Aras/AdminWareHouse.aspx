<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWareHouse.aspx.cs" Inherits="Aras.AdminWareHouse" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClientClick="return confirm('are you sure ?');" OnClick="DeleteButton_Click" />
&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" Text="Create"  />
            <br />
            <br />
        </div>
        <asp:GridView ID="AdminWareHouseGridView" runat="server" Width="585px" Height="297px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="viewWareHouses" >
            <Columns>
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbDeleteHeader" runat="server" AutoPostBack="True" OnCheckedChanged="cbDeleteHeader_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbDelete" runat="server" AutoPostBack="True" OnCheckedChanged="cbDelete_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="warehouse_name" HeaderText="warehouse_name" SortExpression="warehouse_name" />
                <asp:CheckBoxField DataField="disabled" HeaderText="disabled" SortExpression="disabled" />
                <asp:BoundField DataField="phone_no" HeaderText="phone_no" SortExpression="phone_no" />
                <asp:BoundField DataField="address_line_1" HeaderText="address_line_1" SortExpression="address_line_1" />
                <asp:BoundField DataField="parent_warehouse_ID" HeaderText="parent_warehouse_ID" SortExpression="parent_warehouse_ID" />
                <asp:CheckBoxField DataField="is_group" HeaderText="is_group" SortExpression="is_group" />
            </Columns>


        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ></asp:Label>
        <asp:SqlDataSource ID="viewWareHouses" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [warehouse]"></asp:SqlDataSource>
         

    </form>

      <script type="text/javascript" src="js/DeleteRows.js"></script> 
     <script type="text/javascript">

            var tablename = "AdminWareHouseGridView2";
            var deletebtmName = "DeleteButton";
           

            var selected = [];
            var deleteBTM = document.getElementById(deletebtmName);
            appendColumn(tablename);
            deleteBTM.addEventListener('click', function () {
                var rows = selected.length;
                var confrimMessage = "Are you sure to delete " + rows + " rows ?";
                var errorMessage = "You have not selected any rows.";

                if (rows > 0) {
                    var result = confirm(confrimMessage);
                    if (result) 
                        PageMethods.DeleteRowsServer();

         
                    }   
                    
                    else
                        alert(errorMessage);
            });

    </script>
</body>
</html>
