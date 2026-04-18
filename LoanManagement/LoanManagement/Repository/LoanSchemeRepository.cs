using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public class LoanSchemeRepository : ILoanSchemeRepository
    {
        private ApplicationDbContext _dbContext;

        public LoanSchemeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(LoanScheme loanScheme)
        {
            _dbContext.LoanSchemes.Add(loanScheme);
            _dbContext.SaveChanges();
        }
        public List<LoanScheme> Display()
        {
            return _dbContext.LoanSchemes.ToList();
        }
        public LoanScheme Find(int id)
        {
            return _dbContext.LoanSchemes.Find(id);
        }
        public void Update(LoanScheme loanScheme)
        {
            var existingLoanScheme = _dbContext.LoanSchemes.Find(loanScheme.LoanSchemeId);
            if (existingLoanScheme != null)
            {
                // Update the existingLoanScheme properties with the new values
                existingLoanScheme.LoanSchemeName = loanScheme.LoanSchemeName;
                existingLoanScheme.LoanType = loanScheme.LoanType;
                existingLoanScheme.MaxAmount = loanScheme.MaxAmount;
                existingLoanScheme.InterestRate = loanScheme.InterestRate;
                existingLoanScheme.Tenure = loanScheme.Tenure;

                // Save changes to the database
                _dbContext.LoanSchemes.Update(existingLoanScheme);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Loan scheme not found.");
            }
        }

        public void Delete(int id)

        {
            
            LoanScheme loanScheme = _dbContext.LoanSchemes.Find(id);
            loanScheme.isActive=false;
            _dbContext.SaveChanges();
        }
    }
}
