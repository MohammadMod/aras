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
            Application["status"] = "update";
            GridViewRow gridViewRow = ShowSalesInvoicesGridView.SelectedRow;
            Application["InvoiceName"] = gridViewRow.Cells[2].Text;
            Response.Redirect("Transfer.aspx");
        }

        protected void payment_entry_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CustomerPayment.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            if (DropDownList1.SelectedIndex==1)
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("showInvoices_paid", conn);
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

            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("showInvoices", conn);
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
            if (DropDownList1.SelectedIndex!=1)
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
    }
}