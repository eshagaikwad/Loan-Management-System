using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class EligibilityCriteriaService : IEligibilityCriteriaService
    {
        private readonly IEligibilityCriteriaRepository _eligibilityCriteriaRepository;

        public EligibilityCriteriaService(IEligibilityCriteriaRepository eligibilityCriteriaRepository)
        {
            _eligibilityCriteriaRepository = eligibilityCriteriaRepository;
        }
        public void AddEligibilityCriteria(EligibilityCriteria eligibilityCriteria)
        {
            _eligibilityCriteriaRepository.Add(eligibilityCriteria);
        }
        public List<EligibilityCriteria> DisplayEligibilityCriteria()
        {
            return _eligibilityCriteriaRepository.Display();
        }
        public EligibilityCriteria FindEligibilityCriteria(int id)
        {
            return _eligibilityCriteriaRepository.Find(id);
        }
        public void UpdateEligibilityCriteria(EligibilityCriteria eligibilityCriteria)
        {
            _eligibilityCriteriaRepository.Update(eligibilityCriteria);
        }
        public void DeleteEligibilityCriteria(int id)
        {
            _eligibilityCriteriaRepository.Delete(id);
        }
    }
}
