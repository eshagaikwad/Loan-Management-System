using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class RepaymentHistoryService : IRepaymentHistoryService
    {
        private readonly IRepaymentHistoryRepository _repaymentHistoryRepository;

        public RepaymentHistoryService(IRepaymentHistoryRepository repaymentHistoryRepository)
        {
            _repaymentHistoryRepository = repaymentHistoryRepository;
        }
        public List<RepaymentHistory> DisplayHistory()
        {
            return _repaymentHistoryRepository.Display();
        }
        public List<RepaymentHistory> FindHistory(int id)
        {
           return _repaymentHistoryRepository.Find(id);
        }
    }
}
