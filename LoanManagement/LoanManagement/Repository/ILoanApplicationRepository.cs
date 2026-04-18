using LoanManagement.DTO;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface ILoanApplicationRepository
    {
        public void Add(LoanApplication loanApplication);
        public Task<(IEnumerable<LoanApplication>, int totalCount)> Display(int pageNumber, int pageSize);
        public List<LoanApplication> display();
        public LoanApplication Find(int id);
        public void Update(LoanApplication loanApplication);
        public void Delete(int id);
        public Task AddDTO(LoanApplicationDTO loanApplicationDto);
        public Task UpdateDTO(int id, LoanApplicationDTO loanApplicationDto);
        public void Update(int id);

        public void rejectUpdate(int id);



    }
}
