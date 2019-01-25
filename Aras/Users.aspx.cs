﻿using System;
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
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama reding registerd users info to gridview
            try
            {
                bd.UsersGridView(ViewUsersGridView);
               
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

        protected void ViewUsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ViewUsersGridView.EditIndex = e.NewEditIndex;
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void ViewUsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            #region Hama below codes are for updating values of the users
             
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            GridViewRow row = (GridViewRow)ViewUsersGridView.Rows[e.RowIndex];
            TextBox textName = (TextBox)row.Cells[1].Controls[0];
            TextBox companyName = (TextBox)row.Cells[2].Controls[0];
            TextBox debitMoney = (TextBox)row.Cells[3].Controls[0];
            TextBox Location = (TextBox)row.Cells[4].Controls[0];
            TextBox disable = (TextBox)row.Cells[5].Controls[0];
            TextBox PhoneNumber = (TextBox)row.Cells[6].Controls[0];
            TextBox userID = (TextBox)row.Cells[7].Controls[0];

            ViewUsersGridView.EditIndex = -1;
            conn.Open();
            SqlCommand cmd = new SqlCommand("update regester_table set name='" + textName.Text + "',last_name='" + companyName.Text + "',phone_number='" + debitMoney.Text + "',location='" + Location.Text + "',complite_name='" + disable.Text + "',pin_cod='" + PhoneNumber.Text + "'where id='" + int.Parse(userID.Text.ToString()) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            bd.UsersGridView(ViewUsersGridView);


            #endregion
        }

        protected void ViewUsersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                ViewUsersGridView.EditIndex = -1;
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ViewUsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                ViewUsersGridView.PageIndex = e.NewPageIndex;
                bd.UsersGridView(ViewUsersGridView);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ViewUsersGridView_Sorted(object sender, EventArgs e)
        {

        }
    }
}