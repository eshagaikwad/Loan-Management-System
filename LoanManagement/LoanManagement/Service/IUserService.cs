using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Service
{
    public interface IUserService
    {
        public void AddUser(User user);
        public List<User> DisplayUser();
        public User FindUser(int id);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        public void AddUserDTO(UserDTO userDTO);
        public Task UpdateUserDTO(int id, UserDTO userDTO);
    }
}
