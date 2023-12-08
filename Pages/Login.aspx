<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/LoginStyle.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="login-container">
       <p>
           <label for="TextBox4">Username</label>
           <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
       </p>
       <p>
           <label for="TextBox5">Password</label>
           <asp:TextBox ID="TextBox5" runat="server" TextMode="Password"></asp:TextBox>
       </p>
       <p>
           <asp:Button ID="Button2" runat="server" Text="Login" OnClick="Button2_Click" />
       </p>
       <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
       <div class="signup-link">
           <p>Don't have an account? <a href="SignUp.aspx">Sign up here</a></p>
       </div>
   </div>
</asp:Content>
