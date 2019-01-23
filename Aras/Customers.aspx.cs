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
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", con);
           
            DataSet ds = new DataSet();
            da.Fill(ds);
            CustomersGridView.DataSource = ds;
            CustomersGridView.DataBind();

            CustomersGridView.AllowCustomPaging = true;
            CustomersGridView.AllowSorting = true;
            
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            bool atLeastOneRowDeleted = false;
            // Iterate through the Products.Rows property
            foreach (GridViewRow row in CustomersGridView.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    // Delete row! (Well, not really...)
                    atLeastOneRowDeleted = true;
                    // First, get the ProductID for the selected row
                    int productID =
                        Convert.ToInt32(CustomersGridView.DataKeys[row.RowIndex].Value);
                    // "Delete" the row
                    SearchTextBox.Text += string.Format(
                        "This would have deleted ProductID {0}<br />", productID);
                }
            }
            // Show the Label if at least one row was deleted...

            Response.Redirect("NewCustomers.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
          
        }
    }
}