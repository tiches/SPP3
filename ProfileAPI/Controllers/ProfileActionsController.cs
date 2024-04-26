using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using DatingAppLibrary;
using Utilities;



namespace ProfileAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Profiles")]
    public class ProfilesController : Controller

    {



        [HttpGet]
        [HttpGet("GetProfiles")]
        public List<UserProfile> GetProfiles()

        {

            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();

            DataSet myDS = objDB.GetDataSet("SELECT * FROM UserProfiles");



            int count = myDS.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                UserProfile profile = new UserProfile();

                profile.ProfilePhotoURL = objDB.GetField("ProfilePhotoURL", i).ToString();
                profile.Name = objDB.GetField("Name", i).ToString();
                profile.Age = (int)objDB.GetField("Age", i);

                profile.Description = objDB.GetField("Description", i).ToString();
                profile.City = objDB.GetField("City", i).ToString();
                profile.State = objDB.GetField("State", i).ToString();
                profile.Height = (int)objDB.GetField("Height", i);
                profile.Weight = (int)objDB.GetField("Weight", i);

                profile.Interests = objDB.GetField("Interests", i).ToString();

                profile.Likes = objDB.GetField("Likes", i).ToString();

                profile.Dislikes = objDB.GetField("Dislikes", i).ToString();

                profile.FavoriteRestaurants = objDB.GetField("FavRestaurants", i).ToString();

                profile.FavoriteMovies = objDB.GetField("FavMovies", i).ToString();

                profile.FavoriteQuotes = objDB.GetField("FavQuotes", i).ToString();

                profile.Goals = objDB.GetField("Goals", i).ToString();

                profile.CommitmentType = objDB.GetField("CommitmentType", i).ToString();

                profiles.Add(profile);

            }



            return profiles;

        }

        [HttpPost()]
        [HttpPost("AddProfile")]
        public Boolean AddProfile([FromBody] UserProfile profile)

        {

            if (profile != null)

            {

                DBConnect objDB = new DBConnect();

                SqlCommand objCommand = new SqlCommand();



                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.CommandText = "UploadUserProfile";



                objCommand.Parameters.AddWithValue("@UserID", profile.UserID);

                objCommand.Parameters.AddWithValue("@ProfilePhotoUrl", profile.ProfilePhotoURL);

                objCommand.Parameters.AddWithValue("@Name", profile.Name);

                objCommand.Parameters.AddWithValue("@Address", profile.Address);

                objCommand.Parameters.AddWithValue("@City", profile.City);

                objCommand.Parameters.AddWithValue("@State", profile.State);

                objCommand.Parameters.AddWithValue("@Phone", profile.Phone);

                objCommand.Parameters.AddWithValue("@Occupation", profile.Occupation);

                objCommand.Parameters.AddWithValue("@CommitmentType", profile.CommitmentType);

                objCommand.Parameters.AddWithValue("@Interests", profile.Interests);

                objCommand.Parameters.AddWithValue("@Likes", profile.Likes);

                objCommand.Parameters.AddWithValue("@Dislikes", profile.Dislikes);

                objCommand.Parameters.AddWithValue("@FavoriteRestaurants", profile.FavoriteRestaurants);

                objCommand.Parameters.AddWithValue("@FavoriteMovies", profile.FavoriteMovies);

                objCommand.Parameters.AddWithValue("@FavoriteBooks", profile.FavoriteQuotes);

                objCommand.Parameters.AddWithValue("@Goals", profile.Goals);

                objCommand.Parameters.AddWithValue("@Description", profile.Description);



                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);



                if (retVal > 0)

                    return true;

                else

                    return false;

            }

            else

            {

                return false;

            }
        }
    }

}