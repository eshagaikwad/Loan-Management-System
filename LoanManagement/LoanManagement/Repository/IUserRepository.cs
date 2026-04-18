using LoanManagementSystem.Data;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Repository
{
    public interface IUserRepository
    {
        public void Add(User user);
        public List<User> Display();
        public User Find(int id);
        public void Update(User user);
        public void Delete(int id);
        public void AddDTO(UserDTO userDTO);
        public Task UpdateDTO(int id, UserDTO userDTO);
    }
}
