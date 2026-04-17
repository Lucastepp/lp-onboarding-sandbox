using LP.Api.Customer.Onboarding.Enums;

namespace LP.Api.Customer.Onboarding.Entities;

public class OnboardingEntity
{
    public Guid LeadId { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public OnboardingStatus Status { get; set; }
    public OnboardingStep LastCompletedStep { get; set; }
    public OnboardingStep CurrentStep { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}