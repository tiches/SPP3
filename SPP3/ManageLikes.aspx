<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageLikes.aspx.cs" Inherits="SPP3.ManageLikes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Likes</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .card {
            background-color: #dc3545;
            color: white;
            border: none;
        }

        .btn-primary, .btn-secondary {
            background-color: #dc3545;
            border-color: #dc3545;
        }

        .btn-primary:hover, .btn-secondary:hover {
            background-color: #bd2130;
            border-color: #bd2130;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2 class="text-center mb-4">View Likes</h2>
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card text-center">
                        <div class="card-body">
                            <h5 class="card-title">View Sent Likes</h5>
                            <a href="SentLikes.aspx" class="btn btn-primary">View</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card text-center">
                        <div class="card-body">
                            <h5 class="card-title">View Received Likes</h5>
                            <a href="ReceivedLikes.aspx" class="btn btn-primary">View</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center mt-4">
                <div class="col-md-6">
                    <a href="DatingAppHome.aspx" class="btn btn-secondary">Back to Dating Home</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>