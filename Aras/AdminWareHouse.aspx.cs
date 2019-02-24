using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace Aras
{
    public partial class AdminWareHouse : System.Web.UI.Page
    {
        SmartDelete Deletor;

        protected void Page_Load(object sender, EventArgs e)
        {
            // a simple way to not let all users see some pages.
            // if (!Permit.isAllowed(Permessions.OnlyAdmin))
            //   Response.Redirect("Login.aspx");

            //Deletor = new SmartDelete(AdminWareHouseGridView, DeleteButton, "warehouse");
        }

        
    }

}
