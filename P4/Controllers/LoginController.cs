using Microsoft.AspNetCore.Mvc;
using P4.Models;
using DatingAppLibrary;
using Utilities;

namespace P4.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index(LoginModel model)
        {
            if (Request.Cookies["Username"] != null)
            {
                string? Username = Request.Cookies["Username"].ToString();
                model.Username = Username.ToString();
                string? Password = Request.Cookies["Password"].ToString();
                model.Password = Password.ToString();

            }
            return View(model); // Return the login view
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                DAProcessing dbProcess = new DAProcessing();
                UserAccount NewUser = new UserAccount();
                NewUser.Username = Request.Form["Username"].ToString();
                NewUser.Password = Request.Form["Password"].ToString();

                string userPassword = dbProcess.UserLoginPassword(NewUser);


                if (userPassword == model.Password)
                {
                    int userId = dbProcess.UserLoginID(NewUser);

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
                else
                {
                    ModelState.AddModelError("", "Login information incorrect");
                }
            }

            return View("index",model); // Return the view with validation errors
        }

        [HttpPost]
        public ActionResult CreateCookie(LoginModel model)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(30);
            string Username = Request.Form["Username"].ToString();
            string Password = Request.Form["Password"].ToString();
            Response.Cookies.Append("Username", Username, options);
            Response.Cookies.Append("Password", Password, options);     
            
            return View("Index");
        }

        public ActionResult DeleteCookie(LoginModel model)
        {
            Response.Cookies.Delete("Username");
            Response.Cookies.Delete("Password");

            return View("Index");
        }
    }
}