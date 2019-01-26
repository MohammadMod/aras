<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New Invoice.aspx.cs" Inherits="Aras.New_Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>New Invoice</title>
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
    
    <link rel="stylesheet" media="screen" href="https://fontlibrary.org/face/droid-arabic-naskh" type="text/css"/>


    <script src="js/HamaScripts.js"></script>

</head>
<body id="body_newcus">

     
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
                time

          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-6 text-right">
            <h4 class="styleK">وەسڵ</h4>
          </div>
        </div>
      </div>
      <hr>
       </section>

    
    <section class="pt-0 pb-2">
      <div class="container">

            <asp:Label ID="Label1" runat="server" CssClass="alert alert-sm alert-warning alert-dismissible fade show flash" Text="Label"></asp:Label>

        
          
        <div class="border">

            <form id="form1" runat="server">
                
            
                     <div class="col-lg-10 mt-0">
                        <div class="form-group">
                            <label for="Name_resturant"  class="col-form-label styleK">چێشتخانە</label>
                               
                            <asp:DropDownList ID="SelectCustomerDropDownList" CssClass="form-control"
                                runat="server" OnSelectedIndexChanged="SelectCustomerDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                    </div>


                    
                  <div class="col-lg-10 mt-0">
                    <div class="form-group">
                        <label for="Name_resturant" class="col-form-label styleK text-right">جۆری وەسڵ</label>
                        <asp:DropDownList ID="SeriesDropDownList" style="padding-top:0; padding-bottom:0; font-size:12px;"
                            runat="server" CssClass="form-control invois_multK">
                            <asp:ListItem>Name Of Series</asp:ListItem>
                            <asp:ListItem>Name of series return</asp:ListItem>
                        </asp:DropDownList>   
                    </div>
                  </div>


                                        <div class="col-lg-6 mt-0">
                        <div class="form-group">
                            <label for="KiloTextBox" class="col-form-label styleK">کیڵۆ</label>
                            <asp:TextBox ID="KiloTextBox" runat="server" onkeyup="getValues()" CssClass="form-control form-control-lg" required="true"></asp:TextBox>
                        </div>
                    </div>




                    
                 
                    <div class="col-lg-6 mt-0">
                      <div class="form-group">
                          <label for="CostOfKiloTextBox" class="col-form-label styleK"> پارە </label>
                          
                          <asp:TextBox ID="CostOfKiloTextBox" onkeyup="getValues()" runat="server" CssClass="form-control form-control-lg" required ="true"></asp:TextBox>
                      </div>
                    </div>
                   
                    <fieldset disabled>
                        <div class="col-lg-6  mt-0">
                            <div class="form-group">
                                <label for="TotallTextBox" class="col-form-label styleK">گشتی</label>
                                
                                <asp:TextBox ID="TotallTextBox" runat="server" CssClass="form-control form-control-lg" Enabled="False"></asp:TextBox>

                            </div>
                        </div>
                    </fieldset>
                   

                    <div class="col-lg-6 mt-0">
                      <div class="form-group">
                          <label for="DiscountTextBox" class="col-form-label styleK">داشکان </label>
                          <asp:TextBox ID="DiscountTextBox" onkeyup="getValues()" CssClass="form-control form-control-lg" runat="server" required="true"></asp:TextBox>
                      </div>
                    </div>

                    <div class="col-lg-6  mt-0">
                        <fieldset disabled="disabled">
                            <div class="form-group">
                                <label for="TotallAllTextBox" class="col-form-label styleK">كۆی گشتی </label>
                                <asp:TextBox ID="TotallAllTextBox"  CssClass="form-control form-control-lg" Text="0" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>

                    <div class="col-lg-3 col-md-6 col-sm-6  mt-0 pb-3">
                        <div class="form-group">
                            <asp:Button ID="SubmitNewInvoiceButton" Text="درووست کردن" CssClass="btn btn-outline-primary  btn-block styleK" runat="server" OnClick="SubmitNewInvoiceButton_Click" />
                        </div>
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
