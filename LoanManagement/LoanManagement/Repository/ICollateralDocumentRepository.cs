using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Repository
{
    public interface ICollateralDocumentRepository
    {
        public Task AddCollateralDTO(CollateralDocumentDTO collateralDocument);
        public CollateralDocument FindByLoanApplicationId(int loanApplicationId);
    }
}
