using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace P4
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPI : ControllerBase
    {
        public class TeamsController : Controller

        {

            // GET api/teams

            [HttpGet]
            public List<UserAccount> Get()

            {

                DBConnect objDB = new DBConnect();

                DataSet ds = objDB.GetDataSet("SELECT * FROM UserAccounts WHERE Visible=1");

                List<UserAccount> Users = new List<UserAccount>();

                UserAccount user;



                foreach (DataRow record in ds.Tables[0].Rows)

                {

                    user = new UserAccount();

                    user.Username = record["Username"].ToString();

                    user.Password = record["Password"].ToString();

                    user.FullName = record["FullName"].ToString();

                    user.Email = record["Email"].ToString();

                    Users.Add(user);

                }



                return Users;

            }

            [HttpGet("{Id}")]

            public UserAccount Get(int Id)

            {

                DBConnect objDB = new DBConnect();

                DataSet ds = objDB.GetDataSet("SELECT * FROM UserAccounts WHERE ID = " + Id);

                DataRow record;



                UserAccount user = new UserAccount();



                if (ds.Tables[0].Rows.Count != 0)

                {

                    record = ds.Tables[0].Rows[0];

                    user.Username = record["Username"].ToString();

                    user.Password = record["Password"].ToString();

                    user.FullName = record["FullName"].ToString();

                    user.Email = record["Email"].ToString();

                }



                return user;

            }
            [HttpPost]
            public Boolean Post([FromBody] UserAccount user)

            {

                DBConnect objDB = new DBConnect();

                string strSQL = "INSERT INTO UserAccounts (Username, Password, FullName, Email) " +

                                "VALUES ('" + user.Username + "', '" + user.Password + "', '" + user.FullName + "', '" + user.Email + "')";



                // Execute the INSERT statement in the database

                // The DoUpdate() method returns the number of records effected by the INSERT statement.

                // Otherwise, it returns -1 when there was an error exception.

                int result = objDB.DoUpdate(strSQL);



                if (result > 0)

                    return true;





                return false;

            }
        }
    }
}
