using LP.Api.Customer.Onboarding.Entities;

namespace LP.Api.Customer.Onboarding.Repositories;

public class OnboardingRepository : IOnboardingRepository
{
    private static readonly List<OnboardingEntity> _storage = new();

    public void Save(OnboardingEntity onboarding)
    {
        _storage.Add(onboarding);
    }

    public OnboardingEntity? GetByLeadId(Guid id)
    {
        return _storage.FirstOrDefault(x => x.LeadId == id);
    }

    public OnboardingEntity? GetByEmail(string email)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return _storage.FirstOrDefault(x => x.Email.Trim().ToLowerInvariant() == normalizedEmail);
    }
}