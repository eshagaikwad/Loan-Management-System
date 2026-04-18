using System.Linq;
using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class LoanRepaymentRepository : ILoanRepaymentRepository
    {
        private ApplicationDbContext _dbContext;

        public LoanRepaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public LoanRepayment Find(int id)
        {
         return _dbContext.LoanRepayments.Include(x=>x.RepaymentHistory).SingleOrDefault(x => x.LoanApplicationId == id);
        }


        public void CreateRepayment(int loanApplicationId)
        {
            // Find the loan application
            var loanApplication = _dbContext.LoanApplications
                                            .FirstOrDefault(la => la.LoanApplicationId == loanApplicationId);

            if (loanApplication == null)
            {
                Console.WriteLine("Loan Application not found.");
                return; // Exit method if loan application is not found
            }

            // Find the loan scheme associated with the loan application
            var loanScheme = _dbContext.LoanSchemes
                                       .FirstOrDefault(ls => ls.LoanSchemeId == loanApplication.LoanSchemeId);

            if (loanScheme == null)
            {
                Console.WriteLine("Loan Scheme not found.");
                return; // Exit method if loan scheme is not found
            }

            // Calculate the total amount to be paid based on the rate of interest and tenure
            double principalAmount = loanApplication.LoanAmount; // Loan amount (principal)
            double rateOfInterest = loanScheme.InterestRate;     // Interest rate (annual percentage)
            var tenureMonths = loanScheme.Tenure;             // Tenure in months

            // Calculate interest for the tenure period (assuming interest is applied annually)
            double interestAmount = principalAmount * rateOfInterest / 100 * tenureMonths / 12;
            double totalAmountToBePaid = principalAmount + interestAmount; // Principal + interest

            // Define the due date and number of installments based on tenure
            DateTime firstDueDate = DateTime.Now.AddMonths(1); // First due date is in the next month
            int noOfInstallments = tenureMonths;               // Number of installments equals loan tenure

            // Create the first repayment object for the loan repayment table
            var repayment = new LoanRepayment
            {
                LoanApplicationId = loanApplication.LoanApplicationId, // Link to loan application
                TotalLoanAmount = totalAmountToBePaid,
               // PrincipalPaid = 0, // No principal paid initially
               PrincipalAmount = principalAmount,
               InterestAmount = interestAmount,
                EMIAmount = totalAmountToBePaid / noOfInstallments, // EMI for first installment
                DueDate = firstDueDate,  // Set the first due date
                NoOfInstallments = noOfInstallments,  // Total number of installments
                LastPaid = null,  // No payment yet
                IsNPA = false,    // Not a non-performing asset at the start
               // PaymentDate = null, // Payment date will be updated once the user makes a payment
                PaymentStatus = "Pending" // Initial status is pending
            };

            // Add the repayment record to the database
            _dbContext.LoanRepayments.Add(repayment);
            _dbContext.SaveChanges();

            Console.WriteLine("Repayment record created successfully!");
        }


        //public void MakeEMIPayment(int loanRepaymentId, double paymentAmount)
        //{
        //    // Find the loan repayment record
        //    var repayment = _dbContext.LoanRepayments
        //            .FirstOrDefault(r => r.LoanApplicationId == loanRepaymentId);

        //    if (repayment == null)
        //    {
        //        Console.WriteLine("Loan Repayment record not found.");
        //        return;
        //    }

        //    if (repayment.PaymentStatus == "Completed")
        //    {
        //        Console.WriteLine("EMI already paid for this installment.");
        //        return;
        //    }

        //    // Calculate the interest due for the current installment
        //    double monthlyInterestRate = repayment.InterestAmount / repayment.NoOfInstallments;

        //    // Calculate how much of the payment goes towards interest
        //    double interestPaidAmount = Math.Min(paymentAmount, monthlyInterestRate);

        //    // Remaining amount goes to the principal
        //    double principalPaidAmount = paymentAmount - interestPaidAmount;

        //    // Update the LoanRepayment record
        //    repayment.PrincipalPaid += principalPaidAmount; // Add to total principal paid
        //    repayment.InterestAmount -= interestPaidAmount; // Deduct from interest owed
        //    repayment.LastPaid = DateTime.Now; // Update last paid date

        //    // Check if the repayment is fully paid
        //    if (repayment.PrincipalAmount >= repayment.PrincipalAmount)
        //    {
        //        repayment.PaymentStatus = "Completed"; // Mark as completed when fully paid
        //    }
        //    else
        //    {
        //        repayment.PaymentStatus = "Partial"; // Mark as partial if not fully paid
        //    }

        //    // Update the database with the payment information
        //    _dbContext.LoanRepayments.Update(repayment);
        //    _dbContext.SaveChanges();

        //    // Display the payment summary to the user
        //    Console.WriteLine($"EMI Payment Successful!");
        //    Console.WriteLine($"Principal Paid: {principalPaidAmount:C}");
        //    Console.WriteLine($"Interest Paid: {interestPaidAmount:C}");
        //    Console.WriteLine($"Total Paid: {paymentAmount:C}");
        //  //  Console.WriteLine($"Remaining Principal: {(repayment.PrincipalAmount - repayment.principalPaidAmount):C}");
        //    Console.WriteLine($"Remaining Interest: {repayment.InterestAmount:C}");
        //}
        public void MakeEMIPayment(int applicationId, double paymentAmount)
        {
            // Find the loan repayment record by LoanRepaymentId
            var repayment = _dbContext.LoanRepayments
                .FirstOrDefault(r => r.LoanApplicationId == applicationId); // Use LoanRepaymentId

            if (repayment == null)
            {
                Console.WriteLine("Loan Repayment record not found.");
                return;
            }

            //if (repayment.PaymentStatus == "Completed")
            //{
            //    Console.WriteLine("EMI already paid for this installment.");
            //    return;
            //}

            // Calculate the interest due for the current installment based on remaining principal
            double monthlyInterestRate = (repayment.PrincipalAmount - repayment.PrincipalPaid) * (repayment.NoOfInstallments / 100 / 12);

            // Calculate how much of the payment goes towards interest
            double interestPaidAmount = Math.Min(paymentAmount, monthlyInterestRate);

            // Remaining amount goes to the principal
            double principalPaidAmount = paymentAmount - interestPaidAmount;

            // Update the LoanRepayment record
            repayment.PrincipalPaid += principalPaidAmount; // Add to total principal paid
            repayment.InterestAmount -= interestPaidAmount; // Deduct from interest owed
            repayment.LastPaid = DateTime.Now; // Update last paid date

            // Check if the repayment is fully paid
            if (repayment.PrincipalPaid >= repayment.TotalLoanAmount)
            {
                repayment.PaymentStatus = "Completed"; // Mark as completed when fully paid
            }
            else
            {
                repayment.PaymentStatus = "Partial"; // Mark as partial if not fully paid
            }
            var paymentHistory = new RepaymentHistory
            {
                LoanRepaymentId = repayment.LoanRepaymentId, // Link to the loan repayment record
                AmountPaid = paymentAmount,
                PaymentDate = DateTime.Now,
            };

            // Add the payment history record to the database
            _dbContext.RepaymentHistories.Add(paymentHistory);

            // Update the database with the payment information
            _dbContext.LoanRepayments.Update(repayment);
            _dbContext.SaveChanges();

            // Display the payment summary to the user
            Console.WriteLine($"EMI Payment Successful!");
            Console.WriteLine($"Principal Paid: {principalPaidAmount:C}");
            Console.WriteLine($"Interest Paid: {interestPaidAmount:C}");
            Console.WriteLine($"Total Paid: {paymentAmount:C}");
            Console.WriteLine($"Remaining Principal: {(repayment.PrincipalAmount - repayment.PrincipalPaid):C}");
            Console.WriteLine($"Remaining Interest: {repayment.InterestAmount:C}");
        }



        public void MakeVariablePayment(int applicationId, double paymentAmount)
        {
            // Find the loan repayment record
            var repayment = _dbContext.LoanRepayments
                                      .FirstOrDefault(r => r.LoanApplicationId == applicationId);

            if (repayment == null)
            {
                Console.WriteLine("Loan Repayment record not found.");
                return;
            }

            //if (repayment.PrincipalPaid >= repayment.PrincipalAmount)
            //{
            //    Console.WriteLine("This loan has already been paid off.");
            //    return;
            //}


            // Check if the payment is valid
            if (paymentAmount <= 0)
            {
                Console.WriteLine("Invalid payment amount.");
                return;
            }

            // Calculate how much of the payment goes toward the principal
            double principalPaidAmount = paymentAmount; // All payment reduces the principal
            double remainingPrincipal = repayment.PrincipalAmount - repayment.PrincipalPaid; // Update remaining principal calculation

            if (principalPaidAmount > remainingPrincipal)
            {
                Console.WriteLine("Payment exceeds the remaining principal.");
                return;
            }

            // Update the LoanRepayment record
            repayment.PrincipalPaid += principalPaidAmount; // Increment the PrincipalPaid
            repayment.LastPaid = DateTime.Now; // Update last paid date

         
            if (repayment.PrincipalPaid >= repayment.TotalLoanAmount)
            {
                repayment.PaymentStatus = "Completed"; // Mark as completed when fully paid
            }
            else
            {
                repayment.PaymentStatus = "Partial"; // Mark as partial if not fully paid
            }
            var paymentHistory = new RepaymentHistory
            {
                LoanRepaymentId = repayment.LoanRepaymentId, // Link to the loan repayment record
                AmountPaid = paymentAmount,
                PaymentDate = DateTime.Now,

            };

            // Add the payment history record to the database
            _dbContext.RepaymentHistories.Add(paymentHistory);
            // Update the database with the payment information
            _dbContext.LoanRepayments.Update(repayment);
            _dbContext.SaveChanges();

            // Display the payment summary to the user
            Console.WriteLine("Variable Payment Successful!");
            Console.WriteLine($"Principal Paid: {principalPaidAmount:C}");
            Console.WriteLine($"Remaining Principal: {(repayment.PrincipalAmount - repayment.PrincipalPaid):C}");
            Console.WriteLine($"Remaining Interest: {repayment.InterestAmount:C}");
        }








        //    public void PayRepayment(int repaymentId, [FromBody] double paymentAmount)
        //    {
        //        // Find the repayment record
        //        var repayment = _dbContext.LoanRepayments
        //            .FirstOrDefault(r => r.LoanApplicationId == repaymentId);

        //        if (repayment == null)
        //        {
        //            Console.WriteLine("Repayment record not found.");
        //        }

        //        // Check if the payment is valid
        //        if (paymentAmount <= 0 || paymentAmount > repayment.PaymentAmount)
        //        {
        //            Console.WriteLine("Invalid payment amount.");
        //        }

        //        // Reduce the principal amount
        //        //repayment.PrincipalAmount -= (int)paymentAmount;

        //        // Update the AmountToBePaid based on the remaining principal
        //        repayment.PaymentAmount -= (int)paymentAmount;

        //        // Update the number of installments if applicable
        //        if (repayment.NoOfInstallments > 0)
        //        {
        //            repayment.NoOfInstallments--;
        //        }

        //        // Update the LastPaid date
        //        repayment.LastPaid = DateTime.Now;

        //        // Update the due date to the next month for the next installment
        //        repayment.DueDate = DateTime.Now.AddMonths(1);

        //        // Mark as NPA (Non-Performing Asset) if repayment is not made in time (optional)
        //        if (repayment.DueDate < DateTime.Now)
        //        {
        //            repayment.IsNPA = true;
        //        }

        //        // Check if the loan is fully repaid
        //        if (repayment.PrincipalPaid <= 0)
        //        {
        //            repayment.PrincipalPaid = 0; // Ensure no negative principal
        //            repayment.PaymentAmount = 0;
        //            repayment.NoOfInstallments = 0; // No more installments
        //            repayment.IsNPA = false; // Mark as fully paid
        //        }

        //        // Save changes to the database
        //        _dbContext.SaveChanges();

        //        Console.WriteLine("Payment successfull!");
        //    }
        //}















        //public void CreateRepayment(int loanApplicationId)
        //{
        //    // Find the loan application
        //    var loanApplication = _dbContext.LoanApplications.FirstOrDefault(la => la.LoanApplicationId == loanApplicationId);

        //    if (loanApplication == null)
        //    {
        //        Console.WriteLine("Loan Application not found.");
        //    }

        //    // Find the loan scheme associated with the loan application
        //    var loanScheme = _dbContext.LoanSchemes.FirstOrDefault(ls => ls.LoanSchemeId == loanApplication.LoanSchemeId);

        //    if (loanScheme == null)
        //    {
        //        Console.WriteLine("Loan Scheme not found.");
        //    }

        //    // Calculate the total amount to be paid based on the rate of interest and tenure
        //    var principalAmount = (int)loanApplication.LoanAmount;
        //    var rateOfInterest = loanScheme.InterestRate;
        //    var tenure = loanScheme.Tenure; // Assuming tenure is in months
        //    var interestAmount = principalAmount * rateOfInterest / 100 * tenure / 12;
        //    var amountToBePaid = principalAmount + interestAmount;

        //    // Define the due date and number of installments based on tenure
        //    DateTime dueDate = DateTime.Now.AddMonths(1); // First due date is next month
        //    int noOfInstallments = tenure;

        //    // Create the repayment object and set its attributes
        //    var repayment = new LoanRepayment
        //    {
        //        PrincipalPaid = principalAmount,
        //        PaymentAmount = (int)amountToBePaid,
        //        DueDate = dueDate,
        //        NoOfInstallments = noOfInstallments,
        //        LastPaid = DateTime.Now,  // Assuming the last paid date starts now
        //        IsNPA = false,  // Initially not an NPA
        //        LoanApplicationId = loanApplication.LoanApplicationId,
        //        PaymentDate = DateTime.Now,
        //        PaymentStatus = "pending"
        //    };

        //    // Add the repayment record to the database
        //    _dbContext.LoanRepayments.Add(repayment);
        //    _dbContext.SaveChanges();

        //    Console.WriteLine("Payment successfull!");
        //}



        //    public void PayRepayment(int repaymentId, [FromBody] double paymentAmount)
        //    {
        //        // Find the repayment record
        //        var repayment = _dbContext.LoanRepayments
        //            .FirstOrDefault(r => r.LoanApplicationId == repaymentId);

        //        if (repayment == null)
        //        {
        //            Console.WriteLine("Repayment record not found.");
        //        }

        //        // Check if the payment is valid
        //        if (paymentAmount <= 0 || paymentAmount > repayment.PaymentAmount)
        //        {
        //            Console.WriteLine("Invalid payment amount.");
        //        }

        //        // Reduce the principal amount
        //        //repayment.PrincipalAmount -= (int)paymentAmount;

        //        // Update the AmountToBePaid based on the remaining principal
        //        repayment.PaymentAmount -= (int)paymentAmount;

        //        // Update the number of installments if applicable
        //        if (repayment.NoOfInstallments > 0)
        //        {
        //            repayment.NoOfInstallments--;
        //        }

        //        // Update the LastPaid date
        //        repayment.LastPaid = DateTime.Now;

        //        // Update the due date to the next month for the next installment
        //        repayment.DueDate = DateTime.Now.AddMonths(1);

        //        // Mark as NPA (Non-Performing Asset) if repayment is not made in time (optional)
        //        if (repayment.DueDate < DateTime.Now)
        //        {
        //            repayment.IsNPA = true;
        //        }

        //        // Check if the loan is fully repaid
        //        if (repayment.PrincipalPaid <= 0)
        //        {
        //            repayment.PrincipalPaid = 0; // Ensure no negative principal
        //            repayment.PaymentAmount = 0;
        //            repayment.NoOfInstallments = 0; // No more installments
        //            repayment.IsNPA = false; // Mark as fully paid
        //        }

        //        // Save changes to the database
        //        _dbContext.SaveChanges();

        //        Console.WriteLine("Payment successfull!" );
        //    }
        //}

    }

}


