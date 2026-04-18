using LoanManagement.DTO;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;

        public LoanApplicationService(ILoanApplicationRepository loanApplicationRepository)
        {
            _loanApplicationRepository = loanApplicationRepository;
        }
        public void AddLoanApplication(LoanApplication loanApplication)
        {
            _loanApplicationRepository.Add(loanApplication);
        }
        public Task<(IEnumerable<LoanApplication>, int totalCount)> DisplayApplications(int pageNumber, int pageSize)
        {
            return _loanApplicationRepository.Display(pageNumber, pageSize);
        }
        public LoanApplication FindLoanApplication(int id)
        {
            return _loanApplicationRepository.Find(id);
        }
        public void UpdateLoanApplication(LoanApplication loanApplication)
        {
            _loanApplicationRepository.Update(loanApplication);
        }
        public void DeleteLoanApplication(int id)
        {
            _loanApplicationRepository.Delete(id);
        }

        public void UpdateLoan(int id)
        {

            _loanApplicationRepository.Update(id);
}

        public async Task AddLoanDTO(LoanApplicationDTO loanApplicationDto)
        {
            await _loanApplicationRepository.AddDTO(loanApplicationDto);
        }

        public async Task UpdateLoanDTO(int id, LoanApplicationDTO loanApplicationDto)
        {
            await _loanApplicationRepository.UpdateDTO(id,loanApplicationDto);
        }




    }
}
