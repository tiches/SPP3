using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DatingAppLibrary
{
    public class DAProcessing
    {
        public int createUser(UserAccount user)
        {
            int userid = -1;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "CreateUserAccount";

            // Create a return parameter
            SqlParameter returnParameter = new SqlParameter("@returnValue", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            // Adding user account data to command
            objCommand.Parameters.AddWithValue("@Username", user.Username);
            objCommand.Parameters.AddWithValue("@Password", user.Password);
            objCommand.Parameters.AddWithValue("@Fullname", user.FullName);
            objCommand.Parameters.AddWithValue("@Email", user.Email);

            // Adding output parameter for UserID
            SqlParameter outputParameter = new SqlParameter("@UserID", SqlDbType.Int);
            outputParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameter);

            // Execute the command
            objDB.DoUpdateUsingCmdObj(objCommand);


            if (objCommand.Parameters["@UserID"].Value != DBNull.Value)
            {
                userid = Convert.ToInt32(objCommand.Parameters["@UserID"].Value);
            }

            return userid;
        }
        public int UserLogin(UserAccount user)
        {
            int userid = -1;

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ValidateUserLogin";

            objCommand.Parameters.AddWithValue("@Username", user.Username);
            objCommand.Parameters.AddWithValue("@Password", user.Password);

            // Adding output parameter for UserID
            SqlParameter outputParameter = new SqlParameter("@UserID", SqlDbType.Int);
            outputParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(outputParameter);

            // Execute the command
            objDB.DoUpdateUsingCmdObj(objCommand);

            if (objCommand.Parameters["@UserID"].Value != DBNull.Value)
            {
                userid = Convert.ToInt32(objCommand.Parameters["@UserID"].Value);
            }



            return userid;
        }

        public UserAccount getUserByID(int userid)
        {
            UserAccount getUser = new UserAccount();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserAccountByID";
            objCommand.Parameters.AddWithValue("@UserID", userid);


            //output the user account info



            SqlParameter usernameParameter = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
            usernameParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(usernameParameter);

            SqlParameter passwordParameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            passwordParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(passwordParameter);

            SqlParameter fullnameParameter = new SqlParameter("@Fullname", SqlDbType.NVarChar, 100);
            fullnameParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(fullnameParameter);

            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
            emailParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(emailParameter);

            // Execute the command
            objDB.GetDataSetUsingCmdObj(objCommand);

            // Retrieve the output parameter values

            string username = usernameParameter.Value.ToString();
            string password = passwordParameter.Value.ToString();
            string fullname = fullnameParameter.Value.ToString();
            string email = emailParameter.Value.ToString();


            getUser.UserID = userid;
            getUser.Username = username;
            getUser.Password = password;
            getUser.Email = email;
            return getUser;





        }
        public int creatUserProfile(UserProfile userProfile, int userID)
        {
            int profileid = -1;

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "UploadUserProfile";


            SqlParameter returnParameter = new SqlParameter("@ProfileID", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(returnParameter);


            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@ProfilePhotoURL", userProfile.ProfilePhotoURL);
            objCommand.Parameters.AddWithValue("@Name", userProfile.Name);
            objCommand.Parameters.AddWithValue("@Address", userProfile.Address);
            objCommand.Parameters.AddWithValue("@City", userProfile.City);
            objCommand.Parameters.AddWithValue("@State", userProfile.State);
            objCommand.Parameters.AddWithValue("@Phone", userProfile.Phone);
            objCommand.Parameters.AddWithValue("@Occupation", userProfile.Occupation);
            objCommand.Parameters.AddWithValue("@Age", userProfile.Age);
            objCommand.Parameters.AddWithValue("@Height", userProfile.Height);

            objCommand.Parameters.AddWithValue("@Weight", userProfile.Weight); // Add Weight parameter
            objCommand.Parameters.AddWithValue("@CommitmentType", userProfile.CommitmentType); // Add CommitmentType parameter
            objCommand.Parameters.AddWithValue("@Interests", userProfile.Interests);
            objCommand.Parameters.AddWithValue("@Likes", userProfile.Likes);
            objCommand.Parameters.AddWithValue("@Dislikes", userProfile.Dislikes);
            objCommand.Parameters.AddWithValue("@FavoriteRestaurants", userProfile.FavoriteRestaurants);
            objCommand.Parameters.AddWithValue("@FavoriteMovies", userProfile.FavoriteMovies);
            objCommand.Parameters.AddWithValue("@FavoriteBooks", userProfile.FavoriteBooks);
            objCommand.Parameters.AddWithValue("@FavoriteQuotes", userProfile.FavoriteQuotes);
            objCommand.Parameters.AddWithValue("@Goals", userProfile.Goals);
            objCommand.Parameters.AddWithValue("@Description", userProfile.Description);

            objDB.DoUpdateUsingCmdObj(objCommand);


            if (objCommand.Parameters["@ProfileID"].Value != DBNull.Value)
            {
                profileid = Convert.ToInt32(objCommand.Parameters["@ProfileID"].Value);
            }



            return profileid;
        }


        public void EditUserProfile(UserProfile userProfile, int userID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "EditUserProfile";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@ProfilePhotoURL", userProfile.ProfilePhotoURL);
            objCommand.Parameters.AddWithValue("@Name", userProfile.Name);
            objCommand.Parameters.AddWithValue("@Address", userProfile.Address);
            objCommand.Parameters.AddWithValue("@City", userProfile.City);
            objCommand.Parameters.AddWithValue("@State", userProfile.State);
            objCommand.Parameters.AddWithValue("@Phone", userProfile.Phone);
            objCommand.Parameters.AddWithValue("@Occupation", userProfile.Occupation);
            objCommand.Parameters.AddWithValue("@Age", userProfile.Age);
            objCommand.Parameters.AddWithValue("@Height", userProfile.Height);
            objCommand.Parameters.AddWithValue("@Weight", userProfile.Weight);
            objCommand.Parameters.AddWithValue("@CommitmentType", userProfile.CommitmentType);
            objCommand.Parameters.AddWithValue("@Interests", userProfile.Interests);
            objCommand.Parameters.AddWithValue("@Likes", userProfile.Likes);
            objCommand.Parameters.AddWithValue("@Dislikes", userProfile.Dislikes);
            objCommand.Parameters.AddWithValue("@FavoriteRestaurants", userProfile.FavoriteRestaurants);
            objCommand.Parameters.AddWithValue("@FavoriteMovies", userProfile.FavoriteMovies);
            objCommand.Parameters.AddWithValue("@FavoriteBooks", userProfile.FavoriteBooks);
            objCommand.Parameters.AddWithValue("@FavoriteQuotes", userProfile.FavoriteQuotes);
            objCommand.Parameters.AddWithValue("@Goals", userProfile.Goals);
            objCommand.Parameters.AddWithValue("@Description", userProfile.Description);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }






        public void toggleProfileStatus(int userID)
        {


            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "ToggleProfileStatus";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public bool getProfileStatus(int userID)
        {
            bool isActive = false;

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProfileStatus";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            SqlParameter returnParameter = new SqlParameter("@IsActive", SqlDbType.Bit);
            returnParameter.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(returnParameter);

            objDB.DoUpdateUsingCmdObj(objCommand);

            // Retrieve the value of the output parameter
            if (returnParameter.Value != DBNull.Value)
            {
                isActive = (bool)returnParameter.Value;
            }

            return isActive;
        }
        public List<UserProfile> GetActiveUserProfiles(int userID)
        {
            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SelectActiveUserProfiles";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);


            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    UserProfile userProfile = new UserProfile();

                    // Populate the UserProfile object from the DataRow
                    userProfile.UserID = (int)row["UserID"];
                    userProfile.ProfilePhotoURL = row["ProfilePhotoURL"].ToString();
                    userProfile.Name = row["Name"].ToString();
                    userProfile.Address = row["Address"].ToString();
                    userProfile.City = row["City"].ToString();
                    userProfile.State = row["State"].ToString();
                    userProfile.Phone = row["Phone"].ToString();
                    userProfile.Occupation = row["Occupation"].ToString();
                    userProfile.Age = (int)row["Age"];
                    userProfile.Height = (int)row["Height"];
                    userProfile.Weight = (int)row["Weight"];
                    userProfile.CommitmentType = row["CommitmentType"].ToString();
                    userProfile.Interests = row["Interests"].ToString();
                    userProfile.Likes = row["Likes"].ToString();
                    userProfile.Dislikes = row["Dislikes"].ToString();
                    userProfile.FavoriteRestaurants = row["FavRestaurants"].ToString();
                    userProfile.FavoriteMovies = row["FavMovies"].ToString();
                    userProfile.FavoriteBooks = row["FavBooks"].ToString();
                    userProfile.FavoriteQuotes = row["FavQuotes"].ToString();
                    userProfile.Goals = row["Goals"].ToString();
                    userProfile.Description = row["Description"].ToString();

                    profiles.Add(userProfile);
                }
            }


            return profiles;

        }

        public UserProfile GetUserProfileByID(int userID)
        {
            UserProfile userProfile = new UserProfile();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserProfileByID";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            // Get the DataSet using the DBConnect method
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            // Check if DataSet contains any tables and rows
            if (myDS.Tables.Count > 0 && myDS.Tables[0].Rows.Count > 0)
            {
                // Get the first row from the DataSet
                DataRow row = myDS.Tables[0].Rows[0];

                // Populate the UserProfile object from the DataRow
                userProfile.UserID = Convert.ToInt32(row["UserID"]);
                userProfile.ProfilePhotoURL = Convert.ToString(row["ProfilePhotoURL"]);
                userProfile.Name = Convert.ToString(row["Name"]);
                userProfile.Address = Convert.ToString(row["Address"]);
                userProfile.City = Convert.ToString(row["City"]);
                userProfile.State = Convert.ToString(row["State"]);
                userProfile.Phone = Convert.ToString(row["Phone"]);
                userProfile.Occupation = Convert.ToString(row["Occupation"]);
                userProfile.Age = Convert.ToInt32(row["Age"]);
                userProfile.Height = Convert.ToInt32(row["Height"]);
                userProfile.Weight = Convert.ToInt32(row["Weight"]);
                userProfile.CommitmentType = Convert.ToString(row["CommitmentType"]);
                userProfile.Interests = Convert.ToString(row["Interests"]);
                userProfile.Likes = Convert.ToString(row["Likes"]);
                userProfile.Dislikes = Convert.ToString(row["Dislikes"]);
                userProfile.FavoriteRestaurants = Convert.ToString(row["FavRestaurants"]);
                userProfile.FavoriteMovies = Convert.ToString(row["FavMovies"]);
                userProfile.FavoriteBooks = Convert.ToString(row["FavBooks"]);
                userProfile.FavoriteQuotes = Convert.ToString(row["FavQuotes"]);
                userProfile.Goals = Convert.ToString(row["Goals"]);
                userProfile.Description = Convert.ToString(row["Description"]);
            }

            // Return the UserProfile object
            return userProfile;




        }

        public void CreateLike(int senderID, int receiverID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "InsertLike";

            objCommand.Parameters.AddWithValue("@SenderUserID", senderID);
            objCommand.Parameters.AddWithValue("@ReceiverUserID", receiverID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public List<Like> GetSentLikes(int userID)
        {
            List<Like> SentLikes = new List<Like>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSentLikes";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    Like newLike = new Like();

                    // Populate the UserProfile object from the DataRow
                    newLike.LikeID = (int)row["LikeID"];
                    newLike.SenderUserID = (int)row["SenderUserID"];
                    newLike.ReceiverUserID = (int)row["RecipientUserID"];
                    newLike.Matched = row["Matched"].ToString();
                    SentLikes.Add(newLike);
                }
            }
                return SentLikes;
            }

        public List<Like> GetReceivedLikes(int userID)
        {
            List<Like> receivedLikes = new List<Like>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReceivedLikes";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    Like newLike = new Like();

                    // Populate the UserProfile object from the DataRow
                    newLike.LikeID = (int)row["LikeID"];
                    newLike.SenderUserID = (int)row["SenderUserID"];
                    newLike.ReceiverUserID = (int)row["RecipientUserID"];
                    newLike.Matched = row["Matched"].ToString();
                    receivedLikes.Add(newLike);
                }
            }
            return receivedLikes;
        }


        public void DeleteLikeByID(int likeID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "DeleteLikeByID";

            objCommand.Parameters.AddWithValue("@LikeID", likeID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        public void MatchLike(int likeID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "MatchLike";

            objCommand.Parameters.AddWithValue("@LikeID", likeID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        private UserProfile PopulateUserProfileFromDataRow(DataRow row)
        {
            UserProfile userProfile = new UserProfile();

            // Populate the UserProfile object from the DataRow
            userProfile.UserID = (int)row["UserID"];
            userProfile.ProfilePhotoURL = row["ProfilePhotoURL"].ToString();
            userProfile.Name = row["Name"].ToString();
            userProfile.Address = row["Address"].ToString();
            userProfile.City = row["City"].ToString();
            userProfile.State = row["State"].ToString();
            userProfile.Phone = row["Phone"].ToString();
            userProfile.Occupation = row["Occupation"].ToString();
            userProfile.Age = (int)row["Age"];
            userProfile.Height = (int)row["Height"];
            userProfile.Weight = (int)row["Weight"];
            userProfile.CommitmentType = row["CommitmentType"].ToString();
            userProfile.Interests = row["Interests"].ToString();
            userProfile.Likes = row["Likes"].ToString();
            userProfile.Dislikes = row["Dislikes"].ToString();
            userProfile.FavoriteRestaurants = row["FavRestaurants"].ToString();
            userProfile.FavoriteMovies = row["FavMovies"].ToString();
            userProfile.FavoriteBooks = row["FavBooks"].ToString();
            userProfile.FavoriteQuotes = row["FavQuotes"].ToString();
            userProfile.Goals = row["Goals"].ToString();
            userProfile.Description = row["Description"].ToString();

            return userProfile;
        }

        public List<UserProfile> SearchUserProfilesByAge(int userID, int age)
        {
            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchUserProfilesByAge";
            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@Age", age);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    // Populate the UserProfile object from the DataRow
                    UserProfile userProfile = PopulateUserProfileFromDataRow(row);
                    profiles.Add(userProfile);
                }
            }

            return profiles;
        }

        public List<UserProfile> SearchUserProfilesByCity(int userID, string city)
        {
            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchUserProfilesByCity";
            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@City", city);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    // Populate the UserProfile object from the DataRow
                    UserProfile userProfile = PopulateUserProfileFromDataRow(row);
                    profiles.Add(userProfile);
                }
            }

            return profiles;
        }

        public List<UserProfile> SearchUserProfilesByName(int userID, string name)
        {
            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchUserProfilesByName";
            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@Name", name);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    // Populate the UserProfile object from the DataRow
                    UserProfile userProfile = PopulateUserProfileFromDataRow(row);
                    profiles.Add(userProfile);
                }
            }

            return profiles;
        }

        public List<UserProfile> SearchUserProfilesByInterests(int userID, string interests)
        {
            List<UserProfile> profiles = new List<UserProfile>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SearchUserProfilesByInterests";
            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@Interests", interests);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    // Populate the UserProfile object from the DataRow
                    UserProfile userProfile = PopulateUserProfileFromDataRow(row);
                    profiles.Add(userProfile);
                }
            }

            return profiles;
        }

        public List<Match> GetMatchesByUserID(int userID)
        {
            List<Match> matches = new List<Match>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetMatchesByUserID";
            objCommand.Parameters.AddWithValue("@UserID", userID);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables.Count > 0)
            {
                foreach (DataRow row in myDS.Tables[0].Rows)
                {
                    Match newMatch = new Match();

                    // Populate the Match object from the DataRow
                    newMatch.MatchID = (int)row["MatchID"];
                    newMatch.User1ID = (int)row["User1ID"];
                    newMatch.User2ID = (int)row["User2ID"];
                   
                    // Add other properties as needed

                    matches.Add(newMatch);
                }
            }
            return matches;
        }

        public void DeleteMatchByID(int matchID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteMatchByID";
            objCommand.Parameters.AddWithValue("@MatchID", matchID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

    }
    }

