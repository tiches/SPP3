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
    public partial class ManageMatches : System.Web.UI.Page
    {
        DAProcessing dbProcess = new DAProcessing();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = (int)Session["UserID"];
            if (!IsPostBack)
            {
                List<Match> matches = dbProcess.GetMatchesByUserID(userID); 

                DisplayMatches(matches);
            }
        }

        private void DisplayMatches(List<Match> matches)
        {
            foreach (var match in matches)
            {
                int otherUserProfileID = match.User1ID == (int)Session["UserID"] ? match.User2ID : match.User1ID;
                UserProfile otherUserProfile = dbProcess.GetUserProfileByID(otherUserProfileID);

                HtmlGenericControl matchDiv = new HtmlGenericControl("div");
                matchDiv.Attributes["class"] = "match-item";

                Image profilePhoto = new Image();
                profilePhoto.ImageUrl = otherUserProfile.ProfilePhotoURL;
                profilePhoto.CssClass = "profile-photo";
                matchDiv.Controls.Add(profilePhoto);

                Label nameLabel = new Label();
                nameLabel.Text = otherUserProfile.Name;
                matchDiv.Controls.Add(nameLabel);

                Label ageLabel = new Label();
                ageLabel.Text = $"Age: {otherUserProfile.Age}";
                matchDiv.Controls.Add(ageLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = otherUserProfile.Description;
                matchDiv.Controls.Add(descriptionLabel);

                Button requestDateButton = new Button();
                requestDateButton.Text = "Request Date";
                requestDateButton.CssClass = "btn btn-primary match-request-date-btn";
                requestDateButton.CommandArgument = match.MatchID.ToString();
                requestDateButton.Click += RequestDate_Click;
                matchDiv.Controls.Add(requestDateButton);


                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.CssClass = "btn btn-danger match-delete-btn";
                deleteButton.CommandArgument = match.MatchID.ToString();
                deleteButton.Click += DeleteMatch_Click;
                matchDiv.Controls.Add(deleteButton);

                matchesContainer.Controls.Add(matchDiv);
            }
        }

        protected void RequestDate_Click(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            Button requestDateButton = (Button)sender;
            int matchID = Convert.ToInt32(requestDateButton.CommandArgument);

        }

        protected void PlanDate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
          //  Match match = dbProcess.GetMatchByID()
        }

        protected void DeleteMatch_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int matchID = Convert.ToInt32(deleteButton.CommandArgument);

           
            dbProcess.DeleteMatchByID(matchID);

            // Reload the page to reflect changes
            Response.Redirect(Request.RawUrl);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatingAppHome.aspx");
        }
    }
}