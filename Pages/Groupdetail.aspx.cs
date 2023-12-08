using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace SplitBuddy_2._0.Pages
{
    public partial class Groupdetail : Page
    {
        private readonly string connectionString = @"Data Source=SAIFULLAH;Initial Catalog=splitbuddy_2;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load group details when the page is first loaded
                LoadGroupDetails();
            }
        }

        private void LoadGroupDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT GroupName, Currency, Member1, Member2, Member3, Member4, Member5, Member6, Member7, Member8, Member9, Member10 FROM Members";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create a new group card
                            GroupCard groupCard = new GroupCard
                            {
                                GroupName = reader["GroupName"].ToString(),
                                Currency = reader["Currency"].ToString(),
                                Members = new string[]
                                {
                                    reader["Member1"].ToString(),
                                    reader["Member2"].ToString(),
                                    reader["Member3"].ToString(),
                                    reader["Member4"].ToString(),
                                    reader["Member5"].ToString(),
                                    reader["Member6"].ToString(),
                                    reader["Member7"].ToString(),
                                    reader["Member8"].ToString(),
                                    reader["Member9"].ToString(),
                                    reader["Member10"].ToString()
                                }
                            };

                            // Add the group card to the page
                            AddGroupCard(groupCard);
                        }
                    }
                }
            }
        }

        private void AddGroupCard(GroupCard groupCard)
        {
            // Create a new div for the group card
            System.Web.UI.HtmlControls.HtmlGenericControl divGroupCard = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            divGroupCard.Attributes["class"] = "group-card";

            // Add group name to the group card
            System.Web.UI.HtmlControls.HtmlGenericControl divGroupName = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            divGroupName.Attributes["class"] = "group-name";
            divGroupName.InnerText = groupCard.GroupName;
            divGroupCard.Controls.Add(divGroupName);

            // Add members to the group card
            System.Web.UI.HtmlControls.HtmlGenericControl divMembers = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            divMembers.Attributes["class"] = "group-members";
            divMembers.InnerText = "Members: " + string.Join(", ", groupCard.Members);
            divGroupCard.Controls.Add(divMembers);

            // Add the group card to the container
            groupDetailsContainer.Controls.Add(divGroupCard);
        }

        // Class to represent a group card
        private class GroupCard
        {
            public string GroupName { get; set; }
            public string Currency { get; set; }
            public string[] Members { get; set; }
        }
    }
}
