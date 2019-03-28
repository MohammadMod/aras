<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTransfer.aspx.cs" Inherits="Aras.ShowTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Transfer</title>
    
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
        .btn-sm{
            padding-right: 2rem;
            padding-left: 2rem;
            font-size:12px;
            border-radius:.6rem !important;
        }
        @media (max-width: 768px) {
            .btn-sm{
                padding-right: 1.6rem;
                padding-left: 1.6rem;
                font-size:14px;
                border-radius:.5rem !important; 
            }
        }
        @media (max-width: 576px) {
            .btn-sm{
                padding-right: 1.4rem;
                padding-left: 1.4rem;
                font-size:12px;
                border-radius:.4rem !important; 

            }
        }
        @media (max-width: 450px) {
            .btn-sm{
                padding-right: 1.3rem;
                padding-left: 1.3rem;
                font-size:12px;
                border-radius:.3rem !important; 
            }
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
                    <h4 class="styleK">ناردنەکان</h4>
                </div>
            </div>
        </div>
        <hr />
    </section>


    <div class="container">
        <form id="form1" runat="server">

            <div class="form-row ">

                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1">
                    <div class="input-group">
                        <asp:TextBox ID="SearchTextBox" placeholder="..گەران" CssClass="form-control form-control-lg styleK" runat="server" ></asp:TextBox>
                    </div>
                </div>

                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1 text-right">       
                    <asp:Button ID="newButton" CssClass="btn btn-success btn-sm styleK " runat="server" OnClick="newButton_Click" Text="ناردن " />
                </div>
            </div>


            <div class="border p-2">
                <asp:GridView ID="GridView1" runat="server" 
                    CssClass="table table-stripet table-bordered table-hover table-responsive-md text-center">
                    <Columns>
                        <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>

    
    <script>
        function ChangeHeader() {
            var grid = document.getElementById('<%= GridView1.ClientID %>');
            grid.rows[0].cells[1].innerText = 'رەقەم وەسڵ';
            grid.rows[0].cells[2].innerText = 'بۆ مەخزەنی ';
            grid.rows[0].cells[3].innerText = 'لە مەخزەنی';
            grid.rows[0].cells[4].innerText = 'کیڵۆ';
            grid.rows[0].cells[5].innerText = 'کات';
            
            return false;
        }
    </script>

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





