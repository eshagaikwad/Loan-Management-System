using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Net;


namespace LoanManagementSystem.Repository
{
    public class CollateralDocumentRepository : ICollateralDocumentRepository
    {
        private ApplicationDbContext _dbContext;

        public CollateralDocumentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCollateralDTO(CollateralDocumentDTO collateralDocument)
        {
            if (string.IsNullOrEmpty(collateralDocument.Base64FileContent))
            {
                throw new ArgumentException("Document files are required.");
            }

            string base64Data = StripBase64Prefix(collateralDocument.Base64FileContent);
            string cloudinaryFileUrl = await UploadToCloudinaryAsync(base64Data, collateralDocument.FileName);

            CollateralDocument collateralDocument1 = new CollateralDocument
            {
                DocumentType= collateralDocument.DocumentType,
                DateUploaded=DateTime.Now,
                Base64FileContent=cloudinaryFileUrl,
                FileName=collateralDocument.FileName,
                LoanApplicationId=collateralDocument.LoanApplicationId


            };


            _dbContext.CollateralDocuments.Add(collateralDocument1);
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


        public CollateralDocument FindByLoanApplicationId(int loanApplicationId)
        {
            return _dbContext.CollateralDocuments
                .FirstOrDefault(c => c.LoanApplicationId == loanApplicationId);
        }



    }
}
