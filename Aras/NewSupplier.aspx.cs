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
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        string edit = "";
        string disable = "";
        bool check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                  edit= Application["suppliereditid"].ToString();


                    SqlCommand cmd = new SqlCommand("updateshow_supplier", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("id",Int64.Parse(edit));
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlDataReader dr = cmd.ExecuteReader();
                            dr.Read();
                    if (dr.HasRows)
                    {
                        SupplierFullNameTextBox.Text = dr[0].ToString();
                        NewSupplierDepitMoneyTextBox.Text = dr[2].ToString();
                        SupplierLocationTextBox.Text = dr[3].ToString();
                        disable = dr[4].ToString();
                        SupplierPhoneNumberTextBox.Text = dr[5].ToString();


                    }
                            dr.Close();

                    if (disable=="")
                    {
                        DisableCheckBox.Checked = true;
                    }
                    else
                    {
                        DisableCheckBox.Checked = false;
                    }

                   

                }
                catch (Exception ex)
                {
                    check = true;
                }

                if (check == true)
                {
                    updateButton.Enabled = false;
                    updateButton.Visible = false;

                    CreateNewSupplierButton.Enabled = true;
                    CreateNewSupplierButton.Visible = true;

                }
                else
                {
                    updateButton.Enabled = true;
                    updateButton.Visible = true;

                    CreateNewSupplierButton.Enabled = false;
                    CreateNewSupplierButton.Visible = false;
                }



            }
        }

        protected void CreateNewSupplierButton_Click(object sender, EventArgs e)
        {
           
            string myId="";
            try
            {
               myId  = Application["suppliereditid"].ToString();
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
            if (check==true)
            {
                Response.Write("<script language=javascript>alert('you are not in updating mode ');</script>");


            }
            else
            {
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

                    string id = Application["suppliereditid"].ToString();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update supplier set name='" + SupplierFullNameTextBox.Text + "',	debit='" + Int64.Parse(NewSupplierDepitMoneyTextBox.Text) + "',location='" + SupplierLocationTextBox.Text + "',disable='" + disable + "',phone_number='" + SupplierPhoneNumberTextBox.Text + "'where id='" + int.Parse(Application["suppliereditid"].ToString()) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Suppliers.aspx");


                }
                catch (Exception)
                {
                    Response.Write("<script language=javascript>alert('You are not in updating mode');</script>");
                }

            }

        }
    }
}