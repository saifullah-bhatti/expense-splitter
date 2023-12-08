using System;
 // Replace YourNamespace with the actual namespace of your application

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SplitBuddy_2._0.Pages
{
    public partial class Unevenly : System.Web.UI.Page
    {
        private readonly string connectionString = @"Data Source=SAIFULLAH;Initial Catalog=SplitBuddy_2;Integrated Security=True";

        protected void btnSplitUnevenExpenses_Click(object sender, EventArgs e)
{
    // Get the group name from user input
   
    // Get the expense details from user input
    string expenseDescription = txtExpenseDescription.Text.Trim();
    string amountSpent = txtAmountSpent.Text.Trim();
    string payer = ddlPayer.SelectedValue;

    // Validate expense details if needed
    if (string.IsNullOrWhiteSpace(expenseDescription) || string.IsNullOrWhiteSpace(amountSpent) || string.IsNullOrWhiteSpace(payer))
    {
        lblExpenseDistribution.Text = "Please enter valid expense details.";
        return;
    }

            // Get the selected participants
            List<string> participants = new List<string>();
            foreach (ListItem item in chkParticipants.Items)
            {
                if (item.Selected)
                {
                    participants.Add(item.Value);
                }
            }

            // Check if participants are selected
            if (participants.Count == 0)
    {
        lblExpenseDistribution.Text = "Please select participants for the expense.";
        return;
    }

    // Check if the total amount spent is provided
    if (!decimal.TryParse(amountSpent, out decimal totalAmount))
    {
        lblExpenseDistribution.Text = "Please enter a valid amount spent.";
        return;
    }

    // Calculate individual shares based on the amount spent
    Dictionary<string, decimal> individualShares = CalculateUnevenShares(participants, totalAmount);

    // Display the expense distribution
    lblExpenseDistribution.Text = "Expense Distribution:<br />";
    foreach (var participant in individualShares)
    {
        lblExpenseDistribution.Text += $"{participant.Key}: {participant.Value:C}<br />";
    }

    // Insert expense records into the ExpenseRecord table
   
}

        private Dictionary<string, decimal> CalculateUnevenShares(List<string> participants, decimal totalAmount)
        {
            Dictionary<string, decimal> individualShares = new Dictionary<string, decimal>();

            // Your logic to calculate uneven shares based on participants and total amount
            // For simplicity, distributing the total amount evenly among participants in this example
            decimal share = totalAmount / participants.Count;

            foreach (var participant in participants)
            {
                // Check if the participant already exists in the dictionary
                if (individualShares.ContainsKey(participant))
                {
                    // If yes, add the share to the existing value
                    individualShares[participant] += share;
                }
                else
                {
                    // If not, add a new entry
                    individualShares.Add(participant, share);
                }
            }

            return individualShares;
        }
        private void PopulateGroupsDropDown()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT GroupName FROM Members";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ddlPayer.DataSource = reader;
                        ddlPayer.DataTextField = "GroupName";
                        ddlPayer.DataValueField = "GroupName";
                        ddlPayer.DataBind();

                        // Add an empty option at the beginning
                        ddlPayer.Items.Insert(0, new ListItem("Select a group", ""));
                    }
                }
            }
        }
        private void InsertUnevenExpenseRecords(string groupName, string expenseDescription, List<string> participants, Dictionary<string, decimal> individualShares, string payer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Use a transaction to ensure atomicity of database operations
                    using (SqlCommand insertCommand = connection.CreateCommand())
                    {
                        insertCommand.Transaction = transaction;

                        foreach (var participant in participants)
                        {
                            // Customize this part based on your actual ExpenseRecord table structure
                            insertCommand.CommandText = "INSERT INTO ExpenseRecord (GroupName, ExpenseDescription, MemberName, ExpenseAmount, Payer) VALUES (@GroupName, @ExpenseDescription, @MemberName, @ExpenseAmount, @Payer)";
                            insertCommand.Parameters.Clear();
                            insertCommand.Parameters.AddWithValue("@GroupName", groupName);
                            insertCommand.Parameters.AddWithValue("@ExpenseDescription", expenseDescription);
                            insertCommand.Parameters.AddWithValue("@MemberName", participant);
                            insertCommand.Parameters.AddWithValue("@ExpenseAmount", individualShares[participant]);
                            insertCommand.Parameters.AddWithValue("@Payer", payer);

                            // Execute the INSERT statement
                            insertCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction if all operations succeed
                        transaction.Commit();

                        // Display a success message or redirect the user
                        lblExpenseDistribution.Text = "Expense records inserted successfully!";
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions and roll back the transaction
                    transaction.Rollback();

                    // Log or display the error message
                    lblExpenseDistribution.Text = $"An error occurred: {ex.Message}";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdown with groups
                PopulateGroupsDropDown();

                // Populate the checkbox list with participants
                PopulateParticipantsCheckBoxList();
            }
            else
            {
                // Check if the event was caused by a change in ddlPayer
                if (Request.Form[ddlPayer.UniqueID] != null)
                {
                    string selectedGroupName = ddlPayer.SelectedValue;

                    // Populate the ddlPayer dropdown with members of the selected group
                    PopulatePayerDropDown(selectedGroupName);
                }
            }
        }

        private void PopulatePayerDropDown(string selectedGroupName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Modify your query to use a parameter
                string query = "SELECT DISTINCT MemberName FROM Members WHERE GroupName = @GroupName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the @GroupName parameter and provide its value
                    command.Parameters.AddWithValue("@GroupName", selectedGroupName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ddlPayer.DataTextField = "MemberName";
                        ddlPayer.DataValueField = "MemberName";
                        ddlPayer.DataSource = reader;
                        ddlPayer.DataBind();

                        // Add an empty option at the beginning
                        ddlPayer.Items.Insert(0, new ListItem("Select a payer", ""));
                    }
                }
            }
        }



        // Extensions.cs


        private void PopulateParticipantsCheckBoxList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MemberID, GroupName, Currency, Member1, Member2, Member3, Member4, Member5, Member6, Member7, Member8, Member9, Member10, Weight FROM Members";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Iterate through the Member columns (Member1 to Member10)
                            for (int i = 1; i <= 10; i++)
                            {
                                string memberColumnName = $"Member{i}";

                                // Check if the column exists in the result set
                                if (reader.HasColumn(memberColumnName))
                                {
                                    // Assuming 'MemberName' is the desired result
                                    string memberName = reader[memberColumnName].ToString();

                                    // Add the 'MemberName' to the CheckBoxList
                                    chkParticipants.Items.Add(new ListItem(memberName, memberName));
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void ddlPayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroupName = ddlPayer.SelectedValue;
            PopulatePayerDropDown(selectedGroupName);
        }






    }
}
