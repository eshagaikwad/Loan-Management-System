using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LoanManagementSystem.Model
{

    public class LoanApplication
    {
        [Key]
        public int LoanApplicationId { get; set; }

        public DateTime? ApplicationDate { get; set; }

        [Required]
        [Range(1000, 10000000)]
        public double LoanAmount { get; set; }

        [Required]
        [MaxLength(50)]
        [DefaultValue("pending")]
        public string LoanStatus { get; set; }

        public DateTime? RepaymentStartDate { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserAddress { get; set; }



        public string DocumentFileName1 { get; set; }

        [Url]
        public string DocumentUrl1 { get; set; }

        [MaxLength(100)]
        public string DocumentType1 { get; set; }




        public string DocumentFileName2 { get; set; }

        [Url]
        public string DocumentUrl2 { get; set; }

        [MaxLength(100)]
        public string DocumentType2 { get; set; }


        public DateTime? DateUploaded { get; set; }

        [MaxLength(50)]
        [DefaultValue("pending")]
        public string DocumentVerificationStatus { get; set; } 

        public string NPAStatus {  get; set; }

        [Required]
        [MaxLength(50)]
        public string NomineeName { get; set; }

        //[Phone]
        public string NomineePhone { get; set; }

        [Required]
        [MaxLength(20)]
        public string BankAccountNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(11)]
        public string IFSCCode { get; set; }

        // Foreign Keys
        [ForeignKey("User")]
        public int UserId { get; set; }
      

        [ForeignKey("LoanOfficer")]
        public int LoanOfficerId { get; set; }
      

        [ForeignKey("LoanScheme")]
        public int LoanSchemeId { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public LoanOfficer LoanOfficer { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public LoanScheme LoanScheme { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public User User { get; set; }

          
        [JsonIgnore]
        [ValidateNever]

        // Loan Repayments - One to Many Relationship
        public List<CollateralDocument> CollateralDocuments { get; set; }= new List<CollateralDocument>();


    }


















    //public class LoanAplication
    //{
    //    [Key]
    //    public int LoanApplicationId { get; set; }

    //    public DateTime ApplicationDate { get; set; }  

    //    public decimal LoanAmount { get; set; }

    //    [MaxLength(50)]
    //    public string LoanStatus { get; set; }

    //    public DateTime RepaymentStartDate { get; set; }
    //    public string NPAStatus {  get; set; }

    //    public string UserAddress { get; set; }

    //    public string CollateralDocumentUrl { get; set; }
    //    public string CollateralDocumentType { get; set; }
    //    public string VerificationStatus { get; set; }
    //    public string CollateralDocumentFileName { get; set; }
    //    public DateTime DateUploaded { get; set; }



    //    public string NomineeName {  get; set; }
    //    public string NomineePhone {  get; set; }
    //    public string BankAccountNo {  get; set; }
    //    public string BankName {  get; set; }
    //    public string IFSCCode {  get; set; }



    //    [ForeignKey("User")]
    //    public int UserId { get; set; }
    //    public User User { get; set; }

    //    [ForeignKey("LoanOfficer")]
    //    public int LoanOfficerId {  get; set; }
    //    public LoanOfficer LoanOfficer { get; set; }

    //    [ForeignKey("loanscheme")]
    //    public int LoanSchemeId {  get; set; }
    //    public LoanScheme LoanScheme { get; set; }

    //    [JsonIgnore]
    //    [ValidateNever]
    //    public List<LoanRepayment> LoanRepayments { get; set; } = new List<LoanRepayment>();
    //}
}
