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
    public partial class ShowSalesInvoice : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        SmartDelete Deletor;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        string checkedRow = "";
        protected void Page_Load(object sender, EventArgs e)
        {



            #region Bind data to ShowSalesInvoice gv
            if (!IsPostBack)
            {
                try
                {
                    bd.showSalesInvoice(ShowSalesInvoicesGridView);
                    bd.CustomerDropDown(DropDownList2);


                }
                catch (Exception)
                {

                    throw;
                }

            }
            #endregion
            // HAMA  please enter the name of table here, i dont have access to db
            // the 3 at the end means the ID is located on column number 3
            //string tabelname = "sales_invoice";
            //Deletor = new SmartDelete(this.ShowSalesInvoicesGridView, DeleteButton, tabelname, 3, this);

        }

        protected void NewInvoiceButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("New Invoice.aspx");
        }

        protected void ShowSalesInvoicesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                ShowSalesInvoicesGridView.EditIndex = e.NewEditIndex;
                bd.showSalesInvoice(ShowSalesInvoicesGridView);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ShowSalesInvoicesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            #region Hama below codes are for updating values of the suppliers
            try
            {
                int disabled;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                GridViewRow row = (GridViewRow)ShowSalesInvoicesGridView.Rows[e.RowIndex];
                TextBox textName = (TextBox)row.Cells[1].Controls[0];
                TextBox companyName = (TextBox)row.Cells[2].Controls[0];
                TextBox debitMoney = (TextBox)row.Cells[3].Controls[0];
                TextBox Location = (TextBox)row.Cells[4].Controls[0];
                CheckBox disable = (CheckBox)row.Cells[5].Controls[0];
                TextBox PhoneNumber = (TextBox)row.Cells[6].Controls[0];
                TextBox userID = (TextBox)row.Cells[7].Controls[0];

                if (disable.Checked)
                {
                    disabled = 1;
                }
                else
                {
                    disabled = 0;
                }
                ShowSalesInvoicesGridView.EditIndex = -1;
                conn.Open();
                SqlCommand cmd = new SqlCommand("update supplier set name='" + textName.Text + "',company_name='" + companyName.Text + "',	debit='" + Int64.Parse(debitMoney.Text) + "',location='" + Location.Text + "',disable='" + disabled + "',phone_number='" + PhoneNumber.Text + "'where id='" + int.Parse(userID.Text.ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bd.SupplierGridView(ShowSalesInvoicesGridView);
            }
            catch (Exception)
            {

                Response.Write("Invalid data intered Please check the enterd data again");
            }

            #endregion
        }

        protected void ShowSalesInvoicesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ShowSalesInvoicesGridView.EditIndex = -1;
                bd.showSalesInvoice(ShowSalesInvoicesGridView);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ShowSalesInvoicesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            bd.showSalesInvoice(ShowSalesInvoicesGridView);
        }

        protected void ShowSalesInvoicesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {

                ShowSalesInvoicesGridView.PageIndex = e.NewPageIndex;
                bd.showSalesInvoice(ShowSalesInvoicesGridView);
            }
            catch (Exception)
            {

                throw;
            }
        }





        protected void ShowSalesInvoicesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {


            GridViewRow gridViewRow = ShowSalesInvoicesGridView.SelectedRow;
            Application["salesinvoiceid"] = gridViewRow.Cells[2].Text;
            Response.Redirect("New Invoice.aspx");

        }

        public void viewModal(int id)
        {
            SqlCommand cmd = new SqlCommand("showInvoices_for_update", conn);
            conn.Open();


            cmd.Parameters.AddWithValue("ID", id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {




                Label1.Text = dr[0].ToString();

                Label2.Text = dr[1].ToString();

                Label3.Text = dr[2].ToString();
                Label4.Text = dr[3].ToString();

                Label5.Text = dr[4].ToString();
                Label6.Text = dr[5].ToString();

                Label7.Text = dr[6].ToString();



            }
            dr.Close();

 
        }

        protected void payment_entry_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CustomerPayment.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());



            conn.Open();
            SqlCommand cmd = new SqlCommand("showinvoices_statue", conn);
            if (DropDownList1.SelectedIndex == 0)
            {
                cmd.Parameters.AddWithValue("statue", "unpaid");
            }
            if (DropDownList1.SelectedIndex == 1)
            {
                cmd.Parameters.AddWithValue("statue", "paid");
            }
            if (DropDownList1.SelectedIndex == 2)
            {
                cmd.Parameters.AddWithValue("statue", "close");

            }
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ShowSalesInvoicesGridView.DataSource = ds;
                ShowSalesInvoicesGridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                ShowSalesInvoicesGridView.DataSource = ds;
                ShowSalesInvoicesGridView.DataBind();
                int columncount = ShowSalesInvoicesGridView.Rows[0].Cells.Count;
                ShowSalesInvoicesGridView.Rows[0].Cells.Clear();
                ShowSalesInvoicesGridView.Rows[0].Cells.Add(new TableCell());
                ShowSalesInvoicesGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                ShowSalesInvoicesGridView.Rows[0].Cells[0].Text = "No Records Found";
            }


            DropDownList2.SelectedIndex = 0;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //unpaid invoices to grid view
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            SqlCommand cmdaa = new SqlCommand("showInvoices_customer", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdaa);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //first paramenter: parameter name, second parameter: parameter value of object type
            //using this way you can add more parameters
            da.SelectCommand.Parameters.AddWithValue("customername", DropDownList2.SelectedItem.Text);
            if (DropDownList1.SelectedIndex != 1)
            {
                da.SelectCommand.Parameters.AddWithValue("statue", "unpaid");

            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("statue", "paid");

            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            ShowSalesInvoicesGridView.DataSource = ds;
            ShowSalesInvoicesGridView.DataBind();
        }

        protected void ViewModalButton_Click(object sender, EventArgs e)
        {
            int sid = int.Parse(Application["salesinvoiceid"].ToString());

            SqlCommand cmd1 = new SqlCommand("show_sales_invoce_twaice", conn);
            conn.Open();
            cmd1.Parameters.AddWithValue("@sales_invoice_ID", sid);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                InModalGridView.DataSource = ds;
                InModalGridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                InModalGridView.DataSource = ds;
                InModalGridView.DataBind();
                int columncount = InModalGridView.Rows[0].Cells.Count;
                InModalGridView.Rows[0].Cells.Clear();
                InModalGridView.Rows[0].Cells.Add(new TableCell());
                InModalGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                InModalGridView.Rows[0].Cells[0].Text = "No Records Found";
            }
            conn.Close();

            ViewModalButton.Attributes.Add("onclick", "return false;");



        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("New Invoice.aspx");


        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in ShowSalesInvoicesGridView.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    str = gvrow.Cells[1].Text;

                }
            }
            try
            {
                int sid = int.Parse(str);
                Application["salesinvoiceid"] = str;
                Label8.Text = Application["salesinvoiceid"].ToString();
                viewModal(sid);

            }
            catch (Exception)
            {


            }
            finally
            {
                checkedRow = Application["salesinvoiceid"].ToString();
            }


        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            string id = Application["salesinvoiceid"].ToString();
            bool hasPayment = false;
            try
            {
                DataSet ds = new DataSet("TimeRanges");

                SqlCommand sqlComm = new SqlCommand("Show_ID_payment_for_delete_invocie", conn);
                sqlComm.Parameters.AddWithValue("@Slaes_invoice_ID", int.Parse(id));

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);



                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        int Contract_id = Convert.ToInt32(ds.Tables[0].Rows[i]["Pyment_entry_ID"]);

                        SqlCommand cmd1 = new SqlCommand("delete_Payment_entry", conn);
                        conn.Open();
                        cmd1.Parameters.AddWithValue("@Payment_entry_ID", Contract_id);
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                        hasPayment = true;

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }






            SqlCommand cmd = new SqlCommand("delete_Sales_invoice", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Sales_invoce_ID", int.Parse(id));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("ShowSalesInvoice.aspx");
        }
    } 
}


