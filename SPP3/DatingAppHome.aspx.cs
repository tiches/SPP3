using DatingAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPP3
{
    public partial class DatingAppHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserAccount user = new UserAccount();

            int userId = Convert.ToInt32(Session["UserID"]);
           // lblUserID.Text = userId.ToString();

             DAProcessing dbProcess = new DAProcessing();
            user = dbProcess.getUserByID(userId);

            if (user != null)
            {
                // Populate controls with user information
                lblWelcomeMessage.Text = "Hello " + user.FullName + ", welcome to the dating app";
                lblUsername.Text = "Username: " + user.Username;
                lblEmail.Text = "Email: " + user.Email;
                // You can populate other controls as needed
            }

        }
    }
}