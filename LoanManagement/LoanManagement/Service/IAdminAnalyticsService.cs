using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface IAdminAnalyticsService
    {
        public void AddAdminAnalytics(AdminAnalytics adminAnalytics);
        public List<AdminAnalytics> DisplayAdminAnalytics();
        public AdminAnalytics FindAdminAnalytics(int id);
        public void UpdateAdminAnalytics(AdminAnalytics adminAnalytics);
        public void DeleteAdminAnalytics(int id);
    }
}
