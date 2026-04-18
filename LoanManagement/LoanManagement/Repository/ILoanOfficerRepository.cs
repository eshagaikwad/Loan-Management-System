using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public interface ILoanOfficerRepository
    {
        public void AddDTO(LoanOfficerDTO dto);
        public List<LoanOfficer> Display();
        public LoanOfficer Find(int id);
        public void Update(LoanOfficer loanOfficer);
        public void Delete(int id);
        public Task AddDTOAsync(LoanOfficerDTO loanOfficerDTO);
        public Task UpdateDTO(int id, LoanOfficerDTO loanOfficerDTO);
    }
}
