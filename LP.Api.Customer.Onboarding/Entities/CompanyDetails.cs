namespace LP.Api.Customer.Onboarding.Entities
{
    public class CompanyDetails
    {
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyNumber { get; set; } = string.Empty;
        public string RegisteredAddress { get; set; } = string.Empty;
        public string TradingAddress { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public decimal AnnualRevenue { get; set; }
    }
}
