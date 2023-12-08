<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SplitBuddy_2._0.Pages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="description" content="Welcome to SplitPal - Your Ultimate Expense Splitting Solution">
    <link href="../CSS/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
     <h1>&nbsp;</h1>
     <h1>Hassle-Free</h1>
     <h1>Expense sharing</h1>
     <h1>Website</h1>
     <p>&nbsp;</p>
     <p id="features" class="nav-links show">
         <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Solid" Height="45px" ImageUrl="~/images/5.jpg" OnClick="ImageButton" Width="136px" />
     </p>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
     <h2 class="auto-style8"><span class="auto-style9">Split your expenses on different scenarios</span> </h2>
     <p class="auto-style8">
         Regardless of your use case, SplitPal is here to help track and split your expenses right away.
     </p>

     <!-- New section with features -->
     <section id="features">
         <div class="box bg-light">
             <i class="fas fa-hotel fa-3x"></i>
             <h3>
             <img class="auto-style5" src="../images/1.jpg" alt="Image 1" /></h3>
             <h3>Split Restaurant Bills</h3>
             <p class="feature-text">SplitPal is developed to resolve complex itemized calculations on the spot and easily share with your friends. Assign each item and let the app calculate tip and taxes.</p>
         </div>
         <div class="box bg-primary">
             <i class="fas fa-utensils fa-3x"></i>
             <h3>
             <img class="auto-style6" src="../images/2.jpg" alt="Image 2" /></h3>
             <h3>Split Travel Expenses</h3>
             <p class="feature-text">Figuring out splitting expenses during your vacation sure would be tiring with a big group. SplitPal is here to help with splitting travel expenses with different participants for each activity.</p>
         </div>
         <div class="box bg-light">
             <i class="fas fa-dumbbell fa-3x"></i>
             <h3>
             <img class="auto-style7" src="../images/3.jpg" alt="Image 3" /></h3>
             <h3>Split Rent, Utilities with Roommates</h3>
             <p class="feature-text">Use SplitPal as a roommate expense tracker to freely add your monthly expenses such as groceries, rent, utilities, and so on with the ability to share through a simple link.</p>
         </div>
     </section>

     <!-- Apply additional styles to the features section -->
     <style>
         /* Additional styles for the features section */
         #features {
             overflow: auto;
             padding: 5px;
         }

         .box {
             float: left;
             width: 33.3%;
             padding: 50px;
             text-align: center;
         }

         .box i {
             margin-bottom: 2px;
         }

         .auto-style5 {
             width: 310px;
             height: 205px;
             margin-left: 3px;
         }

         
         .auto-style6 {
             width: 310px;
             height: 205px;
             margin-left: 9px;
             margin-top: 4px;
         }
         .auto-style7 {
             width: 310px;
             height: 205px;
             margin-left: 4px;
         }
         .auto-style8 {
             text-align: center;
         }
         .auto-style9 {
             font-size: larger;
         }
         
     </style>

     <p class="auto-style2">
         &nbsp;
     </p>
     &nbsp;
     <h3 class="elementor-image-box-title"></h3>
     <p class="elementor-heading-title elementor-size-default">
         &nbsp;</p>
     <p>&nbsp;</p>
 </div>
</asp:Content>
