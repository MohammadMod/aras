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
        string payment_entry_id;
        static string bil_no = "";
        static string total_amount = "";
        public string moneyInAcc;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!Permit.isAllowed(Permessions.AllUsers))
            //    Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                bd.SupplierName(SelectSupplierDropDownList);
            }

        }
        protected void SelectSupplierDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Purchase_invoies_have_no_payment_entry
            try
            {
                try
                {
                    //pishandani waslakani unpaid

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmdaa = new SqlCommand("Purchase_invoies_have_no_payment_entry", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmdaa);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@supplier", SelectSupplierDropDownList.SelectedItem.Text);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            float para = float.Parse(PayToSupplierTextBox.Text);
            if (CheckBox1.Checked)
            {

                SqlCommand cmdd1 = new SqlCommand("Update_Supplier_Debit", con);
                con.Open();


                cmdd1.Parameters.AddWithValue("Supplier_ID", SelectSupplierDropDownList.SelectedIndex);
                cmdd1.Parameters.AddWithValue("para", para);

                cmdd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd1.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();


                Response.Redirect("/SupplierPaymentaspx.aspx");
            }
            try
            {
                #region Inserting

                string dataa = Request.Form[PayPlusInAccountTextBox.UniqueID];
                string supplierBalance = Request.Form[MoneyInAccountTextBox.UniqueID];

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



                string data = Request.Form[PayPlusInAccountTextBox.UniqueID];

                SqlCommand cmddd = new SqlCommand("Update_purchase_invoce_for_pay", con);
                con.Open();
                cmddd.Parameters.AddWithValue("purchase_invoce_ID", 1005);
                cmddd.Parameters.AddWithValue("Supplier", SelectSupplierDropDownList.SelectedItem.Text);
                cmddd.Parameters.AddWithValue("para", float.Parse(PayToSupplierTextBox.Text));
                cmddd.CommandType = System.Data.CommandType.StoredProcedure;
                cmddd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();


                TextBox tbb = this.Page.FindControl("totallAllForInvoicesTextBox") as TextBox;
                string myDataa = tbb.Text;



                float paray_draw = float.Parse(PayToSupplierTextBox.Text);
                float total_la_wasl = float.Parse(total_amount);

                float outstanding_amount = total_la_wasl - paray_draw;


                //show payment entry id
                SqlCommand cmdddd = new SqlCommand("show_payment_entry_for_purchase_ID", con);
                con.Open();
                cmdddd.Parameters.AddWithValue("@Supplier", SelectSupplierDropDownList.SelectedItem.Text);
                cmdddd.CommandType = System.Data.CommandType.StoredProcedure;
                payment_entry_id = cmdddd.ExecuteScalar().ToString();
                cmdddd.ExecuteNonQuery();
                con.Close();

                Response.Write(payment_entry_id);


                SqlCommand cmdd = new SqlCommand("INSERT_payment_entry_refrence_Purchase", con);
                con.Open();

                cmdd.Parameters.AddWithValue("refrence_name", "purchase invoice");
                cmdd.Parameters.AddWithValue("bill_no", bil_no);
                cmdd.Parameters.AddWithValue("totall_amount", float.Parse(total_amount));
                cmdd.Parameters.AddWithValue("paray_draw", outstanding_amount);
                cmdd.Parameters.AddWithValue("payment_entry_for_purchase_ID", payment_entry_id);

                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd.ExecuteNonQuery();
                con.Close();





                SqlCommand cmdd2 = new SqlCommand("INSERT_purchase_invoce_advance_pyment", con);
                con.Open();

                cmdd2.Parameters.AddWithValue("@Pyment_enrty_ID", payment_entry_id);
                cmdd2.Parameters.AddWithValue("@Purchase_invoice_ID", bil_no);
                cmdd2.Parameters.AddWithValue("@remark", "Note");
                cmdd2.Parameters.AddWithValue("@advance_amount", float.Parse(PayToSupplierTextBox.Text));
                cmdd2.Parameters.AddWithValue("@User_name", "user name");

                cmdd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd2.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Show Payment Entry Purchase.aspx");

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
           



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GridView1.SelectedRow;

            string totalAmount = gridViewRow.Cells[6].Text.ToString();
            totalAllTextBox.Text = totalAmount;
            bil_no = gridViewRow.Cells[1].Text.ToString();
            total_amount = gridViewRow.Cells[6].Text.ToString();

        }
    }
}