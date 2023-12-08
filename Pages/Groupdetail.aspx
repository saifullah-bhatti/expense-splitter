<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Groupdetail.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Groupdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
       <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f8ff; /* Light blue background color */
            margin: 0;
            padding: 0;
        }

        .group-details-container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .group-details-header {
            text-align: center;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .group-card {
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 15px;
            margin-bottom: 20px;
            transition: transform 0.3s;
        }

        .group-card:hover {
            transform: scale(1.05);
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
        }

        .group-name {
            font-size: 20px;
            font-weight: bold;
            color: #333;
            margin-bottom: 10px;
        }

        .group-members {
            font-size: 16px;
            color: #666;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="group-details-container">
        <div class="group-details-header">
            Group Details
        </div>

        <!-- Container for dynamically generated group cards -->
        <div id="groupDetailsContainer" runat="server"></div>
    </div>
</asp:Content>
