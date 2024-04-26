using System.ComponentModel.DataAnnotations;

namespace P4.Models
{
    public class BasicProfileViewModel
    {
        public required string PhotoURL { get; set; }

        public required string Name { get; set; }

        public required string Age { get; set; }

        public required string Description { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }

        public required string Height { get; set; }

        public required string Weight { get; set; }

        public required string Interests { get; set; }

        public required string Likes { get; set; }

        public required string Dislikes { get; set; }

        public required string FavRestaurants { get; set; }

        public required string FavMovies { get; set; }

        public required string FavQuotes { get; set; }

        public required string Goals { get; set; }

        public required string CommitmentType { get; set; }

    }
}

