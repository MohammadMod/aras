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
        protected void Page_Load(object sender, EventArgs e)
        {

            
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
        

            #endregion
        }

        protected void SubmitNewInvoiceButton_Click(object sender, EventArgs e)
        {

          
            try
            {
                #region Hama this region is for inserting to the database
                inD.InsertToNewInvoice(SeriesDropDownList, SelectCustomerDropDownList, float.Parse(KiloTextBox.Text), float.Parse(CostOfKiloTextBox.Text), DateTime.Now, float.Parse(DiscountTextBox.Text));
                Response.Redirect("ShowSalesInvoice.aspx");
                #endregion

                #region Hama this region is for printing the incoice
                Application["kilo"] = KiloTextBox.Text;
                Application["monyOfKilo"] = CostOfKiloTextBox.Text;
                Application["discount"] = DiscountTextBox.Text;
                Application["total"] = TotallTextBox.Text;
                Application["totalAll"] = TotallAllTextBox.Text;

                // Response.Redirect("Voice Print.aspx");
                #endregion
            }
            catch (Exception)
            {
                #region Hama force the user to select a customer and fill the form correctly
                Label1.Visible = true;
                Label1.Text = "Please fill the form correctly";
                KiloTextBox.Text = "";
                CostOfKiloTextBox.Text = "";
                DiscountTextBox.Text = "";
                TotallTextBox.Text = "";
                TotallAllTextBox.Text = "";
                #endregion
            }

        }

        protected void SelectCustomerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}