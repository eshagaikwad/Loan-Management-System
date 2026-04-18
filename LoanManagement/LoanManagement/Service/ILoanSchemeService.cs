using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface ILoanSchemeService
    {
        public void AddLoanScheme(LoanScheme loanScheme);
        public List<LoanScheme> DisplayLoanScheme();
        public LoanScheme FindLoanScheme(int id);
        public void UpdateLoanScheme(LoanScheme loanScheme);
        public void DeleteLoanScheme(int id);
    }
}
