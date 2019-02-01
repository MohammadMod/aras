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
    public partial class SupplierPaymentaspx : System.Web.UI.Page
    {
        BindingData bd = new BindingData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.SupplierName(SelectSupplierDropDownList);
            }

        }
        public string moneyInAcc;
        protected void SelectSupplierDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectSupplierDropDownList.SelectedIndex > 0)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmd = new SqlCommand("Supplier_debit_Show", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", SelectSupplierDropDownList.SelectedIndex);
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

        protected void PayToSupplierTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        protected void PayPlusInAccountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoneyInAccountTextBox.Text = "";
            GridViewRow gridViewRow = GridView1.SelectedRow;

            string totalAmount = gridViewRow.Cells[3].ToString();

            MoneyInAccountTextBox.Text = totalAmount;
        }
    }
}