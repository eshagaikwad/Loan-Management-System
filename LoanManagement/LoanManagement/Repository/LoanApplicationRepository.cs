using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using LoanManagement.Data;
using LoanManagement.Service;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;
using LoanManagement.DTO;
using System.Collections.Generic;

namespace LoanManagementSystem.Repository
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private ApplicationDbContext _dbContext;
        private readonly ICloudinaryService _cloudinaryService;

        public LoanApplicationRepository(ApplicationDbContext dbContext, ICloudinaryService cloudinaryService)
        {
            _dbContext = dbContext;
            _cloudinaryService = cloudinaryService;
        }
        public void Add(LoanApplication loanApplication)
        {
            _dbContext.LoanApplications.Add(loanApplication);
            _dbContext.SaveChanges();
        }
        public async Task<(IEnumerable<LoanApplication>, int totalCount)> Display(int pageNumber, int pageSize)
        {
            var totalCount = await _dbContext.LoanApplications.CountAsync(); // Get total record count
            var data = await _dbContext.LoanApplications
                .OrderBy(lo => lo.ApplicationDate)  // Sort by LoanSchemeId
                .Skip((pageNumber - 1) * pageSize) // Skip to the appropriate page
                .Take(pageSize) // Take the required number of items for the page
                .ToListAsync(); // Convert to list
            return (data, totalCount);
        }
        public List<LoanApplication> display()
        {
            return _dbContext.LoanApplications.ToList();
        }
        public LoanApplication Find(int id)
        {
            return _dbContext.LoanApplications.Find(id);
        }
        public void Update(LoanApplication loanApplication)
        {
            var existingLoanApplication = _dbContext.LoanApplications.Find(loanApplication.LoanApplicationId);
            if (existingLoanApplication != null)
            {
                _dbContext.LoanApplications.Update(existingLoanApplication);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }
        public void Delete(int id)
        {
            LoanApplication loanApplication = _dbContext.LoanApplications.Find(id);
            _dbContext.LoanApplications.Remove(loanApplication);
            _dbContext.SaveChanges();
        }

        //public async Task AddCollateralDTO(ApplicationCollateralDTO applicationCollateralDTO)
        //{
        //    if (string.IsNullOrEmpty(applicationCollateralDTO.Base64FileContent))
        //    {
        //        throw new ArgumentException("Document files are required.");
        //    }

        //    string base64Data = StripBase64Prefix(applicationCollateralDTO.Base64FileContent);
        //    string cloudinaryFileUrl = await UploadToCloudinaryAsync(base64Data, applicationCollateralDTO.FileName);

        //    LoanApplication loanApplication = new LoanApplication
        //    {
        //        LoanApplicationId = 0,
        //        ApplicationDate = DateTime.Now,
        //        LoanAmount = 0,
        //        LoanStatus = "Pending",
        //        RepaymentStartDate = DateTime.Now,
        //        UserAddress = null,
        //        NPAStatus = "Not Applicable",
        //        NomineeName = "",
        //        NomineePhone = "",
        //        BankAccountNo = "",
        //        BankName = "",
        //        IFSCCode = "",
        //        UserId = 0,
        //        LoanOfficerId = 0,
        //        LoanSchemeId = 0,
        //        DocumentFileName1 = "",
        //        DocumentUrl1 = " ",
        //        DocumentType1 = " ",
        //        DocumentFileName2 = "",
        //        DocumentUrl2 = "",
        //        DocumentType2 = " ",
        //        DateUploaded = DateTime.Now,
        //        DocumentVerificationStatus = "Pending",
        //        Collateralurl = applicationCollateralDTO.Base64FileContent,
        //        CollateralFileName = applicationCollateralDTO.FileName,
        //        collateralType = applicationCollateralDTO.CollateralType

               
        //    };

        //    _dbContext.LoanApplications.Add(loanApplication);
        //    await _dbContext.SaveChangesAsync();
        //}



        public async Task AddDTO(LoanApplicationDTO loanApplicationDto)
        {
            if (loanApplicationDto == null)
            {
                throw new ArgumentNullException(nameof(loanApplicationDto), "Loan Application data cannot be null");
            }

            if (string.IsNullOrEmpty(loanApplicationDto.Base64FileContent1) ||
                string.IsNullOrEmpty(loanApplicationDto.Base64FileContent2))
            {
                throw new ArgumentException("Both document files are required.");
            }

           

            // Upload file to Cloudinary for both documents
            string base64Data1 = StripBase64Prefix(loanApplicationDto.Base64FileContent1);
            string cloudinaryFileUrl1 = await UploadToCloudinaryAsync(base64Data1, loanApplicationDto.FileName1);

            string base64Data2 = StripBase64Prefix(loanApplicationDto.Base64FileContent2);
            string cloudinaryFileUrl2 = await UploadToCloudinaryAsync(base64Data2, loanApplicationDto.FileName2);

            // Create LoanApplication entity
            LoanApplication loanApplication = new LoanApplication
            {
                LoanApplicationId = 0,
                ApplicationDate = DateTime.Now,
                LoanAmount = loanApplicationDto.LoanAmount,
                LoanStatus = "Pending",
                RepaymentStartDate = DateTime.Now,
                UserAddress = loanApplicationDto.UserAddress,
                NPAStatus = "Not Applicable",
                NomineeName = loanApplicationDto.NomineeName,
                NomineePhone = loanApplicationDto.NomineePhone,
                BankAccountNo = loanApplicationDto.BankAccountNo,
                BankName = loanApplicationDto.BankName,
                IFSCCode = loanApplicationDto.IFSCCode,
                UserId = loanApplicationDto.UserId,
                LoanOfficerId = loanApplicationDto.LoanOfficerId,
                LoanSchemeId = loanApplicationDto.LoanSchemeId,
                DocumentFileName1 = loanApplicationDto.FileName1,
                DocumentUrl1 = cloudinaryFileUrl1,
                DocumentType1 = loanApplicationDto.DocumentType1,
                DocumentFileName2 = loanApplicationDto.FileName2,
                DocumentUrl2 = cloudinaryFileUrl2,
                DocumentType2 = loanApplicationDto.DocumentType2, // Ensure this is correct
                DateUploaded = DateTime.Now,
                DocumentVerificationStatus = "Pending",
              
            };

            // Add to database
            _dbContext.LoanApplications.Add(loanApplication);
            await _dbContext.SaveChangesAsync();
        }

        private string StripBase64Prefix(string base64Data)
        {
            if (base64Data.StartsWith("data:application/pdf;base64,")) // PDF
            {
                return base64Data.Substring("data:application/pdf;base64,".Length);
            }
            else if (base64Data.StartsWith("data:image/png;base64,")) // PNG
            {
                return base64Data.Substring("data:image/png;base64,".Length);
            }
            else if (base64Data.StartsWith("data:image/jpeg;base64,")) // JPEG
            {
                return base64Data.Substring("data:image/jpeg;base64,".Length);
            }
            else if (base64Data.StartsWith("data:image/gif;base64,")) // GIF
            {
                return base64Data.Substring("data:image/gif;base64,".Length);
            }
            else
            {
                throw new ArgumentException("Unsupported file format. Only PDF and image formats (PNG, JPEG, GIF) are allowed.");
            }
        }

        private async Task<string> UploadToCloudinaryAsync(string base64Data, string fileName)
        {
            var cloudinary = new Cloudinary(new Account("dsx5xnseb", "523562625549671", "09hhhfiXGXvIthZyfyVa8AGCkpQ")); // Replace with your Cloudinary credentials

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("data:image/jpeg;base64," + base64Data), // Adjust as needed based on the file type
                PublicId = fileName,
                Overwrite = true // Adjust based on your needs
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to upload file to Cloudinary: {uploadResult.Error?.Message}");
            }

            return uploadResult.SecureUrl.ToString(); // Return the URL of the uploaded file
        }

        public void Update(int id)
        {
            var existingLoanApplication = _dbContext.LoanApplications
                                        .Include(l => l.CollateralDocuments) // Include related collateral documents
                                        .FirstOrDefault(l => l.LoanApplicationId == id); // Find the loan application with the specific id

            if (existingLoanApplication == null)
            {
                throw new KeyNotFoundException("Loan application not found.");
            }

            // Update DocumentVerificationStatus to 'Completed'
            if (!string.IsNullOrEmpty(existingLoanApplication.DocumentFileName1) ||
                !string.IsNullOrEmpty(existingLoanApplication.DocumentFileName2))
            {
                existingLoanApplication.DocumentVerificationStatus = "Completed";
            }

            // Check if there are any collateral documents uploaded
            if (existingLoanApplication.CollateralDocuments != null && existingLoanApplication.CollateralDocuments.Count > 0)
            {
                // Update LoanStatus to 'granted'
                existingLoanApplication.LoanStatus = "granted";
            }

            // Save changes to the database
            _dbContext.LoanApplications.Update(existingLoanApplication);
            _dbContext.SaveChanges();
        }

        public void rejectUpdate(int id)
        {
            var existingLoanApplication = _dbContext.LoanApplications
                                        .FirstOrDefault(l => l.LoanApplicationId == id); // Find the loan application with the specific id

            if (existingLoanApplication == null)
            {
                throw new KeyNotFoundException("Loan application not found.");
            }

            // Update LoanStatus to 'rejected'
            existingLoanApplication.DocumentVerificationStatus = "rejected";

            // Optionally, you can store the reason for rejection if needed
          

            // Save changes to the database
            _dbContext.LoanApplications.Update(existingLoanApplication);
            _dbContext.SaveChanges();
        }





        public async Task UpdateDTO(int id, LoanApplicationDTO loanApplicationDto)
        {
            //var existingLoanApplication = await _dbContext.LoanApplications.FindAsync(id);

            //if (existingLoanApplication == null)
            //{
            //    throw new KeyNotFoundException("Loan application not found.");
            //}


            //if (loanApplicationDto.FormFile != null && loanApplicationDto.FormFile.Length > 0)
            //{
            //    string uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            //    if (!Directory.Exists(uploadsFolderPath))
            //    {
            //        Directory.CreateDirectory(uploadsFolderPath);
            //    }

            //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + loanApplicationDto.FormFile.FileName;
            //    string filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await loanApplicationDto.FormFile.CopyToAsync(fileStream);
            //    }


            //    //existingLoanApplication.LoanApplicationId = 0;
            //    existingLoanApplication.ApplicationDate = DateTime.Now;
            //    existingLoanApplication.LoanAmount = loanApplicationDto.LoanAmount;
            //    //existingLoanApplication.LoanStatus = loanApplicationDto.LoanStatus;
            //    existingLoanApplication.RepaymentStartDate = DateTime.Now;
            //    existingLoanApplication.UserAddress = loanApplicationDto.UserAddress;
            //    existingLoanApplication.NPAStatus = loanApplicationDto.NPAStatus;
            //    existingLoanApplication.NomineeName = loanApplicationDto.NomineeName;
            //    existingLoanApplication.NomineePhone = loanApplicationDto.NomineePhone;
            //    existingLoanApplication.BankAccountNo = loanApplicationDto.BankAccountNo;
            //    existingLoanApplication.BankName = loanApplicationDto.BankName;
            //    existingLoanApplication.IFSCCode = loanApplicationDto.IFSCCode;
            //    existingLoanApplication.UserId = loanApplicationDto.UserId;
            //    existingLoanApplication.LoanOfficerId = loanApplicationDto.LoanOfficerId;
            //    existingLoanApplication.LoanSchemeId = loanApplicationDto.LoanSchemeId;
            //    existingLoanApplication.DocumentFileName = uniqueFileName;
            //    existingLoanApplication.DocumentUrl = filePath;
            //    existingLoanApplication.DocumentType = loanApplicationDto.DocumentType;
            //    existingLoanApplication.DateUploaded = DateTime.Now;
            //    existingLoanApplication.DocumentVerificationStatus = "Pending";

            //    try
            //    {

            //        _dbContext.LoanApplications.Update(existingLoanApplication);
            //        await _dbContext.SaveChangesAsync();

            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error occurred while updatingan application: " + ex.Message);
            //    }

            //}
            //else
            //{
            //    throw new ArgumentException("A valid document file is required");
            //}
        }







    }
}
