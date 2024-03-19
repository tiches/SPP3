<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMatches.aspx.cs" Inherits="SPP3.ManageMatches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Matches</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .match-item {
            margin-bottom: 20px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .match-item img {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            margin-right: 10px;
        }

        .match-delete-btn {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
    <div class="row">
        <div class="col">
            <asp:Button ID="btnBack" runat="server" Text="Back to Dating App Home" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
        </div>
    </div>
        <div class="container">
            <h2>Matches</h2>
            <div id="matchesContainer" runat="server">
                <!-- Matches will be dynamically added here -->
            </div>
        </div>
    </form>
</body>
</html>