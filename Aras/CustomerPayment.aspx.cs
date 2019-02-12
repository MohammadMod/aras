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
        bool updateSalesInvoiceToPay = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubmitButton.Enabled = false;
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GridView1.SelectedRow;
            string totalAll = gridViewRow.Cells[4].Text.ToString();
            totalAllTextBox.Text = totalAll;
            SubmitButton.Enabled = true;

            updateSalesInvoiceToPay = true;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string data = Request.Form[RecivePlusInAccountTextBox.UniqueID];
                //GridViewRow gridViewRow = GridView1.SelectedRow;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                //SqlCommand cmd = new SqlCommand("INSERT_payment_entry", con);
                //con.Open();

                //cmd.Parameters.AddWithValue("payment_type", "parawargrtn");
                //cmd.Parameters.AddWithValue("Costomer_ID", SelectCustomerDropDownList.SelectedIndex);
                //cmd.Parameters.AddWithValue("posting_date", DateTime.Now);
                //cmd.Parameters.AddWithValue("party_balance", float.Parse(MoneyInAccountTextBox.Text));
                //cmd.Parameters.AddWithValue("difference_amount", float.Parse(data));
                //cmd.Parameters.AddWithValue("unallocated_amount", 0.0);
                //cmd.Parameters.AddWithValue("Series", DBNull.Value);

                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.ExecuteNonQuery();
                //con.Close();

                 #region update sales invoice where the costumer select invoice

                    //update statues in sales invice

                    GridViewRow row = GridView1.SelectedRow;

                    SqlCommand cmdd = new SqlCommand("Update_sales_invoice", con);
                    con.Open();


                    cmdd.Parameters.AddWithValue("Sales_invoice_ID", int.Parse(row.Cells[9].Text));
                    cmdd.Parameters.AddWithValue("Customer", SelectCustomerDropDownList.SelectedIndex);
                    cmdd.Parameters.AddWithValue("para", float.Parse(ReciveFromSupplierTextBox.Text));


                    cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                    #endregion
                
            }
            catch (Exception)
            {

                throw;
            }
          

            //delete from Sales_invoce where ID=11
            //SqlCommand cmdd = new SqlCommand("delete from Sales_invoce where ID={0}" + int.Parse(gridViewRow.Cells[0].Text), con);
            //con.Open();
        }
    }
}