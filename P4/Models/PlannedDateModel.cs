using System.ComponentModel.DataAnnotations;

namespace P4.Models
{
    public class PlannedDateModel
    {
        public required string Time { get; set; }

        public required string Description { get; set; }
    }
}