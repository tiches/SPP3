<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseProfiles.aspx.cs" Inherits="SPP3.BrowseProfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Browse Profiles</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .card {
            width: 300px; /* Fixed width for each card */
            margin: 10px; /* Margin between cards */
        }

        .card-img-top {
            width: 100%;
            height: 200px; /* Fixed height for the profile image */
            object-fit: cover;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Back button and search links -->
            <div class="row mb-3">
                <div class="col">
                    <a href="DatingAppHome.aspx" class="btn btn-secondary">Back</a>
                </div>
                <div class="col text-right">
                    <!-- search links here -->
                   <asp:DropDownList ID="ddlSearchCriteria" runat="server" CssClass="mr-2">
                        <asp:ListItem Value="Age">Search by Age</asp:ListItem>
                        <asp:ListItem Value="City">Search by City</asp:ListItem>
                        <asp:ListItem Value="Interests">Search by Interests</asp:ListItem>
                        <asp:ListItem Value="Name">Search by Name</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control mr-2" />
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>

            <!-- Profile cards container -->
            <div id="profileContainer" runat="server" class="row"></div>
        </div>
    </form>
</body>
</html>