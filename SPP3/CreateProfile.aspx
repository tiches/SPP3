<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="SPP3.CreateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Profile</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/> 
    <style>
        /* Your custom CSS for dating app theme */
        body {
            background-color: #f8f9fa; /* Light gray background */
        }
        .container {
            margin-top: 50px;
        }
        .form-group {
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Create Profile</h2>

           <div class="form-group">
    <label for="txtProfilePhoto">Profile Photo URL:</label>
    <asp:TextBox ID="txtProfilePhotoUrl" runat="server" CssClass="form-control"></asp:TextBox>
</div>
               <div class="form-group">
    <label for="txtAddress">Address:</label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtPhone">Phone:</label>
    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtOccupation">Occupation:</label>
    <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtAge">Age:</label>
    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtHeight">Height (cm):</label>
    <asp:TextBox ID="txtHeight" runat="server" CssClass="form-control"></asp:TextBox>
    
</div>
<div class="form-group">
    <label for="txtWeight">Weight:</label>
    <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control"></asp:TextBox>
    
</div>
<div class="form-group">
    <label for="ddlCommitmentType">Commitment Type:</label>
    <asp:DropDownList ID="ddlCommitmentType" runat="server" CssClass="form-control">
        <asp:ListItem Text="Friends" Value="Friends"></asp:ListItem>
        <asp:ListItem Text="Dating" Value="Dating"></asp:ListItem>
        <asp:ListItem Text="Long Term" Value="Long Term"></asp:ListItem>
    </asp:DropDownList>
</div>
<div class="form-group">
    <label for="txtInterests">Interests:</label>
    <asp:TextBox ID="txtInterests" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtLikesDislikes">Likes/Dislikes:</label>
    <asp:TextBox ID="txtLikesDislikes" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtFavoriteRestaurants">Favorite Restaurants:</label>
    <asp:TextBox ID="txtFavoriteRestaurants" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtFavoriteMovies">Favorite Movies:</label>
    <asp:TextBox ID="txtFavoriteMovies" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtFavoriteBooks">Favorite Books:</label>
    <asp:TextBox ID="txtFavoriteBooks" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtFavoriteQuotes">Favorite Quotes:</label>
    <asp:TextBox ID="txtFavoriteQuotes" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtGoals">Goals:</label>
    <asp:TextBox ID="txtGoals" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtDescription">Description:</label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<asp:Button ID="btnSubmit" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>
            </form>
            </body>
    </html>