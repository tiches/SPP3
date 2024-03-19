using DatingAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SPP3
{
    public partial class ReceivedLikes : System.Web.UI.Page
    {
        DAProcessing dbProcess = new DAProcessing();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = (int)Session["UserID"];

            // Retrieve the list of sent likes for the current user
            List<Like> sentLikes = dbProcess.GetReceivedLikes(userID);

            // Display each sent like
            foreach (Like like in sentLikes)
            {
                // Retrieve the receiver user's profile information
                UserProfile senderProfile = dbProcess.GetUserProfileByID(like.SenderUserID);

                // Create a new div for each like
                HtmlGenericControl likeDiv = new HtmlGenericControl("div");
                likeDiv.Attributes["class"] = "like-item";

                // Display the liked user's profile photo and name
                Image profilePhoto = new Image();
                profilePhoto.ImageUrl = senderProfile.ProfilePhotoURL;
                profilePhoto.CssClass = "profile-photo";
                likeDiv.Controls.Add(profilePhoto);

                Label nameLabel = new Label();
                nameLabel.Text = senderProfile.Name;
                nameLabel.CssClass = "profile-name";
                likeDiv.Controls.Add(nameLabel);

                // Display additional information from the receiver user's profile
                Label ageLabel = new Label();
                ageLabel.Text = $"Age: {senderProfile.Age}";
                likeDiv.Controls.Add(ageLabel);

                Label cityLabel = new Label();
                cityLabel.Text = $"City: {senderProfile.City}";
                likeDiv.Controls.Add(cityLabel);

                // Create a delete button for the like
                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.CssClass = "btn btn-danger";
                deleteButton.CommandArgument = like.LikeID.ToString();
                deleteButton.Click += DeleteLike_Click;

                // Add the controls to the like div
                likeDiv.Controls.Add(deleteButton);

                // Create a match button for the like
                Button matchButton = new Button();
                matchButton.Text = "Match";
                matchButton.CssClass = "btn btn-success";
                matchButton.CommandArgument = like.LikeID.ToString();
                matchButton.Click += Match_Click;
                likeDiv.Controls.Add(matchButton);

                // Add the like div to the page
                likesContainer.Controls.Add(likeDiv);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageLikes.aspx");
        }


        // Event handler for the delete button click
        protected void DeleteLike_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int likeID = Convert.ToInt32(deleteButton.CommandArgument);

            // Call the method to delete the like using the likeID
            dbProcess.DeleteLikeByID(likeID);

            // Refresh the page to reflect the changes
            Response.Redirect(Request.RawUrl);
        }

        protected void Match_Click(object sender, EventArgs e)
        {
            Button matchButton = (Button)sender;
            int likeID = Convert.ToInt32(matchButton.CommandArgument);

            // Call method to handle matching
            dbProcess.MatchLike(likeID);

            // Refresh the page to reflect changes
            Response.Redirect(Request.RawUrl);

        }
    }
}