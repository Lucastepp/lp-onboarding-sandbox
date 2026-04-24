using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Contracts.Signup
{
    public class SignupRequest
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).+$",
            ErrorMessage = "Password must contain uppercase, lowercase and a number")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\+?[0-9]{7,15}$",
            ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        public DeviceInfo Device { get; set; } = new();
    }
}
