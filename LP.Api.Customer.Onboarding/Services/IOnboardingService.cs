using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Contracts.Common;
using LP.Api.Customer.Onboarding.Contracts.PersonalDetails;
using LP.Api.Customer.Onboarding.Contracts.FinancialDetails;
using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Services;

public interface IOnboardingService
{
    OnboardingResponse Signup(SignupRequest request);
    OnboardingResponse? GetByLeadId(Guid leadId);
    OnboardingResponse? GetProgress(Guid leadId);
    OnboardingResponse? UpdateCompanyDetails(Guid leadId, CompanyDetailsRequest request);
    OnboardingResponse? UpdatePersonalDetails(Guid leadId, PersonalDetailsRequest request);
    OnboardingResponse? UpdateFinancialDetails(Guid leadId, FinancialDetailsRequest request);
    OnboardingResponse MapToOnboardingResponse(OnboardingEntity onboarding);
}