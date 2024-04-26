using Microsoft.AspNetCore.Mvc;

namespace P4.Controllers
{
    public class ViewLikesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
