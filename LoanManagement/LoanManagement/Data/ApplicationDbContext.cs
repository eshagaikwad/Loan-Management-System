
using LoanManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set; }
        public DbSet<LoanScheme> LoanSchemes { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanRepayment> LoanRepayments { get; set; }
        public DbSet<AdminAnalytics> AdminAnalytics { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<EligibilityCriteria> EligibilityCriterias { get; set; }
        public DbSet<CollateralDocument> CollateralDocuments { get; set; }
        public DbSet<RepaymentHistory> RepaymentHistories { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
