using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace LoanManagementSystem.Model
{
    public class LoanScheme
    {
        [Key]
        public int LoanSchemeId {  get; set; }
        public string LoanSchemeName { get; set; }
        public string LoanType {  get; set; }
        public double MaxAmount {  get; set; }
        public double InterestRate {  get; set; }

        public bool isActive {  get; set; }
        public int Tenure {  get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<LoanApplication> Application { get; set; } = new List<LoanApplication>();
        [JsonIgnore]
        [ValidateNever]
        public List<AdminAnalytics> AdminAnalytics { get; set; }= new List<AdminAnalytics>();

    }
}
