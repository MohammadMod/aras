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
            if (!IsPostBack)
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

          
                bd.SupplierName(ViewSupplierDropDownList);
                bd.wareHouseName(WareHouseSelectDropDownList);
            }

       

            #endregion



        }

        protected void PurchaseButton_Click(object sender, EventArgs e)
        {
            inD.InsertPurchase(ViewSupplierDropDownList, dateTimeTextBox.Text, float.Parse(KiloTextBox.Text), float.Parse(CostTextBox.Text),WareHouseSelectDropDownList);

            Application["purchaseinvoiceid"] = "";
            Response.Redirect("Show Payment Entry Purchase.aspx");
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {

            string supplier= ViewSupplierDropDownList.SelectedItem.Value.ToString();
            string wareHouse = WareHouseSelectDropDownList.SelectedItem.Value.ToString();
            float total_amount = float.Parse(TotallAllTextBox.Text);

            SqlCommand cmd = new SqlCommand("Update_purchase_invoice_up", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(Application["purchaseinvoiceid"].ToString());
            cmd.Parameters.Add("@Supplier_ID", SqlDbType.NVarChar).Value = supplier;
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = float.Parse(KiloTextBox.Text);
            cmd.Parameters.Add("@totall_amount", SqlDbType.Float).Value = float.Parse(KiloTextBox.Text) * float.Parse(CostTextBox.Text);
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = float.Parse(CostTextBox.Text);
            cmd.Parameters.Add("@warehouse_ID", SqlDbType.NVarChar).Value = wareHouse;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Application["purchaseinvoiceid"] = "";
                Response.Redirect("Show Payment Entry Purchase.aspx");

        
           
        }
    }
}