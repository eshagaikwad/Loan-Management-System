using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.DTO
{
    public class LoginDTO
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string? UserRole {  get; set; }

        [NotMapped]
        public string UserMessage { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }
    }
}
