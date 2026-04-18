using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface IRepaymentHistoryService
    {
        public List<RepaymentHistory> DisplayHistory();
        public List<RepaymentHistory> FindHistory(int id);
    }
}
