<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="SPP3.ManageProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Profile</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        
        body {
            background-color: #f8f9fa; /* Light gray background */
        }
        .container {
            margin-top: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col">
                    <a href="DatingAppHome.aspx" class="btn btn-secondary float-right">Back</a>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <h2>Manage Profile</h2>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" CssClass="btn btn-primary" OnClick="btnEditProfile_Click" />
                </div>
            </div>
            <div class="row mt-3">
                <div class="col">
                    <asp:Button ID="btnToggleStatus" runat="server" Text="Activate/Deactivate Profile" CssClass="btn btn-warning" OnClick="btnToggleStatus_Click" />
                </div>
            </div>
            <div class="row mt-3">
                <div class="col">
                    <asp:Label ID="lblProfileStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>