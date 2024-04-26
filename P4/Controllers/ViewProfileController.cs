using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;
using System.Diagnostics;

namespace P4.Controllers
{
    public class ViewProfileController : Controller
    {
        public IActionResult Index(BasicProfileViewModel model)
        {
            int? UserID = HttpContext.Session.GetInt32("ViewUserID");

            DAProcessing dbProcess = new DAProcessing();

            UserProfile profile = dbProcess.GetUserProfileByID((int)UserID);

            model.PhotoURL = profile.ProfilePhotoURL;
            model.Name = profile.Name;
            model.Age = profile.Age.ToString();
            model.Description = profile.Description;
            model.City = profile.City;
            model.State = profile.State;
            model.Height = profile.Height.ToString();
            model.Weight = profile.Weight.ToString();
            model.Interests = profile.Interests;
            model.Likes = profile.Likes;
            model.Dislikes = profile.Dislikes;
            model.FavMovies = profile.FavoriteMovies;
            model.FavRestaurants = profile.FavoriteRestaurants;
            model.FavQuotes = profile.FavoriteQuotes;
            model.Goals = profile.Goals;
            model.CommitmentType = profile.CommitmentType;

            return View(model);
        }

        public ActionResult SendLike()
        {
            DAProcessing dbProcess = new DAProcessing();

            int? viewingUserID = HttpContext.Session.GetInt32("ViewUserID");
            int? UserID = HttpContext.Session.GetInt32("UserID");

            dbProcess.CreateLike((int)UserID, (int)viewingUserID);
            return RedirectToAction("Index", "BrowseProfiles");
        }
    }
}
