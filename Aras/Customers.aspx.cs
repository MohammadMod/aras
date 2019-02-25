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
        
        BindingData bd = new BindingData();
        SmartDelete Deletor;
        protected void Page_Load(object sender, EventArgs e)
        {

             //if (!Permit.isAllowed(Permessions.AllUsers))
             //   Response.Redirect("Login.aspx");


            #region Hama reading customer names from db to gridview
            if (!IsPostBack)
            {
                try
                {
                    bd.viewCustomers(CustomersGridView);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            #endregion


            // 5 is the location of ID
            if (Permit.isAllowed(Permessions.OnlyAdmin))
                Deletor = new SmartDelete(this.CustomersGridView, DeleteButton, "Customer", 5,this);
            else
                DeleteButton.OnClientClick = "return alert('You must be logged in as Aadmin')";
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {


            Response.Redirect("NewCustomers.aspx");
        }

    }
}