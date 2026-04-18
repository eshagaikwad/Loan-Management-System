using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Model
{
    public class Notification
    {
        [Key]
        public int NotificationId {  get; set; }
        public int UserId { get; set; }
        public string Message {  get; set; }
        public DateTime SendDate { get; set; }
        public int LoanApplicationId { get; set; }
        public LoanApplication Application { get; set; }    

    }
}
