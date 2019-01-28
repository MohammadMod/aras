using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class Purchase : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        Inserting_Data inD = new Inserting_Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama Region
            TotallAllTextBox.Enabled = false;
            dateTimeTextBox.Enabled = false;
            dateTimeTextBox.Text = DateTime.Now.ToString();

            if (!IsPostBack)
            {
                bd.SupplierName(ViewSupplierDropDownList);
            }

            //string Name = Application["Name"].ToString();
            //Response.Write("Welcome: " + Name);

            #endregion



        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            inD.InsertPurchase(ViewSupplierDropDownList, dateTimeTextBox.Text, float.Parse(KiloTextBox.Text), float.Parse(CostTextBox.Text),WareHouseSelectDropDownList);
        }
    }
}