using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.DTO
{
    public class LoanApplicationDTO
    {
        public int LoanApplicationId { get; set; }

        [Required(ErrorMessage = "LoanAmount is required.")]
        public double LoanAmount { get; set; }

        [Required(ErrorMessage = "UserAddress is required.")]
        public string UserAddress { get; set; }

        //[Required(ErrorMessage = "NPAStatus is required.")]
        //public string NPAStatus { get; set; }

        [Required(ErrorMessage = "NomineeName is required.")]
        public string NomineeName { get; set; }

        [Required(ErrorMessage = "NomineePhone is required.")]
    
        public string NomineePhone { get; set; }

        [Required(ErrorMessage = "BankAccountNo is required.")]
        public string BankAccountNo { get; set; }

        [Required(ErrorMessage = "BankName is required.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "IFSCCode is required.")]
        public string IFSCCode { get; set; }

        public int UserId { get; set; }
        public int LoanOfficerId { get; set; }
        public int LoanSchemeId { get; set; }




        [Required(ErrorMessage = "DocumentType is required.")]
        public string DocumentType1 { get; set; }   // 

        [Required(ErrorMessage = "Base64FileContent is required.")]
        public string Base64FileContent1 { get; set; } //document

        [Required(ErrorMessage = "FileName is required.")]
        public string FileName1 { get; set; }  //file name



        [Required(ErrorMessage = "DocumentType is required.")]
        public string DocumentType2 { get; set; }   // 

        [Required(ErrorMessage = "Base64FileContent is required.")]
        public string Base64FileContent2 { get; set; } //document

        [Required(ErrorMessage = "FileName is required.")]
        public string FileName2 { get; set; }  //file name
    }
}
