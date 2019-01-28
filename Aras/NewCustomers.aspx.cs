using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class NewCustomers : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CreateCustomerButton_Click(object sender, EventArgs e)
        {
            #region Hama Creating new customer
            try
            {
                inD.InsertNewCustomer(CostumerNameTextBox.Text, ResturantNameTextBox.Text, LocationTextBox.Text, PhoneNumberTextBox.Text, float.Parse(MoneyInDeptTextBox.Text), DisablesCheckBox);
                Response.Redirect("Customers.aspx");

            }
            catch (Exception)
            {

                throw;
            }

            #endregion
        }
    }
}
