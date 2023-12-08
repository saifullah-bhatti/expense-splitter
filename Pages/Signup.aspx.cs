using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class Signup : System.Web.UI.Page
    {
        SqlConnection saif = new SqlConnection(@"Data Source=SAIFULLAH;Initial Catalog=splitbuddy_2;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            saif.Open();
            SqlCommand cm = new SqlCommand("insert into Signup values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "')", saif);
            cm.ExecuteNonQuery();
            saif.Close();
            Response.Redirect("Login.aspx");
        }
    }
}