using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;

namespace P4.Controllers
{
    public class AccountCreateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountCreate(AccountCreateModel model)
        {
            if (ModelState.IsValid)
            {
                int UserID = -1;

                DAProcessing dbProcess = new DAProcessing();
                UserAccount NewUser = new UserAccount();

                NewUser.Username = Request.Form["CreateUsername"].ToString();
                NewUser.Password = Request.Form["CreatePassword"].ToString();
                NewUser.FullName = Request.Form["CreateFullName"].ToString();
                NewUser.Email = Request.Form["CreateEmail"].ToString();

                UserID = dbProcess.createUser(NewUser);

                if (UserID > 0)
                {

                    HttpContext.Session.SetInt32("UserID", UserID);
                    // Session["UserID"] = userId;
                    return RedirectToAction("Index", "ProfileCreate");
                }
                else
                {
                    ModelState.AddModelError("", "Username Taken");
                }

            }

            

            return View("Index",model); // Return the view with validation errors
        }
    }
}
