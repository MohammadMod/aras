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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama reding registerd users info to gridview
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlDataAdapter da = new SqlDataAdapter("select * from regester_table ", con);

                DataSet ds = new DataSet();
                da.Fill(ds);
                ViewUsersGridView.DataSource = ds;
                ViewUsersGridView.DataBind();

                ViewUsersGridView.AllowCustomPaging = true;
                ViewUsersGridView.AllowSorting = true;
            }
            catch (Exception)
            {

                throw;
            }

            #endregion

        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUsers.aspx");
        }
    }
}