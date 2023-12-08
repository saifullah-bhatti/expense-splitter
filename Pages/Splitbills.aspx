<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="false" CodeBehind="Splitbills.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Splitbills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f8ff; /* Light blue background color */
        }

        .expenses-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .expenses-container p {
            margin-bottom: 15px;
        }

        .expenses-container label {
            display: block;
            font-weight: bold;
        }

        .expenses-container input {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .expenses-container input::placeholder {
            color: #ccc;
        }

        .expenses-container button {
            background-color: #3366FF; /* Light blue button color */
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .expenses-container button:hover {
            background-color: #2980b9; /* Darker blue on hover */
        }

        .auto-style3 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="expenses-container">
        <label for="txtTotalAmount">
            <div class="auto-style3">
                Total Amount Spent
            </div>
        </label>
        <p>
            <asp:TextBox ID="txtTotalAmount" runat="server" Height="38px" placeholder="Enter total amount"></asp:TextBox>
        </p>

        <label for="txtGroupName">
            <div class="auto-style3">
                Group Name
            </div>
        </label>
        <p>
            <asp:TextBox ID="txtGroupName" runat="server" Height="38px" placeholder="Enter group name"></asp:TextBox>
        </p>

        <asp:Button ID="btnSplitExpenses" runat="server" BackColor="#3366FF" ForeColor="White" OnClick="btnSplitExpenses_Click" Text="Split Expenses" />

        <h2>Expense Distribution:</h2>
        <asp:Label ID="lblExpenseDistribution" runat="server" Text=""></asp:Label>
        
        <asp:GridView ID="gridViewGroups" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupName"
            OnRowCommand="gridViewGroups_RowCommand" CssClass="gridview">
            <Columns>
                <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GroupName" />
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:Button ID="btnSelectGroup" runat="server" CommandName="SelectGroup" CommandArgument='<%# Eval("GroupName") %>'
                            Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- Move the button inside the expenses container -->
        <asp:Button ID="btnViewGroups" runat="server" Text="View Existing Groups" OnClick="btnViewGroups_Click" />
    </div>
</asp:Content>
