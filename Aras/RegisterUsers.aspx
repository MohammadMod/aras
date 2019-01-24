 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUsers.aspx.cs" Inherits="Aras.RegisterUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Register</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/metisMenu.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link href="css/slicknav.min.css" rel="stylesheet" />
    <link href="css/themify-icons.css" rel="stylesheet" />
    <link href="css/typography.css" rel="stylesheet" />
    <link href="css/default-css.css" rel="stylesheet" />
    
    <link rel="stylesheet" href="https://www.amcharts.com/lib/3/plugins/export/export.css" type="text/css" media="all" />
    <link href="css/styleee.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <script src="js/vendor/modernizr-2.8.3.min.js"></script>
</head>

<body id="body_LR">
        <div class="login-area" runat="server">

            <div class="containerd">
                <div class="login-box ptb--100">
                    <form id="form1" runat="server">
                
                        <div class="regis-form-head">
                                <h4>تۆمارکردن </h4>
                        </div>

                        <div class="login-form-body">
                            <div class="form-gp">
                                <label for="FullNameTextBox">ناو</label>
                                 <asp:TextBox ID="FullNameTextBox" runat="server" required="true"></asp:TextBox>
                                <i class="ti-user"></i>
                            </div>

                            <div class="form-gp">
                                <label for="UserNameTextBox">ناوی تەواوی</label>
                                <asp:TextBox ID="UserNameTextBox" runat="server" required="true" ></asp:TextBox>
                                <i class="ti-user"></i>
                            </div>

                            <div class="form-gp">
                                <label for="PasswordTextBox">ژمارەی نهێنی</label>
                                <asp:TextBox ID="PasswordTextBox" type="password" runat="server" required="true"></asp:TextBox>
                                <i class="ti-lock">    
                                </i>
                            </div>

                        
                            <div class="form-gp">
                                <label for="PhoneTextBox">ژمارەی موبایل</label>    
                                <asp:TextBox ID="PhoneTextBox" runat="server" required="true"></asp:TextBox>
                                <i class="ti-mobile"></i>
                            </div>

                             <div class="form-gp">
                                <label for="LocationTextBox">شوێنی نشتەجێبوون</label>
                                <asp:TextBox ID="LocationTextBox" runat="server" required="true"></asp:TextBox>
                                <i class="ti-location-pin"></i>
                            </div>

                            <div class="form-gps">
                                <label for="AdminCheckBox">ئەدمین</label>
                                <asp:CheckBox ID="AdminCheckBox" runat="server"  />
                                <%--<i class="ti-lock">    
                                </i>--%>
                            </div>
                            

                            <div class="submit-btn-area">
                                 <asp:Button ID="RegisterButton" runat="server" CssClass="btnn" type="submit" Text="تۆمارکردن"  OnClick="RegisterButton_Click" />
                            </div>

                        </div>
                    </form>
                </div>
            </div>
      </div>

       
       
       
       
       
        
   


    <script src="js/app.js"></script>
    <script src="js/bar-chart.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.slicknav.min.js"></script>
    <script src="js/jquery.slimscroll.min.js"></script>
    <script src="js/line-chart.js"></script>
    <script src="js/maps.js"></script>
    <script src="js/metisMenu.min.js"></script>
    <script src="js/myScripts.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/pie-chart.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/scripts.js"></script>
    </body>
</html>
