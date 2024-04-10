using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DatingAppLibrary;
using System.Data.SqlClient;
using System.Data;
namespace SPP3
{
    public partial class CreateLogon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int userid = -1;
            
            UserAccount newUser = new UserAccount
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullname.Text,
                Email = txtEmail.Text
            };

            DAProcessing dbProcess = new DAProcessing();
           userid = dbProcess.createUser(newUser);

            Session["UserID"] = userid;

            if (userid > 0)
            {

                Response.Redirect("CreateProfile.aspx");
            }
            else
            {
                string errorMsg = "Username is taken";
                lblErrorMsg.Text = errorMsg;
                lblErrorMsg.Visible = true;

            }
            /*
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.CommandText = "CreateUserAccount";

            SqlParameter parameter = new SqlParameter("returnValue", SqlDbType.Int);

            parameter.Direction = ParameterDirection.ReturnValue;

            objCommand.Parameters.Add(parameter);

        parameter = new SqlParameter("@UserName", txtName.Text);

                objCommand.Parameters.Add(parameter);
           
*/
            //  objDB.DoUpdateUsingCmdObj

        }
    }
}