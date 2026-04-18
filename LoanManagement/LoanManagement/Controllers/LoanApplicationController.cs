using LoanManagement.DTO;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles= "User")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;
        private readonly ILoanApplicationRepository _loanApplicationRepository;

        public LoanApplicationController(ILoanApplicationService loanApplicationService,ILoanApplicationRepository loanApplicationRepository)
        {
            _loanApplicationService = loanApplicationService;
            _loanApplicationRepository = loanApplicationRepository;
        }


        //[Authorize(Roles = "User")]
        [HttpPost("DTO")]
        public async Task<IActionResult> PostDTO([FromBody] LoanApplicationDTO loanApplicationDto)
        {
            try
            {
                await _loanApplicationService.AddLoanDTO(loanApplicationDto);
                // Return a JSON object instead of a plain string
                return Ok(new { message = "Loan application added successfully" });
            }
            catch (Exception ex)
            {
                // Return the error message as a JSON object
                return BadRequest(new { error = ex.Message });
            }
        }

        //[HttpPost("CollateralPost")]
        //public async Task<IActionResult> PostCollateralDTO([FromBody] ApplicationCollateralDTO loanApplicationDto)
        //{
        //    try
        //    {
        //        await _loanApplicationRepository.AddCollateralDTO(loanApplicationDto);
        //        // Return a JSON object instead of a plain string
        //        return Ok(new { message = "Loan application added successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Return the error message as a JSON object
        //        return BadRequest(new { error = ex.Message });
        //    }
        //}
        [HttpPut("reject/{id}")]
        public IActionResult RejectLoanApplication(int id)
        {
            try
            {
                // Call the service to reject the loan application
                _loanApplicationRepository.rejectUpdate(id);

                return Ok(new { message = "Loan application rejected successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while rejecting the loan application.", error = ex.Message });
            }
        }


        //[Authorize(Roles = "LoanOfficer")]
        [HttpPut("DTO{id}")]
        public async Task<IActionResult> PutDTO(int id, [FromForm] LoanApplicationDTO loanApplicationDto)
        {
            try
            {
                await _loanApplicationService.UpdateLoanDTO(id, loanApplicationDto);
                return Ok("Loan application updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [Authorize(Roles = "User,LoanOfficer")]
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 3)
        {
            Console.WriteLine(pageNumber);
            var (data, totalCount) = await _loanApplicationService.DisplayApplications(pageNumber, pageSize);
            return Ok(new { data, totalCount });

        }
        [HttpGet("getApplications")]
        public List<LoanApplication> Get()
        {
          return  _loanApplicationRepository.display().ToList();
        }

        [HttpGet("{id}")]
        public LoanApplication Get(int id)
        {
            return _loanApplicationService.FindLoanApplication(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loanApplicationService.DeleteLoanApplication(id);
        }

        //[Authorize(Roles = "User")]
        //[HttpPost]
        //public void Post([FromBody] LoanApplication loanApplication)
        //{
        //    _loanApplicationService.AddLoanApplication(loanApplication);
        //}



        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                // Call the service method to update the loan application by id
                _loanApplicationService.UpdateLoan(id);

                // Return NoContent to indicate the update was successful with no content in the response
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // If the loan application is not found, return a 404 Not Found response
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Return a generic 500 Internal Server Error for any other exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }






    }
}
