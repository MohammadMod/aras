<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clolsing Invoices.aspx.cs" Inherits="Aras.Clolsing_Invoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Driver:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </p>

        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
           
            <Columns>
                <asp:CommandField SelectText="Close !" ShowSelectButton="True"   />
            </Columns>
           
            <PagerTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </PagerTemplate>
        </asp:GridView>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
