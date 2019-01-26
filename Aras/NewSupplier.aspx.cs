using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aras
{
    public partial class NewSupplier : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateNewSupplierButton_Click(object sender, EventArgs e)



        {
            #region Hama Creating new Supplier
            try
            {
                inD.newSupplier(SupplierFullNameTextBox.Text, NewSupplierDepitMoneyTextBox.Text, SupplierLocationTextBox.Text, DisableCheckBox, SupplierPhoneNumberTextBox.Text);
                Response.Redirect("Supp" +
                    "liers.aspx");

            }
            catch (Exception)
            {

                throw;
            }
            #endregion
        }
    }
}