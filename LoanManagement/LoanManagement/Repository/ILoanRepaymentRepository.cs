using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Repository
{
    public interface ILoanRepaymentRepository
    {
        public void CreateRepayment(int loanApplicationId);
        public void MakeEMIPayment(int applicationId, double paymentAmount);

        public void MakeVariablePayment(int applicationId, double paymentAmount);
        public LoanRepayment Find(int id);


        //public void PayRepayment(int repaymentId, [FromBody] double paymentAmount);
        //public void MakeRepayment(LoanRepaymentDTO loanRepayment);
        //public Task<List<LoanRepayment>> GetRepaymentHistory(int id);
        //public void Add(LoanRepayment loanRepayment);
        //public List<LoanRepayment> Display();
        //public LoanRepayment Find(int id);
        //public void Update(LoanRepayment loanRepayment);
        //public void Delete(int id);
    }
}
