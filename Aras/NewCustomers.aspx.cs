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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateCustomerButton_Click(object sender, EventArgs e)
        {

            #region Hama Creating new customer
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmd = new SqlCommand("INSERT_CUSTOMER", con);
                con.Open();

                cmd.Parameters.AddWithValue("name", CostumerNameTextBox.Text);
                cmd.Parameters.AddWithValue("resturant_name", ResturantNameTextBox.Text);
                cmd.Parameters.AddWithValue("location", LocationTextBox.Text);
                cmd.Parameters.AddWithValue("phone_namber", PhoneNumberTextBox.Text);
                cmd.Parameters.AddWithValue("credit", float.Parse(MoneyInDeptTextBox.Text));

                if (DisablesCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("disable", "1");
                }

                else
                {
                    cmd.Parameters.AddWithValue("disable", "0");
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("Succece");
            }
            catch (Exception)
            {

                throw;
            }

            #endregion
        }
    }
}
