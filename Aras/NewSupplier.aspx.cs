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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateNewSupplierButton_Click(object sender, EventArgs e)
        {
            #region Hama Creating new Supplier
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());


                SqlCommand cmd = new SqlCommand("INSERT_Supplier", con);

                con.Open();

                cmd.Parameters.AddWithValue("name", SupplierFullNameTextBox.Text);
                cmd.Parameters.AddWithValue("company_name", "Aras");
                cmd.Parameters.AddWithValue("debit", NewSupplierDepitMoneyTextBox.Text);
                cmd.Parameters.AddWithValue("location", SupplierLocationTextBox.Text);

                if (DisableCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("disable", "1");
                }

                else
                {
                    cmd.Parameters.AddWithValue("disable", "0");
                }
                cmd.Parameters.AddWithValue("phone_number", SupplierPhoneNumberTextBox.Text);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();


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