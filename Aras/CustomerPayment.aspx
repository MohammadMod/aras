﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPayment.aspx.cs" Inherits="Aras.CustomerPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
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
    
    <section class="py-2">
      <div class="container">
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6 col-6">
                <div id="txt"></div>

          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-6 text-right">
            <h4 class="styleK">پارەدانی لە چێشتخانە</h4>
          </div>
        </div>
      </div>
      <hr/>
    </section>
    
    
    <section class="pt-0 pb-1">
        <div class="container">
            <div class="row text-right pb-3">
                <div class="col-lg-12 col-md-12 col-sm-12 col-12">
                    <a href="/ShowSalesInvoice.aspx" class="btn btn-facebook styleK">پشاندانی پسولەی فرۆشیار</a>
                </div>
            </div>
            <div class="border">

                <form id="form1" runat="server">
                    <div class="col-lg-10 mt-0">
                        <div class="form-group">
                            <label for="SelectCustomerDropDownList" class="col-form-label styleK text-right">دیاری کردنی شوفێر</label>
                            <asp:DropDownList CssClass="form-control invois_multK" ID="SelectCustomerDropDownList" Style="padding-top: 0; padding-bottom: 0; font-size: 12px;"
                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="SelectCustomerDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-lg-6 mt-0">
                        <div class="form-group">
                            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="styleK" Text="پارە دان لە حیسابی " AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </div>
                    </div>



                    <div class="col-lg-6 mt-0">
                        <fieldset disabled="disabled">
                            <div class="form-group">
                                <label for="MoneyInAccountTextBox" class="col-form-label styleK">پارە لە حیساب</label>
                                <asp:TextBox ID="MoneyInAccountTextBox" CssClass="form-control form-control-lg" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>



                    <div class="col-lg-6 mt-0">
                        <div class="form-group">
                            <label for="ReciveFromSupplierTextBox" class="col-form-label styleK">پارە دان</label>
                            <asp:TextBox ID="ReciveFromSupplierTextBox" runat="server" CssClass="form-control form-control-lg" onkeyup="calculateCustomer()" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <div runat="server" id="hideDive">
                        <div class="col-lg-6 mt-0">
                            <fieldset disabled="disabled">
                                <div class="form-group">
                                    <label for="totalAllTextBox" class="col-form-label styleK">کۆی گشتی لەناو وەسل</label>
                                    <asp:TextBox ID="totalAllTextBox" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                                </div>
                            </fieldset>
                        </div>

                        <div class="col-lg-6 mt-0">
                            <div class="form-group">
                                <label for="RecivePlusInAccountTextBox" class="col-form-label styleK">پارە لە وەسل</label>
                                <asp:TextBox ID="RecivePlusInAccountTextBox" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                            </div>
                        </div>
                        <hr />

                        <div class="col-lg-6 mt-0">
                            <div class="form-group">
                                <label for="searchTextBox" class="col-form-label styleK">گەران</label>
                                <asp:TextBox ID="searchTextBox" runat="server" CssClass="form-control form-control-lg" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox>
                            </div>
                        </div>

                        <div class="container">

                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                CssClass="table table-stripet table-bordered table-hover table-responsive-md text-center">
                                <Columns>
                                    <asp:CommandField SelectText="Pay" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                            
                        </div>
                        <hr />

                    <div class="offset-lg-6 offset-md-6 col-lg-6 col-md-6 mt-0 text-right">
                        <div class="form-group">
                            <label for="unpaidTotalAllInvoicesTextBox" class="col-form-label styleK">کۆی گشتی</label>

                            <asp:TextBox ID="unpaidTotalAllInvoicesTextBox" ReadOnly="true" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    </div>

                    <div class="col-md-3 col-sm-3 col-lg-3 mb-3">
                        <asp:Button ID="SubmitButton" CssClass="btn btn-success btn-block" runat="server" Text="پارە وەرگرتن" OnClick="SubmitButton_Click" />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                    </div>

                   
                </form>
            </div>
        </div>
    </section>

    
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
