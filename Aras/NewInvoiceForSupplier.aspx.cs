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
    
    public partial class NewInvoiceForSupplier : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();
        BindingData bd = new BindingData();
        private object amount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.SupplierName(SelectCustomerDropDownList);
                bd.wareHouseName(ChoseWareHouseDropDownList);
            }
        }

        protected void SubmitNewInvoiceButton_Click(object sender, EventArgs e)
        {
            //INSERT_payment_entry
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            SqlCommand cmd = new SqlCommand("INSERT_sales_Invoce", con);

            con.Open();

            cmd.Parameters.AddWithValue("payment_type", "paradan");
            cmd.Parameters.AddWithValue("Costomer_ID", SelectCustomerDropDownList.SelectedIndex);

            cmd.Parameters.AddWithValue("posting_date", DateTime.Now);
            cmd.Parameters.AddWithValue("party_balance", "");

            //cmd.Parameters.AddWithValue("difference_amount", date);
            //cmd.Parameters.AddWithValue("unallocated_amount", discount);
            //cmd.Parameters.AddWithValue("sales_invoice_advance_payment_ID", DBNull.Value);

            //cmd.Parameters.AddWithValue("Series", SeriesDropDownList.SelectedItem.Text);

            //cmd.Parameters.AddWithValue("warehouse_ID", wareHouseId.SelectedIndex);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}