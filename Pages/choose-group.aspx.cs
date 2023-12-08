using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class choose_group : Page
    {
        protected void btnNewGroup_Click(object sender, EventArgs e)
        {
            // Redirect to the page for creating a new group
            Response.Redirect("AddMembers.aspx");
        }

        protected void btnOpenGroup_Click(object sender, EventArgs e)
        {
            // Redirect to the page for opening an existing group
            Response.Redirect("Splitbills.aspx");
        }
    }
}