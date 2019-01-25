using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Aras
{
    public partial class New_Invoice : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        Inserting_Data inD = new Inserting_Data();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            #region Hama reding the customer names form the db to the dropdown list
            try
            {
                Label1.Visible = false;
                if (!IsPostBack)
                {
                    bd.CustomerDropDown(SelectCustomerDropDownList);
                }
            }
            catch (Exception)
            {

                throw;
            }


            #endregion

            DateTimeTextBox.Text = DateTime.Now.ToString();
            DateTimeTextBox.Enabled = false;
        }

        protected void SubmitNewInvoiceButton_Click(object sender, EventArgs e)
        {

            #region Hama this region is for inserting to the database
            try
            {
                inD.InsertToNewInvoice(SeriesDropDownList, SelectCustomerDropDownList, float.Parse(KiloTextBox.Text), float.Parse(CostOfKiloTextBox.Text), Convert.ToDateTime(DateTimeTextBox.Text), float.Parse(DiscountTextBox.Text));
                Response.Redirect("ShowSalesInvoice.aspx");

            }
            catch (Exception)
            {
                Response.Write("Wrong data entered");
                KiloTextBox.Text = "";
                CostOfKiloTextBox.Text = "";
                DiscountTextBox.Text = "";
                TotallTextBox.Text = "";
                TotallAllTextBox.Text = "";
            }

            #endregion


            #region Hama this region is for printing the incoice
                Application["kilo"] = KiloTextBox.Text;
                Application["monyOfKilo"] = CostOfKiloTextBox.Text;
                Application["discount"] = DiscountTextBox.Text;
                Application["total"] = TotallTextBox.Text;
                Application["totalAll"] = TotallAllTextBox.Text;

                // Response.Redirect("Voice Print.aspx");
                #endregion

        }

        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}