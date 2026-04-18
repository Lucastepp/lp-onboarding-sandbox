using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Enums;
using LP.Api.Customer.Onboarding.Entities;
using LP.Api.Customer.Onboarding.Repositories;

namespace LP.Api.Customer.Onboarding.Services
{
    public class OnboardingService : IOnboardingService
    {
        private readonly IOnboardingRepository _repository;

        public OnboardingService(IOnboardingRepository repository)
        {
            _repository = repository;
        }

        public OnboardingResponse Signup(SignupRequest request)
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

            _repository.Save(onboarding);

            var response = new OnboardingResponse
            {
                OnboardingId = onboarding.LeadId,
                Status = onboarding.Status.ToString(),
                LastCompletedStep = onboarding.LastCompletedStep.ToString(),
                CurrentStep = onboarding.CurrentStep.ToString()
            };

            return response;
        }
        public OnboardingEntity? GetByLeadId(Guid leadId)
        {
            return _repository.GetByLeadId(leadId);
        }
    }
}
