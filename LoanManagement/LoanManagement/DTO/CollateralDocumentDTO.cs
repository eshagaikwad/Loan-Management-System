using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanManagementSystem.DTO
{
    public class CollateralDocumentDTO
    {
        [Key]
        public int CollateralDocumentId {  get; set; }
        public string DocumentType { get; set; }

        public string Base64FileContent { get; set; }

        public string FileName { get; set; }


       [ForeignKey("LoanApplcation")]
        public int LoanApplicationId { get; set; }



        //[JsonIgnore]
        //[ValidateNever]
        //public LoanApplication LoanApplication { get; set; }
    }
}
