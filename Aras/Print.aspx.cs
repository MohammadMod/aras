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
                //customerNameLbl.Text = Application["Name"].ToString();
                DateLbl.Text = DateTime.Now.ToString();
                DiscountLbl.Text = Application["discount"].ToString();
                KiloLbl.Text = Application["kilo"].ToString();
                TotalAllLbl.Text = Application["totalAll"].ToString();
                TotalLbl.Text = Application["total"].ToString();
                AmountLbl.Text = Application["monyOfKilo"].ToString();

               
            }
            catch (Exception)
            {

            }
        }
    }
}