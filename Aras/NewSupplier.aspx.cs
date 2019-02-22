using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aras
{
    public partial class NewSupplier : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {

                    SupplierFullNameTextBox.Text = Application["name"].ToString();
                    NewSupplierDepitMoneyTextBox.Text = Application["debit"].ToString();
                    SupplierLocationTextBox.Text = Application["location"].ToString();
                    SupplierPhoneNumberTextBox.Text = Application["phone_number"].ToString();

                
                }
                catch (Exception)
                {

                }
              
               



            }
        }

        protected void CreateNewSupplierButton_Click(object sender, EventArgs e)
        {
            string myId="";
            try
            {
               myId  = Application["id"].ToString();
            }
            catch (Exception)
            {

               
            }


            if (myId=="")
            {
                #region Hama Creating new Supplier
                try
                {
                    inD.newSupplier(SupplierFullNameTextBox.Text, NewSupplierDepitMoneyTextBox.Text, SupplierLocationTextBox.Text, DisableCheckBox, SupplierPhoneNumberTextBox.Text);
                    Response.Redirect("Suppliers.aspx");

                }
                catch (Exception)
                {

                    throw;
                }

                #endregion
            }
            else
            {
                Response.Write("<script language=javascript>alert('You are not in creating mode please update');</script>");
            }





        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            int disable = 0;

            try
            {
             
                    if (DisableCheckBox.Checked)
                    {
                        disable = 1;
                    }
                    else
                    {
                        disable = 0;
                    }
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

                    string id = Application["id"].ToString();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update supplier set name='" + SupplierFullNameTextBox.Text + "',	debit='" + Int64.Parse(NewSupplierDepitMoneyTextBox.Text) + "',location='" + SupplierLocationTextBox.Text + "',disable='" + disable + "',phone_number='" + SupplierPhoneNumberTextBox.Text + "'where id='" + int.Parse(Application["id"].ToString()) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                
             
                
            }
            catch (Exception)
            {
                Response.Write("<script language=javascript>alert('You are not in updating mode');</script>");
            }
            Application["name"] = "";
            Application["debit"] = "";
            Application["location"] = "";
            Application["phone_number"] = "";
        }
    }
}