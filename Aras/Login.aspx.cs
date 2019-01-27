using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;

namespace Aras
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            #region Hama login
            //login done just the cookies remained
            char admin = '1';

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            SqlCommand cmd = new SqlCommand("login_search", con);
            cmd.Parameters.AddWithValue("complite_name", UserNameTextBox.Text);
            cmd.Parameters.AddWithValue("password", PasswordTextBox.Text);
            //cmd.Parameters.AddWithValue("Admin", admin);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[3].ToString() == "1")
                {
                    Application["Admin"] = "Admin";
                    Response.Write(Application["Admin"].ToString());
                    //FormsAuthentication.RedirectFromLoginPage(UserNameTextBox.Text, false);


                }

                else
                {
                    Application["Admin"] = "User";
                    Response.Write(Application["Admin"].ToString());
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");

                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }

        }


        #endregion

    }
}
