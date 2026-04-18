using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoanOfficerController : ControllerBase
    {
        private readonly ILoanOfficerService _loanOfficerService;

        public LoanOfficerController(ILoanOfficerService loanOfficerService)
        {
            _loanOfficerService = loanOfficerService;
        }

        [HttpGet]
        public List<LoanOfficer> Get()
        {
            return _loanOfficerService.DisplayLoanOfficer();
        }
        
        [HttpGet("{id}")]
        public LoanOfficer Get(int id)
        {
            return _loanOfficerService.FindLoanOfficer(id);
        }


        [HttpPost]
        public void Post([FromBody] LoanOfficerDTO loanOfficerDTO)
        {
            _loanOfficerService.AddOfficerrDTO(loanOfficerDTO);
        }


        [HttpPut("DTO{id}")]
        public async Task<IActionResult> PutDTO(int id, [FromForm] LoanOfficerDTO loanOfficerDTO)
        {
            try
            {
                await _loanOfficerService.UpdateOfficerDTO(id, loanOfficerDTO);
                return Ok("Loan application updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loanOfficerService.DeleteLoanOfficer(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message); 
            }
        }
    }
}
