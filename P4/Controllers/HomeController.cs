using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;
using System.Diagnostics;

namespace P4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            // Retrieve UserID from session
            int? userId = HttpContext.Session.GetInt32("UserID");

            if (userId != null)
            {
                // Create an instance of DAProcessing
                DAProcessing dbProcess = new DAProcessing();

                // Call the method to get UserProfile by UserID
                UserProfile userProfile = dbProcess.GetUserProfileByID((int)userId);

                // Pass the userProfile object to the view
                return View(userProfile);
            }
            else
            {
                // Handle the case where UserID is not found in session
                // Redirect to login page or show an error message
                return RedirectToAction("Index", "Login");
            }
        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

