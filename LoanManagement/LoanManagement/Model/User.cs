using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string? UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string? UserPhone { get; set; }

        public string UserRole { get; set; }

        public DateTime? RegisterationDate { get; set; }
        
        [NotMapped]
        public string? UserMessage { get; set; }
        [NotMapped]
        public string? AccessToken { get; set; }

       


        [JsonIgnore]
        [ValidateNever]

        public List<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();
        [JsonIgnore]
        [ValidateNever]
        List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}




//using System.ComponentModel.DataAnnotations;

//namespace LoanManagementSystem.Model
//{
//    public class User
//    {
//        [Key]
//        public int UserId {  get; set; }
//        public string UserName { get; set; }
//        public string UserEmail { get; set; }
//        public string UserPassword {  get; set; }
//        public string UserPhone { get; set; }
//        public string UserRole { get; set; }
//        public string KYCStatus { get; set; }
//        public DateTime RegisterationDate {  get; set; }
//        public List<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();
//        public List<Notification> Notifications { get; set; }= new List<Notification>();
//    }
//}
