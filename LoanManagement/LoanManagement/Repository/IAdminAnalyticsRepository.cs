using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface IAdminAnalyticsRepository
    {
        public void Add(AdminAnalytics adminAnalytics);
        public List<AdminAnalytics> Display();
        public AdminAnalytics Find(int id);
        public void Update(AdminAnalytics adminAnalytics);
        public void Delete(int id);
    }
}
