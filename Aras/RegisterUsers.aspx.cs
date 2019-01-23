using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace Aras
{
    public partial class RegisterUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            #region Hama 
            //checking for avilability of the username 
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                con.Open();

                SqlCommand cmdd = new SqlCommand("select * from [regester_table] where complite_name=@name", con);

                cmdd.Parameters.AddWithValue("name", UserNameTextBox.Text);

                SqlDataReader rd = cmdd.ExecuteReader();

                if (rd.HasRows)
                {
                    Response.Write("username is available");
                    UserNameTextBox.Text = "";
                }
                else
                {
                    con.Close();

                    //register the user if the username is avilable or not
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT_Regester", con);

                        con.Open();
                        cmd.Parameters.AddWithValue("name", FullNameTextBox.Text);
                        cmd.Parameters.AddWithValue("last_name", "LastName");
                        cmd.Parameters.AddWithValue("phone_number", Int64.Parse(PhoneTextBox.Text));
                        cmd.Parameters.AddWithValue("location", LocationTextBox.Text);
                        cmd.Parameters.AddWithValue("complite_name", UserNameTextBox.Text);
                        cmd.Parameters.AddWithValue("pin_cod", PasswordTextBox.Text);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("Login.aspx");

                    }

                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            #endregion
        }
    }
}