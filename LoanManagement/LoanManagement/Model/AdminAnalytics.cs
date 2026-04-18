using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LoanManagementSystem.Model
{
    public class AdminAnalytics
    {
        [Key]
        public int AnalyticsId {  get; set; }
        public int ApplicationsCount {  get; set; }
        public int ApprovedLoansCount {  get; set; }
        public int RejectedLoansCount { get; set; }
        public double TotalLoanAmount {  get; set; }
        public double TotalRepaymentCollected {  get; set; }
        public DateTime ReportDate { get; set; }
        public int LoanSchemeId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public LoanScheme LoanScheme { get; set; }  

    }
}
