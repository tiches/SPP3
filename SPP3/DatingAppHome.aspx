<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatingAppHome.aspx.cs" Inherits="SPP3.DatingAppHome" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dating App - Home</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <!-- Your custom CSS for dating app theme -->
    <style>
        /* Add your custom CSS for dating app theme here */
        body {
            background-color: #f8f9fa; /* Light gray background */
        }
        .header {
            background-color: #ff4d4d; /* Red color for header */
            color: #fff; /* White text color */
            padding: 20px;
            text-align: center;
        }
        .container {
            margin-top: 50px;
        }
    </style>
</head>
<body>
    <div class="header">
        <h1><asp:Label ID="lblWelcomeMessage" runat="server" /></h1>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h2>Navigation</h2>
                <ul class="list-group">
                    <li class="list-group-item"><a href="ManageProfile.aspx">Manage Public Profile</a></li>
                    <li class="list-group-item"><a href="BrowseProfiles.aspx">Browse Users</a></li>
                     <li class="list-group-item"><a href="ViewLikes.aspx">View Likes</a></li>
                    <li class="list-group-item"><a href="view-matches.aspx">View Matches</a></li>
                    <li class="list-group-item"><a href="view-dates.aspx">View Dates</a></li>
                </ul>
            </div>
            <!-- You can add more sections/columns here -->
            <div class="col-md-6">
                <h2>User Information</h2>
                <p><strong>Username:</strong> <asp:Label ID="lblUsername" runat="server" /></p>
                <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></p>
            </div>
        </div>
    </div>
</body>
</html>