using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aras
{
    public class BindingData
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        #region Hama Bind Data to ViewSupplierGridView
        //this method is for binding data from db to ViewSupplierGridView
        public void SupplierGridView(GridView ViewSuppliersGridView)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from supplier", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewSuppliersGridView.DataSource = ds;
                    ViewSuppliersGridView.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ViewSuppliersGridView.DataSource = ds;
                    ViewSuppliersGridView.DataBind();
                    int columncount = ViewSuppliersGridView.Rows[0].Cells.Count;
                    ViewSuppliersGridView.Rows[0].Cells.Clear();
                    ViewSuppliersGridView.Rows[0].Cells.Add(new TableCell());
                    ViewSuppliersGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                    ViewSuppliersGridView.Rows[0].Cells[0].Text = "No Records Found";
                }
                ViewSuppliersGridView.AllowPaging = true;
                ViewSuppliersGridView.AllowSorting = true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion



        #region Hama Bind Data from db to users gridview in users form
        public void UsersGridView(GridView ViewUsersGridView)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from regester_table", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewUsersGridView.DataSource = ds;
                    ViewUsersGridView.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ViewUsersGridView.DataSource = ds;
                    ViewUsersGridView.DataBind();
                    int columncount = ViewUsersGridView.Rows[0].Cells.Count;
                    ViewUsersGridView.Rows[0].Cells.Clear();
                    ViewUsersGridView.Rows[0].Cells.Add(new TableCell());
                    ViewUsersGridView.Rows[0].Cells[0].ColumnSpan = columncount;
                    ViewUsersGridView.Rows[0].Cells[0].Text = "No Records Found";
                }
                ViewUsersGridView.AllowPaging = true;
                ViewUsersGridView.AllowSorting = true;
            }
            catch (Exception)
            {

                throw;
            }
               
         
           
        }
        #endregion



        #region Bind Data to show sales invoice 

        public void showSalesInvoice(GridView showSalesInvoice)
        {
            try
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
                    showSalesInvoice.DataSource = ds;
                    showSalesInvoice.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    showSalesInvoice.DataSource = ds;
                    showSalesInvoice.DataBind();
                    int columncount = showSalesInvoice.Rows[0].Cells.Count;
                    showSalesInvoice.Rows[0].Cells.Clear();
                    showSalesInvoice.Rows[0].Cells.Add(new TableCell());
                    showSalesInvoice.Rows[0].Cells[0].ColumnSpan = columncount;
                    showSalesInvoice.Rows[0].Cells[0].Text = "No Records Found";
                }
                showSalesInvoice.AllowPaging = true;
                showSalesInvoice.AllowSorting = true;
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion


        #region Bind Data to dropDown list in new invoice
        public void CustomerDropDown(DropDownList SelectCustomerDropDownList)
        {
            DataTable subjects = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT [name] FROM [Customer]", conn);
            adapter.Fill(subjects);

            conn.Open();
            SelectCustomerDropDownList.DataSource = subjects;
            SelectCustomerDropDownList.DataTextField = "name";
            SelectCustomerDropDownList.DataValueField = "name";
            SelectCustomerDropDownList.DataBind();
            SelectCustomerDropDownList.Items.Insert(0, new ListItem("Select", "NA"));

            conn.Close();
        }
        #endregion
    }
}