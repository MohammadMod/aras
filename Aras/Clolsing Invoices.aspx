﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clolsing Invoices.aspx.cs" Inherits="Aras.Clolsing_Invoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show closing</title>
    
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

    <style>
        .pt-4{
            padding-top:2rem !important;
        }
        .btn-primary{
            border-radius:4px !important;
        }
    </style>
</head>
<body id="body_newcus" onload="startTime(); ChangeHeader()">
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
                    <h4 class="styleK">پارە ناردن</h4>
                </div>
            </div>
        </div>
        <hr />
    </section>

    <form id="form1" runat="server">
        <div class="container">

            <div class="form-row pb-2">
                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1">
                    <label for="DropDownList1" class="col-form-label styleK">شوفێر</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control " Style="padding-top: 0; padding-bottom: 0; font-size: 16px;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1 text-right pt-4">
                    <asp:Button ID="ViewButton" runat="server" CssClass="btn btn-primary btn-sm styleK" data-toggle="modal" data-target="#sizedModalLg" Text="بینین" />
                </div>
            </div>

            <div class="border p-2">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    CssClass="table table-stripet table-bordered table-hover table-responsive-md text-center">
                    <Columns>
                        <asp:CommandField SelectText="Close !" ShowSelectButton="True" />
                    </Columns>

                    <PagerTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>

         <%-- Modal --%>
        <div class="modal fade" id="sizedModalLg" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
            <div class="modal-dialog modal-md" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">بینینی زانیاری فرۆشیار </h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body m-3" runat="server">
                        <div class="container-fluid">

                            <div class="row border">
                                <div class="col-8">
                                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>

                                </div>
                                <div class="col-4 styleK">
                                    رەقەم وەسڵ
                                </div>
                            </div>


                            <div class="row border">
                                <div class="col-8">
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-4 styleK">
                                    کات
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:Button ID="PrintButton" class="btn btn-warning btn-sm" runat="server" Text="Print" />
                        <asp:Button ID="Edit" runat="server" CssClass="btn btn-info btn-sm styleK" Text="دەستکاری کردن" />
                        <asp:Button ID="Button1" CssClass="btn btn-danger btn-sm styleK" runat="server" Text="رەشکردنەوە" />

                    </div>
                </div>
            </div>
        </div>
        <%-- End Modal --%>
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
