﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class Purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Hama Region
            TotallAllTextBox.Enabled = false;
            dateTimeTextBox.Enabled = false;
            dateTimeTextBox.Text = DateTime.Now.ToString();


            string Name = Application["Name"].ToString();
            Response.Write("Welcome: " + Name);

            #endregion


        }
    }
}