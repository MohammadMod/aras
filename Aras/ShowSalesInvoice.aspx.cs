using System;
using System.Collections.Generic;
using System.Configuration;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Bind data to ShowSalesInvoice gv
            if (!IsPostBack)
            {
                try
                {
                    bd.showSalesInvoice(ShowSalesInvoicesGridView);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            #endregion

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
    }
}