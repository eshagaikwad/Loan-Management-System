using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface IEligibilityCriteriaRepository
    {
        public void Add(EligibilityCriteria eligibilityCriteria);
        public List<EligibilityCriteria> Display();
        public EligibilityCriteria Find(int id);
        public void Update(EligibilityCriteria eligibilityCriteria);
        public void Delete(int id);
    }
}
