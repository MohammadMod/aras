<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierPaymentaspx.aspx.cs" Inherits="Aras.SupplierPaymentaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SupplierPayment</title>
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
    <script src="SearchInGrids.js"></script>
</head>
<body id="body_newcus" onload="startTime()">
    <div class="main">
        <nav class="navbar navbar-expand navbar-light bg-dark">
            <div class="container">
                <div class=" d-sm-inline-block text-white-70">
                    <a href="/"><i class="fa fa-home home_icon"></i></a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-white-50" href="#" id="userDropdown" data-toggle="dropdown">
                                <img src="image/avatar.jpeg" class="avatar img-fluid rounded-circle mr-1" alt="Chris Wood">
                                <span class="text-white-50">
                                      <%--<asp:Label ID="label2"  runat="server"  text=""></asp:Label>--%>
                                </span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right " aria-labelledby="userDropdown">

                                <a class="dropdown-item text-right" href="#">
                                    <i class="align-middle mr-1 " data-feather="user"></i>زانیاری زیاتر</a>
                                <a class="dropdown-item text-right " href="#"><i class="align-middle mr-1" data-feather="pie-chart"></i>Analytics</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item text-right" href="#">چوونە دەرەوە</a>

                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
    
    <section class="py-3">
      <div class="container">
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6 col-6">
                <div id="txt"></div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-6 text-right">
            <h4 class="styleK">پارەدانی فرۆشیار</h4>
          </div>
        </div>
      </div>
      <hr/>
       </section>

        <div class="container">
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
                    Para dan:<asp:TextBox ID="PayToSupplierTextBox" runat="server" required="true" OnTextChanged="PayToSupplierTextBox_TextChanged" onkeyup="calculateSupplier()"></asp:TextBox>
                    <br />
                    <br />
                    Parai wasl - para la hisab:<asp:TextBox ID="PayPlusInAccountTextBox" runat="server" ReadOnly="true"></asp:TextBox>
                    <br />
                    <br />
                    total all la naw wasl:
                    <asp:TextBox ID="totalAllTextBox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Search:
            <asp:TextBox ID="searchTextBox" runat="server" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                </div>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="salesInvoicehasnopaymententry" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                    <Columns>
                        <asp:CommandField SelectText="Pay" ShowSelectButton="True" />
                        <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
                        <asp:BoundField DataField="Posting_date" HeaderText="Posting_date" SortExpression="Posting_date" />
                        <asp:BoundField DataField="rate" HeaderText="rate" SortExpression="rate" />
                        <asp:BoundField DataField="totall_amount" HeaderText="totall_amount" SortExpression="totall_amount" />
                        <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="salesInvoicehasnopaymententry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="Purchase_invoies_have_no_payment_entry" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="SelectSupplierDropDownList" Name="supplier" PropertyName="SelectedIndex" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="PurchaseInvoiceHasNoPaymentEntry" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="show_purchase_Invoices" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <p>
                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                </p>
            </form>
        </div>
    

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
