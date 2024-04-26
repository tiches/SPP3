using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class ReceivedLikesController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            List<Like> ReceivedLikes = dbProcess.GetReceivedLikes((int)userID);
            List<UserProfile> profiles = new List<UserProfile>();

            foreach (Like like in ReceivedLikes)
            {
                UserProfile senderProfile = dbProcess.GetUserProfileByID(like.SenderUserID);
                profiles.Add(senderProfile);
            }

            return View(profiles);
        }
        public IActionResult DeleteLike(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int LikeID = dbProcess.FindLikeID(UserID, (int)userID);
            dbProcess.DeleteLikeByID(LikeID);

            return RedirectToAction("Index", "ReceivedLikes");
        }
        public IActionResult Match(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int LikeID = dbProcess.FindLikeID(UserID, (int)userID);
            dbProcess.MatchLike(LikeID);
            dbProcess.DeleteLikeByID(LikeID);

            return RedirectToAction("Index", "ReceivedLikes");
        }
    }
}
