using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    
    public partial class NewInvoiceForSupplier : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.SupplierName(SelectCustomerDropDownList);
            }
        }

        protected void SubmitNewInvoiceButton_Click(object sender, EventArgs e)
        {
            inD.InsertToNewInvoice(SeriesDropDownList, SelectCustomerDropDownList, float.Parse(KiloTextBox.Text), float.Parse(CostOfKiloTextBox.Text), DateTime.Now, float.Parse(DiscountTextBox.Text), ChoseWareHouseDropDownList);

        }
    }
}