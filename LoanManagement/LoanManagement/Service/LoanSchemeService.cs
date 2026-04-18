using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class LoanSchemeService : ILoanSchemeService
    {
        private readonly ILoanSchemeRepository _loanSchemeRepository;

        public LoanSchemeService(ILoanSchemeRepository loanSchemeRepository)
        {
            _loanSchemeRepository = loanSchemeRepository;
        }
        public void AddLoanScheme(LoanScheme loanScheme)
        {
            _loanSchemeRepository.Add(loanScheme);
        }
        public List<LoanScheme> DisplayLoanScheme()
        {
            return _loanSchemeRepository.Display();
        }
        public LoanScheme FindLoanScheme(int id)
        {
            return _loanSchemeRepository.Find(id);
        }
        public void UpdateLoanScheme(LoanScheme loanScheme)
        {
            _loanSchemeRepository.Update(loanScheme);
        }
        public void DeleteLoanScheme(int id)
        {
            _loanSchemeRepository.Delete(id);
        }
    }
}
