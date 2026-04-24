namespace LP.Api.Customer.Onboarding.Exceptions;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException()
        : base("Email already exists.")
    {
    }

    public DuplicateEmailException(string message)
        : base(message)
    {
    }

    public DuplicateEmailException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}