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
    public partial class Customers : System.Web.UI.Page
    {
        string checkBox = "";
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama reading customer names from db to gridview
            try
            {
                bd.viewCustomers(CustomersGridView);
            }
            catch (Exception)
            {

                throw;
            }
            #endregion


        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
          

            Response.Redirect("NewCustomers.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            #region Mr. Milad
            //when the user clicks the check box then click the delete button a message should pop up for confirmation

            #endregion
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }
    }
}