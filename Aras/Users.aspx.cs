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
    public partial class Users : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        string checkAdmin = "";
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama reding registerd users info to gridview
            if (!IsPostBack)
            {
                try
                {
                    bd.UsersGridView(ViewUsersGridView);

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
            Response.Redirect("RegisterUsers.aspx");
        }

        protected void ViewUsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ViewUsersGridView.EditIndex = e.NewEditIndex;
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void ViewUsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            #region Hama below codes are for updating values of the users
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                GridViewRow row = (GridViewRow)ViewUsersGridView.Rows[e.RowIndex];
                TextBox fName = (TextBox)row.Cells[1].Controls[0];
                TextBox lName = (TextBox)row.Cells[2].Controls[0];
                TextBox phoneNumber = (TextBox)row.Cells[3].Controls[0];
                TextBox Location = (TextBox)row.Cells[4].Controls[0];
                TextBox completeName = (TextBox)row.Cells[5].Controls[0];
                TextBox Password = (TextBox)row.Cells[6].Controls[0];
                TextBox userID = (TextBox)row.Cells[7].Controls[0];

                ViewUsersGridView.EditIndex = -1;
                conn.Open();
                SqlCommand cmd = new SqlCommand("update regester_table set name='" + fName.Text + "',last_name='" + lName.Text + "',phone_number='" + phoneNumber.Text + "',location='" + Location.Text + "',complite_name='" + completeName.Text + "',pin_cod='" + Password.Text + "'where id='" + int.Parse(userID.Text.ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                Response.Write("invalid data intered");
            }
          


            #endregion
        }

        protected void ViewUsersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ViewUsersGridView.EditIndex = -1;
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ViewUsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                ViewUsersGridView.PageIndex = e.NewPageIndex;
                bd.UsersGridView(ViewUsersGridView);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ViewUsersGridView_Sorted(object sender, EventArgs e)
        {

        }

        protected void ViewUsersGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            bd.UsersGridView(ViewUsersGridView);
        }

        protected void ViewUsersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
          


        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUsers.aspx");

        }
        public void viewModal(int id)
        {
            SqlCommand cmd = new SqlCommand("show_User_update", conn);
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

                checkAdmin = dr[6].ToString();

            }
            dr.Close();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in ViewUsersGridView.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    str = gvrow.Cells[7].Text;

                }
            }
            try
            {
                int sid = int.Parse(str);
                Application["userid"] = str;
                Label8.Text = Application["userid"].ToString();
                viewModal(sid);

            }
            catch (Exception)
            {


            }
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            ViewButton.Attributes.Add("onclick", "return false;");

        }
    }
}