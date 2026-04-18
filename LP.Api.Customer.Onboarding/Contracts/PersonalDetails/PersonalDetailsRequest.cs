namespace LP.Api.Customer.Onboarding.Contracts.PersonalDetails;

public class PersonalDetailsRequest
{
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string ResidentialAddress { get; set; } = string.Empty;
    public string EmploymentStatus { get; set; } = string.Empty;
}