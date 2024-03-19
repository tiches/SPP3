using DatingAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPP3
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        DAProcessing dbProcess = new DAProcessing();
        int userid;
        int viewingUserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = (int)Session["UserID"];
            viewingUserID = Convert.ToInt32(Request.QueryString["UserID"]);

            if (!IsPostBack)
            {
                // userid = (int)Session["UserID"];
                
                // Load the user profile
                int userID = Convert.ToInt32(Request.QueryString["UserID"]);
                //for likes purposes
                

                UserProfile userProfile = dbProcess.GetUserProfileByID(userID);

                viewingUserID = userProfile.UserID;
                // Set the profile photo
                Image imgProfilePhoto = new Image();
                imgProfilePhoto.ImageUrl = userProfile.ProfilePhotoURL;
                imgProfilePhoto.CssClass = "img-fluid rounded";
                divProfilePhoto.Controls.Add(imgProfilePhoto);

                // Set other profile information
                lblName.InnerText = userProfile.Name;
                lblAge.InnerText = userProfile.Age.ToString();
                lblDescription.InnerText = userProfile.Description;
                lblCity.InnerText = userProfile.City;
                lblState.InnerText = userProfile.State;
                lblHeight.InnerText = userProfile.Height.ToString();
                lblWeight.InnerText = userProfile.Weight.ToString();
                lblInterests.InnerText = userProfile.Interests;
                lblLikes.InnerText = userProfile.Likes;
                lblDislikes.InnerText = userProfile.Dislikes;
                lblFavRestaurants.InnerText = userProfile.FavoriteRestaurants;
                lblFavMovies.InnerText = userProfile.FavoriteMovies;
                lblFavQuotes.InnerText = userProfile.FavoriteQuotes;
                lblGoals.InnerText = userProfile.Goals;
                lblCommitmentType.InnerText = userProfile.CommitmentType;
                
              
            }


        }

        protected void btnSendLike_Click(object sender, EventArgs e)
        {
            dbProcess.CreateLike(userid, viewingUserID);
            lblLikeSent.Text = "Like has been sent!";
            lblLikeSent.Visible = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseProfiles.aspx");
        }
    }
}