﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write("Welcome: " + Session["username"].ToString());
            }
            catch (Exception)
            {

                Response.Redirect("login.aspx");
            }
            


        }
    }
}