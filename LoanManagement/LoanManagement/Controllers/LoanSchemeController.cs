using LoanManagement.Data;
using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoanSchemeController : ControllerBase
    {
        private readonly ILoanSchemeService _loanSchemeService;
        private readonly ApplicationDbContext _applicationDbContext;

        public LoanSchemeController(ILoanSchemeService loanSchemeService,ApplicationDbContext applicationDbContext)
        {
            _loanSchemeService = loanSchemeService;
            _applicationDbContext = applicationDbContext;
        }

        //[Authorize(Roles = "User")]



        [HttpGet]
        public async Task<List<LoanScheme>> Get( )
        {
            return await _applicationDbContext.LoanSchemes
                // Take the number of records for the current page
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public LoanScheme Get(int id)
        {
            return _loanSchemeService.FindLoanScheme(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] LoanScheme loanScheme)
        {
            _loanSchemeService.AddLoanScheme(loanScheme);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put([FromBody] LoanScheme loanScheme)
        {
            _loanSchemeService.UpdateLoanScheme(loanScheme);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loanSchemeService.DeleteLoanScheme(id);
        }
    }
}
