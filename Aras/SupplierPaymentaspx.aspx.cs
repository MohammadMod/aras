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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!Permit.isAllowed(Permessions.AllUsers))
            //    Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                bd.SupplierName(SelectSupplierDropDownList);

               
            }

        }
        public string moneyInAcc;
        protected void SelectSupplierDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Purchase_invoies_have_no_payment_entry
            try
            {
                try
                {
                    //pishandani waslakani unpaid
                   
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
                }


                //pishandani qardi supplier
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmd = new SqlCommand("Supplier_debit_Show", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("id", SelectSupplierDropDownList.SelectedIndex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MoneyInAccountTextBox.Text = cmd.ExecuteScalar().ToString();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //total all Invoiceakan
                    SqlCommand cmdd = new SqlCommand("All_Debit", con);
                    con.Open();
                    cmdd.Parameters.AddWithValue("supplier", SelectSupplierDropDownList.SelectedItem.Text);
                    cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                    totallAllForInvoicesTextBox.Text = cmdd.ExecuteScalar().ToString();
                    cmdd.ExecuteNonQuery();
                    con.Close();
               
                moneyInAcc = MoneyInAccountTextBox.Text;
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
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
            float para = float.Parse(PayToSupplierTextBox.Text);
            if (CheckBox1.Checked)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                SqlCommand cmdd = new SqlCommand("Update_Supplier_Debit", con);
                con.Open();


                cmdd.Parameters.AddWithValue("Supplier_ID", SelectSupplierDropDownList.SelectedIndex);
                cmdd.Parameters.AddWithValue("para", -para);

                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();


                Response.Redirect("/SupplierPaymentaspx.aspx");
            }
            else
            {
                try
                {
                    //insert remained
                    string dataa = Request.Form[PayPlusInAccountTextBox.UniqueID];
                    string supplierBalance = Request.Form[MoneyInAccountTextBox.UniqueID];

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmd = new SqlCommand("INSERT_payment_entry_for_Purchase", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("Supplier_ID", SelectSupplierDropDownList.SelectedIndex);
                    cmd.Parameters.AddWithValue("Posting_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("Different_amount", float.Parse(dataa));
                    cmd.Parameters.AddWithValue("paray_draw", float.Parse(PayToSupplierTextBox.Text));
                    cmd.Parameters.AddWithValue("party_balanceas", MoneyInAccountTextBox.Text);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();


                    GridViewRow row = GridView1.SelectedRow;
                    string data = Request.Form[PayPlusInAccountTextBox.UniqueID];

                    SqlCommand cmddd = new SqlCommand("Update_purchase_invoce_for_pay", con);
                    con.Open();
                    cmddd.Parameters.AddWithValue("purchase_invoce_ID", int.Parse(row.Cells[1].Text));
                    cmddd.Parameters.AddWithValue("Supplier", SelectSupplierDropDownList.SelectedIndex);
                    cmddd.Parameters.AddWithValue("para", float.Parse(PayToSupplierTextBox.Text));
                    cmddd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmddd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();


                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
                }

                finally
                {
                    Response.Redirect("Show Payment Entry Purchase.aspx");
                }
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
            try
            {
                TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
                string myData = tb.Text;
                PayToSupplierTextBox.Text = myData;
                if (CheckBox1.Checked)
                {
                    GridView1.Visible = false;
                    hideDive.Visible = false;
                }
                else
                {
                    GridView1.Visible = true;
                    hideDive.Visible = true;
                }
            }
            catch (Exception)
            {
               Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
            }
           
        }
    }
}