using System;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LoanManagementSystem.Service
{
    public class LoanRepaymentService : ILoanRepaymentService
    {
        private readonly ILoanRepaymentRepository _loanRepaymentRepository;

        public LoanRepaymentService(ILoanRepaymentRepository loanRepaymentRepository)
        {
            _loanRepaymentRepository = loanRepaymentRepository;
        }


        public void CreateLoanRepayment(int loanApplicationId)
        {
            _loanRepaymentRepository.CreateRepayment(loanApplicationId);
        }
        public void MakeLoanEMIPayment(int applicationId, double paymentAmount)
        {
            _loanRepaymentRepository.MakeEMIPayment(applicationId, paymentAmount);
        }

        public void MakeLoanVariablePayment(int applicationId, double paymentAmount)
        {
            _loanRepaymentRepository.MakeVariablePayment(applicationId, paymentAmount);
        }
        public LoanRepayment FindRepayment(int id)
        {
            return _loanRepaymentRepository.Find(id);
        }





    }
}
