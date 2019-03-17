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
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string period = "";
            string statues = "";

            if (periodDropDownList.SelectedIndex==0)
            {
                period = "daily";
            }
            else
            {
                period = "Monthly";
            }

            if (statuesDropDownList.SelectedIndex==0)
            {
                statues = "paid";
            }
            else
            {
                statues = "unpaid";
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            SqlCommand cmdaa = new SqlCommand("sales_invoce_report", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdaa);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //first paramenter: parameter name, second parameter: parameter value of object type
            //using this way you can add more parameters
            da.SelectCommand.Parameters.AddWithValue("priod", period);
            da.SelectCommand.Parameters.AddWithValue("from", Convert.ToDateTime(start_date_txt.Text).Date);
            da.SelectCommand.Parameters.AddWithValue("to", Convert.ToDateTime(end_date_txt.Text).Date);
            da.SelectCommand.Parameters.AddWithValue("stauts", statues);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}