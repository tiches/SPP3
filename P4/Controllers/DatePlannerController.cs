using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;

namespace P4.Controllers
{
    public class DatePlannerController : Controller
    {
        public IActionResult Index(PlannedDateModel model )
        {
            DAProcessing dbProcess = new DAProcessing();

            int? userID = HttpContext.Session.GetInt32("UserID");
            int? DateID = HttpContext.Session.GetInt32("DateID");

            PlannedDate Date = dbProcess.FindDate((int)userID, (int)DateID);

            model.Time = Date.Time;
            model.Description = Date.Description;


            return View(model);
        }
    }
}
