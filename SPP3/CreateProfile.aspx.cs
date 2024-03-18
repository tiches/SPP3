using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DatingAppLibrary;

namespace SPP3
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        UserProfile userprof = new UserProfile();
        int profileid;
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
             userid = (int)Session["UserID"];
          
        }

         protected void SubmitButton()
        {
            /*
            DAProcessing dbProcess = new DAProcessing();


            //Process the form data when the submit button is clicked
            userprof.ProfilePhotoURL = txtProfilePhotoUrl.Text;
            userprof.Address = txtAddress.Text;
            userprof.Phone = txtPhone.Text;
            userprof.Occupation = txtOccupation.Text;
            userprof.Age= Convert.ToInt32(txtAge.Text);
            userprof.Height= Convert.ToInt32(txtHeight.Text);
            userprof.Weight= Convert.ToInt32(txtWeight.Text);
            userprof.CommitmentType= ddlCommitmentType.SelectedValue;
            userprof.Interests= txtInterests.Text;
            userprof.LikesDislikes = txtLikesDislikes.Text;
            userprof.FavoriteRestaurants = txtFavoriteRestaurants.Text;
            userprof.FavoriteMovies = txtFavoriteMovies.Text;
            userprof.FavoriteBooks = txtFavoriteBooks.Text;
            userprof.FavoriteQuotes = txtFavoriteQuotes.Text;
            userprof.Goals = txtGoals.Text;
            userprof.Description = txtDescription.Text;

            //Now you can use the form data for further processing (e.g., saving to the database)

            profileid = dbProcess.creatUserProfile(userprof, userid);

            Session["ProfileID"] = profileid;

            */
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DAProcessing dbProcess = new DAProcessing();

            //Process the form data when the submit button is clicked
            userprof.ProfilePhotoURL = txtProfilePhotoUrl.Text;
            userprof.Name = txtName.Text;
            userprof.Address = txtAddress.Text;
            userprof.City = txtCity.Text;
            userprof.State = txtState.Text;
            userprof.Phone = txtPhone.Text;
            userprof.Occupation = txtOccupation.Text;
            userprof.Age = Convert.ToInt32(txtAge.Text);
            userprof.Height = Convert.ToInt32(txtHeight.Text);
            userprof.Weight = Convert.ToInt32(txtWeight.Text);
            userprof.CommitmentType = ddlCommitmentType.SelectedValue;
            userprof.Interests = txtInterests.Text;
            userprof.Likes = txtLikes.Text;
            userprof.Dislikes = txtDislikes.Text;
            userprof.FavoriteRestaurants = txtFavoriteRestaurants.Text;
            userprof.FavoriteMovies = txtFavoriteMovies.Text;
            userprof.FavoriteBooks = txtFavoriteBooks.Text;
            userprof.FavoriteQuotes = txtFavoriteQuotes.Text;
            userprof.Goals = txtGoals.Text;
            userprof.Description = txtDescription.Text;

            //Now you can use the form data for further processing (e.g., saving to the database)

            profileid = dbProcess.creatUserProfile(userprof, userid);

            Session["ProfileID"] = profileid;
        }
    }
}