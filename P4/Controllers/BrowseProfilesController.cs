using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;
using System.ComponentModel;
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

        public ActionResult ViewProfile(int UserID)
        {
            HttpContext.Session.SetInt32("ViewUserID", UserID);
            return RedirectToAction("Index", "ViewProfile");
        }

    }

}
