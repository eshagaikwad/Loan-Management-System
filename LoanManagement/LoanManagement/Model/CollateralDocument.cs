using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Model
{
    public class CollateralDocument
    {
        [Key]
        public int CollateralDocumentId {  get; set; }
  
        public string DocumentType { get; set; }   

        public string Base64FileContent { get; set; } 

        public string FileName { get; set; }  

        //public string VerificationStatus {  get; set; }
        public DateTime DateUploaded {  get; set; }


        [ForeignKey("LoanApplcation")]
        public int LoanApplicationId { get; set; }

        //[JsonIgnore]
        //[ValidateNever]
        //public LoanApplication LoanApplication { get; set; }
    }
}
