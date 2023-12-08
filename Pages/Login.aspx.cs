using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection saif2 = new SqlConnection(@"Data Source=SAIFULLAH;Initial Catalog=splitbuddy_2;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            saif2.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Signup WHERE Username ='" + TextBox4.Text + "' AND Password_ = '" + TextBox5.Text + "'", saif2);
            DataTable ds = new DataTable();
            da.Fill(ds);


            saif2.Close();

            if (ds.Rows.Count > 0)
            {
                Response.Redirect("choose-group.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid username or password.";
                ErrorMessageLabel.Visible = true;

            }
        }
    }
}