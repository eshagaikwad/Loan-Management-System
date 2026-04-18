using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class LoanOfficerService : ILoanOfficerService
    {
        private readonly ILoanOfficerRepository _loanOfficerRepository;

        public LoanOfficerService(ILoanOfficerRepository loanOfficerRepository)
        {
            _loanOfficerRepository = loanOfficerRepository;
        }
        public void AddOfficerrDTO(LoanOfficerDTO dto)

        {

            _loanOfficerRepository.AddDTO(dto);

        }

        public List<LoanOfficer> DisplayLoanOfficer()
        {
           return _loanOfficerRepository.Display();
        }
        public LoanOfficer FindLoanOfficer(int id)
        {
            return _loanOfficerRepository.Find(id);
        }
        public void UpdateLoanOfficer(LoanOfficer loanOfficer)
        {
            _loanOfficerRepository.Update(loanOfficer);
        }
        public void DeleteLoanOfficer(int id)
        {
            _loanOfficerRepository.Delete(id);
        }
        public void AddOfficerDTO(LoanOfficerDTO loanOfficerDTO)
        {
            _loanOfficerRepository.AddDTOAsync(loanOfficerDTO);
        }
        public async Task UpdateOfficerDTO(int id, LoanOfficerDTO loanOfficerDTO)
        {
            await _loanOfficerRepository.UpdateDTO(id, loanOfficerDTO);
        }
    }
}
