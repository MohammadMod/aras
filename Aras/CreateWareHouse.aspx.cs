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
    public partial class CreateWareHouse : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bd.wareHouseName(wareHouseDropDownList);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_warehouse", con);
                con.Open();
                cmd.Parameters.AddWithValue("warehouse_name", WareHouseNameTextBox.Text);
                cmd.Parameters.AddWithValue("phone_no", WareHousePhoneTextBox0.Text);
                cmd.Parameters.AddWithValue("address_line_1", WareHouseAddressTextBox1.Text);
                cmd.Parameters.AddWithValue("parent_warehouse_ID", wareHouseDropDownList.SelectedIndex);

                if (isGroupCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("is_group", "1");
                }
                else
                {
                    cmd.Parameters.AddWithValue("is_group", "0");
                }
                if (disabledCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("disabled", "1");
                }
                else
                {
                    cmd.Parameters.AddWithValue("disabled", "0");

                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
            }
          
        }
    }
}