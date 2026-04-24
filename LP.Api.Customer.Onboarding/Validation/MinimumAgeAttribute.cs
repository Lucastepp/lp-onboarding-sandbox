using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Validation;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minAge;

    public MinimumAgeAttribute(int minAge)
    {
        _minAge = minAge;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dob)
        {
            return new ValidationResult("Invalid date");
        }

        if (dob > DateTime.UtcNow)
        {
            return new ValidationResult("Date of birth cannot be in the future");
        }

        var age = DateTime.UtcNow.Year - dob.Year;

        if (dob > DateTime.UtcNow.AddYears(-age))
        {
            age--;
        }

        if (age < _minAge)
        {
            return new ValidationResult($"Must be at least {_minAge} years old");
        }

        return ValidationResult.Success;
    }
}