using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Contracts.CompanyDetails;

public class CompanyDetailsRequest
{
    [Required]
    [MinLength(2)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    [RegularExpression(@"^[A-Za-z0-9]+$",
        ErrorMessage = "Company number must be alphanumeric")]
    public string CompanyNumber { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    public string RegisteredAddress { get; set; } = string.Empty;

    public string TradingAddress { get; set; } = string.Empty;

    public string Industry { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal AnnualRevenue { get; set; }
}