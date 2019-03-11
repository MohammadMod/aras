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
            try
            {
                if (Session["username"] != null)  // has user logged in?
                    ;
                else
                    throw new Exception();

            }
            catch
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                //SubmitButton.Enabled = false;
                //ReciveFromSupplierTextBox.Enabled = false;
                bd.CustomerDropDown(SelectCustomerDropDownList); 
            }
        }

        public string moneyInAcc;
        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //unpaid invoices to grid view
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmdaa = new SqlCommand("sales_invoies_have_no_payment_entry", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdaa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //first paramenter: parameter name, second parameter: parameter value of object type
                //using this way you can add more parameters
                da.SelectCommand.Parameters.AddWithValue("customer", SelectCustomerDropDownList.SelectedItem.Text);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception)
            {

                Response.Write("<script language=javascript>alert('No unpaid sales invoices');</script>");
            }
           

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                //pishan dani qarzi mushtari
                SqlCommand cmd = new SqlCommand("Customer_debit_Show", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("Customer_name", SelectCustomerDropDownList.SelectedItem.Text);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MoneyInAccountTextBox.Text = cmd.ExecuteScalar().ToString();
                    cmd.ExecuteNonQuery();
                    con.Close();

           
         
                moneyInAcc = MoneyInAccountTextBox.Text;
            }
            catch (Exception)
            {

                Response.Write("<script language=javascript>alert('Error in using the form ');</script>");
            }

            try
            {
                //pishandani koi gshti waslakan
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmd = new SqlCommand("All_credit", con);
                con.Open();
                cmd.Parameters.AddWithValue("customer", SelectCustomerDropDownList.SelectedItem.Text);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                unpaidTotalAllInvoicesTextBox.Text =  cmd.ExecuteScalar().ToString();
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception)
            {

                Response.Write("<script language=javascript>alert('Please select a supplier ');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gridViewRow = GridView1.SelectedRow;
            string totalAll = gridViewRow.Cells[4].Text.ToString();
            totalAllTextBox.Text = totalAll;
            SubmitButton.Enabled = true;
            ReciveFromSupplierTextBox.Enabled = true;
            updateSalesInvoiceToPay = true;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            float para = float.Parse(ReciveFromSupplierTextBox.Text);
            //para la hisab
            if (CheckBox1.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                    SqlCommand cmdd = new SqlCommand("Update_customer_creidt", con);
                    con.Open();
                    cmdd.Parameters.AddWithValue("Customer_Name", SelectCustomerDropDownList.SelectedItem.Text);
                    cmdd.Parameters.AddWithValue("para", -para);
                    cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                    Response.Redirect("/CustomerPayment.aspx");
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Error in data entered');</script>");
                }
                
            }
            else
            {
                try
                {
                    try
                    {
                        string username =  Session["username"].ToString();

                        string data = Request.Form[RecivePlusInAccountTextBox.UniqueID];
                        string moneyInDibt = Request.Form[MoneyInAccountTextBox.UniqueID];
                        TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
                        string myData = tb.Text;

                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                        #region MyRegion
                        SqlCommand cmd = new SqlCommand("INSERT_payment_entry", con);
                        con.Open();

                        cmd.Parameters.AddWithValue("payment_type", "parawargrtn");
                        cmd.Parameters.AddWithValue("Costomer_ID", SelectCustomerDropDownList.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("posting_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("party_balance", Int64.Parse(myData));
                        cmd.Parameters.AddWithValue("difference_amount", float.Parse(data));
                        cmd.Parameters.AddWithValue("unallocated_amount", float.Parse(ReciveFromSupplierTextBox.Text));
                        cmd.Parameters.AddWithValue("Series", username);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        con.Close();


                       





                        #endregion
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language=javascript>alert('Error in inserting');</script>");
                    }

                    try
                    {
                        //mawa

                        //try
                        //{
                        //    // INSERT_payment_entry refrence mawa
                        //    string myID = "";
                        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                        //    SqlCommand cmd = new SqlCommand("show_payment_entry_ID", con);
                        //    con.Open();
                        //    cmd.Parameters.AddWithValue("customer", SelectCustomerDropDownList.SelectedItem.Text);
                        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //    myID = cmd.ExecuteScalar().ToString();
                        //    cmd.ExecuteNonQuery();
                        //    con.Close();
                        //}
                        //catch (Exception)
                        //{

                        //    throw;
                        //}
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    try
                    {
                        #region update sales invoice where the costumer select invoice

                        //update statues in sales invice
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                        GridViewRow row = GridView1.SelectedRow;

                        SqlCommand cmdd = new SqlCommand("Update_sales_invoice", con);
                        con.Open();


                        cmdd.Parameters.AddWithValue("Sales_invoice_ID", int.Parse(row.Cells[9].Text));
                        cmdd.Parameters.AddWithValue("Customer", SelectCustomerDropDownList.SelectedItem.Text);
                        cmdd.Parameters.AddWithValue("para", float.Parse(ReciveFromSupplierTextBox.Text));


                        cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdd.ExecuteNonQuery();
                        con.Close();
                        GridView1.DataBind();

                        #endregion
                    }
                    catch (Exception)
                    {

                        Response.Write("<script language=javascript>alert('Error in updating the statues');</script>");
                    }

                   


                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
                }
           

            }
            //delete from Sales_invoce where ID=11
            //SqlCommand cmdd = new SqlCommand("delete from Sales_invoce where ID={0}" + int.Parse(gridViewRow.Cells[0].Text), con);
            //con.Open();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
                string myData = tb.Text;
                ReciveFromSupplierTextBox.Enabled = true;
                ReciveFromSupplierTextBox.Text = myData;
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