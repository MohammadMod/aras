<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Aras.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reports</title>
    
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

    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="css/app.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://www.amcharts.com/lib/3/plugins/export/export.css" type="text/css" media="all" />
    

    <link href="css/styleee.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/vendor/modernizr-2.8.3.min.js"></script>
    <script src="js/HamaScripts.js"></script>
    <script src="SearchInGrids.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        tr:first-child{
            color:deepskyblue;
        }

        tr:last-child{
            color:#0097a7;
            font-size:20px;
        }

        td:first-child{
            color:#00838f !important;
        }
    </style>
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
            <h4 class="styleK">راپۆرت</h4>
          </div>
        </div>
      </div>
      <hr/>
    </section>
    <div class="container">

        <form id="form1" runat="server">
            <div class="form-row pb-2 ">

                <div class="col-6 col-sm-6 col-md-6 col-lg-3 my-1">
                    <label for="dtp_input1" class="control-label">کاتی دەست پێک</label>
                    <div class="input-group date form_datetime" data-date="" data-date-format="yyyy-mm-dd" data-link-field="dtp_input1">

                        <asp:TextBox ID="Date_start" placeholder="دەست پێك" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-prepend">
                            <span class="input-group-text"><span class="fas fa-calendar-alt"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                        </div>
                    </div>

                </div>

                <div class="col-6 col-sm-6 col-md-6 col-lg-3 my-1">
                    <label for="dtp_input1" class="control-label">تا کاتی</label>
                    <div class="input-group date form_datetime" data-date="" data-date-format="yyyy-mm-dd" data-link-field="dtp_input1">

                        <asp:TextBox ID="TextBox1" placeholder="دەست پێك" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-prepend">
                            <span class="input-group-text"><span class="fas fa-calendar-alt"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                        </div>
                    </div>

                </div>

                <div class="col-6 col-sm-6 col-md-6 col-lg-3 ">
                    <label for="periodDropDownList" class="col-form-label styleK">بە گوێرەی</label>

                    <asp:DropDownList CssClass="form-control " Style="padding-top: 0; padding-bottom: 0; font-size: 16px;"
                        ID="periodDropDownList" runat="server">
                        <asp:ListItem  Selected="True">daily</asp:ListItem>
                        <asp:ListItem>Monthly</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-lg-3">
                    <label for="statuesDropDownList" class="col-form-label styleK">جۆری وەسڵ</label>
                     
                    <asp:DropDownList ID="statuesDropDownList" CssClass="form-control " Style="padding-top: 0; padding-bottom: 0; font-size: 16px;" runat="server">
                        <asp:ListItem>paid</asp:ListItem>
                        <asp:ListItem>unpaid</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                From:
            </div>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            To:<br />
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
      

         
            <br />
            <div class="border p-3">
                <asp:GridView ID="GridView1" CssClass="table table-stripet table-bordered table-hover table-responsive-md table-responsive-lg text-center" runat="server">
                </asp:GridView>
            </div>

            <div class="col-lg-3 col-md-6 col-sm-6  mt-0 py-3">
                <div class="form-group">
                     <asp:Button ID="submitButton" runat="server" Text="ئەنجام" CssClass="btn btn-primary  btn-block styleK"  OnClick="submitButton_Click"  />
                </div>
            </div>

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

    <script src="js/bootstrap-datetimepicker.js"></script>
    <script>
        $('.form_datetime').datetimepicker({
            weekStart: 1,
            todayBtn: 1,// view Btn Today
            autoclose: 1,
            //todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
        });
    </script>
</body>
</html>
