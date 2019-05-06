using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Aras
{
    public partial class Purchase : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        Inserting_Data inD = new Inserting_Data();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        string edit = "";
        bool check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region update
            try
            {
                edit = Application["purchaseinvoiceid"].ToString();


                SqlCommand cmd = new SqlCommand("showPurchase_invoice_for_update", conn);
                conn.Open();


                cmd.Parameters.AddWithValue("ID", Int64.Parse(edit));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    ViewSupplierDropDownList.SelectedValue = dr[1].ToString();
                    WareHouseSelectDropDownList.SelectedValue = dr[7].ToString();

                    KiloTextBox.Text = dr[3].ToString();
                    TotallAllTextBox.Text = dr[4].ToString();

                    CostTextBox.Text = dr[5].ToString();




                }
                dr.Close();
            }
            catch (Exception)
            {
                check = true;
            }



            if (check == false)
            {
                PurchaseButton.Enabled = false;
                updateButton.Enabled = true;

                PurchaseButton.Visible = false;
                updateButton.Visible = true;
            }

            else
            {
                PurchaseButton.Enabled = true;
                updateButton.Enabled = false;

                PurchaseButton.Visible = true;
                updateButton.Visible = false;
            }

            conn.Close();


            #endregion

            #region Hama Region
            TotallAllTextBox.Enabled = false;
            dateTimeTextBox.Enabled = false;
            dateTimeTextBox.Text = DateTime.Now.ToString();

            if (!IsPostBack)
            {
                bd.SupplierName(ViewSupplierDropDownList);
                bd.wareHouseName(WareHouseSelectDropDownList);
            }

            //string Name = Application["Name"].ToString();
            //Response.Write("Welcome: " + Name);

            #endregion



        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            inD.InsertPurchase(ViewSupplierDropDownList, dateTimeTextBox.Text, float.Parse(KiloTextBox.Text), float.Parse(CostTextBox.Text),WareHouseSelectDropDownList);
            Response.Redirect("Show Payment Entry Purchase.aspx");
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update_purchase_invoice_up", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(Application["purchaseinvoiceid"]));
            cmd.Parameters.AddWithValue("Supplier_ID", Convert.ToString(ViewSupplierDropDownList.SelectedItem.Text));
            cmd.Parameters.AddWithValue("rate", int.Parse(KiloTextBox.Text));
            cmd.Parameters.AddWithValue("totall_amount", int.Parse(TotallAllTextBox.Text));
            cmd.Parameters.AddWithValue("amount", int.Parse(CostTextBox.Text));
            cmd.Parameters.AddWithValue("warehouse_ID", Convert.ToString(WareHouseSelectDropDownList.SelectedItem.Text));
           
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
    }
}