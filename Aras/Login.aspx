ad<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aras.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Login</title>    
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
    
    <link rel="stylesheet" href="https://www.amcharts.com/lib/3/plugins/export/export.css" type="text/css" media="all" />

    <link href="css/style.css" rel="stylesheet" />
    <link href="css/styleee.css" rel="stylesheet" />
    <script src="js/vendor/modernizr-2.8.3.min.js"></script>
    <style>
        .submit-btn-area .btnn {
        width: 100%;
        height: 50px;
        border: none;
        background: #fff;
        color: #585b5f;
        border-radius: 40px;
        text-transform: uppercase;
        letter-spacing: 0;
        font-weight: 600;
        font-size: 12px;
        box-shadow: 0 0 22px rgba(0, 0, 0, 0.07);
        -webkit-transition: all 0.3s ease 0s;
        transition: all 0.3s ease 0s;
    }

        .submit-btn-area .btnn:hover {
            background: #2c71da;
            color: #ffffff;
        }
    </style>
</head>

<body id="body_LR"> 
    <div class="login-area" >
        <div class="container">
            <div class="login-box ptb--100">
                <form  runat="server">
                    <div class="login-form-head">
                        <h4>داخیل بوون</h4>
                    </div>

                    <div class="login-form-body">
                        <div class="form-gp">
                            <label for="UserNameTextBox">ناوی بەکارهێنەر</label>
                            <i class="ti-user"></i>
                           <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>

                        </div>

                        <div class="form-gp">
                            <label for="PasswordTextBox">ژمارەی نهێنی</label>
                            <i class="ti-lock"></i>
                            <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <asp:CheckBox ID="ReminderCheck" CssClass=""  runat="server" Text=" لەبیرم مەکە ! " />    
                        <br />
                        <br />
                        <div class="submit-btn-area">    
                             <asp:Button ID="LoginButton" runat="server" CssClass="btnn" type="submit"  Text="داخیل بوون"  OnClick="LoginButton_Click" />
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
