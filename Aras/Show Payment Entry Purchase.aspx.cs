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
    public partial class Show_Payment_Entry_Purchase : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("show_purchase_Invoices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }


        protected void NewPushesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void viewModal(int id)
        {
            SqlCommand cmd = new SqlCommand("showPurchase_invoice_for_update", conn);
            conn.Open();


            cmd.Parameters.AddWithValue("ID", id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                Label1.Text = dr[0].ToString();

                Label2.Text = dr[1].ToString();

                Label3.Text = dr[2].ToString();
                Label4.Text = dr[3].ToString();

                Label5.Text = dr[4].ToString();
                Label6.Text = dr[5].ToString();

                Label7.Text = dr[6].ToString();
                Label7.Text = dr[7].ToString();


            }
            dr.Close();
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    str = gvrow.Cells[1].Text;

                }
            }
            try
            {
                int pid = int.Parse(str);
                Application["purchaseinvoiceid"] = str;
                Label8.Text = Application["purchaseinvoiceid"].ToString();
                viewModal(pid);

            }
            catch (Exception)
            {


            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase.aspx");
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            ViewButton.Attributes.Add("onclick", "return false;");

        }
    }
}