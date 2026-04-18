using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Model
{
    public class Admin
    {
        [Key]
        public int AdminId {  get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string UserMessage { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }

    }
}
