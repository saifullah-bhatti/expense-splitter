<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="choose-group.aspx.cs" Inherits="SplitBuddy_2._0.Pages.choose_group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f8ff; /* Light blue background color */
            margin: 0;
            padding: 0;
        }

        .select-container {
            max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .auto-style3 {
            text-align: center;
            color: #3498db; /* Header color */
        }

        /* Style for the image buttons and labels */
        .button-container {
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: center;
            margin-top: 20px;
        }

        .image-btn {
            border: none;
            background: none;
            cursor: pointer;
            transition: transform 0.3s, color 0.3s;
            margin: 0 10px;
        }

        .image-btn:hover {
            transform: scale(1.1);
            color: #3498db; /* Header color on hover */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="select-container">
        <h2 class="auto-style3">Select an Option</h2>

        <!-- Button container for horizontal arrangement -->
        <div class="button-container">
            <!-- Image button for making a new group -->
            <asp:ImageButton ID="imgBtnNewGroup" runat="server" ImageUrl="~/Images/6.png" CssClass="image-btn" OnClick="btnNewGroup_Click" Height="80px" Width="104px" />

            <asp:Label ID="Label1" runat="server" Text="Make a New Group"></asp:Label>

            <!-- Image button for opening an existing group -->
            <asp:ImageButton ID="imgBtnOpenGroup" runat="server" ImageUrl="~/Images/7.png" CssClass="image-btn" OnClick="btnOpenGroup_Click" Height="80px" Width="104px" />

            <asp:Label ID="Label2" runat="server" Text="Open Existing Group"></asp:Label>
        </div>
    </div>
</asp:Content>
