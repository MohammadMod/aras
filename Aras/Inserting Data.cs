using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aras
{
    public class Inserting_Data
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        public string alertIsAvilable { set; get; }
        public void InsertToNewInvoice(DropDownList series, DropDownList customer, float rate, float amount, DateTime date, float discount)
        {
            #region for new invoice form inserting data to db
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_sales_Invoce", con);

                con.Open();

                cmd.Parameters.AddWithValue("series", series.SelectedItem.Text);
                cmd.Parameters.AddWithValue("Customer", customer.SelectedIndex);

                cmd.Parameters.AddWithValue("rate", rate);
                cmd.Parameters.AddWithValue("amount", amount);

                cmd.Parameters.AddWithValue("posting_date", date);
                cmd.Parameters.AddWithValue("discount", discount);
                cmd.Parameters.AddWithValue("sales_invoice_advance_payment_ID", DBNull.Value);

                cmd.Parameters.AddWithValue("satute", "unpaid");

                cmd.Parameters.AddWithValue("Totall", rate * amount);
                cmd.Parameters.AddWithValue("Totall_All", rate * amount - discount);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            #endregion


        }

        public void registerUsers(string userName,string FullName,int phoneNumber,string location,string Password)
        {


            //checking for avilability of the username 
            try
            {
                con.Open();

                SqlCommand cmdd = new SqlCommand("select * from [regester_table] where complite_name='" + userName + "'", con);

                cmdd.Parameters.AddWithValue("name", userName);

                SqlDataReader rd = cmdd.ExecuteReader();

                if (rd.HasRows)
                {
                    alertIsAvilable="username is available";
                    
                }
                else
                {
                    con.Close();

                    //register the user if the username is avilable or not
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT_Regester", con);

                        con.Open();
                        cmd.Parameters.AddWithValue("name", FullName);
                        cmd.Parameters.AddWithValue("last_name", "LastName");
                        cmd.Parameters.AddWithValue("phone_number", phoneNumber);
                        cmd.Parameters.AddWithValue("location", location);
                        cmd.Parameters.AddWithValue("complite_name", userName);
                        cmd.Parameters.AddWithValue("pin_cod", Password);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        con.Close();


                    }

                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void newSupplier(string supplierName,string depitMoney,string location, CheckBox DisableCheckBox, string supplierPhoneNumer )
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_Supplier", con);

                con.Open();
                cmd.Parameters.AddWithValue("name", supplierName);
                cmd.Parameters.AddWithValue("company_name", "Aras");
                cmd.Parameters.AddWithValue("debit", depitMoney);
                cmd.Parameters.AddWithValue("location", location);

                if (DisableCheckBox.Checked == true)
                {
                    cmd.Parameters.AddWithValue("disable", "1");
                }

                else
                {
                    cmd.Parameters.AddWithValue("disable", "0");
                }
                cmd.Parameters.AddWithValue("phone_number", supplierPhoneNumer);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}