﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="SPP3.ViewProfile" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Profile</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        /* Additional CSS for styling */
        body {
            background-color: #f8f9fa; /* Light gray background */
        }

        .profile-container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .profile-photo {
            text-align: center;
            margin-bottom: 20px;
        }

        .profile-photo img {
            max-width: 100%;
            height: auto;
            border-radius: 10px;
        }

        .profile-info {
            text-align: left;
        }

        .profile-info h3 {
            color: #dc3545; /* Red color */
            margin-bottom: 20px;
        }

        .profile-info p {
            margin-bottom: 10px;
        }

        /* Like button */
        .like-button {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <div class="profile-photo" runat="server" id="divProfilePhoto">
            </div>
            <div class="profile-info">
                <h3 runat="server" id="lblName"></h3>
                <p><strong>Age:</strong> <span runat="server" id="lblAge"></span></p>
                <p><strong>Description:</strong> <span runat="server" id="lblDescription"></span></p>
                 <p><strong>City:</strong> <span runat="server" id="lblCity"></span></p>
                 <p><strong>State:</strong> <span runat="server" id="lblState"></span></p>
                 <p><strong>Height (cm):</strong> <span runat="server" id="lblHeight"></span></p>
                 <p><strong>Weight(kgs):</strong> <span runat="server" id="lblWeight"></span></p>
                 <p><strong>Interests:</strong> <span runat="server" id="lblInterests"></span></p>
                 <p><strong>Likes:</strong> <span runat="server" id="lblLikes"></span></p>
                 <p><strong>Dislikes:</strong> <span runat="server" id="lblDislikes"></span></p>
                 <p><strong>Favorite Restaurants:</strong> <span runat="server" id="lblFavRestaurants"></span></p>
                 <p><strong>Favorite Movies:</strong> <span runat="server" id="lblFavMovies"></span></p>
                 <p><strong>Favorite Quotes:</strong> <span runat="server" id="lblFavQuotes"></span></p>
                 <p><strong>Goals:</strong> <span runat="server" id="lblGoals"></span></p>
                 <p><strong>Commitment Type:</strong> <span runat="server" id="lblCommitmentType"></span></p>
             
            </div>
            <div class="like-button">
                <asp:Button ID="btnSendLike" runat="server" Text="Send Like"  CssClass="btn btn-danger" OnClick="btnSendLike_Click" />
                <asp:Label ID="lblLikeSent" runat="server" CssClass="text-success mt-2" Visible="false"></asp:Label>
            </div>
            <div class="back-button">
                <asp:Button ID="btnBack" runat="server" Text="Back to Browse Users" OnClick="btnBack_Click" CssClass="btn btn-secondary mt-3" />
            </div>
        </div>
    </form>
</body>
</html>