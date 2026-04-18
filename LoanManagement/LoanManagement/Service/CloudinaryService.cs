using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace LoanManagement.Service
{
    public class CloudinaryService:ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration config)
        {
            var account = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadFileAsync(string base64FileContent, string fileName)
        {
            byte[] fileBytes = Convert.FromBase64String(base64FileContent);

            using (var stream = new MemoryStream(fileBytes))
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, stream)
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return uploadResult.SecureUrl.AbsoluteUri;
            }
        }
    }
}
