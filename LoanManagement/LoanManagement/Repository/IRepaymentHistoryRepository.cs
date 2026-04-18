using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface IRepaymentHistoryRepository
    {
        public List<RepaymentHistory> Display();
        public List<RepaymentHistory> Find(int id);   
    }
}
