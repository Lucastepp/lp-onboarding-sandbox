using LP.Api.Customer.Onboarding.Contracts.Common;
using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.FinancialDetails;
using LP.Api.Customer.Onboarding.Contracts.PersonalDetails;
using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Entities;
using LP.Api.Customer.Onboarding.Enums;
using LP.Api.Customer.Onboarding.Exceptions;
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
            var normalizedEmail = request.Email.Trim().ToLowerInvariant();

            var existingLead = _repository.GetByEmail(normalizedEmail);

            if (existingLead is not null)
            {
                throw new DuplicateEmailException("An account with this email already exists.");
            }

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

            return MapToOnboardingResponse(onboarding);

        }
        public OnboardingResponse? GetByLeadId(Guid leadId)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding is null)
            {
                return null;
            }

            return MapToOnboardingResponse(onboarding);
        }

        public OnboardingResponse? GetProgress(Guid leadId)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding is null)
            {
                return null;
            }

            return MapToOnboardingResponse(onboarding);
        }

        public OnboardingResponse? UpdateCompanyDetails(Guid leadId, CompanyDetailsRequest request)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding is null)
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

            return MapToOnboardingResponse(onboarding);
        }

        public OnboardingResponse? UpdatePersonalDetails(Guid leadId, PersonalDetailsRequest request)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding == null)
            {
                return null;
            }

            onboarding.PersonalDetails = new PersonalDetails
            {
                DateOfBirth = request.DateOfBirth,
                Nationality = request.Nationality,
                EmploymentStatus = request.EmploymentStatus,
                ResidentialAddress = request.ResidentialAddress,
            };

            return MapToOnboardingResponse(onboarding);
        }

        public OnboardingResponse? UpdateFinancialDetails(Guid leadId, FinancialDetailsRequest request)
        {
            var onboarding = _repository.GetByLeadId(leadId);

            if (onboarding == null)
            {
                return null;
            }

            onboarding.FinancialDetails = new FinancialDetails
            {
                UseOpenBanking = request.UseOpenBanking,
                HasUploadedDocuments = request.HasUploadedDocuments,
                AnnualRevenue = request.AnnualRevenue,
                MonthlyRevenue = request.MonthlyRevenue,
                MonthlyExpenses = request.MonthlyExpenses
            };

            return MapToOnboardingResponse(onboarding);
        }

        public OnboardingResponse MapToOnboardingResponse(OnboardingEntity onboarding)
        {
            return new OnboardingResponse
            {
                LeadId = onboarding.LeadId,
                Status = onboarding.Status.ToString(),
                LastCompletedStep = onboarding.LastCompletedStep.ToString(),
                CurrentStep = onboarding.CurrentStep.ToString()
            };
        }
    }
}   
