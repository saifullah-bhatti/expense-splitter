using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class Splitbills : Page
    {
        private readonly string connectionString = @"Data Source=SAIFULLAH;Initial Catalog=SplitBuddy_2;Integrated Security=True";

        protected void btnSplitExpenses_Click(object sender, EventArgs e)
        {
            // Get the group name from user input
            string groupName = txtGroupName.Text.Trim();

            // Validate the group name if needed
            if (string.IsNullOrWhiteSpace(groupName))
            {
                lblExpenseDistribution.Text = "Please enter a valid group name.";
                return;
            }

            // Get the group members based on the provided group name
            List<string> members = GetGroupMembers(groupName);

            // Check if there are members in the group
            if (members.Count == 0)
            {
                lblExpenseDistribution.Text = "No members found in the group.";
                return;
            }

            // Check if the total amount is provided
            if (string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                lblExpenseDistribution.Text = "Please enter the total amount spent.";
                return;
            }

            // Calculate the share for each member
            decimal totalAmount = decimal.Parse(txtTotalAmount.Text);
            decimal share = totalAmount / members.Count;

            // Display the expense distribution
            lblExpenseDistribution.Text = "Expense Distribution:<br />";
            foreach (var member in members)
            {
                lblExpenseDistribution.Text += $"{member}: {share:C}<br />";
            }

            // Insert expense records into the ExpenseRecord table
            InsertExpenseRecords(groupName, members, share);
        }

        protected void btnViewGroups_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT GroupName FROM Members";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        gridViewGroups.DataSource = reader;
                        gridViewGroups.DataBind();
                    }
                }
            }
        }

        protected void gridViewGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectGroup")
            {
                // Handle the "SelectGroup" command
                string groupName = e.CommandArgument.ToString();

                // Your logic to handle the selection of a group, e.g., redirect to a detailed view or perform some action
                txtGroupName.Text = groupName;
            }
            // Add more conditions for other commands if needed
        }
        private Guid GenerateUniqueMemberID()
        {
            // Generate a new GUID (unique identifier)
            return Guid.NewGuid();
        }

        private List<string> GetGroupMembers(string groupName)
        {
            List<string> members = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use a SELECT query to retrieve members based on the group name
                string query = $"SELECT Member1, Member2, Member3, Member4, Member5, Member6, Member7, Member8, Member9, Member10 FROM Members WHERE GroupName = @GroupName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupName", groupName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                // Read member values from the SqlDataReader
                                string member = reader[$"Member{i}"] as string;
                                if (!string.IsNullOrWhiteSpace(member))
                                {
                                    members.Add(member);
                                }
                            }
                        }
                    }
                }
            }

            return members;
        }
        private void InsertExpenseRecords(string groupName, List<string> members, decimal share)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use an INSERT query to insert expense records into the ExpenseRecord table
                string insertQuery = "INSERT INTO ExpenseRecord (GroupName, MemberName, ExpenseAmount) VALUES (@GroupName, @MemberName, @ExpenseAmount)";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    foreach (var member in members)
                    {
                        // Customize this part based on your actual ExpenseRecord table structure
                        insertCommand.Parameters.Clear();
                        insertCommand.Parameters.AddWithValue("@GroupName", groupName);
                        insertCommand.Parameters.AddWithValue("@MemberName", member);
                        insertCommand.Parameters.AddWithValue("@ExpenseAmount", share);

                        // Execute the INSERT statement
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}