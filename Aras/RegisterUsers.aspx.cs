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
        protected void Page_Load(object sender, EventArgs e)
        {

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
                inD.registerUsers(UserNameTextBox.Text, FullNameTextBox.Text, int.Parse(PhoneTextBox.Text), LocationTextBox.Text, PasswordTextBox.Text, isAdmin);
                Response.Redirect("Users.aspx");
            }
            catch (Exception)
            {
                Response.Write("invalid data entered please check the form again");
            }
                

        
          

            #endregion

        }
    }
}