<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Aras.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div id="printDiv" style="margin:0; padding:0;">
          <%--  NO:
            <asp:Label ID="voiceNoLbl" runat="server" Text="Label"></asp:Label>
            <br />--%>
            <br />
            Customer name:
            <asp:Label ID="customerNameLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Date:
            <asp:Label ID="DateLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Kilo:
            <asp:Label ID="KiloLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Amount:
            <asp:Label ID="AmountLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Total:<asp:Label ID="TotalLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Discount:<asp:Label ID="DiscountLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Total all:<asp:Label ID="TotalAllLbl" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>

<input type="button" value="print" title="print" onclick="printing()"/>

        <script>
            function printing() {

                            window.print();
            }

        </script>

    </form>
</body>
</html>
