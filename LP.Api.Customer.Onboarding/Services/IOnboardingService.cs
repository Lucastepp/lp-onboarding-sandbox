using LP.Api.Customer.Onboarding.Contracts.Signup;

namespace LP.Api.Customer.Onboarding.Services;

public interface IOnboardingService
{
    SignupResponse Signup(SignupRequest request);
}