using Microsoft.AspNetCore.Mvc;

namespace P4.Models
{
    public class BasicProfileViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
