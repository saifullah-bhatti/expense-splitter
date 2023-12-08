<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Unevenly.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Unevenly" %>
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
            text-align: center; /* Center-align the container */
        }

        .expenses-container p {
            margin-bottom: 15px;
        }

        .expenses-container label {
            display: block;
            font-weight: bold;
            text-align: left; /* Left-align labels */
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

        </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <label for="txtExpenseDescription">
    <div class="auto-style1">
        Expense Description
    </div>
</label>
<p>
    <asp:TextBox ID="txtExpenseDescription" runat="server" Height="38px" placeholder="Enter expense description"></asp:TextBox>
</p>
     
<label for="txtAmountSpent">
    <div class="auto-style1">
        Amount Spent
    </div>
</label>
<p>
    <asp:TextBox ID="txtAmountSpent" runat="server" Height="38px" placeholder="Enter amount spent"></asp:TextBox>
</p>
     <label for="ddlPayer">
        <div class="auto-style1">
            Select Group
        </div>
    </label>
    <p class="auto-style1">
<asp:DropDownList ID="ddlPayer" runat="server" AutoPostBack="true"></asp:DropDownList>
    </p>

 <label for="chkParticipants">
        <div class="auto-style1">
            Participants
        </div>
    </label>
    <p class="auto-style1">
        <asp:CheckBoxList ID="chkParticipants" runat="server"></asp:CheckBoxList>
    </p>

<label for="ddlPayer">
    <div class="auto-style1">
        Payer
    </div>
</label>

<p class="auto-style1">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPayer_SelectedIndexChanged"></asp:DropDownList>

    <asp:CheckBoxList ID="chkParticipants0" runat="server"></asp:CheckBoxList>
</p>
            <asp:Label ID="lblExpenseDistribution" runat="server" Text=""></asp:Label>

<asp:Button ID="btnSplitUnevenExpenses" runat="server" BackColor="#3366FF" ForeColor="White" OnClick="btnSplitUnevenExpenses_Click" Text="Split Uneven Expenses" />
</asp:Content>
