using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class ViewProfileController : Controller
    {
        public IActionResult Index()
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");

            return View();
        }
    }
}
