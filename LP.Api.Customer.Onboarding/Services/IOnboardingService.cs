using LP.Api.Customer.Onboarding.Contracts.Signup;
using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Services;

public interface IOnboardingService
{
    SignupResponse Signup(SignupRequest request);

    OnboardingEntity? GetById(Guid id);
}