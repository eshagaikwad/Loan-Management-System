using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAnalyticsController : ControllerBase
    {
        private readonly IAdminAnalyticsService _adminAnalyticsService;

        public AdminAnalyticsController(IAdminAnalyticsService adminAnalyticsService)
        {
            _adminAnalyticsService = adminAnalyticsService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public List<AdminAnalytics> Get()
        {
            return _adminAnalyticsService.DisplayAdminAnalytics();
        }

        [HttpGet("{id}")]
        public AdminAnalytics Get(int id)
        {
            return _adminAnalyticsService.FindAdminAnalytics(id);
        }

        [Authorize(Roles = "LoanOfficer")]
        [HttpPost]
        public void Post([FromBody] AdminAnalytics adminAnalytics)
        {
            _adminAnalyticsService.AddAdminAnalytics(adminAnalytics);
        }

        [Authorize(Roles = "LoanOfficer")]
        [HttpPut("{id}")]
        public void Put([FromBody] AdminAnalytics adminAnalytics)
        {
            _adminAnalyticsService.UpdateAdminAnalytics(adminAnalytics);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _adminAnalyticsService.DeleteAdminAnalytics(id);
        }
    }
}
