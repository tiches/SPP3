using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class ViewDatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
