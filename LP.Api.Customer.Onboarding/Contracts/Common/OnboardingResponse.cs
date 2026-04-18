namespace LP.Api.Customer.Onboarding.Contracts.Signup
{
    public class OnboardingResponse
    {
        public Guid OnboardingId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string LastCompletedStep { get; set; } = string.Empty;
        public string CurrentStep { get; set; } = string.Empty;
    }
}
