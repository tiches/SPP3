using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DatingAppLibrary;
using Utilities;


namespace P4.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");
            List<Match> matches = dbProcess.GetMatchesByUserID((int)userID);
            List<UserProfile> profiles = new List<UserProfile>();

            foreach (Match match in matches)
            {
                int otherUserProfileID = match.User1ID == (int)userID ? match.User2ID : match.User1ID;
                UserProfile otherUserProfile = dbProcess.GetUserProfileByID(otherUserProfileID);
                profiles.Add(otherUserProfile);
            }
            return View(profiles);
        }
        public IActionResult RemoveMatch(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int MatchID = dbProcess.FindMatchID(UserID, (int)userID);
            dbProcess.DeleteMatchByID(MatchID);

            return RedirectToAction("Index", "Matches");

        }

        public IActionResult RequestDate(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            dbProcess.SendDateRequest((int)userID, UserID);

            return RedirectToAction("Index", "Matches");
        }
    }
}
