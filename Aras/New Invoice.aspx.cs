using System;
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
                #region Hama this region is for inserting to the database
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                SqlCommand cmdd = new SqlCommand("show_warehouse_quantity", conn);
                conn.Open();
                cmdd.Parameters.AddWithValue("warehouse_name", ChoseWareHouseDropDownList.SelectedItem.Text);
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;
                cmdd.ExecuteNonQuery();
                conn.Close();

                inD.InsertToNewInvoice(SeriesDropDownList, SelectCustomerDropDownList, float.Parse(KiloTextBox.Text), float.Parse(CostOfKiloTextBox.Text), DateTime.Now, float.Parse(DiscountTextBox.Text), ChoseWareHouseDropDownList);
                #endregion

                
                Response.Redirect("/CustomerPayment.aspx");


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
                //Label1.Visible = true;
                //Label1.Text = "Please fill the form correctly";
                //KiloTextBox.Text = "";
                //CostOfKiloTextBox.Text = "";
                //DiscountTextBox.Text = "";
                //TotallTextBox.Text = "";
                //TotallAllTextBox.Text = "";
                throw;
                #endregion
            }

        }

        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

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