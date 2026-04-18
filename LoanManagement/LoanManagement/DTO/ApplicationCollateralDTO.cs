namespace LoanManagement.DTO
{
    public class ApplicationCollateralDTO
    {
        public int Id { get; set; }

       
        public string Base64FileContent { get; set; }  // Assuming this is a base64 string for the collateral
        public string FileName { get; set; }            // Original file name
        public string CollateralType { get; set; }


    }
}
