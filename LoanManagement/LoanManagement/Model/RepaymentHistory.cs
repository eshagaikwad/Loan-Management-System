using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LoanManagementSystem.Model
{
    public class RepaymentHistory
    {
        [Key]
        public int PaymentHistoryId { get; set; } // Unique identifier for the payment record
        public double AmountPaid { get; set; } // Amount paid
        public DateTime PaymentDate { get; set; } // Date of the payment

        [ForeignKey("LoanRepayment")]
        public int LoanRepaymentId { get; set; } // Foreign key to LoanRepayment

        //[JsonIgnore]
        //[ValidateNever]
        //public LoanRepayment LoanRepayment { get; set; }
    }
}
