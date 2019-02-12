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
            bd.wareHouseName(FromWareHouseDropDownList);
            bd.wareHouseName(ToWareHouseDropDownList);
            string app= Application["InvoiceName"].ToString();
            Response.Write(app);
            TranseferAmountTextBox.Text = app;
        }

        protected void ToWareHouseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FromWareHouseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //SqlCommand cmdd = new SqlCommand("show_warehouse_amount", conn);
            //conn.Open();
            //cmdd.Parameters.AddWithValue("warehouse_name", FromWareHouseDropDownList.SelectedItem.Selected.ToString());
            //cmdd.CommandType = System.Data.CommandType.StoredProcedure;
            //AmountInWareHouseTextBox.Text = cmdd.ExecuteScalar().ToString();
            //cmdd.ExecuteNonQuery();
            //conn.Close();
            //conn.Close();

            Response.Write(FromWareHouseDropDownList.SelectedItem.Text);
            Response.Write(FromWareHouseDropDownList.SelectedItem.Value.ToString());
            Response.Write(FromWareHouseDropDownList.SelectedItem.Selected.ToString());
            Response.Write(FromWareHouseDropDownList.SelectedValue.ToString());
            Response.Write(FromWareHouseDropDownList.SelectedValue.ToString());
            Response.Write(FromWareHouseDropDownList.SelectedIndex.ToString());
            Response.Write(FromWareHouseDropDownList.DataTextField.ToString());

        }
    }
}