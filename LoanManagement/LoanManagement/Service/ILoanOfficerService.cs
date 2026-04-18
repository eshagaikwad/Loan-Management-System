using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Service
{
    public interface ILoanOfficerService
    {
        public void AddOfficerrDTO(LoanOfficerDTO dto);
        public List<LoanOfficer> DisplayLoanOfficer();
        public LoanOfficer FindLoanOfficer(int id);
        public void UpdateLoanOfficer(LoanOfficer loanOfficer);
        public void DeleteLoanOfficer(int id);
        public void AddOfficerDTO(LoanOfficerDTO loanOfficerDTO);
        public Task UpdateOfficerDTO(int id, LoanOfficerDTO loanOfficerDTO);
    }
}
