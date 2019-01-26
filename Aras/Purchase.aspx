<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Aras.Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Puchase</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/metisMenu.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link href="css/slicknav.min.css" rel="stylesheet" />
    <link href="css/themify-icons.css" rel="stylesheet" />
    <link href="css/typography.css" rel="stylesheet" />
    <link href="css/default-css.css" rel="stylesheet" />

    <link href="css/app.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://www.amcharts.com/lib/3/plugins/export/export.css" type="text/css" media="all" />

    <link href="css/styleee.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/vendor/modernizr-2.8.3.min.js"></script>
    <script src="js/HamaScripts.js"></script>

</head>
<body>

    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            Supplier:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Kilo: <asp:TextBox ID="KiloTextBox" runat="server" oninput="calculate()"></asp:TextBox>
            <br />
            <br />
            Cost:<asp:TextBox ID="CostTextBox" runat="server" oninput="calculate()"></asp:TextBox>
            <br />
            <br />
            Total all:
            <asp:TextBox ID="TotallAllTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp; dateTime:<asp:TextBox ID="dateTimeTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="PurchaseButton" runat="server" Text="Submit" />
        </div>
    </form>

    
     <script src="js/app.js"></script>
    
    <script src="js/vendor/jquery-2.2.4.min.js"></script>
    <!-- bootstrap 4 js -->
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/metisMenu.min.js"></script>
    <script src="js/jquery.slimscroll.min.js"></script>
    <script src="js/jquery.slicknav.min.js"></script>
    
    <!-- others plugins -->
    <script src="js/plugins.js"></script>
    <script src="js/scripts.js"></script>
</body>
</html>
