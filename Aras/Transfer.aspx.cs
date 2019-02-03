using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    
    public partial class Transfer : System.Web.UI.Page
    {
        BindingData bd = new BindingData();
        protected void Page_Load(object sender, EventArgs e)
        {
            bd.wareHouseName(FromWareHouseDropDownList);
            bd.wareHouseName(ToWareHouseDropDownList);
        }
    }
}