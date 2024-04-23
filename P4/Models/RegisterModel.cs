namespace P4.Models
{
    public class RegisterModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
    }
}
