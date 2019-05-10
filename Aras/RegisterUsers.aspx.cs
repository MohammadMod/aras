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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        Inserting_Data inD = new Inserting_Data();
        UserValidator validator;
        string edit = "";
        bool check = false;
        string checkAdmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!Permit.isAllowed(Permessions.OnlyAdmin))
                //    Response.Redirect("Login.aspx");
                //updating
                //updateButton.Attributes["Onclick"] = "return confirm('Do you really want to save?')";
                #region update
                try
                {
                    edit = Application["userid"].ToString();


                    SqlCommand cmd = new SqlCommand("show_User_update", conn);
                    conn.Open();


                    cmd.Parameters.AddWithValue("ID", Int64.Parse(edit));
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        FullNameTextBox.Text = dr[0].ToString();

                        PhoneTextBox.Text = dr[2].ToString();
                        LocationTextBox.Text = dr[3].ToString();

                        UserNameTextBox.Text = dr[4].ToString();
                        PasswordTextBox.Text = dr[5].ToString();

                        checkAdmin = dr[6].ToString();

                        if (checkAdmin=="True")
                        {
                            AdminCheckBox.Checked = true;
                        }
                        else
                        {
                            AdminCheckBox.Checked = false;
                        }

                    }
                    dr.Close();
                }
                catch (Exception)
                {

                    check = true;
                }



                if (check == false)
                {
                    Button2.Enabled = false;
                    updateButton.Enabled = true;

                    Button2.Visible = false;
                    updateButton.Visible = true;
                }

                else
                {
                    Button2.Enabled = true;
                    updateButton.Enabled = false;

                    Button2.Visible = true;
                    updateButton.Visible = false;
                }

                conn.Close();


                #endregion
            }
            validator = new UserValidator();
        }
     
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            

          
            

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
                finally
                {
                    Application["userid"] = "";
                }
            

           




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
            Page.Validate();
            string isAdmin = "";

            if (AdminCheckBox.Checked)
            {
                isAdmin = "1";
            }
            else
            {
                isAdmin = "0";
            }
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("update regester_table set name='" + FullNameTextBox.Text + "',last_name='" + "last_name" + "',phone_number='" + PhoneTextBox.Text + "',location='" + LocationTextBox.Text + "',complite_name='" + UserNameTextBox.Text + "',pin_cod='" + PasswordTextBox.Text + "',Admin='" + isAdmin + "'where id='" + int.Parse(Application["userid"].ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Users.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('You are not in updating mode');</script>");
            }
            finally
            {
                Application["userid"] = "";
            }
            
         

        }
    }
}