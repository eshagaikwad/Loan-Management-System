using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
//using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;
using MimeKit;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using LoanManagement.Data;

namespace LoanManagementSystem.Repository
{
    public class LoanOfficerRepository : ILoanOfficerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanOfficerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddDTO(LoanOfficerDTO dto)
        {
            LoanOfficer loanOfficer = new LoanOfficer
            {
                LoanOfficerName = dto.LoanOfficerName,
                LoanOfficerEmail = dto.LoanOfficerEmail,
                LoanOfficerPassword = dto.LoanOfficerPassword,
                LoanOfficerPhone = dto.LoanOfficerPhone,
                OfficerRole = "LoanOfficer",
                RegisterationDate = DateTime.Now,
            };
            _dbContext.LoanOfficers.Add(loanOfficer);
            _dbContext.SaveChanges();
            SendLoanOfficerCredentialsMail(loanOfficer);
        }


        public async Task AddDTOAsync(LoanOfficerDTO loanOfficerDTO)
        {
            if (loanOfficerDTO == null)
            {
                throw new ArgumentNullException(nameof(loanOfficerDTO), "Loan officer data cannot be null");
            }

            try
            {
                LoanOfficer loanOfficer = new LoanOfficer
                {
                 
                    LoanOfficerName = loanOfficerDTO.LoanOfficerName,
                    LoanOfficerEmail = loanOfficerDTO.LoanOfficerEmail,
                    LoanOfficerPassword = loanOfficerDTO.LoanOfficerPassword,
                    LoanOfficerPhone = loanOfficerDTO.LoanOfficerPhone,
                    OfficerRole = "LoanOfficer",
                    isActive = loanOfficerDTO.isActive,
                    RegisterationDate = DateTime.Now
                };

                await SendLoanOfficerCredentialsMail(loanOfficer);

              await  _dbContext.LoanOfficers.AddAsync(loanOfficer);
                await _dbContext.SaveChangesAsync();

               
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving the User: " + ex.Message);
            }
        }
        private static async Task SendLoanOfficerCredentialsMail(LoanOfficer loanOfficer)
        {
            if (loanOfficer == null)
            {
                throw new ArgumentNullException(nameof(loanOfficer), "Loan officer is null.");
            }

            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("LoanHub", "cm.a.66.shweta.avhad@gmail.com"));
                email.To.Add(new MailboxAddress(loanOfficer.LoanOfficerName, loanOfficer.LoanOfficerEmail));
                email.Subject = "Welcome to LoanHub";

                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"Dear {loanOfficer.LoanOfficerName},<br><br>" +
                           "Welcome to the Loan Management System!<br><br>" +
                           "Your account has been successfully created by Admin.<br><br>" +
                           "Here are your login credentials:<br>" +
                           $"<strong>Username:</strong> {loanOfficer.LoanOfficerName}<br>" +
                           $"<strong>Password:</strong> {loanOfficer.LoanOfficerPassword}<br><br>" +
                           "If you have any questions, feel free to contact support.<br><br>" +
                           "Best regards,<br>LoanHub"
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("cm.a.66.shweta.avhad@gmail.com", "abwm vabm kcyt fxvg");

                    // Send email asynchronously
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }

                Console.WriteLine("Email sent successfully to loan officer.");
            }
            catch (ArgumentNullException argEx)
            {
                Console.WriteLine("Argument null exception: " + argEx.Message);
                throw;
            }
            catch (SmtpCommandException smtpEx)
            {
                Console.WriteLine($"SMTP Command Error: {smtpEx.Message}");
                Console.WriteLine($"StatusCode: {smtpEx.StatusCode}");
                throw;
            }
            catch (SmtpProtocolException protocolEx)
            {
                Console.WriteLine($"SMTP Protocol Error: {protocolEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                throw;
            }
        }





        public async Task UpdateDTO(int id, LoanOfficerDTO loanOfficerDTO)
        {
            var existingLoanOfficer = await _dbContext.LoanOfficers.FindAsync(id);

            if (existingLoanOfficer == null)
            {
                throw new KeyNotFoundException("Loan application not found.");
            }



            existingLoanOfficer.LoanOfficerName = loanOfficerDTO.LoanOfficerName;
            existingLoanOfficer.LoanOfficerEmail = loanOfficerDTO.LoanOfficerEmail;
            existingLoanOfficer.LoanOfficerPhone = loanOfficerDTO.LoanOfficerPhone;
            existingLoanOfficer.LoanOfficerPassword = loanOfficerDTO.LoanOfficerPassword;
            existingLoanOfficer.OfficerRole = "LoanOfficer";
            existingLoanOfficer.RegisterationDate = DateTime.Now;

                try
                {

                    _dbContext.LoanOfficers.Update(existingLoanOfficer);
                    await _dbContext.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error occurred while updating loan officer: " + ex.Message);
                }
        }


        public List<LoanOfficer> Display()
        {
            return _dbContext.LoanOfficers.ToList();
        }
        public LoanOfficer Find(int id)
        {
            return _dbContext.LoanOfficers.Find(id);
        }

        public void Update(LoanOfficer loanOfficer)
        {
            var existingLoanOfficer = _dbContext.LoanOfficers.Find(loanOfficer.LoanOfficerId);
            if (existingLoanOfficer != null)
            {
                _dbContext.LoanOfficers.Update(existingLoanOfficer);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Loan Officer not found");
            }
        }
        public void Delete(int id)
        {
            LoanOfficer loanOfficer = _dbContext.LoanOfficers.Find(id);
           loanOfficer.isActive=false;
            _dbContext.SaveChanges();
        }

    }
}
