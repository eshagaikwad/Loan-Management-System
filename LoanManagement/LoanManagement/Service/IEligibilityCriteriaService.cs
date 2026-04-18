using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface IEligibilityCriteriaService
    {
        public void AddEligibilityCriteria(EligibilityCriteria eligibilityCriteria);
        public List<EligibilityCriteria> DisplayEligibilityCriteria();
        public EligibilityCriteria FindEligibilityCriteria(int id);
        public void UpdateEligibilityCriteria(EligibilityCriteria eligibilityCriteria);
        public void DeleteEligibilityCriteria(int id);
    }
}
