using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For session management
using System;
using Utilities;

namespace P4.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View(); // This will show the initial create page view
        }

        [HttpPost]
        public IActionResult Create(UserProfile userProfile)
        {

            // Retrieve UserID from session
            // int userId = (int)HttpContext.Session.GetInt32("UserID"); ?? throw new InvalidOperationException("UserID is missing from session.");

            //  userId = (int)HttpContext.Session.GetInt32("UserID");

            int userId = HttpContext.Session.GetInt32("UserID") ?? throw new InvalidOperationException("UserID is missing from session.");


            // Instantiate DAProcessing
            DAProcessing dbProcess = new DAProcessing();

            // Assign the UserID to the UserProfile
            userProfile.UserID = (int)userId;

            // Save the UserProfile using DAProcessing class from DatingAppLibrary
           int profileID = dbProcess.createUserProfile(userProfile, userId);

            // Redirect to Dating App User Home
            return RedirectToAction("UserHome", "Home");
        }
    }
}
