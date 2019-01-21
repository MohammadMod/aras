<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUsers.aspx.cs" Inherits="Aras.RegisterUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>he</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/app.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/default-css.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/metisMenu.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link href="css/slicknav.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/styleee.css" rel="stylesheet" />
    <link href="css/themify-icons.css" rel="stylesheet" />
    <link href="css/typography.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-area" runat="server">
        <div class="container">
            <div class="login-box-register ptb--100">
                </div>
                    <div class="login-form-body">
                        <div class="form-gp">
                            <label for="InputName">ناو</label>
                            <asp:TextBox ID="InputName" runat="server"></asp:TextBox>
                            <i class="ti-user"></i>
                        </div>

                        <div class="form-gp">
                            <label for="InputLast">ناوی باوکی</label>                            
                            <asp:TextBox ID="InputLast" runat="server" ></asp:TextBox>
                            <i class="ti-user"></i>
                        </div>
                        
                        <div class="form-gp">
                            <label for="InputPhone">ژمارەی موبایل</label>                            
                            <asp:TextBox ID="InputPhone" runat="server" ></asp:TextBox>
                            <i class="fa fa-mobile-phone"></i>
                        </div>
                        
                        <div class="form-gp">
                            <label for="InputLoca">شوێنی نشتەجێبوون</label>
                            <asp:TextBox ID="InputLoca" runat="server" ></asp:TextBox>
                            <i class="ti-location-pin"></i>
                        </div>

                        <div class="form-gp">
                            <label for="exampleInputFullN">ناوی تەواوی</label>
                            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                            <i class="ti-user"></i>
                        </div>

                        <div class="form-gp">
                            <label for="InputPassword">ژمارەی نهێنی</label>
                            <asp:TextBox ID="InputPassword" type="password" runat="server" ></asp:TextBox>
                            <i class="ti-lock">
                            
                            </i>
                        </div>

                        <br />
                            <br />
                            Admin:
                            <asp:CheckBox ID="CheckBox1" runat="server" />

                        <div class="submit-btn-area">
                            <%--<asp:Button ID="Button1" CssClass="btnn" type="submit" Text="تۆمارکردن" runat="server" OnClick="Button1_Click" />--%>
                        </div>

                    </div>
                
            </div>
    </div>
    </form>
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
