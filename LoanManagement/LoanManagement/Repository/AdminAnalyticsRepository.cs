using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class AdminAnalyticsRepository : IAdminAnalyticsRepository
    {
        private ApplicationDbContext _dbContext;

        public AdminAnalyticsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(AdminAnalytics adminAnalytics)
        {
            _dbContext.AdminAnalytics.Add(adminAnalytics);
            _dbContext.SaveChanges();
        }
        public List<AdminAnalytics> Display()
        {
            return _dbContext.AdminAnalytics.ToList();
        }
        public AdminAnalytics Find(int id)
        {
            return _dbContext.AdminAnalytics.Find(id);
        }
        public void Update(AdminAnalytics adminAnalytics)
        {
            var existingAnalytics = _dbContext.AdminAnalytics.Find(adminAnalytics.AnalyticsId);
            if (existingAnalytics != null)
            {
                // Update the existingAnalytics properties with the new values
                existingAnalytics.ApplicationsCount = adminAnalytics.ApplicationsCount;
                existingAnalytics.ApprovedLoansCount = adminAnalytics.ApprovedLoansCount;
                existingAnalytics.RejectedLoansCount = adminAnalytics.RejectedLoansCount;
                existingAnalytics.TotalLoanAmount = adminAnalytics.TotalLoanAmount;
                existingAnalytics.TotalRepaymentCollected = adminAnalytics.TotalRepaymentCollected;
                existingAnalytics.ReportDate = adminAnalytics.ReportDate;
                existingAnalytics.LoanSchemeId = adminAnalytics.LoanSchemeId;

                // Save changes to the database
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Analytics record not found.");
            }
        }

        public void Delete(int id)
        {
            AdminAnalytics adminAnalytics = _dbContext.AdminAnalytics.Find(id);
            _dbContext.AdminAnalytics.Remove(adminAnalytics);
            _dbContext.SaveChanges();
        }
    }
}
