﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}