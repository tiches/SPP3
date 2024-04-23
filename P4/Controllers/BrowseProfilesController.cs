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
    }

}
