using DatingAppLibrary;
using Microsoft.AspNetCore.Mvc;
using P4.Models;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;                        
using System.Net;                       
using Utilities;
using DatingAppLibrary;
using Newtonsoft.Json;
using System.Data;

namespace P4.Controllers
{
    public class ProfileCreateController : Controller
    {
        String webApiUrl = "https://cis-iis2.temple.edu/Spring2024/CIS3342_tun32988/WebAPITest/api/Profiles/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProfileCreate(ProfileModel model)
        {
            // Create an object of the Customer class which is avaialable through the web service reference and WSDL

            UserProfile profile = new UserProfile();

            int? userid = HttpContext.Session.GetInt32("UserID");

            profile.UserID = (int)userid;
            profile.ProfilePhotoURL = Request.Form["PhotoURL"].ToString();
            profile.Name = Request.Form["Name"].ToString();
            profile.Address = Request.Form["Address"].ToString();
            profile.City = Request.Form["City"].ToString();
            profile.State = Request.Form["State"].ToString();
            profile.Phone = Request.Form["Phone"].ToString();
            profile.Occupation = Request.Form["Occupation"].ToString();
            profile.Age = Convert.ToInt32(Request.Form["Age"].ToString());
            profile.Height = Convert.ToInt32(Request.Form["Height"].ToString());
            profile.Weight = Convert.ToInt32(Request.Form["Weight"].ToString());
            profile.CommitmentType = Request.Form["CommitmentType"].ToString();
            profile.Interests = Request.Form["Interests"].ToString();
            profile.Likes = Request.Form["Likes"].ToString();
            profile.Dislikes = Request.Form["Dislikes"].ToString();
            profile.FavoriteRestaurants = Request.Form["FavRestaurants"].ToString();
            profile.FavoriteMovies = Request.Form["FavMovies"].ToString();
            profile.FavoriteBooks = Request.Form["FavBooks"].ToString();
            profile.FavoriteQuotes = Request.Form["FavQuotes"].ToString();
            profile.Goals = Request.Form["Goals"].ToString();
            profile.Description = Request.Form["Description"].ToString();



            // Serialize a Customer object into a JSON string.

            string jsonProfile = JsonConvert.SerializeObject(profile, Formatting.Indented);


            try

            {

                // Send the Customer object to the Web API that will be used to store a new customer record in the database.

                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.

                WebRequest request = WebRequest.Create(webApiUrl + "AddProfile/");

                request.Method = "POST";

                request.ContentLength = jsonProfile.Length;

                request.ContentType = "application/json";



                // Write the JSON data to the Web Request

                StreamWriter writer = new StreamWriter(request.GetRequestStream());

                writer.Write(jsonProfile);

                writer.Flush();

                writer.Close();



                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);

                String data = reader.ReadToEnd();

                reader.Close();

                response.Close();



                if (data == "true")

                    return RedirectToAction("UserHome", "Home");


                catch (Exception ex) {

                ModelState.AddModelError("", ex.ToString());
                return View("Index", model);
            }
        }
    }



            }

            catch (Exception ex)

            {

                ModelState.AddModelError("",ex.ToString());
                return View("Index", model);

            }

        }
            //if (ModelState.IsValid)
            //{

                //UserProfile userprof = new UserProfile();
                //int profileid;

                //int? userid = HttpContext.Session.GetInt32("UserID");

                //DAProcessing dbProcess = new DAProcessing();

                //userprof.ProfilePhotoURL = Request.Form["PhotoURL"].ToString();
                //userprof.Name = Request.Form["Name"].ToString();
                //userprof.Address = Request.Form["Address"].ToString();
                //userprof.City = Request.Form["City"].ToString();
                //userprof.State = Request.Form["State"].ToString();
                //userprof.Phone = Request.Form["Phone"].ToString();
                //userprof.Occupation = Request.Form["Occupation"].ToString();
                //userprof.Age = Convert.ToInt32(Request.Form["Age"].ToString());
                //userprof.Height = Convert.ToDouble(Request.Form["Height"].ToString());
                //userprof.Weight = Convert.ToDouble(Request.Form["Weight"].ToString());
                //userprof.CommitmentType = Request.Form["CommitmentType"].ToString();
                //userprof.Interests = Request.Form["Interests"].ToString();
                //userprof.Likes = Request.Form["Likes"].ToString();
                //userprof.Dislikes = Request.Form["Dislikes"].ToString();
                //userprof.FavoriteRestaurants = Request.Form["FavRestaurants"].ToString();
                //userprof.FavoriteMovies = Request.Form["FavMovies"].ToString();
                //userprof.FavoriteBooks = Request.Form["FavBooks"].ToString();
                //userprof.FavoriteQuotes = Request.Form["FavQuotes"].ToString();
                //userprof.Goals = Request.Form["Goals"].ToString();
                //userprof.Description = Request.Form["Description"].ToString();

                //profileid = dbProcess.createUserProfile(userprof, (int)userid);


                //HttpContext.Session.SetInt32("ProfileID", profileid);

                //return RedirectToAction("UserHome", "Home");
            }
            //return View("Index", model);

        }
