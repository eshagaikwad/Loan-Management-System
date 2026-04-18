using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.DTO
{
    public class LoginOfficerDTO
    {
        [Key]
        public int LoanOfficerId { get; set; }
        public string LoanOfficerName { get; set; }
        public string LoanOfficerPassword { get; set; }
        public string? OfficerRole { get; set; }

        [NotMapped]
        public string UserMessage { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }
    }
}
   

