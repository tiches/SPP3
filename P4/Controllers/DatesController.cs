using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class DatesController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            List<PlannedDate> Dates = dbProcess.FindDates((int)userID);
            List<UserProfile> profiles = new List<UserProfile>();

            foreach (PlannedDate Date in Dates)
            {
                if (Date.userIDone == (int)userID)
                {
                    UserProfile profile = dbProcess.GetUserProfileByID(Date.userIDtwo);
                    profiles.Add(profile);
                }
                else if (Date.userIDone == (int)userID)
                {
                    UserProfile profile = dbProcess.GetUserProfileByID(Date.userIDone);
                    profiles.Add(profile);
                }
            }

            return View(profiles);
        }

        public IActionResult PlanDate(int userID)
        {
            HttpContext.Session.SetInt32("DateID", userID);

            return RedirectToAction("Index", "DatePlanner");
        }
    }
}
