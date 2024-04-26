
using System.ComponentModel.DataAnnotations;

namespace P4.Models
{
    public class BasicProfileInfoModel
    {
        public required string PhotoURL { get; set; }

        public required string Name { get; set; }

        public required string Age { get; set; }

        public required string Description { get; set; }

    }
}
