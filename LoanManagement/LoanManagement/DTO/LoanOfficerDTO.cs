using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace LoanManagementSystem.Data
{
    public class LoanOfficerDTO
    {
        [Key]
        public int LoanOfficerId { get; set; }
        public string LoanOfficerName { get; set; }
        public string LoanOfficerEmail { get; set; }
        public string LoanOfficerPassword { get; set; }
        public string LoanOfficerPhone { get; set; }

        [DefaultValue(true)]
        public bool isActive {  get; set; }=true;
        
    }
}
