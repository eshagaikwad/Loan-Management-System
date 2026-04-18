using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using LoanManagementSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "LoanOfficer")]
        [HttpGet]
        public List<User> Get()
        {
            return _userService.DisplayUser();
        }

        
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.FindUser(id);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public void Post([FromBody] UserDTO user)
        {
            _userService.AddUserDTO(user);
            //_userService.AddUser(user);
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] UserDTO userDTO)
        {
            _userService.UpdateUserDTO(id,userDTO);
        }


        //[Authorize("LoanOfficer")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
