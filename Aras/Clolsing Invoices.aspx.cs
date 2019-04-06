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
    public partial class Clolsing_Invoices : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("showInvoices_paid", conn);
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

                DataTable subjectss = new DataTable();

                SqlDataAdapter adapterr = new SqlDataAdapter("select [complite_name] from [dbo].[regester_table]", conn);
                adapterr.Fill(subjectss);

                conn.Open();
                DropDownList1.DataSource = subjectss;
                DropDownList1.DataTextField = "complite_name";
                DropDownList1.DataValueField = "complite_name";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select", "NA"));

                conn.Close();
            }

         



        }



        protected void cbDelete_CheckedChanged(object sender, EventArgs e)
        {

         
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GridView1.SelectedRow;
            int id =int.Parse(gridViewRow.Cells[1].Text);
            conn.Open();
            SqlCommand cmd = new SqlCommand(" update [dbo].[Sales_invoce] set  [satute]='close' where ID='" + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("showinvoices_for_close", conn);
                cmd.Parameters.AddWithValue("username", DropDownList1.SelectedItem.Text);
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
}