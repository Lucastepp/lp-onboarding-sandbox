using LP.Api.Customer.Onboarding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Contracts.PersonalDetails;

public class PersonalDetailsRequest
{
    [Required]
    [MinimumAge(18)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Nationality { get; set; } = string.Empty;

    [Required]
    public string ResidentialAddress { get; set; } = string.Empty;

    [Required]
    public string EmploymentStatus { get; set; } = string.Empty;
}