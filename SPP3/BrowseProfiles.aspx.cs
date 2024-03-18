using DatingAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SPP3
{
    public partial class BrowseProfiles : System.Web.UI.Page
    {
        DAProcessing dbProcess = new DAProcessing();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = (int)Session["UserID"];
                List<UserProfile> profiles = dbProcess.GetActiveUserProfiles(userID);
                DisplayProfiles(profiles);
            }
        }
        private void DisplayProfiles(List<UserProfile> profiles)
        {
            foreach (var profile in profiles)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl card = new HtmlGenericControl("div");
                card.Attributes["class"] = "card";
                card.Attributes["onclick"] = "window.location.href = 'ViewProfile.aspx?UserID=" + profile.UserID + "'"; // Redirect to ViewProfile.aspx with userid as query parameter

                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes["src"] = profile.ProfilePhotoURL;
                img.Attributes["class"] = "card-img-top";

                HtmlGenericControl cardBody = new HtmlGenericControl("div");
                cardBody.Attributes["class"] = "card-body";

                HtmlGenericControl name = new HtmlGenericControl("h4"); // Add this line
                name.InnerText = profile.Name; // Set the inner text to the user's name

                HtmlGenericControl age = new HtmlGenericControl("p");
                age.InnerText = "Age: " + profile.Age;

                HtmlGenericControl description = new HtmlGenericControl("p");
                description.InnerText = profile.Description;

                card.Controls.Add(img);
                cardBody.Controls.Add(name);
                cardBody.Controls.Add(age);
                cardBody.Controls.Add(description);
                card.Controls.Add(cardBody);

                profileContainer.Controls.Add(card);
            }
        }
    }
}