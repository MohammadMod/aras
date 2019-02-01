using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class CustomerPayment : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.CustomerDropDown(SelectCustomerDropDownList); 
            }
        }

        public string moneyInAcc;
        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectCustomerDropDownList.SelectedIndex > 0)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmd = new SqlCommand("Customer_debit_Show", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", SelectCustomerDropDownList.SelectedIndex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MoneyInAccountTextBox.Text = "-" + cmd.ExecuteScalar().ToString();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                else
                {
                    Response.Write("please select a supplier");
                }
                moneyInAcc = MoneyInAccountTextBox.Text;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}