<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUsers.aspx.cs" Inherits="Aras.RegisterUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                            <br />
                            <br />
                            Admin:
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            </i>
                        </div>

                        <div class="submit-btn-area">
                            <asp:Button ID="Button1" CssClass="btnn" type="submit" Text="تۆمارکردن" runat="server" OnClick="Button1_Click" />
                        </div>

                    </div>
                
            </div>
    </div>
    </form>
</body>
</html>
