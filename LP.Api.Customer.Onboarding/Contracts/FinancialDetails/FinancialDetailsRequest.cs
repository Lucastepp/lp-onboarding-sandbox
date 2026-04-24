using System.ComponentModel.DataAnnotations;

namespace LP.Api.Customer.Onboarding.Contracts.FinancialDetails
{
    public class FinancialDetailsRequest
    {
        // How data is collected
        public bool UseOpenBanking { get; set; }
        public bool HasUploadedDocuments { get; set; }

        // Manual input
        [Range(0, double.MaxValue)]
        public decimal? AnnualRevenue { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MonthlyRevenue { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MonthlyExpenses { get; set; }
    }
}
