using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class addMembers : Page
    {
        private readonly string connectionString = @"Data Source=SAIFULLAH;Initial Catalog=splitbuddy_2;Integrated Security=True";

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // Check if the group name already exists
            if (GroupNameExists(TextBox1.Text))
            {
                // Display a message that the group name already exists
                LabelMessage.Text = "Group name already exists. Please choose a different group name.";
                return;
            }

            // Check if at least two group members are provided
            if (string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                LabelMessage.Text = "Please provide at least two group member names.";
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Members (GroupName, Currency, Member1, Member2, Member3, Member4, Member5, Member6, Member7, Member8, Member9, Member10) " +
                               "VALUES (@GroupName, @Currency, @Member1, @Member2, @Member3, @Member4, @Member5, @Member6, @Member7, @Member8, @Member9, @Member10)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupName", TextBox1.Text);
                    command.Parameters.AddWithValue("@Currency", currencyList.Value);
                    command.Parameters.AddWithValue("@Member1", TextBox2.Text);
                    command.Parameters.AddWithValue("@Member2", TextBox3.Text);
                    command.Parameters.AddWithValue("@Member3", TextBox4.Text);
                    command.Parameters.AddWithValue("@Member4", TextBox5.Text);
                    command.Parameters.AddWithValue("@Member5", TextBox6.Text);
                    command.Parameters.AddWithValue("@Member6", TextBox7.Text);
                    command.Parameters.AddWithValue("@Member7", TextBox8.Text);
                    command.Parameters.AddWithValue("@Member8", TextBox9.Text);
                    command.Parameters.AddWithValue("@Member9", TextBox10.Text);
                    command.Parameters.AddWithValue("@Member10", TextBox11.Text);

                    command.ExecuteNonQuery();
                }

                // Display success message or perform other actions after successful insertion
                LabelMessage.Text = "Record inserted successfully!";

                // Redirect to Home.aspx
                Response.Redirect("Splitbills.aspx");
            }
        }

        private bool GroupNameExists(string groupName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Members WHERE GroupName = @GroupName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupName", groupName);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
