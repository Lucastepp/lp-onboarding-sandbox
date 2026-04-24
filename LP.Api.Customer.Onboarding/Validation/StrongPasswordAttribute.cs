using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Validation;

public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string password)
            return new ValidationResult("Invalid password");

        if (password.Length < 8)
            return new ValidationResult("Password must be at least 8 characters");

        if (!password.Any(char.IsUpper))
            return new ValidationResult("Password must contain at least one uppercase letter");

        if (!password.Any(char.IsLower))
            return new ValidationResult("Password must contain at least one lowercase letter");

        if (!password.Any(char.IsDigit))
            return new ValidationResult("Password must contain at least one number");

        return ValidationResult.Success;
    }
}