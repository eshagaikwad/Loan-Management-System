using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface ILoanSchemeRepository
    {
        public void Add(LoanScheme loanScheme);
        public List<LoanScheme> Display();
        public LoanScheme Find(int id);
        public void Update(LoanScheme loanScheme);
        public void Delete(int id);
    }
}
