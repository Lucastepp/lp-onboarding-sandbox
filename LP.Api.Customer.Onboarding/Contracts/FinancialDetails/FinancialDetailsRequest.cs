namespace LP.Api.Customer.Onboarding.Contracts.FinancialDetails
{
    public class FinancialDetailsRequest
    {
        // How data is collected
        public bool UseOpenBanking { get; set; }
        public bool HasUploadedDocuments { get; set; }

        // Manual input
        public decimal? AnnualRevenue { get; set; }
        public decimal? MonthlyRevenue { get; set; }
        public decimal? MonthlyExpenses { get; set; }

    }
}
