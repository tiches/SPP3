using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class DateRequestsController : Controller
    {
        public IActionResult Index()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            List<DateRequest> ReceivedRequests = dbProcess.FindDateRequests((int)userID);
            List<UserProfile> profiles = new List<UserProfile>();

            foreach (DateRequest Request in ReceivedRequests)
            {
                UserProfile senderProfile = dbProcess.GetUserProfileByID(Request.SenderUserID);
                profiles.Add(senderProfile);
            }

            return View(profiles);
        }
        public IActionResult AcceptDate(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int RequestID = dbProcess.FindRequestID(UserID,(int)userID);

            dbProcess.AcceptDate(RequestID,UserID,(int)userID);

            return RedirectToAction("Index", "DateRequests");

        }
        public IActionResult DenyDate(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int RequestID = dbProcess.FindRequestID(UserID, (int)userID);

            dbProcess.DenyDate(RequestID);

            return RedirectToAction("Index", "DateRequests");
        }
        public IActionResult IgnoreDate(int UserID)
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");

            int RequestID = dbProcess.FindRequestID(UserID, (int)userID);

            dbProcess.IgnoreDate(RequestID);

            return RedirectToAction("Index", "DateRequests");
        }
    }
}
