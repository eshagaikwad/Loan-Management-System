using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repository;

namespace LoanManagementSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }
        public List<User> DisplayUser()
        {
            return _userRepository.Display();
        }
        public User FindUser(int id)
        {
            return _userRepository.Find(id);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user); 
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id); 
        }

        public void AddUserDTO(UserDTO userDTO)
        {
            _userRepository.AddDTO(userDTO);
        }
        public async Task UpdateUserDTO(int id, UserDTO userDTO)
        {
            await _userRepository.UpdateDTO(id, userDTO);
        }
    }
}
