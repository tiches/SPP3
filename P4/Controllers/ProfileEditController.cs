using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace P4.Controllers
{
    public class ProfileEditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveProfile(ProfileModel model)
        {
            UserProfile userprof = new UserProfile();
            int profileid;
            int? UserID = HttpContext.Session.GetInt32("UserID");

            DAProcessing dbProcess = new DAProcessing();

            //Process the form data when the submit button is clicked
            userprof.ProfilePhotoURL = Request.Form["PhotoURL"].ToString();
            userprof.Name = Request.Form["Name"].ToString();
            userprof.Address = Request.Form["Address"].ToString();
            userprof.City = Request.Form["City"].ToString();
            userprof.State = Request.Form["State"].ToString();
            userprof.Phone = Request.Form["Phone"].ToString();
            userprof.Occupation = Request.Form["Occupation"].ToString();
            userprof.Age = Convert.ToInt32(Request.Form["Age"].ToString());
            userprof.Height = Convert.ToInt32(Request.Form["Height"].ToString());
            userprof.Weight = Convert.ToInt32(Request.Form["Weight"].ToString());
            userprof.CommitmentType = Request.Form["CommitmentType"].ToString();
            userprof.Interests = Request.Form["Interests"].ToString();
            userprof.Likes = Request.Form["Likes"].ToString();
            userprof.Dislikes = Request.Form["Dislikes"].ToString();
            userprof.FavoriteRestaurants = Request.Form["FavoriteRestaurants"].ToString();
            userprof.FavoriteMovies = Request.Form["FavoriteMovies"].ToString();
            userprof.FavoriteBooks = Request.Form["FavoriteBooks"].ToString();
            userprof.FavoriteQuotes = Request.Form["FavoriteQuotes"].ToString();
            userprof.Goals = Request.Form["Goals"].ToString();
            userprof.Description = Request.Form["Description"].ToString();



            dbProcess.EditUserProfile(userprof, (int)UserID);

            return View(model);
        }
 
    }
}
