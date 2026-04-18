using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentHistoryController : ControllerBase
    {
        private readonly IRepaymentHistoryService _repaymentHistoryService;

        public RepaymentHistoryController(IRepaymentHistoryService repaymentHistoryService)
        {
            _repaymentHistoryService = repaymentHistoryService;
        }
        // GET: api/<RepaymentHistoryController>
        [HttpGet]
        public List<RepaymentHistory> Get()
        {
            return _repaymentHistoryService.DisplayHistory();
        }

        // GET api/<RepaymentHistoryController>/5
        [HttpGet("{id}")]
        public List<RepaymentHistory> Get(int id )
        {
            var history = _repaymentHistoryService.FindHistory(id);
            return history;

        
        }

       
        //// POST api/<RepaymentHistoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RepaymentHistoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RepaymentHistoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
