<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewInvoiceForSupplier.aspx.cs" Inherits="Aras.NewInvoiceForSupplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/HamaScripts.js"></script>
    <style type="text/css">


.form-control-lg,
.input-group-lg>.form-control,
.input-group-lg>.input-group-append>.btn,
.input-group-lg>.input-group-append>.input-group-text,
.input-group-lg>.input-group-prepend>.btn,
.input-group-lg>.input-group-prepend>.input-group-text {
    padding: 13.6px 16px;
    padding: .85rem 1rem;
}

.form-control {
    font-size: 14px;
    border: 1px solid rgba(170, 170, 170, .3);
    padding: 10.72px 12.8px;
    padding: .67rem .8rem;
}

.form-control,
.form-control:focus {
    outline: none;
    box-shadow: none;
}

.form-control-lg{height:calc(2.2rem + 2px);padding:.35rem 1rem;font-size:1rem;line-height:1.5;border-radius:.3rem}.form-control{transition:none}.form-control{display:block;width:100%;height:calc(1.8125rem + 2px);padding:.25rem .7rem;font-size:.875rem;line-height:1.5;color:#495057;background-color:#fff;background-clip:padding-box;border:1px solid #ced4da;border-radius:.2rem;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out}

.form-control-lg, .input-group-lg > .form-control,
.input-group-lg > .input-group-prepend > .input-group-text,
.input-group-lg > .input-group-append > .input-group-text,
.input-group-lg > .input-group-prepend > .btn,
.input-group-lg > .input-group-append > .btn {
  padding: 0.5rem 1rem;
  font-size: 1.25rem;
  line-height: 1.5;
  border-radius: 0.3rem;
}

.form-control {
  display: block;
  width: 100%;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  color: #495057;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  border-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

*,:after,:before{text-shadow:none!important;box-shadow:none!important}*,:after,:before{box-sizing:border-box}

*, *:before, *:after {
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
}

* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

  *,
  *::before,
  *::after {
    text-shadow: none !important;
    box-shadow: none !important;
  }
  
*,
*::before,
*::after {
  box-sizing: border-box;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            select supplier:
            <asp:DropDownList ID="SelectCustomerDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            chose warehouse:<asp:DropDownList ID="ChoseWareHouseDropDownList" runat="server" DataSourceID="WareHouseName" DataTextField="warehouse_name" DataValueField="warehouse_name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="WareHouseName" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT [warehouse_name] FROM [warehouse]"></asp:SqlDataSource>
            <br />
            <br />
            name of invoice:<asp:DropDownList ID="SeriesDropDownList" runat="server">
                <asp:ListItem>Name Of Invoice</asp:ListItem>
                <asp:ListItem>Name Of Invoice Return</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            kilo:<asp:TextBox ID="KiloTextBox" runat="server" onkeyup="getValues()" CssClass="form-control form-control-lg" required="true"></asp:TextBox>
                        <br />
            <br />
            cost of kilo:<asp:TextBox ID="CostOfKiloTextBox" onkeyup="getValues()" runat="server" CssClass="form-control form-control-lg" required ="true"></asp:TextBox>
                      <br />
            <br />
            total:<asp:TextBox ID="TotallTextBox" runat="server" CssClass="form-control form-control-lg" Enabled="False"></asp:TextBox>

                            <br />
            <br />
            discount:<asp:TextBox ID="DiscountTextBox" onkeyup="getValues()" CssClass="form-control form-control-lg" runat="server" required="true"></asp:TextBox>
                      <br />
            <br />
            total all:<asp:TextBox ID="TotallAllTextBox"  CssClass="form-control form-control-lg" Text="0" runat="server" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:Button ID="SubmitNewInvoiceButton" Text="درووست کردن" CssClass="btn btn-primary  btn-block styleK" runat="server" OnClick="SubmitNewInvoiceButton_Click" />
                        <br />
        </div>
    </form>
</body>
</html>
