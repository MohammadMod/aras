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
        string UpdateOrNew = "New";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    UpdateOrNew = Application["status"].ToString();

                }
                catch (Exception)
                {

                  
                }
                if (UpdateOrNew !="" && UpdateOrNew=="Update")
                {
                    SupplierFullNameTextBox.Text = Application["name"].ToString();
                    NewSupplierDepitMoneyTextBox.Text = Application["debit"].ToString();
                    SupplierLocationTextBox.Text = Application["location"].ToString();
                    SupplierPhoneNumberTextBox.Text = Application["phone_number"].ToString();
                }
               


            }
        }

        protected void CreateNewSupplierButton_Click(object sender, EventArgs e)
        {


            if (UpdateOrNew == "Update" && UpdateOrNew != "")
            {
                UpdateOrNew = "New";
                Application["status"] = UpdateOrNew;
                string id = Application["id"].ToString();
            }

            else
            {
                #region Hama Creating new Supplier
                try
                {
                    inD.newSupplier(SupplierFullNameTextBox.Text, NewSupplierDepitMoneyTextBox.Text, SupplierLocationTextBox.Text, DisableCheckBox, SupplierPhoneNumberTextBox.Text);
                    Response.Redirect("Suppliers.aspx");

                }
                catch (Exception)
                {

                    throw;
                }

                #endregion
            }


        }
    }
}