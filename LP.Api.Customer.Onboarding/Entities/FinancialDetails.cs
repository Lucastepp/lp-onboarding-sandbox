namespace LP.Api.Customer.Onboarding.Entities
{
    public class FinancialDetails
    {
        public bool UseOpenBanking { get; set; }
        public bool HasUploadedDocuments { get; set; }

        public decimal? AnnualRevenue { get; set; }
        public decimal? MonthlyRevenue { get; set; }
        public decimal? MonthlyExpenses { get; set; }
    }
}
