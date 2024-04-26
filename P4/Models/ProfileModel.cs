
using System.ComponentModel.DataAnnotations;

namespace P4.Models
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "Photo is required")]
        public required string PhotoURL { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public required string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        public required string Occupation { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public required string Age { get; set; }

        [Required(ErrorMessage = "Height is required")]
        public required string Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public required string Weight { get; set; }

        [Required(ErrorMessage = "Commitment is required")]
        public required string Commitment { get; set; }

        [Required(ErrorMessage = "Interests are required")]
        public required string Interests { get; set; }

        [Required(ErrorMessage = "Likes are required")]
        public required string Likes { get; set; }

        [Required(ErrorMessage = "Dislikes are required")]
        public required string Dislikes { get; set; }

        [Required(ErrorMessage = "Favorite Restaurants are required")]
        public required string FavoriteRestaurants { get; set; }

        [Required(ErrorMessage = "Favorite Movies are required")]
        public required string FavoriteMovies { get; set; }

        [Required(ErrorMessage = "Favorite Books are required")]
        public required string FavoriteBooks { get; set; }

        [Required(ErrorMessage = "FavoriteQuotes is required")]
        public required string FavoriteQuotes { get; set; }

        [Required(ErrorMessage = "Goals are required")]
        public required string Goals { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }
    }
}