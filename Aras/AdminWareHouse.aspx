<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminWareHouse.aspx.cs" Inherits="Aras.AdminWareHouse" %>

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
    <style>
        @media (max-width: 768px) {
            .btn-sm{
                padding: 9px 11px;
                font-size:11px;
            }
        }
        @media (max-width: 576px) {
            .btn-sm{
                padding: 9px 9px;
                font-size:9px;
            }
        }
        @media (max-width: 420px) {
            .btn-sm{
                padding: 9px 6px;
                font-size:8px;
            }
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
                            <asp:Label ID="UserName" runat="server"></asp:Label>
                                </span>
                            </a>
                            <div class="dropdown-menu dropdown-menu-right " aria-labelledby="userDropdown">
                               
                                <a class="dropdown-item text-right" href="#">
                                    <i class="align-middle mr-1 " data-feather="user"></i>زانیاری زیاتر</a>
                                <a class="dropdown-item text-right " href="#"><i class="align-middle mr-1" data-feather="pie-chart"></i>Analytics</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item text-right" href="/logout">چوونە دەرەوە</a>

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
            <h4 class="styleK">مەخزەنی ئەدمین</h4>
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
                        <asp:TextBox ID="SearchTextBox" CssClass="form-control form-control-lg styleK" placeholder="..گەران" runat="server"></asp:TextBox>

                        <div class="input-group-prepend">

                            <asp:Button ID="SearchButton" CssClass="input-group-text styleK" runat="server" Text="گەران" />
                        </div>
                    </div>
                </div>


                <div class="col-6 col-sm-6 col-md-6 col-lg-6 my-1 text-right">
                    <asp:Button ID="CreateButton"  CssClass="btn btn-success btn-sm styleK" runat="server" Text="دروستکردن" OnClick="CreateButton_Click" />
                    <asp:Button ID="ViewButton" runat="server" CssClass="btn btn-primary btn-sm styleK" data-toggle="modal" data-target="#sizedModalLg" Text="بینین" />
                    <asp:Button ID="EditButton" CssClass="btn btn-warning btn-sm styleK" runat="server" Text="دەستکاری کردن" />
                    <asp:Button ID="DeleteButton" CssClass="btn btn-danger btn-sm styleK" runat="server" Text="رەشکردنەوە" />
                </div>
            </div>

            <div class="border p-3">
                <asp:GridView ID="AdminWareHouseGridView" runat="server" AllowPaging="True" PageSize="5" 
                    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="viewWareHouses" 
                    CssClass="table table-stripet table-bordered table-hover table-responsive-lg text-center " >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbDeleteHeader" runat="server" AutoPostBack="true" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbDelete" runat="server" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="warehouse_name" HeaderText="warehouse_name" SortExpression="warehouse_name" />
                        <asp:CheckBoxField DataField="disabled" HeaderText="disabled" SortExpression="disabled" />
                        <asp:BoundField DataField="phone_no" HeaderText="phone_no" SortExpression="phone_no" />
                        <asp:BoundField DataField="address_line_1" HeaderText="address_line_1" SortExpression="address_line_1" />
                        <asp:BoundField DataField="parent_warehouse_ID" HeaderText="parent_warehouse_ID" SortExpression="parent_warehouse_ID" />
                        <asp:CheckBoxField DataField="is_group" HeaderText="is_group" SortExpression="is_group" />
                 
                    </Columns>
                </asp:GridView>
                
                <asp:SqlDataSource ID="viewWareHouses" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [warehouse]"></asp:SqlDataSource>
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

