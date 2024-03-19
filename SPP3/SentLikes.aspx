<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SentLikes.aspx.cs" Inherits="SPP3.SentLikes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Likes</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Add your custom CSS styles here */
        .like-item {
            border: 1px solid #ccc;
            padding: 10px;
            margin-bottom: 10px;
        }
        .profile-photo {
            width: 50px;
            height: 50px;
            border-radius: 50%;
            margin-right: 10px;
        }
        .profile-name {
            font-weight: bold;
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <div class="container">
        <h1>View Likes</h1>
        <div id="likesContainer" runat="server">
            <!-- Likes will be dynamically added here -->
        </div>
        <asp:Button ID="btnBack" runat="server" Text="Back to Dating Home" CssClass="btn btn-primary" OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>