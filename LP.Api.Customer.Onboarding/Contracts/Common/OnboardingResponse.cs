namespace LP.Api.Customer.Onboarding.Contracts.Common;

public class OnboardingResponse
{
    public Guid LeadId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string LastCompletedStep { get; set; } = string.Empty;
    public string CurrentStep { get; set; } = string.Empty;
}
