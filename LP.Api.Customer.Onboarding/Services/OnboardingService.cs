using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Enums;
using LP.Api.Customer.Onboarding.Entities;
using LP.Api.Customer.Onboarding.Repositories;
using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.Common;

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
                LeadId = onboarding.LeadId,
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

        public OnboardingResponse? UpdateCompanyDetails(Guid leadId, CompanyDetailsRequest request)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding == null)
            {
                return null;
            }

            onboarding.CompanyDetails = new CompanyDetails
            {
                CompanyName = request.CompanyName,
                CompanyNumber = request.CompanyNumber,
                RegisteredAddress = request.RegisteredAddress,
                TradingAddress = request.TradingAddress,
                Industry = request.Industry,
                AnnualRevenue = request.AnnualRevenue
            };

            onboarding.LastCompletedStep = OnboardingStep.CompanyDetails;
            onboarding.CurrentStep = OnboardingStep.PersonalDetails;

            var response = new OnboardingResponse
            {
                LeadId = onboarding.LeadId,
                Status = onboarding.Status.ToString(),
                LastCompletedStep = onboarding.LastCompletedStep.ToString(),
                CurrentStep = onboarding.CurrentStep.ToString()
            };

            return response;
        }
    }
}
