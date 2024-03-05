using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppLibrary
{
    public class UserProfile
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ProfilePhotoURL { get; set; }
        public string Interests { get; set; }
        public string LikesDislikes { get; set; }
        public string FavoriteRestaurants { get; set; }
        public string FavoriteMovies { get; set; }
        public string FavoriteBooks { get; set; }
        public string FavoriteQuotes { get; set; }
        public string Goals { get; set; }
        public string CommitmentType { get; set; }
        public string Description { get; set; }
    }
}
