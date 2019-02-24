using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string username = "";
                if (username=="")
                {
                    try
                    {
                        username = Application["Name"].ToString();
                        Response.Write(username);

                    }
                    catch (Exception)
                    {
                        try
                        {
                            HttpCookie myCookie = Request.Cookies["savedCookie"];
                            username = myCookie.Values["userid"].ToString();
                            Response.Write("Hello " + username + " from cockies");
                        }
                        catch (Exception)
                        {

                            
                        }
                       
                    }
                }
                //customerNameLbl.Text = Application["Name"].ToString();
                //DateLbl.Text = DateTime.Now.ToString();
                //DiscountLbl.Text = Application["discount"].ToString();
                //KiloLbl.Text = Application["kilo"].ToString();
                //TotalAllLbl.Text = Application["totalAll"].ToString();
                //TotalLbl.Text = Application["total"].ToString();
                //AmountLbl.Text = Application["monyOfKilo"].ToString();


               
            }
            catch (Exception)
            {

            }
        }
    }
}