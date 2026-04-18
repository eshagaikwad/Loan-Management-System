using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public class EligibilityCriteriaRepository : IEligibilityCriteriaRepository
    {
        private ApplicationDbContext _dbContext;

        public EligibilityCriteriaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(EligibilityCriteria eligibilityCriteria)
        {
            _dbContext.EligibilityCriterias.Add(eligibilityCriteria);
            _dbContext.SaveChanges();
        }
        public List<EligibilityCriteria> Display()
        {
            return _dbContext.EligibilityCriterias.ToList();
        }
        public EligibilityCriteria Find(int id)
        {
            return _dbContext.EligibilityCriterias.Find(id);
        }
        public void Update(EligibilityCriteria eligibilityCriteria)
        {
            var existingCriteria = _dbContext.EligibilityCriterias.Find(eligibilityCriteria.EligibilityCriteriaId);
            if (existingCriteria != null)
            {
                // Update the fields with the new values from eligibilityCriteriaRepository
                existingCriteria.MinimumIncome = eligibilityCriteria.MinimumIncome;
                existingCriteria.MinimumAge = eligibilityCriteria.MinimumAge;
                existingCriteria.MaximumAge = eligibilityCriteria.MaximumAge;
                existingCriteria.MinimumCreditScore = eligibilityCriteria.MinimumCreditScore;
                existingCriteria.EmploymentYears = eligibilityCriteria.EmploymentYears;
                existingCriteria.Documents = eligibilityCriteria.Documents;

                // Save changes to the database
                _dbContext.EligibilityCriterias.Update(existingCriteria);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Eligibility Criteria not found");
            }
        }

        public void Delete(int id)
        {
            EligibilityCriteria eligibilityCriteria = _dbContext.EligibilityCriterias.Find(id);
            _dbContext.EligibilityCriterias.Remove(eligibilityCriteria);
            _dbContext.SaveChanges();
        }
    }
}
