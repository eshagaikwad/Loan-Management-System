using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollateralDocumentController : ControllerBase
    {
        private readonly ICollateralDocumentService _collateralDocumentService;
        private ApplicationDbContext _dbContext;
        private readonly ICollateralDocumentRepository _collateralDocumentRepository;

        public CollateralDocumentController(ICollateralDocumentService collateralDocumentService, ApplicationDbContext dbContext,ICollateralDocumentRepository collateralDocument)
        {
            _collateralDocumentService = collateralDocumentService;
            _dbContext = dbContext;
            _collateralDocumentRepository = collateralDocument;
        }


        //[Authorize(Roles = "User")]
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadCollateralDocument([FromBody] CollateralDocumentDTO collateralDocument)
        {
            try
            {
                await _collateralDocumentRepository.AddCollateralDTO(collateralDocument);
                return Ok(new { message = "Collateral document uploaded successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        ////[Authorize(Roles = "LoanOfficer")]
        //[HttpGet]
        //[Route("DownloadFileByName/{fileName}")]
        //public async Task<IActionResult> DownloadFileByName(string fileName)
        //{
        //    try
        //    {
        //        var fileResult = await _collateralDocumentService.DownloadFile(fileName);  // Call the new service method
        //        return fileResult;  // This should be of type FileContentResult if the file is successfully found and loaded
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return NotFound(new { message = "File not found" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}



        //[HttpGet]
        //[Route("DownloadFile/{id}")]
        //public async Task<IActionResult> DownloadFile(int id)
        //{
        //    try
        //    {
        //        var fileResult = await _collateralDocumentService.DownloadFile(id);  // Assuming the service method is async
        //        return fileResult;  // This should be of type FileContentResult if the file is successfully found and loaded
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        return NotFound(new { message = "File not found" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}



        [HttpGet("collaterals/{applicationId}")]
        public IActionResult GetCollateralByApplicationId(int applicationId)
        {
            var collateral = _collateralDocumentRepository.FindByLoanApplicationId(applicationId);
            if (collateral == null)
            {
                return NotFound(); // 404 response if no collateral found
            }
            return Ok(collateral);
        }

        //[HttpGet("{id}")]
        //public CollateralDocument Get(int id)
        //{
        //    return _collateralDocumentService.FindCollateralDocument(id);
        //}

        //[HttpPost]
        //public void Post([FromBody] CollateralDocument collateralDocument)
        //{
        //    _collateralDocumentService.AddCollateralDocument(collateralDocument);
        //}

        //[HttpPut("{id}")]
        //public void Put([FromBody] CollateralDocument collateralDocument)
        //{
        //    _collateralDocumentService.UpdateCollateralDocument(collateralDocument);
        //}


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _collateralDocumentService.DeleteCollateralDocument(id);
        //}
    }
}

