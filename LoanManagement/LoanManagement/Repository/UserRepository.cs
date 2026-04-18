using LoanManagement.Data;
using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;

namespace LoanManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public List<User> Display()
        {
            return _dbContext.Users.ToList();
        }
        public User Find(int id)
        {
            User user = _dbContext.Users.Find(id);
            return user;
        }
        //User existingUser=_dbContext.Users.Find(id);
        public void Update(User user)
        {
            var existingUser = _dbContext.Users.Find(user.UserId);
            if (existingUser != null)
            {           
                _dbContext.Users.Update(existingUser);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        public void Delete(int id)
        {
            User user = _dbContext.Users.Find(id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void AddDTO(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO), "Loan Application data cannot be null");
            }

            try
            {
                User user = new User
                {
                    UserId = 0,
                    UserName = userDTO.UserName,
                    UserEmail=userDTO.UserEmail,
                    UserPassword = userDTO.UserPassword,
                    UserPhone = userDTO.UserPhone,
                    UserRole="User",
                    RegisterationDate=DateTime.Now
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while saving the User: " + ex.Message);
            }

        }


        public async Task UpdateDTO(int id, UserDTO userDTO)
        {
            // Fetch the existing user
            var existingUser = await _dbContext.Users.FindAsync(id);

            // Check if the user exists
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // Update the properties with the values from the DTO
            existingUser.UserName = userDTO.UserName;
            existingUser.UserEmail = userDTO.UserEmail ?? existingUser.UserEmail; // Only update if not null
            existingUser.UserPhone = userDTO.UserPhone ?? existingUser.UserPhone; // Only update if not null
            existingUser.UserPassword = userDTO.UserPassword;

            // Set default values or maintain existing ones
            existingUser.UserRole = existingUser.UserRole ?? "User"; // Default to "User" if not already set
            existingUser.RegisterationDate = existingUser.RegisterationDate ?? DateTime.Now; // Set if null

            try
            {
                // Ensure the entity is marked as modified
                _dbContext.Users.Update(existingUser);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating user: " + ex.Message);
            }
        }


    }
}
