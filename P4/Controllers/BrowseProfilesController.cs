using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace P4.Controllers
{
    public class BrowseProfilesController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? UserID = HttpContext.Session.GetInt32("UserID");

            List<UserProfile> profiles = dbProcess.GetActiveUserProfiles((int)UserID);
            return View(profiles);
        }

        public IActionResult ViewProfile(int userId)
        {
            DAProcessing dbProcess = new DAProcessing();
            UserProfile userProfile = dbProcess.GetUserProfileByID(userId);

            // Exclude properties you don't want to display
           // userProfile.UserID = 0;
          //  userProfile.Address = null;

            return View(userProfile);
        }

        [HttpPost]
        public IActionResult ViewProfile(int userId, UserProfile model)
        {
            // Handle any postback logic, if needed
            // For example, you can process form submissions here

            // Reload the user profile after any modifications
            DAProcessing dbProcess = new DAProcessing();
            UserProfile userProfile = dbProcess.GetUserProfileByID(userId);

            // Exclude properties you don't want to display
            // userProfile.UserID = 0;
            // userProfile.Address = null;

            return View(userProfile);
        }


        [HttpPost]
        public IActionResult SendLike(int userId)
        {
            // Get the UserID from session
            int? sessionUserId = HttpContext.Session.GetInt32("UserID");

            // Check if sessionUserId is null or not
            if (sessionUserId.HasValue)
            {
                // Call the CreateLike method in DAProcessing to send the like
                DAProcessing dbProcess = new DAProcessing();
                dbProcess.CreateLike((int)sessionUserId, userId);

            }
            ViewBag.LikeSent = "Like sent successfully!";


            // Redirect back to the ViewProfile page after sending the like
            return RedirectToAction("ViewProfile", "BrowseProfiles", new { userId = userId });
        }

    }
}