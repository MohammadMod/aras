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
    
    public partial class Transfer : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.wareHouseName(fromWareHouseDropDownList);
                bd.wareHouseName(toWareHouseDropDownList);
            }
           
            //test
            //string app = Application["InvoiceName"].ToString();
            //Response.Write(app);
            //TranseferAmountTextBox.Text = app;

        }


        protected void fromWareHouseDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdd = new SqlCommand("show_warehouse_quantity", conn);
                conn.Open();
                cmdd.Parameters.AddWithValue("warehouse_name", fromWareHouseDropDownList.SelectedItem.Text);
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                AmountInWareHouseTextBox.Text = cmdd.ExecuteScalar().ToString();
                cmdd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                Response.Write("<script language=javascript>alert('No data in this warehouse found');</script>");

            }


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            float amountInWareHouse = float.Parse(AmountInWareHouseTextBox.Text);
            float transferAmount = float.Parse(TranseferAmountTextBox.Text);

            if (transferAmount>amountInWareHouse)
            {
                Response.Write("<script language=javascript>alert('Not enough quantity');</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmd = new SqlCommand("INSERT_Transfer", con);
                con.Open();
                cmd.Parameters.AddWithValue("sours_warehouse_ID", fromWareHouseDropDownList.SelectedItem.Text);
                cmd.Parameters.AddWithValue("Target_warehouse_ID", toWareHouseDropDownList.SelectedItem.Text);
                cmd.Parameters.AddWithValue("quantityas", float.Parse(TranseferAmountTextBox.Text));
                cmd.Parameters.AddWithValue("Date_time", DateTime.Now);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ShowTransfer.aspx");
        }
    }
}