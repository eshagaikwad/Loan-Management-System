using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EligibilityCriteriaController : ControllerBase
    {
        private readonly IEligibilityCriteriaService _eligibilityCriteriaService;

        public EligibilityCriteriaController(IEligibilityCriteriaService eligibilityCriteriaService)
        {
            _eligibilityCriteriaService = eligibilityCriteriaService;
        }


        //[Authorize(Roles = "User")]
        [HttpGet]
        public List<EligibilityCriteria> Get()
        {
            return _eligibilityCriteriaService.DisplayEligibilityCriteria();
        }

        [HttpGet("{id}")]
        public EligibilityCriteria Get(int id)
        {
            return _eligibilityCriteriaService.FindEligibilityCriteria(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] EligibilityCriteria eligibilityCriteria)
        {
            _eligibilityCriteriaService.AddEligibilityCriteria(eligibilityCriteria);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put([FromBody] EligibilityCriteria eligibilityCriteria)
        {
            _eligibilityCriteriaService.UpdateEligibilityCriteria(eligibilityCriteria);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _eligibilityCriteriaService.DeleteEligibilityCriteria(id);
        }
    }
}
