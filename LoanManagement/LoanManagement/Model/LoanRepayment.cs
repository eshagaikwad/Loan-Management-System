using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Model
{
    public class LoanRepayment
    {
        [Key]
        public int LoanRepaymentId {  get; set; }
        public double TotalLoanAmount { get; set; }
        public double EMIAmount {  get; set; }
        public double PrincipalAmount {  get; set; }
        public double InterestAmount { get; set; }
        public double PrincipalPaid { get; set; }
        //public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public int NoOfInstallments { get; set; }
        public DateTime? LastPaid { get; set; }
        public bool IsNPA {  get; set; }
        public string PaymentStatus { get; set; }
        [ForeignKey("LoanApplication")]
        public int LoanApplicationId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public LoanApplication LoanApplication { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<RepaymentHistory> RepaymentHistory { get; set; } = new List<RepaymentHistory>();
    }
}




//public double? RemainingPrincipal { get; set; }
//public double? InterestPaid { get; set; }
