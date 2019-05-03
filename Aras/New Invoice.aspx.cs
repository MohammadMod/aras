﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Aras
{
    public partial class New_Invoice : System.Web.UI.Page
    {
        Inserting_Data inD = new Inserting_Data();
        BindingData bd = new BindingData();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        string username = "";
        string edit = "";
        bool check = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            #region checkLogedIn
            //if (Session["username"] != null)  // has user logged in?
            //    ;
            //else
            //    throw new Exception();
            //username = Session["username"].ToString();
            #endregion



            #region update
            try
            {
                edit = Application["salesinvoiceid"].ToString();


                SqlCommand cmd = new SqlCommand("showInvoices_for_update", conn);
                conn.Open();


                cmd.Parameters.AddWithValue("ID", Int64.Parse(edit));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    SelectCustomerDropDownList.SelectedValue = dr[0].ToString();
                    ChoseWareHouseDropDownList.SelectedValue = dr[1].ToString();

                    KiloTextBox.Text = dr[2].ToString();
                    CostOfKiloTextBox.Text = dr[3].ToString();

                    TotallTextBox.Text = dr[4].ToString();
                    DiscountTextBox.Text = dr[5].ToString();


                    TotallAllTextBox.Text = dr[6].ToString();


                }
                dr.Close();
            }
            catch (Exception)
            {

                check = true;
            }
         
        

            if (check==false)
            {
                SubmitNewInvoiceButton.Enabled = false;
                UpdateButton.Enabled = true;

                SubmitNewInvoiceButton.Visible = false;
                UpdateButton.Visible = true;
            }

            else
            {
                SubmitNewInvoiceButton.Enabled = true;
                UpdateButton.Enabled = false;

                SubmitNewInvoiceButton.Visible = true;
                UpdateButton.Visible = false;
            }

            conn.Close();


            #endregion




            if (!IsPostBack)
            {


                try
                {
                    bd.wareHouseName(ChoseWareHouseDropDownList);
                }
                catch (Exception)
                {

                }

                #region Hama reding the customer names form the db to the dropdown list
                try
                {
                    Label1.Visible = false;
                    if (!IsPostBack)
                    {
                        DataTable subjects = new DataTable();

                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT [name] FROM [Customer]", con);
                        adapter.Fill(subjects);

                        con.Open();
                        SelectCustomerDropDownList.DataSource = subjects;
                        SelectCustomerDropDownList.DataTextField = "name";
                        SelectCustomerDropDownList.DataValueField = "name";
                        SelectCustomerDropDownList.DataBind();
                        SelectCustomerDropDownList.Items.Insert(0, new ListItem("Select", "NA"));

                        con.Close();

                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            #endregion
        }

        protected void SubmitNewInvoiceButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (edit=="")
                {
                    #region Hama this region is for inserting to the database
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                    SqlCommand cmdd = new SqlCommand("show_warehouse_quantity", conn);
                    conn.Open();
                    cmdd.Parameters.AddWithValue("warehouse_name", ChoseWareHouseDropDownList.SelectedItem.Text);
                    cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdd.ExecuteNonQuery();
                    conn.Close();

                    inD.InsertToNewInvoice(SeriesDropDownList, SelectCustomerDropDownList, float.Parse(KiloTextBox.Text), float.Parse(CostOfKiloTextBox.Text), DateTime.Now, float.Parse(DiscountTextBox.Text), ChoseWareHouseDropDownList, username);
                    #endregion


                    Response.Redirect("/CustomerPayment.aspx");
                }

                else
                {
                    Response.Write("<script language=javascript>alert('You are not in new invoice mode please update ');</script>");

                }

                #region Hama this region is for printing the incoice

                //Application["kilo"] = KiloTextBox.Text;
                //Application["monyOfKilo"] = CostOfKiloTextBox.Text;
                //Application["discount"] = DiscountTextBox.Text;
                //Application["total"] = TotallTextBox.Text;
                //Application["totalAll"] = TotallAllTextBox.Text;

                //Response.Redirect("Print.aspx");
                // Response.Redirect("Voice Print.aspx");
                #endregion
            }
            catch (Exception)
            {
                #region Hama force the user to select a customer and fill the form correctly
              
                throw;
                #endregion
            }

        }

        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            
           

            SqlCommand cmd = new SqlCommand("Update_salesinvoice", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(Application["salesinvoiceid"]));
            cmd.Parameters.AddWithValue("rate", float.Parse(KiloTextBox.Text));
            cmd.Parameters.AddWithValue("amount", float.Parse(CostOfKiloTextBox.Text));
            cmd.Parameters.AddWithValue("discount", float.Parse(DiscountTextBox.Text));
            cmd.Parameters.AddWithValue("Customer", Convert.ToString(SelectCustomerDropDownList.SelectedItem.Text));
            cmd.Parameters.AddWithValue("Totall", float.Parse(TotallTextBox.Text));
            cmd.Parameters.AddWithValue("Totall_All", float.Parse(TotallAllTextBox.Text));
            cmd.Parameters.AddWithValue("warehouse_ID",Convert.ToString(ChoseWareHouseDropDownList.SelectedItem.Text));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (edit != "")
            {

            }
            else
            {

                Response.Write("<script language=javascript>alert('You are not in updating mode please make new invoice');</script>");

            }
        }

      
        protected void ChoseWareHouseDropDownList_SelectedIndexChanged2(object sender, EventArgs e)
        {
            //show QTY
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            try
            {
                SqlCommand cmdd = new SqlCommand("show_warehouse_quantity", conn);
                conn.Open();
                cmdd.Parameters.AddWithValue("warehouse_name", ChoseWareHouseDropDownList.SelectedItem.Text);
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                amountTextBox.Text = cmdd.ExecuteScalar().ToString();
                cmdd.ExecuteNonQuery();
                conn.Close();

               

            }
            catch (Exception)
            {

                Response.Write("<script language=javascript>alert('No data in this warehouse found');</script>");

            }
        }
    }
}