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

            if (!Permit.isAllowed(Permessions.AllUsers))
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                bd.SupplierName(SelectSupplierDropDownList);
                MoneyInAccountTextBox.Enabled = true;
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
            //insert remained
            string dataa = Request.Form[PayPlusInAccountTextBox.UniqueID];
            string supplierBalance = MoneyInAccountTextBox.Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            SqlCommand cmd = new SqlCommand("INSERT_payment_entry_for_Purchase", con);
            con.Open();
            cmd.Parameters.AddWithValue("Supplier_ID", SelectSupplierDropDownList.SelectedIndex);
            cmd.Parameters.AddWithValue("Posting_date", DateTime.Now);
            cmd.Parameters.AddWithValue("Different_amount", float.Parse(dataa));
            cmd.Parameters.AddWithValue("paray_draw", float.Parse(PayToSupplierTextBox.Text));
            cmd.Parameters.AddWithValue("party_balanceas", float.Parse(supplierBalance));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();

            if (CheckBox1.Checked)
            {
                GridViewRow row = GridView1.SelectedRow;
                string data = Request.Form[PayPlusInAccountTextBox.UniqueID];

                SqlCommand cmdd = new SqlCommand("Update_Supplier_Debit", con);
                con.Open();
                cmdd.Parameters.AddWithValue("Supplier_ID", SelectSupplierDropDownList.SelectedIndex);
                cmdd.Parameters.AddWithValue("para", float.Parse(PayToSupplierTextBox.Text));
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();

            }
            else
            {
            GridViewRow row = GridView1.SelectedRow;
            string data = Request.Form[PayPlusInAccountTextBox.UniqueID];

            SqlCommand cmddd = new SqlCommand("Update_purchase_invoce_for_pay", con);
            con.Open();
            cmddd.Parameters.AddWithValue("purchase_invoce_ID", int.Parse(row.Cells[1].Text));
            cmddd.Parameters.AddWithValue("Supplier", SelectSupplierDropDownList.SelectedIndex);
            cmddd.Parameters.AddWithValue("para",float.Parse(PayToSupplierTextBox.Text));
            cmddd.CommandType = System.Data.CommandType.StoredProcedure;
            cmddd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GridView1.SelectedRow;
            string totalAmount = gridViewRow.Cells[4].Text.ToString();
            totalAllTextBox.Text = totalAmount;

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
            //string myData = tb.Text;
            //myData = myData.Remove(0, 2);

            //PayToSupplierTextBox.Text = myData;
        }
    }
}