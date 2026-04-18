using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class RepaymentHistoryRepository : IRepaymentHistoryRepository
    {
        private ApplicationDbContext _dbContext;

        public RepaymentHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<RepaymentHistory> Display()
        {
            return _dbContext.RepaymentHistories.ToList();
        }
        public List<RepaymentHistory> Find(int id)
        {
            return _dbContext.RepaymentHistories
                             .Where(x => x.LoanRepaymentId == id)
                                              // Take the required number of records
                             .ToList();
        }


    }
}
