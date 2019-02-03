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
        protected void Page_Load(object sender, EventArgs e)
        {
            // a simple way to not let all users see some pages.
            // if (!Permit.isAllowed(Permessions.OnlyAdmin))
            //   Response.Redirect("Login.aspx");
        }

        protected void cbDeleteHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in this.AdminWareHouseGridView.Rows)
            {
                ((CheckBox)Row.FindControl("cbDelete")).Checked = ((CheckBox)sender).Checked;
            }
        }

        protected void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox =
          (CheckBox)AdminWareHouseGridView.HeaderRow.FindControl("cbDeleteHeader");
            if (headerCheckBox.Checked)
            {
                headerCheckBox.Checked = ((CheckBox)sender).Checked;
            }
            else
            {
                bool allCheckBoxesChecked = true;
                foreach (GridViewRow gridViewRow in AdminWareHouseGridView.Rows)
                {
                    if (!((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                    {
                        allCheckBoxesChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = allCheckBoxesChecked;
            }
        }

        public void DeleteEmployees(List<string> IDList)
        {
            string tableName = "warehouse";
            string idColumn = "ID";
            string CS = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                List<string> parameters = IDList.Select((s, i) => "@Parameter" + i.ToString()).ToList();
                string inClause = string.Join(",", parameters);
                string deleteCommandText = $"Delete from {tableName}  where {idColumn} IN ( { inClause} )";
                SqlCommand cmd = new SqlCommand(deleteCommandText, con);

                for (int i = 0; i < parameters.Count; i++)
                {
                    cmd.Parameters.AddWithValue(parameters[i], IDList[i]);
                }

                con.Open();
                lblMessage.Text = cmd.CommandText;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            List<string> lstEmployeeIdsToDelete = new List<string>();
            foreach (GridViewRow gridViewRow in AdminWareHouseGridView.Rows)
            {
                if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                {
                    string employeeId =  (gridViewRow.Cells[1]).Text;
                    lstEmployeeIdsToDelete.Add(employeeId);
                }
            }
            if (lstEmployeeIdsToDelete.Count > 0)
            {
                //DeleteEmployees(lstEmployeeIdsToDelete);
                //AdminWareHouseGridView.DataBind();
                lblMessage.ForeColor = System.Drawing.Color.Navy;
                lblMessage.Text = lstEmployeeIdsToDelete.Count.ToString() + " row(s) deleted";
                foreach (var item in lstEmployeeIdsToDelete)
                {
                    lblMessage.Text += $" {item}";
                }
                
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No rows selected to delete";
            }
        }
    }
}
