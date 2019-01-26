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
    public partial class Suppliers : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama reding registerd users info to gridview
            if (!IsPostBack)
            {
                try
                {
                    bd.SupplierGridView(ViewSuppliersGridView);
                    ViewSuppliersGridView.AllowCustomPaging = true;
                    ViewSuppliersGridView.AllowSorting = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }


            #endregion
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewSupplier.aspx");
        }

        protected void ViewSuppliersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ViewSuppliersGridView.EditIndex = e.NewEditIndex;
                bd.SupplierGridView(ViewSuppliersGridView);
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        protected void ViewSuppliersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            #region Hama below codes are for updating values of the suppliers
            try
            {
                int disabled;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                GridViewRow row = (GridViewRow)ViewSuppliersGridView.Rows[e.RowIndex];
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
                ViewSuppliersGridView.EditIndex = -1;
                conn.Open();
                SqlCommand cmd = new SqlCommand("update supplier set name='" + textName.Text + "',company_name='" + companyName.Text + "',	debit='" + Int64.Parse(debitMoney.Text) + "',location='" + Location.Text + "',disable='" + disabled + "',phone_number='" + PhoneNumber.Text + "'where id='" + int.Parse(userID.Text.ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bd.SupplierGridView(ViewSuppliersGridView);
            }
            catch (Exception)
            {

                Response.Write("Invalid data intered Please check the enterd data again");
            }
           
            #endregion

        }

        protected void ViewSuppliersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                ViewSuppliersGridView.PageIndex = e.NewPageIndex;
                bd.SupplierGridView(ViewSuppliersGridView);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        protected void ViewSuppliersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ViewSuppliersGridView.EditIndex = -1;
                bd.SupplierGridView(ViewSuppliersGridView);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        protected void ViewSuppliersGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            bd.SupplierGridView(ViewSuppliersGridView);
        }
    }
}