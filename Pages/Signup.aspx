<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Signup.css" rel="stylesheet" />
     <script>
         
     function validateFields() {
         var password = document.getElementById('<%= TextBox3.ClientID %>').value;
         var confirmPassword = document.getElementById('<%= TextBox4.ClientID %>').value;
         var dob = document.getElementById('<%= TextBox5.ClientID %>').value;

         if (password === confirmPassword && dob !== "") {
             document.getElementById('<%= Button1.ClientID %>').disabled = false;
             document.getElementById('<%= Button1.ClientID %>').style.opacity = 1;
         } else {
             document.getElementById('<%= Button1.ClientID %>').disabled = true;
             document.getElementById('<%= Button1.ClientID %>').style.opacity = 0.5;
         }
     }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="signup-container">
     <p>
         <label for="TextBox1">Username</label>
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     </p>
     <p>
         <label for="TextBox2">Email</label>
         <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
     </p>
     <p>
         <label for="TextBox3">Password</label>
         <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" oninput="validateFields()"></asp:TextBox>
     </p>
     <p>
         <label for="TextBox4">Confirm Password</label>
         <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" oninput="validateFields()"></asp:TextBox>
     </p>
     <p>
         <label for="TextBox5">Date of Birth</label>
         <asp:TextBox ID="TextBox5" runat="server" oninput="validateFields()"></asp:TextBox>
     </p>
     <p>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Signup" disabled />
     </p>
 </div>
</asp:Content>
