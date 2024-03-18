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
        public int UserLogin (UserAccount user)
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
            objCommand.Parameters.AddWithValue("@Address", userProfile.Address);
            objCommand.Parameters.AddWithValue("@Phone", userProfile.Phone);
            objCommand.Parameters.AddWithValue("@Occupation", userProfile.Occupation);
            objCommand.Parameters.AddWithValue("@Age", userProfile.Age);
            objCommand.Parameters.AddWithValue("@Height", userProfile.Height);

            objCommand.Parameters.AddWithValue("@Weight", userProfile.Weight); // Add Weight parameter
            objCommand.Parameters.AddWithValue("@CommitmentType", userProfile.CommitmentType); // Add CommitmentType parameter
            objCommand.Parameters.AddWithValue("@Interests", userProfile.Interests);
            objCommand.Parameters.AddWithValue("@LikesDislikes", userProfile.LikesDislikes);
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
    }
}
