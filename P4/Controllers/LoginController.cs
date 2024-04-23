using Microsoft.AspNetCore.Mvc;
using P4.Models;
using DatingAppLibrary;
using Utilities;

namespace P4.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(); // Return the login view
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                DAProcessing dbProcess = new DAProcessing();
                int userId = dbProcess.UserLogin(new UserAccount
                {
                    Username = model.Username,
                    Password = model.Password
                });

                if (userId > 0)
                {
                    HttpContext.Session.SetInt32("UserID", userId);
                    // Session["UserID"] = userId;
                    return RedirectToAction("UserHome", "Home"); // Redirect to home page
                }
                else
                {
                    ModelState.AddModelError("", "Login information incorrect");
                }
            }

            return View(model); // Return the view with validation errors
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(); // Return the Register view
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                int userId = -1;

                UserAccount newUser = new UserAccount
                {
                    Username = model.Username,
                    Password = model.Password,
                    FullName = model.FullName,
                    Email = model.Email
                };

                DAProcessing dbProcess = new DAProcessing();
                userId = dbProcess.createUser(newUser);

                if (userId > 0)
                {
                    HttpContext.Session.SetInt32("UserID", userId);
                    return RedirectToAction("Create", "UserProfile"); // Redirect to Create Profile action
                }
                else
                {
                    ModelState.AddModelError("", "Username is taken");
                }
            }

            return View(model); // Return the view with validation errors
        }



    }
}