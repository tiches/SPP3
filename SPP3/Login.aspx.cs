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
    public partial class Login : System.Web.UI.Page
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DAProcessing dbProcess = new DAProcessing();

            UserAccount checkUser = new UserAccount();
            checkUser.Password = txtPassword.Text;
            checkUser.Username = txtUsername.Text;

           
           string userid= dbProcess.UserLoginPassword(checkUser);

           // lblErrorMsg.Text = userid.ToString();

            if (userid == txtPassword.Text)
            {


                Session["UserID"] = userid;
                Response.Redirect("DatingAppHome.aspx");

            }
            else
            {
                lblErrorMsg.Text = "Login information incorrect";
                lblErrorMsg.Visible = true;
            }
        }
    }
}