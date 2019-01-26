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
                inD.registerUsers(UserNameTextBox.Text, FullNameTextBox.Text, int.Parse(PhoneTextBox.Text), LocationTextBox.Text, PasswordTextBox.Text);
                Response.Redirect("Users.aspx");

            }
            catch (Exception)
            {

                throw;
            }
          

            #endregion

        }
    }
}