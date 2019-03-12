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
    public partial class Expenses : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["username"] != null)  // has user logged in?
                        ;
                    else
                        throw new Exception();

                }
                catch
                {
                    Response.Redirect("Login.aspx");
                }
                username = Session["username"].ToString();
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmd = new SqlCommand("INSERT_expens", con);
                con.Open();
                cmd.Parameters.AddWithValue("amount", float.Parse(amountTextBox.Text));
                cmd.Parameters.AddWithValue("tebini", detailsTextBox.Text);
                cmd.Parameters.AddWithValue("driver", username);
                cmd.Parameters.AddWithValue("posting_dateas", DateTime.Now);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("/Show Expinces.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
            }

        }
    }
}