using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace P4.Controllers
{
    public class SentLikesController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            List<Like> SentLikes = dbProcess.GetSentLikes((int)userID);
            List<UserProfile> profiles = new List<UserProfile>();

            foreach(Like like in SentLikes)
            {
                UserProfile receiverProfile = dbProcess.GetUserProfileByID(like.ReceiverUserID);
                profiles.Add(receiverProfile);
            }

            return View(profiles);
        }

        public ActionResult DeleteLike(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int LikeID = dbProcess.FindLikeID((int)userID, UserID);
            dbProcess.DeleteLikeByID(LikeID);

            return RedirectToAction("Index", "SentLikes");
        }
    }
}
