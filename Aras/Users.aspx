<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Aras.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>users</title>

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
            border-radius:.6rem !important;
        }
        @media (max-width: 768px) {
            .btn-sm{
                padding: 9px 11px;
                font-size:11px;
                border-radius:.8rem !important; 
            }
        }
        @media (max-width: 576px) {
            .btn-sm{
                padding: 9px 9px;
                font-size:9px;
                border-radius:.6rem !important; 

            }
        }
        @media (max-width: 450px) {
            .btn-sm{
                padding: 8px 7px;
                font-size:8px;
                border-radius:.4rem !important; 
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
            <h4 class="styleK">شوفێرەکان</h4>
          </div>
        </div>
      </div>
      <hr/>
    </section>


    <form id="form1" runat="server">
        <div class="container">

            <div class="form-row ">

                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1">
                    <div class="input-group">
                        <asp:TextBox ID="SearchTextBox" placeholder="..گەران" CssClass="form-control form-control-lg styleK" runat="server" onkeyup="Search_Gridview(this, 'ViewUsersGridView')"></asp:TextBox>
                        <div class="input-group-prepend">
                            <asp:Button ID="SearchButton" CssClass="input-group-text styleK" Text="گەران" runat="server" />

                        </div>
                    </div>
                </div>


                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1 text-right">


                    <asp:Button ID="CreateButton" CssClass="btn btn-success btn-sm styleK" Text="دروستکردن" runat="server" OnClick="CreateButton_Click" />
                    <asp:Button ID="ViewButton" runat="server" CssClass="btn btn-primary btn-sm styleK" data-toggle="modal" data-target="#sizedModalLg" Text="بینین" OnClick="ViewButton_Click" />

                    <asp:Button ID="EditButton" CssClass="btn btn-warning btn-sm styleK" runat="server" Text="دەستکاری کردن" OnClick="Edit_Click" />
                    <asp:Button ID="DeleteButton" CssClass="btn btn-danger btn-sm styleK" runat="server" Text="رەشکردنەوە" />

                </div>
            </div>


            <div class="border p-3">
                <asp:GridView ID="ViewUsersGridView" runat="server" OnRowCancelingEdit="ViewUsersGridView_RowCancelingEdit"
                    OnRowEditing="ViewUsersGridView_RowEditing" OnRowUpdating="ViewUsersGridView_RowUpdating" 
                    AllowSorting="True" OnPageIndexChanging="ViewUsersGridView_PageIndexChanging" OnSorted="ViewUsersGridView_Sorted"
                    OnSorting="ViewUsersGridView_Sorting" 
                    CssClass="table table-stripet table-bordered table-hover table-responsive-md text-center " OnSelectedIndexChanged="ViewUsersGridView_SelectedIndexChanged">
                    <Columns>
                         <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbDeleteHeader" runat="server" AutoPostBack="True" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>

        <%-- Modal --%>
        <div class="modal fade" id="sizedModalLg" tabindex="-1" role="dialog" aria-hidden="true" runat="server">
        <div class="modal-dialog modal-md" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title text-center">بینینی پسولەی فرۆشتن</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            </div>
              <div class="modal-body m-3" runat="server">
                  <div class="container-fluid text-center">

                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              رەقەم وەسڵ
                          </div>
                      </div>

                      <div class="row border">

                          <div class="col-8  ">
                              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK ">
                              ناوی جیشتخانە
                          </div>
                      </div>
                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              مەخزەن
                          </div>
                      </div>
                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              کیلۆ
                          </div>
                      </div>


                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              پارەی یەک کیڵۆ
                          </div>
                      </div>


                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              گشتی
                          </div>
                      </div>

                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              داشکان
                          </div>
                      </div>

                      <div class="row border">
                          <div class="col-8">
                              <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                          </div>
                          <div class="col-4 styleK">
                              کۆی گشتی
                          </div>
                      </div>

                      
                  </div>

              </div>
            <div class="modal-footer">

                <asp:Button ID="PrintButton" class="btn btn-warning" runat="server" Text="Print" />
                <asp:Button ID="Edit" runat="server" CssClass="btn btn-info btn-sm styleK" Text="دەستکاری کردن" OnClick="Edit_Click" />   
                <asp:Button ID="Button1" CssClass="btn btn-danger btn-sm styleK" runat="server" Text="رەشکردنەوە" />

            </div>
          </div>
        </div>
                    </div>

        <%-- End Modal --%>
    
    
    <script>
        function ChangeHeader() {
            var grid = document.getElementById('<%= ViewUsersGridView.ClientID %>');
            grid.rows[0].cells[1].innerText = 'ناو';
            grid.rows[0].cells[2].innerText = 'کۆتا ناو';
            grid.rows[0].cells[3].innerText = 'رەقەم موبایڵ';
            grid.rows[0].cells[4].innerText = 'شوێن';
            grid.rows[0].cells[5].innerText = 'ناوی تەواوی';
            grid.rows[0].cells[6].innerText = 'وشەی نهێنی';
            grid.rows[0].cells[7].innerText = 'ئای دی';
            grid.rows[0].cells[8].innerText = 'ئەدمین';

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
        
    </form>
    
    
    </body>
</html>
