using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class AdminAnalyticsService : IAdminAnalyticsService
    {
        private readonly IAdminAnalyticsRepository _adminAnalyticsRepository;

        public AdminAnalyticsService(IAdminAnalyticsRepository adminAnalyticsRepository)
        {
            _adminAnalyticsRepository = adminAnalyticsRepository;
        }
        public void AddAdminAnalytics(AdminAnalytics adminAnalytics)
        {
            _adminAnalyticsRepository.Add(adminAnalytics);
        }
        public List<AdminAnalytics> DisplayAdminAnalytics()
        {
            return _adminAnalyticsRepository.Display();
        }
        public AdminAnalytics FindAdminAnalytics(int id)
        {
            return _adminAnalyticsRepository.Find(id);
        }
        public void UpdateAdminAnalytics(AdminAnalytics adminAnalytics)
        {
            _adminAnalyticsRepository.Update(adminAnalytics);
        }
        public void DeleteAdminAnalytics(int id)
        {
            _adminAnalyticsRepository.Delete(id);
        }
    }
}
