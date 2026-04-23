namespace LP.Api.Customer.Onboarding.Exceptions;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException(string message) : base(message)
    {
    }
}