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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        BindingData bd = new BindingData();
        bool updateSalesInvoiceToPay = false;
        string username = "";
        string payment_entry_id;
        string edit = "";
        bool check = false;
        string myData = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //try
                //{
                //    if (Session["username"] != null)  // has user logged in?
                //        ;
                //    else
                //        throw new Exception();
                //    username = Session["username"].ToString();

                //}
                //catch
                //{
                //    Response.Redirect("Login.aspx");
                //}

                try
                {
                    edit = Application["paymentid"].ToString();
                    Application["paymentid"] = "";

                    //SqlCommand cmd = new SqlCommand("show_payment_refrence_for_update", conn);
                    //conn.Open();


                    //cmd.Parameters.AddWithValue("@Payment_entry_ID", Int64.Parse(edit));
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //SqlDataReader dr = cmd.ExecuteReader();
                    //dr.Read();
                    //if (dr.HasRows)
                    //{

                    //    //SelectCustomerDropDownList.SelectedValue = dr[1].ToString();
                    //    //totalAllTextBox.Text = dr[5].ToString();

                    //    SqlDataAdapter da = new SqlDataAdapter("select * from  Your TableName", conn);
                    //    DataSet ds = new DataSet();
                    //    try
                    //    {
                    //        da.Fill(ds, "YourTableName");
                    //        GridView1.DataSource = ds;
                    //        GridView1.DataBind();
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Response.Write(e.Message);
                    //    }
                    //    finally
                    //    {
                    //        ds.Dispose();
                    //        da.Dispose();
                    //        con.Dispose();
                    //    }
                    //dr.Close();

                    //

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmdaa = new SqlCommand("show_payment_refrence_for_update", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmdaa);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //first paramenter: parameter name, second parameter: parameter value of object type
                    //using this way you can add more parameters
                    da.SelectCommand.Parameters.AddWithValue("@Payment_entry_ID", Int64.Parse(edit));
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();


                    //
                }
                catch (Exception)
                {

                    check = true;
                }

                //update
                if (check == false)
                {
                    SubmitButton.Enabled = false;
                    Button1.Enabled = true;

                    SubmitButton.Visible = false;
                    Button1.Visible = true;

                    //GridView1.Enabled = false;

                }

                //new
                else
                {

                    SubmitButton.Enabled = true;
                    Button1.Enabled = false;

                    SubmitButton.Visible = true;
                    Button1.Visible = false;

                    //GridView1.Enabled = true;

                }

                conn.Close();


                //SubmitButton.Enabled = false;
                //ReciveFromSupplierTextBox.Enabled = false;
                try
                {
                    bd.CustomerDropDown(SelectCustomerDropDownList);
                }
                catch (Exception)
                {

                    
                }

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


                    TextBox tbb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
                    string myDataa = tbb.Text;
                    SqlCommand cmd = new SqlCommand("insert_to_pay_to_account", con);

                    con.Open();

                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("depit_amount", Int64.Parse(myDataa));
                    cmd.Parameters.AddWithValue("recieved_amount", Int64.Parse(ReciveFromSupplierTextBox.Text));
                    cmd.Parameters.AddWithValue("resturant_name", SelectCustomerDropDownList.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("date", DateTime.Now.Date);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();

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
                    GridViewRow row1 = GridView1.SelectedRow;
                    string totalInInvoice = row1.Cells[4].Text;

                    string data = Request.Form[RecivePlusInAccountTextBox.UniqueID];

                    string moneyInDibt = Request.Form[MoneyInAccountTextBox.UniqueID];
                    TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
                    myData = tb.Text;
                    float diffrent_amount = float.Parse(ReciveFromSupplierTextBox.Text);
                    float difrint = 0;
                    difrint = diffrent_amount - float.Parse(totalInInvoice);

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    #region MyRegion
                    SqlCommand cmd = new SqlCommand("INSERT_payment_entry", con);
                    con.Open();

                    cmd.Parameters.AddWithValue("payment_type", "parawargrtn");
                    cmd.Parameters.AddWithValue("Costomer_ID", SelectCustomerDropDownList.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("posting_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("party_balance", Int64.Parse(myData));
                    cmd.Parameters.AddWithValue("difference_amount",Math.Abs(difrint));
                    cmd.Parameters.AddWithValue("unallocated_amount", float.Parse(ReciveFromSupplierTextBox.Text));
                    cmd.Parameters.AddWithValue("Series", username);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();

                   


                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Error in inserting to payment entry ');</script>");

                }

                #region insert payment entry refrence
                try
                {
                    TextBox tbb = this.Page.FindControl("totalAllTextBox") as TextBox;
                    string myDataa = tbb.Text;

                    GridViewRow row2 = GridView1.SelectedRow;

                    string bil_no = row2.Cells[9].Text.ToString();
                    string total_amount = row2.Cells[4].Text.ToString();

                    float paray_draw = float.Parse(ReciveFromSupplierTextBox.Text);
                    float total_la_wasl = float.Parse(total_amount);

                    float outstanding_amount = total_la_wasl - paray_draw;

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                    //show payment entry id
                    SqlCommand cmddd = new SqlCommand("show_payment_entry_ID", con);
                    con.Open();
                    cmddd.Parameters.AddWithValue("customer_Name", SelectCustomerDropDownList.SelectedItem.Text);
                    cmddd.CommandType = System.Data.CommandType.StoredProcedure;
                    payment_entry_id = cmddd.ExecuteScalar().ToString();
                    cmddd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmdd = new SqlCommand("INSERT_payment_entry_refrence", con);
                    con.Open();

                    cmdd.Parameters.AddWithValue("refrence_name", "sales invoice");
                    cmdd.Parameters.AddWithValue("bill_no", bil_no);
                    cmdd.Parameters.AddWithValue("totall_amount", float.Parse(total_amount));
                    cmdd.Parameters.AddWithValue("allocated_amount", float.Parse(ReciveFromSupplierTextBox.Text));
                    cmdd.Parameters.AddWithValue("outstanding_amount", outstanding_amount);
                    cmdd.Parameters.AddWithValue("Pyment_entry_ID", payment_entry_id);

                    cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdd.ExecuteNonQuery();
                    con.Close();

                    
                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('Error in inserting to payment entry refrence ');</script>");
                }
                GridViewRow row = GridView1.SelectedRow;
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                   
                    string salesInvoiceID = "";
                    salesInvoiceID = row.Cells[9].Text;
                    SqlCommand cmdd1 = new SqlCommand("Insert_sales_invoice_advance_payment",con);
                    con.Open();
                    cmdd1.Parameters.AddWithValue("@Pyment_entry_ID", payment_entry_id);
                    cmdd1.Parameters.AddWithValue("@remark", Convert.ToString(DateTime.Now));
                    cmdd1.Parameters.AddWithValue("@advanced_amount", float.Parse(ReciveFromSupplierTextBox.Text));
                    cmdd1.Parameters.AddWithValue("@User_name", username);
                    cmdd1.Parameters.AddWithValue("@sales_invoice_ID", int.Parse(salesInvoiceID));

                    cmdd1.CommandType = CommandType.StoredProcedure;
                    cmdd1.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {

                    throw;
                }




                #endregion

              


                #region update sales invoice where the costumer select invoice
                try
                {
                    //update statues in sales invice
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                    GridViewRow roww = GridView1.SelectedRow;

                    SqlCommand cmdddd = new SqlCommand("Update_sales_invoice", con);
                    con.Open();


                    cmdddd.Parameters.AddWithValue("Sales_invoice_ID", int.Parse(roww.Cells[9].Text));
                    cmdddd.Parameters.AddWithValue("Customer", SelectCustomerDropDownList.SelectedItem.Text);
                    cmdddd.Parameters.AddWithValue("para", float.Parse(ReciveFromSupplierTextBox.Text));


                    cmdddd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdddd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    throw;
                    Response.Write("<script language=javascript>alert('Error in updating sales invoice ');</script>");
                }
               

                        #endregion
                    

                   


                
             
           

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string customer = SelectCustomerDropDownList.SelectedItem.Value.ToString();

            GridViewRow row = GridView1.SelectedRow;
            string totalInInvoice = row.Cells[4].Text;
            string id = row.Cells[9].Text;
            string data = Request.Form[RecivePlusInAccountTextBox.UniqueID];

            string moneyInDibt = Request.Form[MoneyInAccountTextBox.UniqueID];
            TextBox tb = this.Page.FindControl("MoneyInAccountTextBox") as TextBox;
            myData = tb.Text;
            float diffrent_amount = float.Parse(ReciveFromSupplierTextBox.Text);
            float difrint = 0;
            difrint = diffrent_amount - float.Parse(totalInInvoice);


            //Response.Write("Costumer=" + customer + "" + "warehouse=" + warehouse + "" + "rate=" + rate + "" + "amount=" + amount + "" + "discount=" + discount + "" + "total=" + total + "" + "total_All=" + TotallAllTextBox + "" + "ID=" + id + "");

            SqlCommand cmd = new SqlCommand("[Update_payment_entry_Up]", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            conn.Open();
            cmd.Parameters.Add("@payment_type", SqlDbType.NVarChar).Value = "Edit Parawargrtn";
            cmd.Parameters.Add("@Costomer_ID", SqlDbType.NVarChar).Value = customer;
            cmd.Parameters.Add("@party_balance", SqlDbType.Float).Value = myData;
            cmd.Parameters.Add("@difference_amount", SqlDbType.Float).Value = difrint;
            cmd.Parameters.Add("@unallocated_amount", SqlDbType.Float).Value = ReciveFromSupplierTextBox.Text;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(id);
            cmd.Parameters.Add("@Series", SqlDbType.VarChar).Value = username;
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("ShowSalesInvoice.aspx");
        }
    }
}
#endregion