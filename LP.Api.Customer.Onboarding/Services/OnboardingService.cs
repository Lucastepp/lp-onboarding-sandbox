using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Enums;
using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Services
{
    public class OnboardingService : IOnboardingService
    {
        public SignupResponse Signup(SignupRequest request)
        {
            var onboarding = new OnboardingEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                Status = OnboardingStatus.InProgress,
                LastCompletedStep = OnboardingStep.Signup,
                CurrentStep = OnboardingStep.CompanyDetails
            };

            var response = new SignupResponse
            {
                OnboardingId = onboarding.Id,
                Status = onboarding.Status.ToString(),
                LastCompletedStep = onboarding.LastCompletedStep.ToString(),
                CurrentStep = onboarding.CurrentStep.ToString()
            };

            return response;
        }
    }
}
