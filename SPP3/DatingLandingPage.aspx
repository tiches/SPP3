﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatingLandingPage.aspx.cs" Inherits="SPP3.DatingLandingPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Romantic Dating Site</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #ffe6e6; /* Light pink background */
            margin: 0;
            padding: 0;
            text-align: center;
        }
        .container {
            max-width: 800px;
            margin: 100px auto;
            padding: 20px;
            background-color: #fff; /* White background */
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Box shadow */
        }
        h1 {
            color: #ff4d4d; /* Reddish color for title */
        }
        p {
            font-size: 18px;
            line-height: 1.6;
            color: #333; /* Dark text color */
        }
        .links {
            margin-top: 30px;
        }
        .links a {
            display: inline-block;
            padding: 10px 20px;
            margin: 0 10px;
            text-decoration: none;
            color: #fff; /* White text color */
            background-color: #ff4d4d; /* Reddish color for buttons */
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }
        .links a:hover {
            background-color: #e60000; /* Darker shade of red on hover */
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Welcome to our Romantic Dating Site</h1>
        <p>Find your perfect match and start your romantic journey today!</p>
        
        <div class="links">
            <a href="login.aspx">Sign In</a>
            <a href="createlogon.aspx">Sign Up</a>
        </div>
    </div>
</body>
</html>