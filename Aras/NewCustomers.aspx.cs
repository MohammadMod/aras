using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class NewCustomers : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] != null)  // has user logged in?
                    ;
                else
                    throw new Exception();

            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    //CostumerNameTextBox.Text = Application["rname"].ToString();
                    //ResturantNameTextBox.Text = Application["resturant_name"].ToString();
                    //LocationTextBox.Text = Application["location"].ToString();
                    //PhoneNumberTextBox.Text = Application["phone_number"].ToString();
                    //MoneyInDeptTextBox.Text = Application["credit"].ToString();
                }
                catch (Exception)
                {

                }
               
            }
        }

        protected void CreateCustomerButton_Click(object sender, EventArgs e)
        {

            //string myId = "";
            //try
            //{
            //    myId = Application["id"].ToString();
            //}
            //catch (Exception)
            //{


            //}

            //if (myId == "")
            //{
                #region Hama Creating new customer
                try
                {
                    inD.InsertNewCustomer(CostumerNameTextBox.Text, ResturantNameTextBox.Text, LocationTextBox.Text, PhoneNumberTextBox.Text, float.Parse(MoneyInDeptTextBox.Text), DisablesCheckBox);
                    Response.Redirect("Customers.aspx");

                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('An Error occurred or may invalid data entered, please try again ');</script>");
                }
            //}
            //else
            //{
            //    Response.Write("<script language=javascript>alert('You are not in creating mode ');</script>");
            //}

            #endregion
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int disable = 0;
            if (DisablesCheckBox.Checked)
            {
                disable = 1;
            }
            else
            {
                disable = 0;
            }
            try
            {
                string myId = Application["id"].ToString();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("update [dbo].[Customer] set [name]='" + CostumerNameTextBox.Text + "',[resturant_name]='" + ResturantNameTextBox.Text + "',[location]='" + LocationTextBox.Text + "',[phone_namber]='" + PhoneNumberTextBox.Text + "',[disable]='" + disable + "',[credit]='" + MoneyInDeptTextBox.Text + "'where id='" + int.Parse(myId) + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Customers.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('You are not in updating mode');</script>");
            }
        }
    }
}
