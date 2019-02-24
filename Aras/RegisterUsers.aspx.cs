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
        Inserting_Data inD = new Inserting_Data();
        UserValidator validator; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //updating
                try
                {
                    UserNameTextBox.Text = Application["username"].ToString();
                    FullNameTextBox.Text = Application["fullname"].ToString();
                    LocationTextBox.Text = Application["location"].ToString();
                    PasswordTextBox.Text = Application["password"].ToString();
                    PhoneTextBox.Text = Application["phone"].ToString();
                }
                catch (Exception)
                {

                }
            }
            validator = new UserValidator();
        }
     
        protected void RegisterButton_Click(object sender, EventArgs e)
        {

            //string myId = "";
            //try
            //{
            //    myId = Application["id"].ToString();
            //}
            //catch (Exception)
            //{


            //}

            //if (myId == "")
            //{
                #region Hama RegisterUsers
                try
                {
                    char isAdmin;
                    if (AdminCheckBox.Checked == true)
                    {
                        isAdmin = '1';
                    }
                    else
                    {
                        isAdmin = '0';
                    }

                    // checks if the username is valid or not
                    if (validator.isInValid(UserNameTextBox.Text))
                        throw new Exception(validator.ToString());


                    inD.registerUsers(UserNameTextBox.Text, FullNameTextBox.Text, Int64.Parse(PhoneTextBox.Text), LocationTextBox.Text, PasswordTextBox.Text, isAdmin);
                    Response.Redirect("Users.aspx");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", $"<script language='javascript'>alert('{ex.Message}');</script>");
                }
            //}

            //else
            //{
            //    Response.Write("<script language=javascript>alert('You are not in creating mode please update');</script>");
            //}




            #endregion

        }

        class UserValidator : Validation
        {
            List<char> valids;
            int max, min;

            public UserValidator( int maxChar = 256, int minChar = 6) 
            {
                type = "username";
                valids = new List<char>();
                //"A-Z"
                for (char i = 'A'; i <= 'Z'; i++)
                {
                    valids.Add(i);
                }

                //"a-z"
                for (char i = 'a'; i <= 'z'; i++)
                {
                    valids.Add(i);
                }

                //0-9
                for (char i = '0'; i <= '9'; i++)
                {
                    valids.Add(i);
                }
                // '.', '_', 
                valids.Add('.');
                valids.Add('_');
                max = maxChar;
                min = minChar;


            }

            public bool isInValid(string username)
            {
                data = username;
                bool result = isEmpty()
                    | invalidChars(valids)
                    | isTooLong(max)
                    | isTooShort(min);

                return result;
            }

            public override string ToString()
            {
                if (errorMessage.Length > 0)
                    return $"username is invalid: {errorMessage}";
                else
                    return $"username is valid: {data}";
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int isAdmin = 0;
            if (AdminCheckBox.Checked)
            {
                isAdmin = 1;
            }
            else
            {
                isAdmin = 0;
            }
            try
            {
                string myId = Application["id"].ToString();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("update regester_table set name='" + FullNameTextBox.Text + "',last_name='" + "last_name" + "',phone_number='" + PhoneTextBox.Text + "',location='" + LocationTextBox.Text + "',complite_name='" + UserNameTextBox.Text + "',pin_cod='" + PasswordTextBox.Text + "',Admin='" + isAdmin + "'where id='" + int.Parse(myId) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('You are not in updating mode');</script>");
            }
            

        }
    }
}