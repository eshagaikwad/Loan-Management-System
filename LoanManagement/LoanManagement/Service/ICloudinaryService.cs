namespace LoanManagement.Service
{
    public interface ICloudinaryService
    {
        Task<string> UploadFileAsync(string base64FileContent, string fileName);
    }
}
