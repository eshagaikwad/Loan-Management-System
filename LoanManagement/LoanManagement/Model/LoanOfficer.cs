using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LoanManagementSystem.Model
{
    public class LoanOfficer
    {
        [Key]
        public int LoanOfficerId {  get; set; }    
        public string LoanOfficerName {  get; set; }
        public string LoanOfficerEmail {  get; set; }
        public string LoanOfficerPassword {  get; set; }
        public string LoanOfficerPhone { get; set; }
        public string OfficerRole {  get; set; }

        [DefaultValue(true)]
        public bool isActive {  get; set; }=true;
        public DateTime RegisterationDate { get; set; }
        [NotMapped]
        public string? UserMessage { get; set; }
        [NotMapped]
        public string? AccessToken { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<LoanApplication> Application { get; set; }=new List<LoanApplication>();
    }
}












//public int UserId { get; set; }
//[JsonIgnore]
//[ValidateNever]
//public User User { get; set; }
