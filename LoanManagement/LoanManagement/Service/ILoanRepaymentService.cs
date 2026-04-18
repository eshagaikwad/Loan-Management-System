using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Service
{
    public interface ILoanRepaymentService
    {
        public void CreateLoanRepayment(int loanApplicationId);
        public void MakeLoanEMIPayment(int applicationId, double paymentAmount);

        public void MakeLoanVariablePayment(int applicationId, double paymentAmount);
        public LoanRepayment FindRepayment(int id);




        //public void CreateLoanRepayment(int loanApplicationId);
        // public void PayLoanRepayment(int repaymentId, [FromBody] double paymentAmount);
        //public void MakeLoanRepayment(LoanRepaymentDTO loanRepayment);
        //public Task<List<LoanRepayment>> GetLoanRepaymentHistory(int id);
        //public void AddLoanRepayment(LoanRepayment loanRepayment);
        //public List<LoanRepayment> DisplayLoanRepayment();
        //public LoanRepayment FindLoanRepayment(int id);
        //public void UpdateLoanRepayment(LoanRepayment loanRepayment);
        //public void DeleteLoanRepayment(int id);
    }
}
