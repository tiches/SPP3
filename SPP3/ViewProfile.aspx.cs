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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Load the user profile
                int userID = Convert.ToInt32(Request.QueryString["UserID"]);
                UserProfile userProfile = dbProcess.GetUserProfileByID(userID);

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
                
                // Set other profile information as needed
            }


        }

        protected void btnSendLike_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseProfiles.aspx");
        }
    }
}