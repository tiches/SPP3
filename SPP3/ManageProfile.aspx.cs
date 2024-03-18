using DatingAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPP3
{
    public partial class ManageProfile : System.Web.UI.Page
    {
        int userid;
        int profileid;
        DAProcessing dbProcess = new DAProcessing();
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = (int)Session["UserID"];
           if(dbProcess.getProfileStatus(userid)== true)
            {
                lblProfileStatus.Text = "Your Profile is active";
            }
           else
            {
                lblProfileStatus.Text = "Your Profile is not active";
            }
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {

        }

        protected void btnToggleStatus_Click(object sender, EventArgs e)
        {
            dbProcess.toggleProfileStatus(userid);
            Response.Redirect(Request.RawUrl);
        }
    }
}