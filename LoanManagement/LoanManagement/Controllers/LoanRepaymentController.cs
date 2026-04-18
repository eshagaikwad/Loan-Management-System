using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanRepaymentController : ControllerBase
    {
        private readonly ILoanRepaymentService _loanRepaymentService;

        public LoanRepaymentController(ILoanRepaymentService loanRepaymentService)
        {
            _loanRepaymentService = loanRepaymentService;
        }

        //[Authorize(Roles = "LoanOfficer")]
        //[HttpGet("Get")]
        //public Task<List<LoanRepayment>> GetRepaymwnt(int id)
        //{
        //    return _loanRepaymentService.GetLoanRepaymentHistory(id);
        //}

        //[Authorize(Roles = "User")]
        [HttpPost("createRepayment")]
        public IActionResult PostRepayment(int applicationId)  // Corrected parameter name
        {
            Console.WriteLine(applicationId);
            _loanRepaymentService.CreateLoanRepayment(applicationId);
            return Ok(applicationId);
        }

        [HttpPost("PayEMI")]
        public void PostEMI(int loanRepaymentId, double paymentAmount)
        {
            _loanRepaymentService.MakeLoanEMIPayment(loanRepaymentId,paymentAmount);
        }

        [HttpPost("PayVariable")]
        public void PostVariable(int loanRepaymentId, double paymentAmount)
        {
            _loanRepaymentService.MakeLoanVariablePayment(loanRepaymentId, paymentAmount);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var repayment = _loanRepaymentService.FindRepayment(id);
            if (repayment == null)
            {
                return NotFound(); // Return 404 if repayment not found
            }
            return Ok(repayment); // Return 200 with the repayment details
        }









        //[HttpPost("loanApplicationId")]
        //public void PostRepayment(int id)
        //{
        //    _loanRepaymentService.CreateLoanRepayment(id);
        //}


        //[HttpGet]
        //public List<LoanRepayment> Get()
        //{
        //    return _loanRepaymentService.DisplayLoanRepayment();
        //}

        //[HttpGet("{id}")]
        //public LoanRepayment Get(int id)
        //{
        //    return _loanRepaymentService.FindLoanRepayment(id);
        //}

        //[Authorize(Roles = "User")]
        //[HttpPost]
        //public void Post([FromBody] LoanRepayment loanRepayment)
        //{
        //    _loanRepaymentService.AddLoanRepayment(loanRepayment);
        //}

        //[HttpPut("{id}")]
        //public void Put([FromBody] LoanRepayment loanRepayment)
        //{
        //    _loanRepaymentService.UpdateLoanRepayment(loanRepayment);
        //}


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _loanRepaymentService.DeleteLoanRepayment(id);
        //}
    }
}
