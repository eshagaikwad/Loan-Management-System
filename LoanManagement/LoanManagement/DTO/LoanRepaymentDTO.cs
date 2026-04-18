using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoanManagementSystem.DTO
{
    public class LoanRepaymentDTO
    {
        [Key]
        public int LoanRepaymentId { get; set; }
        public double PaymentAmount { get; set; }
        public int LoanApplicationId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public LoanApplication LoanApplication { get; set; }
    }









    //public class LoanRepaymentDTO
    //{
    //    [Key]
    //    public int LoanRepaymentId { get; set; }
    //    public double PaymentAmount { get; set; }
    //    public string PaymentMethod { get; set; }
    //    public int LoanApplicationId { get; set; }
    //    [JsonIgnore]
    //    [ValidateNever]
    //    public LoanApplication LoanApplication { get; set; }
    //}
}
