
using LoanManagement.DTO;
using LoanManagementSystem.DTO;
using LoanManagementSystem.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admin_UserJWTExample.Generate_Function
{
    public class GenerateToken
    {

        public static string GetToken(LoginDTO user, IConfiguration _configuration)
        {

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
        new Claim("UserId",user.UserId.ToString()),
        new Claim("UserName",user.UserName),
        new Claim("UserPassword",user.UserPassword),
        new Claim(ClaimTypes.Role,user.UserRole),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jti (JWT ID) is used to ensure uniqueness 
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn);

            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }


        public static string GetTokenOfficer(LoginOfficerDTO loanOfficer, IConfiguration _configuration)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
        new Claim("loanOfficer Id",loanOfficer.LoanOfficerId.ToString()),
        new Claim("loanOfficer Name",loanOfficer.LoanOfficerName),
        new Claim(ClaimTypes.Role, loanOfficer.OfficerRole),
        new Claim("loanOfficerPassword",loanOfficer.LoanOfficerPassword),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jti (JWT ID) is used to ensure uniqueness
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn);

            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }
    }
}
