<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Aras.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="Search" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CreateButton" runat="server" OnClick="CreateButton_Click" Text="Create" />
            <br />
            <br />
        </div>
        <asp:GridView ID="ViewUsersGridView" runat="server" OnRowCancelingEdit="ViewUsersGridView_RowCancelingEdit" OnRowEditing="ViewUsersGridView_RowEditing" OnRowUpdating="ViewUsersGridView_RowUpdating" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="ViewUsersGridView_PageIndexChanging" OnSorted="ViewUsersGridView_Sorted">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </form>
</body>
</html>
