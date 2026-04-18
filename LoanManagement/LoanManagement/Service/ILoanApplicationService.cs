using LoanManagement.DTO;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface ILoanApplicationService
    {
        public void AddLoanApplication(LoanApplication loanApplication);
        public Task<(IEnumerable<LoanApplication>, int totalCount)> DisplayApplications(int pageNumber, int pageSize);
        public LoanApplication FindLoanApplication(int id);
        public void UpdateLoanApplication(LoanApplication loanApplication);
        public void DeleteLoanApplication(int id);
        public Task AddLoanDTO(LoanApplicationDTO loanApplicationDto);
        public Task UpdateLoanDTO(int id,LoanApplicationDTO loanApplicationDto);
        public void UpdateLoan(int id);
    }
}
