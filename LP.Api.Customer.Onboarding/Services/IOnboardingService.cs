using LP.Api.Customer.Onboarding.Contracts.CompanyDetails;
using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Contracts.Common;
using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Services;

public interface IOnboardingService
{
    OnboardingResponse Signup(SignupRequest request);
    OnboardingEntity? GetByLeadId(Guid leadId);
    OnboardingResponse? UpdateCompanyDetails(Guid leadId, CompanyDetailsRequest request);
}