using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Repositories;

public interface IOnboardingRepository
{
    void Save(OnboardingEntity onboarding);
    OnboardingEntity? GetByLeadId(Guid id);
    OnboardingEntity? GetByEmail(string email);
}