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
    public class SmartDelete
    {
        GridView inputGrid;

        Button DeleteButton;
        public string NoRowAlert;
        public string allDeleteAlert;
        string tableName;
        string idColumn = "ID";

        public SmartDelete(GridView gridview, Button deletBTM, string Table, string ID="ID" )
        {

            tableName = Table;
            idColumn = "ID";
            inputGrid = gridview;
            DeleteButton = deletBTM;
            NoRowAlert = "no row has been selected";
            allDeleteAlert = "are you sure to delete all ?";


            ((CheckBox)inputGrid.HeaderRow.FindControl("cbDeleteHeader")).CheckedChanged += cbDeleteHeader_CheckedChanged;

            foreach (GridViewRow Row in this.inputGrid.Rows)
            {
                ((CheckBox)Row.FindControl("cbDelete")).CheckedChanged += cbDelete_CheckedChanged;
            }


            deletBTM.Click += DeleteButton_Click;
            DeleteButton.OnClientClick = $"return alert('{NoRowAlert}')";
        }

        public void cbDeleteHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in this.inputGrid.Rows)
            {
                ((CheckBox)Row.FindControl("cbDelete")).Checked = ((CheckBox)sender).Checked;
            }
            if (((CheckBox)sender).Checked)
                DeleteButton.OnClientClick = $"return confirm('{allDeleteAlert}');";
            else
                DeleteButton.OnClientClick = $"return alert('{NoRowAlert}')";
        }

        public void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)inputGrid.HeaderRow.FindControl("cbDeleteHeader");
            if (headerCheckBox.Checked)
            {
                headerCheckBox.Checked = ((CheckBox)sender).Checked;
            }
            else
            {
                bool allCheckBoxesChecked = true;
                foreach (GridViewRow gridViewRow in inputGrid.Rows)
                {
                    if (!((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                    {
                        allCheckBoxesChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = allCheckBoxesChecked;
            }

            int counter = 0;
            foreach (GridViewRow gridViewRow in inputGrid.Rows)
            {
                if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                {
                    counter++;
                }
            }

            if (counter == 0)
                DeleteButton.OnClientClick = $"return alert('{NoRowAlert}')";
            else
                DeleteButton.OnClientClick = $"return confirm('are you sure to delete {counter} rows ?');";
        }

        public void DeleteEmployees(List<string> IDList)
        {

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
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            List<string> lstEmployeeIdsToDelete = new List<string>();
            foreach (GridViewRow gridViewRow in inputGrid.Rows)
            {
                if (((CheckBox)gridViewRow.FindControl("cbDelete")).Checked)
                {
                    string employeeId = (gridViewRow.Cells[1]).Text;
                    lstEmployeeIdsToDelete.Add(employeeId);
                }
            }
            if (lstEmployeeIdsToDelete.Count > 0)
            {
                DeleteEmployees(lstEmployeeIdsToDelete);
                inputGrid.DataBind();



            }

        }
    }
}