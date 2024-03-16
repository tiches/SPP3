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
    }
}
