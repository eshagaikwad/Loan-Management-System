using Admin_UserJWTExample.Generate_Function;
using LoanManagement.Data;
using LoanManagement.DTO;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Admin_UserJWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly ApplicationDbContext dbContext;
        public readonly IUserService _userService;

        private static readonly HttpClient httpClient = new HttpClient();

        public AuthenticationController(IConfiguration configuration, ApplicationDbContext _dbContext, IUserService userService)
        {
            _configuration = configuration;
            dbContext = _dbContext;
            _userService = userService;
        }

        [HttpPost("Register")]
        public void Post([FromBody] UserDTO user)
        {
            _userService.AddUserDTO(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLoginDetails(LoginDTO user)
        {
            if (user != null)
            {
                var result = dbContext.Users.Where(t => t.UserName == user.UserName && 
                t.UserPassword == user.UserPassword)
                    .FirstOrDefault();
                if (result == null)                      //string.IsNullOrEmpty(result.Email) 
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    user.UserId = result.UserId;
                    user.UserRole = result.UserRole;
                    user.UserMessage = "Login Success";
                    user.AccessToken = GenerateToken.GetToken(user, _configuration);
                    return Ok(user);
                }
            }
            return BadRequest();
        }

        [HttpPost("loginLoanOfficer")]
        public async Task<IActionResult> PostLoginLoanOfficer(LoginOfficerDTO loanOfficer)
        {
            if (loanOfficer != null)
            {
                var result = dbContext.LoanOfficers
                    .Where(t => t.LoanOfficerName == loanOfficer.LoanOfficerName &&
                                t.LoanOfficerPassword == loanOfficer.LoanOfficerPassword)
                    .FirstOrDefault();

                if (result == null) // Invalid credentials
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    // Assign the LoanOfficerId from the result
                    loanOfficer.LoanOfficerId = result.LoanOfficerId;
                    loanOfficer.OfficerRole = result.OfficerRole;
                    loanOfficer.UserMessage = "Login Success";
                    loanOfficer.AccessToken = GenerateToken.GetTokenOfficer(loanOfficer, _configuration);

                    return Ok(loanOfficer);  // Return the loanOfficer with correct ID
                }
            }

            return BadRequest();
        }



    }
}
